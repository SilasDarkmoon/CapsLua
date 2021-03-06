﻿--[[--

Debug functions.

## Functions ##

-   echo
-   echoInfo
-   echoError
-   printf

]]

function echo(...)
    if LogEnabled == false or LogInfoEnabled == false then return end
    local arr = {}
    for i = 1, select('#', ...) do
        local arg = select(i, ...)
        arr[#arr + 1] = tostring(arg)
    end
    print(table.concat(arr, "\t"))
end

--[[--

Output a formatted string.

Depends on the platform, output to console or log file. @see echo().

@param string format
@param mixed ...

@see echo

]]
function printf(fmt, ...)
    if LogEnabled == false or LogInfoEnabled == false then return end
    echo(string.format(tostring(fmt), ...))
end

function echoError(fmt, ...)
    if LogEnabled == false or LogInfoEnabled == false then return end
    local msg = string.format("[ERR] %s", string.format(tostring(fmt), ...))
    echo(msg)
end

function echoInfo(fmt, ...)
    if LogEnabled == false or LogInfoEnabled == false then return end
    echo("[INFO] " .. string.format(tostring(fmt), ...))
end

function echoLog(tag, fmt, ...)
    if LogEnabled == false or LogInfoEnabled == false then return end
    echo(string.format("[%s] %s", string.upper(tostring(tag)), string.format(tostring(fmt), ...)))
end

function getPackageName(moduleName)
    local packageName = ""
    local pos = string.find(string.reverse(moduleName), "%.")
    if pos then
        packageName = string.sub(moduleName, 1, string.len(moduleName) - pos + 1)
    end
    return packageName
end

--[[--

Dumps information about a variable.

@param mixed object
@param string label
@param bool isReturnContents
@param int nesting
@return nil|string

]]
function dump(object, label)
    if LogEnabled == false or LogInfoEnabled == false then return end
    local result = vardump(object, label)
    local str = table.concat(result, "\n")
    echo(str)
    return str
end

function dumpq(object, label)
    local result = vardump(object, label)
    local str = table.concat(result, "\n")
    return str
end

function dumpw(object, label)
    if LogEnabled == false or LogWarningEnabled == false then return end
    printw(dumpq(object, label))
end

function dumpe(object, label)
    if LogEnabled == false or LogErrorEnabled == false then return end
    local msg = dumpq(object, label)
    printe(msg)
end

function dumpraw(object, label)
    if LogEnabled == false or LogInfoEnabled == false then return end
    local result = vardump(object, label, true)
    local str = table.concat(result, "\n")
    echo(str)
    return str
end

--[[--

Outputs or returns a parsable string representation of a variable.

@param mixed object
@param string label
@return table each line

]]
function vardump(object, label, israw)
    local lookupTable = {}
    local indexed = {}
    local result = {}

    local function _v(v)
        if type(v) == "string" then
            local str = string.gsub(v, "\\", "\\\\")
            str = string.gsub(str, "\"", "\\\"")
            return "\""..str.."\""
        end
        if type(v) == 'number' or type(v) == 'boolean' then
            return tostring(v)
        end
        if clr.isobj(v) then
            if v == clr.null then
                return "'"..tostring(clr.type(v))..", null'"
            else
                return "'"..tostring(clr.type(v))..", "..tostring(v).."'"
            end
        end
        return "'"..tostring(v).."'"
    end

    local _vardump -- local function _vardump
    local function _k(k, indent, nest)
        if type(k) == "string" then
            if k ~= "" then
                local firstChar = string.byte (k, 1)
                if firstChar >= 65 and firstChar <= 90 or firstChar == 95 or firstChar >= 97 and firstChar <= 122 then
                    --a-zA-Z_
                    return k
                end
            end
            return string.format('["%s"]', k)
        end
        if type(k) == 'number' or type(k) == 'boolean' then
            return string.format("[%s]", tostring(k))
        end
        if type(k) == 'table' then
            if lookupTable[k] then
                local line = lookupTable[k]
                local rv = string.format("['*%s*']", tostring(line))
                if not indexed[line] then
                    result[line] = result[line]..string.format(" --*%s*", line)
                    indexed[line] = line
                end
                return rv
            else
                local line = #result + 1
                local rv = string.format("['*%s*']", tostring(line))
                local kkey = string.format("['*%s*:']", tostring(line))
                _vardump(k, kkey, indent, nest)
                if nest == 1 then
                    result[#result] = result[#result]..','
                end
                --lookupTable[k] = line
                indexed[line] = line
                return rv
            end
        end
        return string.format("['%s']", tostring(k))
    end

    local function clrobj2str(obj)
        local metatable = getmetatable(obj)
        if not metatable or not metatable.__tostring then
            return clr.System.String.Format("{0}", obj)
        else
            return tostring(obj)
        end
    end

    function _vardump(object, label, indent, nest, isArr)
        if (label == nil) then label = "var" end
        local postfix = ""
        if nest > 1 then postfix = "," end
        local reallabel = indent
        if not isArr then
            local key = _k(label, indent, nest)
            reallabel = string.format("%s%s = ", indent, key)
        end
        if type(object) ~= "table" then
            result[#result +1] = string.format("%s%s%s", reallabel, _v(object), postfix)
        elseif lookupTable[object] then
            local line = lookupTable[object]
            result[#result +1] = string.format("%s'*%s*'%s", reallabel, line, postfix)
            if not indexed[line] then
                result[line] = result[line]..string.format(" --*%s*", line)
                indexed[line] = line
            end
        else
            local line = #result + 1
            lookupTable[object] = line

            if not israw and clr.isobj(object) then
                if object == clr.null then
                    result[line] = string.format("%s'%s, null'", reallabel, tostring(clr.type(object)))
                else
                    result[line] = string.format("%s'%s, %s'", reallabel, tostring(clr.type(object)), clrobj2str(object))
                end
            else
                if getmetatable(object) and getmetatable(object).__isobject then
                    result[line] = string.format("%s{ -- __isobject", reallabel)
                else
                    result[line] = string.format("%s{", reallabel)
                end

                local indent2 = indent .. "    "
                local keys = {}
                local allKeyIsInt = true
                local minKey, maxKey = #object, 0
                for k, v in pairs(object) do
                    keys[#keys + 1] = k
                    if type(k) == 'number' and k == math.floor(k) then
                        if k > maxKey then
                            maxKey = k
                        end
                        if k < minKey then
                            minKey = k
                        end
                    else
                        allKeyIsInt = false
                    end
                end
                local isObjArr = allKeyIsInt and #keys == maxKey and minKey == 1
                table.sort(keys, function(a, b)
                    if type(a) == "number" and type(b) == "number" then
                        return a < b
                    else
                        return tostring(a) < tostring(b)
                    end
                end)
                for i, k in ipairs(keys) do
                    _vardump(object[k], k, indent2, nest + 1, isObjArr)
                end
                result[#result +1] = string.format("%s}%s", indent, postfix)
            end
        end
    end
    _vardump(object, label, "", 1)

    return result
end

function ndump(...)
    if LogEnabled == false or LogInfoEnabled == false then return end
    local str
    for i = 1, select('#', ...) do
        local arg = select(i, ...)
        local result = vardump(arg, i)
        if str then
            str = str..'\n'
        else
            str = ""
        end
        str = str..table.concat(result, "\n")..','
    end
    echo(str)
end

local function ndumpq(...)
    local str
    for i = 1, select('#', ...) do
        local arg = select(i, ...)
        local result = vardump(arg, i)
        if str then
            str = str..'\n'
        else
            str = ""
        end
        str = str..table.concat(result, "\n")..','
    end

    return str
end

function ndumpw(...)
    if LogEnabled == false or LogWarningEnabled == false then return end
    printw(ndumpq(...))
end

function ndumpe(...)
    if LogEnabled == false or LogErrorEnabled == false then return end
    printe(ndumpq(...))
end