
function string.utf8char(dig)
    if dig < 128 then
        return string.char(dig)
    elseif dig < 2048 then
        return string.char(math.floor(dig / 64) + 192, dig % 64 + 128)
    elseif dig < 65536 then
        return string.char(math.floor(dig / 4096) + 224, math.floor((dig % 4096) / 64) + 128, dig % 64 + 128)
    else
        -- TODO: this is out of ucs2 range
        return ""
    end
end

--- 将字符串拆成单个字符，存在一个table中
function string.utf8tochars(input)
    local isOk, list = pcall(function ()
        local list = {}
        local len  = string.len(input)
        local index = 1
        local arr  = {0xc0, 0xe0, 0xf0, 0xf8, 0xfc}

        while index <= len do
            local c = string.byte(input, index)
            local offset = 1

            for i, v in ipairs(arr) do
                if c < v then
                    offset = i
                    break
                end
            end

            local str = string.sub(input, index, index + offset - 1)
            index = index + offset
            table.insert(list, str)
        end

        return list
    end, input)

    if not isOk then
        return {input}
    else
        return list
    end
end

--- 将秒数保留至小数点后两位并转换为xx'yy''格式
-- @param second 秒数，类型number/string (10.22)
-- @return string (10'22'')
function string.convertSecondToTimeString(second)
    local result = string.format("%.2f", tostring(second))
    result = string.gsub(result, "%.", "\'")
    result = result .. "\'\'"
    return result
end

--[[--

Convert special characters to HTML entities.

The translations performed are:

-   '&' (ampersand) becomes '&amp;'
-   '"' (double quote) becomes '&quot;'
-   "'" (single quote) becomes '&#039;'
-   '<' (less than) becomes '&lt;'
-   '>' (greater than) becomes '&gt;'

@param string input
@return string

]]
function string.htmlspecialchars(input)
    for k, v in pairs(string._htmlspecialchars_set) do
        input = string.gsub(input, k, v)
    end
    return input
end
string._htmlspecialchars_set = {}
string._htmlspecialchars_set["&"] = "&amp;"
string._htmlspecialchars_set["\""] = "&quot;"
string._htmlspecialchars_set["'"] = "&#039;"
string._htmlspecialchars_set["<"] = "&lt;"
string._htmlspecialchars_set[">"] = "&gt;"

--[[--

Inserts HTML line breaks before all newlines in a string.

Returns string with '<br />' inserted before all newlines (\n).

@param string input
@return string

]]
function string.nl2br(input)
    return string.gsub(input, "\n", "<br />")
end

--[[--

Returns a HTML entities formatted version of string.

@param string input
@return string

]]
function string.text2html(input)
    input = string.gsub(input, "\t", "    ")
    input = string.htmlspecialchars(input)
    input = string.gsub(input, " ", "&nbsp;")
    input = string.nl2br(input)
    return input
end

--[[--

Split a string by string.

@param string str
@param string delimiter
@return table

]]
function string.split(str, delimiter)
    if (delimiter=='') then return false end
    local pos,arr = 0, {}
    -- for each divider found
    for st,sp in function() return string.find(str, delimiter, pos, true) end do
        table.insert(arr, string.sub(str, pos, st - 1))
        pos = sp + 1
    end
    table.insert(arr, string.sub(str, pos))
    return arr
end

--[[--

Strip whitespace (or other characters) from the beginning of a string.

@param string str
@return string

]]
function string.ltrim(str)
    return string.gsub(str, "^[ \t\n\r]+", "")
end

--[[--

Strip whitespace (or other characters) from the end of a string.

@param string str
@return string

]]
function string.rtrim(str)
    return string.gsub(str, "[ \t\n\r]+$", "")
end

--[[--

Strip whitespace (or other characters) from the beginning and end of a string.

@param string str
@return string

]]
function string.trim(str)
    str = string.gsub(str, "^[ \t\n\r]+", "")
    return string.gsub(str, "[ \t\n\r]+$", "")
end

--[[--

Make a string's first character uppercase.

@param string str
@return string

]]
function string.ucfirst(str)
    return string.upper(string.sub(str, 1, 1)) .. string.sub(str, 2)
end

--[[--

@param string str
@return string

]]
function string.urlencodeChar(char)
    return "%" .. string.format("%02X", string.byte(char))
end

--[[--

URL-encodes string.

@param string str
@return string

]]
function string.urlencode(str)
    -- convert line endings
    str = string.gsub(tostring(str), "\n", "\r\n")
    -- escape all characters but alphanumeric, '.' and '-'
    str = string.gsub(str, "([^%w%.%- ])", string.urlencodeChar)
    -- convert spaces to "+" symbols
    return string.gsub(str, " ", "+")
end

--[[--

Get UTF8 string length.

@param string str
@return int

]]
function string.utf8len(str)
    local len  = #str
    local left = len
    local cnt  = 0
    local arr  = {0, 0xc0, 0xe0, 0xf0, 0xf8, 0xfc}
    while left ~= 0 do
        local tmp = string.byte(str, -left)
        local i   = #arr
        while arr[i] do
            if tmp >= arr[i] then
                left = left - i
                break
            end
            i = i - 1
        end
        cnt = cnt + 1
    end
    return cnt
end

function string.capital(s)
    if type(s) == 'string' and string.len(s) > 0 then
        return string.upper(string.sub(s, 1, 1)) .. string.sub(s, 2)
    else
        return s
    end
end

function string.formatIntWithComma(amount)
    if type(amount) ~= 'number' then
        return tostring(amount)
    end
    amount = math.floor(amount)
    local formatted = tostring(amount)
    while true do
        formatted, k = string.gsub(formatted, "^(-?%d+)(%d%d%d)", '%1,%2')
        if k == 0 then
            break
        end
    end
    return formatted
end