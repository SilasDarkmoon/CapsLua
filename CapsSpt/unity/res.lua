local UnityEngine = clr.UnityEngine
local ResManager = clr.Capstones.UnityEngineEx.ResManager
local Object = UnityEngine.Object
local GameObject = UnityEngine.GameObject
local CapsUnityLuaBehav = clr.CapsUnityLuaBehav
local EventSystem = UnityEngine.EventSystems.EventSystem
local Mask = UnityEngine.UI.Mask
local Canvas = UnityEngine.Canvas

res = {}

res.preProcess = nil
res.postProcess = nil

function res.DoPreProcess(arg)
    if res.preProcess ~= nil and type(res.preProcess) == 'function' then
        res.preProcess(arg)
    end
end

function res.DoPostProcess(arg)
    if res.postProcess ~= nil and type(res.postProcess) == 'function' then
        res.postProcess(arg)
    end
end

--#region Instantiate and Scene Tree
function res.GetLuaScript(obj)
    if obj and obj ~= clr.null then
        return obj:GetComponent(CapsUnityLuaBehav)
    end
end

function res.Instantiate(name)
    local prefab = ResManager.LoadRes(name)
    if prefab then
        local obj = Object.Instantiate(prefab)
        if obj then
            return obj, res.GetLuaScript(obj)
        end
    end
end

function res.Destroy(obj)
    Object.Destroy(obj)
end

function res.AddChild(parent, name)
    local child = res.Instantiate(name)
    if child then
        if parent then
            child.transform:SetParent(parent.transform, false)
        end
    end
    return child
end

function res.ClearChildren(parentTrans)
    if parentTrans and parentTrans.childCount > 0 then
        for i = 1, parentTrans.childCount do
            Object.Destroy(parentTrans:GetChild(i - 1).gameObject)
        end
    end
end

function res.ClearChildrenImmediate(parentTrans)
    if parentTrans and parentTrans.childCount > 0 then
        for i = 1, parentTrans.childCount do
            Object.DestroyImmediate(parentTrans:GetChild(0).gameObject)
        end
    end
end
--#endregion Instantiate and Scene Tree

--#region Dialog Order
local usedOrder = {}
local currentOrder = 0

function res.SetDialogOrder(order)
    if usedOrder[order] == 1 then  --如果即将设置的层级已被占用，则重新计算层级
        local newOrder = res.ApplyDialogOrder()
        usedOrder[newOrder] = 1
        if newOrder > currentOrder then
            currentOrder = newOrder
        end
        return newOrder
    end
    usedOrder[order] = 1
    if order > currentOrder then
        currentOrder = order
    end
    return order
end

function res.ApplyDialogOrder()
    currentOrder = currentOrder + 100
    usedOrder[currentOrder] = 1
    return currentOrder
end

function res.GetCurrentDialogOrder()
    return currentOrder
end

function res.RestoreDialogOrder(order)
    usedOrder[order] = nil
    if order == currentOrder then
        currentOrder = 0
        for k, v in pairs(usedOrder) do
            if k > currentOrder then
                currentOrder = k
            end
        end
    end
end
--#endregion Dialog Order

--#region Raw Load and Cleanup
function res.DestroyAll()
    ResManager.DestroyAll()
end
function res.DestroyAllHard()
    ResManager.DestroyAllHard()
end

function res.Cleanup()
    ResManager.Cleanup()
end

function res.LoadRes(name, type)
    return ResManager.LoadRes(name, type)
end

function res.LoadResAsync(name, type)
    return ResManager.LoadResAsync(name, type)
end

function res.LoadScene(name, additive)
    ResManager.LoadScene(name, additive)
end

function res.LoadSceneAsync(name, additive)
    return ResManager.LoadSceneAsync(name, additive)
end

function res.UnloadAllRes(unloadPermanentBundle)
    ResManager.UnloadAllRes(not not unloadPermanentBundle)
end

function res.GetLuaMemory()
    local memory = collectgarbage("count")
    return string.format("%.2fM", (memory * 0.001))
end
--#endregion Raw Load and Cleanup

--#region Res Cache
local ResCache = {}

function res.CacheRes(name)
	local handle = ResCache[name]
	if handle then
		handle.AddRef()  --Lua assist checked flag
	else
		local obj = ResManager.LoadRes(name)
		if obj then
            local handle = {}
            handle.obj = obj
			ResCache[name] = handle

			local RefCnt = 1
			handle.AddRef = function()
				RefCnt = RefCnt + 1
			end
			handle.Release = function()
				RefCnt = RefCnt - 1
				if RefCnt <= 0 then
					handle.Destroy()  --Lua assist checked flag
				end
			end
			handle.Destroy = function()
				handle.obj = nil
				ResCache[name] = nil
			end
		end
    end
end

function res.UncacheRes(name)
    local handle = ResCache[name]
    if handle then
        handle.Release()  --Lua assist checked flag
    end
end

function res.ClearResCache()
	local handles = {}
	for k, v in pairs(ResCache) do
		handles[#handles + 1] = v
	end
	for i, v in ipairs(handles) do
		v.Destroy()  --Lua assist checked flag
	end
end

function res.DontDestroyOnLoad(obj)
    Object.DontDestroyOnLoad(obj)
end
--#endregion Res Cache

function res.GetCurrentEventSystem()
    if res.currentEventSystem and res.currentEventSystem ~= clr.null then
        return res.currentEventSystem
    end

    local esObj = GameObject.Find("UICameraAndEventSystem(Clone)/EventSystem")
    if esObj ~= nil and esObj ~= clr.null then
        local eventSystemComp = esObj:GetComponent(EventSystem)
        if eventSystemComp and eventSystemComp ~= clr.null then
            res.currentEventSystem = eventSystemComp
            return eventSystemComp
        end
    end
    
    local eventSystemComp = EventSystem.current
    if eventSystemComp and eventSystemComp ~= clr.null then
        res.currentEventSystem = eventSystemComp
        return eventSystemComp
    end

    --TODO: Find first disabled EventSystem.
    res.currentEventSystem = nil
    return nil
end

function res.SetCurrentEventSystemEnabled(enabled)
    local eventSystem = res.GetCurrentEventSystem()
    res.SetEventSystemEnabled(eventSystem, enabled)
end

function res.SetEventSystemEnabled(eventSystemComp, enabled)
    if eventSystemComp then
        eventSystemComp.enabled = enabled
    end
end

-- 判断物体是否在mask中，
-- 主要用于自己写的shader在mask和非mask下的模板缓冲id的设置
-- tf:transform
function res.IsInMask(tf)
    if tf and tf ~= clr.null then
        local mask = tf:GetComponentInParent(Mask)
        return mask and mask ~= clr.null
    end
    return false
end

function res.FindCanvasLayerNameAndOrder(tf)
    local lLayerName, order
    if tf and tf ~= clr.null then
        local canvas = tf:GetComponentInParent(Canvas)
        if canvas and canvas ~= clr.null then
            order = canvas.sortingOrder
            lLayerName = canvas.sortingLayerName
        end
    end
    return lLayerName, order
end

return res
