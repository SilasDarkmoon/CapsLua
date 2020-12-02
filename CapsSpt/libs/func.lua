
local tonumber_ = tonumber
--[[--

Convert to number.

@param mixed v
@return number

]]
function tonumber(v, base)
    return tonumber_(v, base) or 0
end

--[[--

Convert to integer.

@param mixed v
@return number(integer)

]]
function toint(v)
    return math.round(tonumber(v))
end

--[[--

Convert to boolean.

@param mixed v
@return boolean

]]
function tobool(v)
    return (v ~= nil and v ~= false)
end

--[[--

Convert to table.

@param mixed v
@return table

]]
function totable(v)
    if type(v) ~= "table" then v = {} end
    return v
end

--[[--

Returns a formatted version of its variable number of arguments following the description given in its first argument (which must be a string). string.format() alias.

@param string format
@param mixed ...
@return string

]]
function format(...)
    return string.format(...)
end

--[[--

Creating a copy of an table with fully replicated properties.

**Usage:**

    -- Creating a reference of an table:
    local t1 = {a = 1, b = 2}
    local t2 = t1
    t2.b = 3    -- t1 = {a = 1, b = 3} <-- t1.b changed

    -- Createing a copy of an table:
    local t1 = {a = 1, b = 2}
    local t2 = clone(t1)
    t2.b = 3    -- t1 = {a = 1, b = 2} <-- t1.b no change


@param mixed object
@return mixed

]]
function clone(object)
    local lookup_table = {}
    local function _copy(object)
        if type(object) ~= "table" then
            return object
        elseif lookup_table[object] then
            return lookup_table[object]
        end
        local new_table = {}
        lookup_table[object] = new_table
        for key, value in pairs(object) do
            new_table[_copy(key)] = _copy(value)
        end
        return setmetatable(new_table, getmetatable(object))
    end
    return _copy(object)
end

function shallowClone(object)
    if type(object) ~= "table" then
        return object
    end
    local new_table = {}
    for key, value in pairs(object) do
        new_table[key] = value
    end
    return setmetatable(new_table, getmetatable(object))
end

-- 判断val是否在t里
function isInArray(t, val)
    for _, v in ipairs(t) do
        if v == val then
            return true
        end
    end
    return false
end

--[[--

Create an class.

**Usage:**

    local Shape = class("Shape")

    -- base class
    function Shape:ctor(shapeName)
        self.shapeName = shapeName
        printf("Shape:ctor(%s)", self.shapeName)
    end

    function Shape:draw()
        printf("draw %s", self.shapeName)
    end

    --

    local Circle = class("Circle", Shape)

    function Circle:ctor()
        Circle.super.ctor(self, "circle")   -- call super-class method
        self.radius = 100
    end

    function Circle:setRadius(radius)
        self.radius = radius
    end

    function Circle:draw()                  -- overrideing super-class method
        printf("draw %s, raidus = %0.2f", self.shapeName, self.raidus)
    end

    --

    local Rectangle = class("Rectangle", Shape)

    function Rectangle:ctor()
        Rectangle.super.ctor(self, "rectangle")
    end

    --

    local circle = Circle.new()             -- output: Shape:ctor(circle)
    circle:setRaidus(200)
    circle:draw()                           -- output: draw circle, radius = 200.00

    local rectangle = Rectangle.new()       -- output: Shape:ctor(rectangle)
    rectangle:draw()                        -- output: draw rectangle


@param string classname
@param table|function super-class
@return table

]]
function class(super, classname)
    local superType = type(super)
    if superType == "string" then
        local classnametype = type(classname)
        if classname == nil or classnametype == "table" or classnametype == "function" then
            local realsuper = classname
            classname = super
            super = realsuper
            superType = classnametype
        end
    end
    local cls

    if superType ~= "function" and superType ~= "table" then
        superType = nil
        super = nil
    end

    if superType == "function" or (super and super.__ctype == 1) then
        -- inherited from native C++ Object
        cls = {}

        if superType == "table" then
            -- copy fields from super
            for k,v in pairs(super) do cls[k] = v end
            cls.__create = super.__create
            cls.super    = super
        else
            cls.__create = super
            cls.ctor = function() end
        end

        cls.__cname = classname
        cls.__ctype = 1

        function cls.new(...)
            local instance = cls.__create(...)
            -- copy fields from class to native object
            for k,v in pairs(cls) do instance[k] = v end
            instance.class = cls
            instance:ctor(...)
            return instance
        end

    else
        -- inherited from Lua Object
        if super then
            cls = clone(super)
            cls.super = super
            if super.__index == super then
                cls.__index = nil
            end
        else
            cls = {ctor = function() end}
        end

        cls.__cname = classname
        cls.__ctype = 2 -- lua
        if not cls.__index then
            cls.__index = cls
        end

        function cls.new(...)
            local instance = setmetatable({}, cls)
            instance.class = cls
            instance:ctor(...)
            return instance
        end
    end

    function cls.attach(instance, ...)
        for k,v in pairs(cls) do instance[k] = v end
        instance.class = cls
        instance:ctor(...)
        return instance
    end

    return cls
