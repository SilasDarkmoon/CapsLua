if not clr.Capstones.UnityEngineEx.ThreadSafeValues.IsMainThread then
    require('libs.init')
end

clr.Capstones.LuaWrap.HotFixCaller.LoadDesignatedHash("data.hotfixhash")

local hotfix = {}
local hotfixmap = require("hotfix.map")
if not hotfixmap[0] then
    hotfixmap[0] = "hotfix.default"
end

local meta = {}
if not hotfixver then
    hotfixver = 0
elseif type(hotfixver) ~= "number" then
    hotfixver = tonumber(hotfixver)
end

if hotfixver == 0 then
    local lib = hotfixmap[0]
    meta.__index = require(lib)
elseif hotfixver < 0 then
    meta.__index = {}
else
    local selver, sellib
    for k, v in pairs(hotfixmap) do
        if k > hotfixver then
            if not selver or k < selver then
                selver, sellib = k, v
            end
        end
    end
    print("FOUND-HOTFIX-VER")
    print(selver)
    print(sellib)
    print("HOTFIX-PACKAGE-VER")
    print(hotfixver)
    if not sellib then
        sellib = hotfixmap[0]
    end
    meta.__index = require(sellib)
end

setmetatable(hotfix, meta)

return hotfix