end

--[[--

hecks if the given key or index exists in the table.

@param table arr
@param mixed key
@return boolean

]]
function isset(arr, key)
    return type(arr) == "table" and arr[key] ~= nil
end

--[[--

Rounds a float.

@param number num
@return number(integer)

]]
function math.round(num)
    return math.floor(num + 0.5)
end

--[[--

Count all elements in an table.

@param table t
@return number(integer)

]]
function table.nums(t)
    local count = 0
    for k, v in pairs(t) do
        count = count + 1
    end
    return count
end

--[[--

Return all the keys or a subset of the keys of an table.

**Usage:**

    local t = {a = 1, b = 2, c = 3}
    local keys = table.keys(t)
    -- keys = {"a", "b", "c"}


@param table t
@return table

]]
function table.keys(t)
    local keys = {}
    for k, v in pairs(t) do
        keys[#keys + 1] = k
    end
    return keys
end

--[[--

Return all the values of an table.

**Usage:**

    local t = {a = "1", b = "2", c = "3"}
    local values = table.values(t)
    -- values = {1, 2, 3}


@param table t
@return table

]]
function table.values(t)
    local values = {}
    for k, v in pairs(t) do
        values[#values + 1] = v
    end
    return values
end

--[[--

Merge tables.

**Usage:**

    local dest = {a = 1, b = 2}
    local src  = {c = 3, d = 4}
    table.merge(dest, src)
    -- dest = {a = 1, b = 2, c = 3, d = 4}


@param table dest
@param table src

]]
function table.merge(dest, src)
    for k, v in pairs(src) do
        dest[k] = v
    end
end

function table.deepmerge(dst, src)
    local visited = {}
    local function mergeTable(dst, src)
        visited[src] = dst
        for k, v in pairs(src) do
            if type(v) ~= "table" then
                dst[k] = v
            else
                if visited[v] then
                    dst[k] = visited[v]
                else
                    if type(dst[k]) ~= "table" then
                        dst[k] = v
                    else
                        mergeTable(dst[k], v)
                    end
                end
            end
        end
    end

    mergeTable(dst, src)
    return dst
end

--[[--

Merge arraies.

**Usage:**

    local dest = {1, 2}
    local src  = {3, 4}
    table.imerge(dest, src)
    -- dest = {1, 2, 3, 4}


@param table dest
@param table src

]]
function table.imerge(dest, src)
    for i, v in ipairs(src) do
        table.insert(dest, v)
    end
end

function table.clear(tab)
    for k, v in pairs(tab) do
        tab[k] = nil
    end
end

--[[--

Return formatted string with a comma (",") between every group of thousands.

**Usage:**

    local value = math.comma("232423.234") -- value = "232,423.234"


@param number num
@return string

]]
function string.formatNumberThousands(num)
    local formatted = tostring(tonumber(num))
    while true do
        formatted, k = string.gsub(formatted, "^(-?%d+)(%d%d%d)", '%1,%2')  --Lua assist checked flag
        if k == 0 then break end
    end
    return formatted
end

math.nan = 0/0
math.max_int32 = 0x7FFFFFFF
math.min_int32 = -math.max_int32 - 1
math.eps = 1e-6

function math.isNan(num)
    return num ~= num
end

function math.clamp(num, min, max)
    if num < min then num = min end
    if num > max then num = max end
    return num
end

function math.cmpf(a, b)
    if a < b - math.eps then
        return -1
    elseif a > b + math.eps then
        return 1
    else
        return 0
    end
end

function math.sign(num)
    if num > math.eps then
        return 1
    elseif num < -math.eps then
        return -1
    end
    return 0
end

--[Comment]
--return a < b ? { min = a, max = b } : { min = b, max = a }
function math.range(a, b)
    return a < b and { min = a, max = b } or { min = b, max = a }
end

--[Comment]
--return x >= min and x <= max
function math.isInRange(x, min, max)
    return x >= min and x <= max
end

--[Comment]
--return a random real number in range [min, max)
function math.randomInRange(min, max)
    return min + math.random() * (max - min)
end

--[Comment]
--ceil the number to precision: math.ceilEx(7.44, 0.1) = 7.5
--return math.ceil(number / precision) * precision
function math.ceilEx(number, precision)
    return math.ceil(number / precision) * precision
end

function math.lerp(a, b, bweight)
    bweight = math.clamp(bweight, 0, 1)
    return a * (1 - bweight) + b * bweight
end

function math.isInt(num)
    return type(num) == "number" and num == math.floor(num)
end

function table.isEmpty(table)
    if table == nil then return true end
    if type(table) ~= 'table' then return false end
    local empty = true
    for k,v in pairs(table) do
        empty = false
        break
    end
    return empty
end

function table.compare(data1, data2)
    if type(data1) == 'table' and type(data2) == 'table' then
        local allKeys = {}
        for k,v in pairs(data1) do
            allKeys[k] = v
        end
        for k,v in pairs(data2) do
            allKeys[k] = v
        end
        local part2 = 0
        for k,v in pairs(allKeys) do
            local v1 = data1[k]
            local v2 = data2[k]
            local part = table.compare(v1, v2)
            if math.isNan(part) then
                return part
            elseif part ~= 0 then
                if (part2 > 0 and part < 0) or (part2 < 0 and part > 0) then
                    return math.nan
                end
                part2 = part
            end
        end
        return part2
    elseif data1 == nil and data2 == nil then
        return 0
    elseif data1 == nil then
        return -1
    elseif data2 == nil then
        return 1
    elseif type(data1) ~= type(data2) then
        return math.nan
    elseif type(data1) == 'number' then
        return data1 - data2
    elseif type(data1) == 'string' then
        if data1 < data2 then
            return -1
        elseif data1 > data2 then
            return 1
        else
            return 0
        end
    elseif data1 == data2 then
        return 0
    else
        return math.nan
    end
end

function table.compareArray(data1, data2)
    if type(data1) == 'table' and type(data2) == 'table' then
        for i,v1 in ipairs(data1) do
            local v2 = data2[i]
            local part = table.compareArray(v1, v2)
            if part ~= 0 then
                return part
            end
        end
        if #data2 > #data1 then
            return -1
        else
            return 0
        end
    elseif data1 == nil and data2 == nil then
        return 0
    elseif data1 == nil then
        return -1
    elseif data2 == nil then
        return 1
    elseif type(data1) ~= type(data2) then
        return math.nan
    elseif type(data1) == 'number' then
        return data1 - data2
    elseif type(data1) == 'string' then
        if data1 < data2 then
            return -1
        elseif data1 > data2 then
            return 1
        else
            return 0
        end
    elseif data1 == data2 then
        return 0
    else
        return math.nan
    end
end

function table.shuffleArray(t)
    for i = #t, 1, -1 do
        local j = math.random(i)
        t[i], t[j] = t[j], t[i]
    end
end

--- 换算数字，超过1万数字形式为xx万，超过1亿数字形式为xx亿
-- @param num 数字，类型number
-- @param n 保留小数位数（默认两位）
-- @return 数字转换后的字符串形式，类型string
-- function string.formatNumWithUnit(num, n)
--     num = tonumber(num)
--     if not n then
--         n = 2
--     else
--         n = tonumber(n)
--     end

--     if num < 10000 then
--         return tostring(num)
--     elseif num < 100000000 then
--         num = math.floor(num / math.pow(10, 4 - n)) / math.pow(10, n)
--         return lang.transstr("logogramMoneyTenThousand", num)
--     else
--         num = math.floor(num / math.pow(10, 8 - n)) / math.pow(10, n)
--         return lang.transstr("logogramMoneyHundredMillon", num)
--     end
-- end

--- 换算数字，超过1万数字形式为xx万，超过1亿数字形式为xx亿
-- @param num 数字，类型number
-- @param n 保留小数位数（默认两位）
-- @return 第一个string为数字，第二个string为单位
-- function string.formatNumSplitUnit(num, n)
--     num = tonumber(num)
--     if not n then
--         n = 2
--     else
--         n = tonumber(n)
--     end

--     if num < 10000 then
--         return tostring(num)
--     elseif num < 100000000 then
--         return string.trimNumber(string.format("%.2f", num / 10000)), lang.transstr("tenThousand")
--     else
--         return string.trimNumber(string.format("%.2f", num / 100000000)), lang.transstr("hundredMillon")
--     end
-- end

function math.concatCompareFunc(...)
    local funcs = {}
    local reverse = {}
    for i = 1, select('#', ...) do
        local arg = select(i, ...)
        if type(arg) == 'function' then
            funcs[#funcs + 1] = arg
        elseif type(arg) == 'table' and type(arg[1]) == 'function' then
            funcs[#funcs + 1] = arg[1]
            reverse[#funcs] = arg[2]
        end
    end
    local function concatedCompare(a, b)
        for i,v in ipairs(funcs) do
            local pv = v(a, b)
            if type(pv) == 'number' then
                if pv ~= 0 then
                    if reverse[i] then
                        return -pv
                    else
                        return pv
                    end
                end
            end
        end
        return 0
    end
    return concatedCompare
end

-- 按指定的顺序遍历table
function pairsByKeys(t, f)
    local a = {}
    for n in pairs(t) do a[#a + 1] = n end
    table.sort(a, f)
    local i = 0
    return function ()
        i = i + 1
        return a[i], t[a[i]]
    end
end

-- 将一个number转换为二进制表示的table
-- 如10转换为二进制是1010
-- 传入参数mask=10
-- 返回{false, true, false, true}
-- 低位在table的前面，高位在table的后面
function math.getMaskTable(mask)
    mask = tonumber(mask)
    local tab = {}
    while mask > 0 do
        table.insert(tab, mask % 2 == 1 and true or false)
        mask = math.floor(mask / 2)
    end
    return tab
end

function ToBase64(source_str)
    local b64chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'
    local s64 = ''
    local str = source_str

    while #str > 0 do
        local bytes_num = 0
        local buf = 0

        for byte_cnt=1,3 do
            buf = (buf * 256)
            if #str > 0 then
                buf = buf + string.byte(str, 1, 1)
                str = string.sub(str, 2)
                bytes_num = bytes_num + 1
            end
        end

        for group_cnt=1,(bytes_num+1) do
            b64char = math.fmod(math.floor(buf/262144), 64) + 1
            s64 = s64 .. string.sub(b64chars, b64char, b64char)
            buf = buf * 64
        end

        for fill_cnt=1,(3-bytes_num) do
            s64 = s64 .. '='
        end
    end

    return s64
end

function FromBase64(str64)
    local b64chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'
    local temp={}
    for i=1,64 do
        temp[string.sub(b64chars,i,i)] = i
    end
    temp['=']=0
    local str=""
    for i=1,#str64,4 do
        if i>#str64 then
            break
        end
        local data = 0
        local str_count=0
        for j=0,3 do
            local str1=string.sub(str64,i+j,i+j)
            if not temp[str1] then
                return
            end
            if temp[str1] < 1 then
                data = data * 64
            else
                data = data * 64 + temp[str1]-1
                str_count = str_count + 1
            end
        end
        for j=16,0,-8 do
            if str_count > 0 then
                str=str..string.char(math.floor(data/math.pow(2,j)))
                data=math.fmod(data,math.pow(2,j))
                str_count = str_count - 1
            end
        end
    end
    return str
end

-- import("abc") => require("abc")
-- import("./abc") => require(CURRENT_DIR .. "abc")
-- import("../abc") => require(PARENT_DIR .. "abc")
function import(lib)
    -- if not specified relative path, use default require
    if string.sub(lib, 1, 2) ~= "./" and string.sub(lib, 1, 3) ~= "../" then
        return require(lib)
    end

    -- deal with relative path
    local _, package = debug.getlocal(3, 1)

    local cnt, level = 1, 1
    while cnt ~= 0 do
        -- eat up any "./" prefix
        local t = 1
        while t ~= 0 do
            lib, t = string.gsub(lib, "^(%./)", "", 2)
            if t ~= 0 then
                cnt = 1
            end
        end

        -- count "../", add to level
        lib, cnt = string.gsub(lib, "^(%.%./)", "", 3)
        if cnt ~= 0 then
            level = level + 1
        end
    end

    for i = 1, level do
        package = (package):match("^(.+)[%./][^%./]+") or ""
    end

    return require(package .. "/" .. lib)
end
