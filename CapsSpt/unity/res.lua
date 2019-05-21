local UnityEngine = clr.UnityEngine
local LightmapData = UnityEngine.LightmapData
local LightmapSettings = UnityEngine.LightmapSettings
local ResManager = clr.Capstones.UnityEngineEx.ResManager
local Object = UnityEngine.Object
local GameObject = UnityEngine.GameObject
local Canvas = UnityEngine.Canvas
local Image = UnityEngine.UI.Image
local CanvasScaler = UnityEngine.UI.CanvasScaler
local GraphicRaycaster = UnityEngine.UI.GraphicRaycaster
local RectTransform = UnityEngine.RectTransform
local Vector2 = UnityEngine.Vector2
local Camera = UnityEngine.Camera
local RenderMode = UnityEngine.RenderMode
local CapsUnityLuaBehav = clr.CapsUnityLuaBehav
local Time = UnityEngine.Time
local StandaloneInputModule = UnityEngine.EventSystems.StandaloneInputModule

luaevt.reg("LowMemory", function()
    res.CollectGarbageDeep()
end)

res = {}
res.LoadType = {
    Change = "change",
    Push = "push",
    Pop = "pop",
}

res.sceneSeq = 0
res.sceneCache = {}
--[[
{
    path = {
        obj = xxx,
        view = xxx
        seq = 0,
        ctrl = xxx,
    },
    ...
}
--]]
res.ctrlStack = {}
--[[
{
    {
        path = xxx,
        args = xxx,
        argc = xxx,
        blur = true,
        dialogs = {
            {
                path = nil,
                order = xxx,
                args = xxx,
                argc = xxx,
            },
            {
                path = nil,
                order = xxx,
                args = xxx,
                argc = xxx,
            },
            {
                path = nil,
                order = xxx,
                args = xxx,
                argc = xxx,
            },
        },
    },
}
--]]
--[[
res.curSceneInfo = {
    view = nil,
    ctrl = nil,
    path = nil,
    blur = true,
    dialogs = {
        {
            view = nil,
            ctrl = nil,
            path = nil,
            order = xxx,
        },
        {
            view = nil,
            ctrl = nil,
            path = nil,
            order = xxx,
        },
        {
            view = nil,
            ctrl = nil,
            path = nil,
            order = xxx,
        },
    },
}
--]]

local function GetSceneSeq()
    res.sceneSeq = res.sceneSeq + 1
    return res.sceneSeq
end

local sceneCacheMax = 5
local delayRunGCTime = 15

-- if device.level == "middle" then
--     sceneCacheMax = 4
--     delayRunGCTime = 10
-- elseif device.level == "low" then
--     sceneCacheMax = 3
--     delayRunGCTime = 9
-- end

if clr.UnityEngine.SystemInfo.systemMemorySize <= 1024 then
    delayRunGCTime = 5
end

luaevt.trig("___EVENT__SET_PERF_LEVEL")

function res.ClearChildren(obj, time)
    if res.IsClrNull(obj) then return end
    if time == nil or type(time) ~= "number" then time = 0 end
    GameUtil.ClearChildren(obj, time)
end

function res.ClearChildrenImmediate(obj)
    if res.IsClrNull(obj) then return end
    GameUtil.ClearChildrenImmediate(obj)
end

function res.SetSceneCacheMax(cnt)
    if type(cnt) ~= "number" or cnt < 1 then
        cnt = 1
    end
    sceneStackMax = cnt
end

function res.GetSceneCacheMax()
    return sceneCacheMax
end

function res.IsClrNull(obj)
    return obj == nil or obj == clr.null
end
--打开转菊花等待---
function res.ShowWaitForPost(msg)
    res.CloseWaitForPost()
    local dialog, blockdlg = res.ShowDialog("Assets/CapstonesRes/Game/UI/Common/Template/Loading/WaitForPost.prefab", "overlay", false)
    if dialog == nil or dialog == clr.null or blockdlg == nil then return end
    if msg ~= nil and type(msg) == "string" and blockdlg.contentcomp ~= nil then blockdlg.contentcomp:SetTxts({msg}) end
    cache.SetWaitForPostGameObject(blockdlg)
end
--关闭转菊花等待---
function res.CloseWaitForPost()
    local blockdlg = cache.GetWaitForPostGameObject(nil)
    if blockdlg == nil or blockdlg == clr.null then
       
    else
        local closeDialog = blockdlg.closeDialog
        if type(closeDialog) == "function" then
            closeDialog()
        end
        local obj = blockdlg.gameObject
        if obj == nil or obj == clr.null then 
            Object.Destroy(obj)
            cache.SetWaitForPostGameObject(nil)
            return
        end
    end
    cache.SetWaitForPostGameObject(nil)
end

function res.CacheObjIsClrNull(objs)
    if objs == nil then return true end
    return ResManager.CacheObjIsNull(objs)
end

function res.DestroyGameObjectList(objs)
    if objs == nil then return end
    ResManager.DestroyGameObjectList(objs)
end

local function TrimSceneCache(isNoCollectGarbage)
    if table.nums(res.sceneCache) <= sceneCacheMax then return end
    local sceneTable = {}
    for k, v in pairs(res.sceneCache) do
        local sceneInfo = v
        sceneInfo.path = k
        table.insert(sceneTable, sceneInfo)
    end
    table.sort(sceneTable, function(a, b) return a.seq > b.seq end)
    res.sceneCache = {}
    for i, v in ipairs(sceneTable) do
        if i <= sceneCacheMax then
            local path = v.path
            res.sceneCache[path] = v
        elseif not res.CacheObjIsClrNull(v.obj) then
            res.DestroyGameObjectList(v.obj)
            v.obj = nil
        end
    end
    if isNoCollectGarbage ~= true and #sceneTable > sceneCacheMax then
        res.CollectGarbage()
    end
end

local ctrlStackMax = math.max_int32 

function res.SetCtrlStackMax(cnt)
    if type(cnt) ~= "number" or cnt < 1 then
        cnt = 1
    end
    ctrlStackMax = cnt
end

function res.GetCtrlStackMax()
    return ctrlStackMax
end

local function TrimCtrlStack()
    if #res.ctrlStack > ctrlStackMax then
        for i = ctrlStackMax + 1, #res.ctrlStack do
            res.ctrlStack[i] = nil
        end
    end
end

local function SaveCurrentSceneInfo()
    local dialogObjs = {}
    if type(res.curSceneInfo) == "table" and type(res.curSceneInfo.dialogs) == "table" then
        for i, v in ipairs(res.curSceneInfo.dialogs) do
            table.insert(dialogObjs, v.view.dialog.gameObject)
            res.RestoreDialogOrder(v.view.dialog.currentOrder)
        end
    end
    local dialogObjsArr = clr.array(dialogObjs, GameObject)
    local packs = ResManager.PackSceneAndDialogs(dialogObjsArr)
    local sgos = packs.sceneObj
    local dialogObjs = packs.dialogObjs
    local dgos = clr.table(dialogObjs)
    local dgosDisable = {}
    local sgoDisable = true
    local isTrimSceneCache = false
    if type(res.curSceneInfo) == "table" and not res.IsClrNull(res.curSceneInfo.view) then
        local sceneCacheItem = res.sceneCache[res.curSceneInfo.path]
        if not sceneCacheItem then
            res.sceneCache[res.curSceneInfo.path] = {
                obj = sgos,
                view = res.curSceneInfo.view,
                seq = GetSceneSeq(),
                ctrl = res.curSceneInfo.ctrl,
            }
            isTrimSceneCache = true
        else
           sceneCacheItem.seq = GetSceneSeq()
            if res.CacheObjIsClrNull(sceneCacheItem.obj) then
                sceneCacheItem.obj = sgos
                sceneCacheItem.ctrl = res.curSceneInfo.ctrl
            end
        end
        if res.curSceneInfo.ctrl and type(res.curSceneInfo.ctrl.OnExitScene) == "function" then
            res.curSceneInfo.ctrl:OnExitScene()
        end
    else
        sgoDisable = false
    end

    for i, dgo in ipairs(dgos) do
        if type(res.curSceneInfo) == "table" and type(res.curSceneInfo.dialogs) == "table" then
            local curDialogInfo = res.curSceneInfo.dialogs[i]
            if type(curDialogInfo) == "table" and curDialogInfo.view ~= clr.null then
                table.insert(dgosDisable, true)
                local dgosItem = res.sceneCache[curDialogInfo.path]
                if not dgosItem then
                    res.sceneCache[curDialogInfo.path] = {
                        obj = dgo,
                        view = curDialogInfo.view,
                        seq = GetSceneSeq(),
                        ctrl = curDialogInfo.ctrl,
                    }
                    isTrimSceneCache = true
                else
                    dgosItem.seq = GetSceneSeq()
                    if res.CacheObjIsClrNull(dgosItem.obj) then
                        dgosItem.obj = dgo
                        dgosItem.ctrl = curDialogInfo.ctrl
                    end
                end
                if curDialogInfo.ctrl and type(curDialogInfo.ctrl.OnExitScene) == "function" then
                    curDialogInfo.ctrl:OnExitScene()
                end
            else
                table.insert(dgosDisable, false)
            end
        else
            table.insert(dgosDisable, false)
        end
    end

    if isTrimSceneCache == true then
        TrimSceneCache()
    end

    local isCacheToDontDestroyRoot = false
    local function CacheToDontDestroyRootFun()
        isCacheToDontDestroyRoot = true
        ResManager.CacheToDontDestroyRoot(sgos)
        ResManager.CacheToDontDestroyRoot(dialogObjs)
    end

    local function DisableOrDestroyCurrentSceneObj(isLoadScene)
        if not res.CacheObjIsClrNull(sgos) then
            if sgoDisable  then
                ResManager.SetCacheActive(sgos,true,false)
            else
                res.DestroyGameObjectList(sgos)
            end
        end
        if type(dgos) == "table" then
            ResManager.SetCacheActive(dialogObjs,true,false)
            for i, dgo in ipairs(dgos) do
                if not res.IsClrNull(dgo) and not dgosDisable[i] then
                   GameUtil.Destroy(dgo)
                end
            end
        end
         if isLoadScene == true then
            res.ClearSceneCache()
        end
    end
    return DisableOrDestroyCurrentSceneObj, CacheToDontDestroyRootFun
end

local function SaveCurrentStatusData()
    -- 如果之前的场景是有ctrl的prefab，则保存其信息
    if type(res.curSceneInfo) == "table" and res.curSceneInfo.ctrl then
        -- 保存ctrl恢复的数据信息
        local args = {res.curSceneInfo.ctrl:GetStatusData()}
        local argc = select('#', res.curSceneInfo.ctrl:GetStatusData())

        local ctrlInfo = {
            path = res.curSceneInfo.path,
            args = args,
            argc = argc,
            blur = res.curSceneInfo.blur,
        }

        table.insert(res.ctrlStack, ctrlInfo)
        TrimCtrlStack()
    end

    if type(res.curSceneInfo) == "table" and type(res.curSceneInfo.dialogs) == "table" and #res.curSceneInfo.dialogs > 0 then
        res.ctrlStack[#res.ctrlStack].dialogs = {}
        for i, dialogInfo in ipairs(res.curSceneInfo.dialogs) do
            local args = {dialogInfo.ctrl:GetStatusData()}
            local argc = select('#', dialogInfo.ctrl:GetStatusData())

            local ctrlInfo = {
                path = dialogInfo.path,
                args = args,
                argc = argc,
                order = dialogInfo.order,
            }

            table.insert(res.ctrlStack[#res.ctrlStack].dialogs, ctrlInfo)
        end
    end
end

local function ClearCurrentSceneInfo()
    res.curSceneInfo = nil
end

local function LoadPrefabDialog(loadType, ctrlPath, order, ...)
    cache.setGlobalTempData(true, "LoadingPrefabDialog")

    -- 记录当前窗口信息
    local dialogInfo = {}
    if type(res.curSceneInfo.dialogs) ~= "table" then
        res.curSceneInfo.dialogs = {}
    end
    table.insert(res.curSceneInfo.dialogs, dialogInfo)
    dialogInfo.path = ctrlPath

    local cachedSceneInfo = res.sceneCache[ctrlPath]
    res.sceneCache[ctrlPath] = nil
    local ctrlClass = require(ctrlPath)

    local args = {...}
    local argc = select('#', ...)

    local function CreateDialog()
        local viewPath = ctrlClass.viewPath
        local dialog, dialogcomp = res.ShowDialog(viewPath, "camera", ctrlClass.dialogStatus.touchClose, ctrlClass.dialogStatus.withShadow, ctrlClass.dialogStatus.unblockRaycast, true)
        dialogInfo.view = dialogcomp.contentcomp
        dialogInfo.order = dialog:GetComponent(Canvas).sortingOrder
        dialogInfo.ctrl = ctrlClass.new(dialogInfo.view, unpack(args, 1, argc))
        dialogInfo.ctrl.__loadType = loadType
        dialogInfo.ctrl:Refresh(unpack(args, 1, argc))
        res.GetLuaScript(dialog).OnExitScene = function ()
            if type(dialogInfo.ctrl.OnExitScene) == "function" then
                dialogInfo.ctrl:OnExitScene()
            end
        end
    end

    if type(cachedSceneInfo) == "table" then
        if not res.CacheObjIsClrNull(cachedSceneInfo.obj) then
            dialogInfo.view = cachedSceneInfo.view
            dialogInfo.ctrl = cachedSceneInfo.ctrl
            dialogInfo.order = order
            dialogInfo.view.dialog:setOrder(order)
            dialogInfo.ctrl.__loadType = loadType
            dialogInfo.ctrl:Refresh(unpack(args, 1, argc))

            local scd, uds = res.GetLastSCDAndUDs(false)

            ResManager.UnpackSceneObj(cachedSceneInfo.obj,true)
            
            res.AdjustDialogCamera(scd, uds, dialogInfo.view.gameObject, dialogInfo.view.dialog.withShadow)
        else
            res.sceneCache[ctrlPath] = nil
            CreateDialog()
        end
    else
        CreateDialog()
    end

    cache.removeGlobalTempData("LoadingPrefabDialog")
    return dialogInfo.ctrl
end

local function LoadPrefabScene(loadType, ctrlPath, isBlur, dialogData, ...)
    require("ui.control.button.LuaButton").frameCount = clr.UnityEngine.Time.frameCount
    -- 记录当前场景信息res.curSceneInfo
    res.curSceneInfo = {
        path = ctrlPath,
    }
    local cachedSceneInfo = res.sceneCache[ctrlPath]
    res.sceneCache[ctrlPath] = nil
    local ctrlClass = require(ctrlPath)

    local args = {...}
    local argc = select('#', ...)

    local function CreateDialogs()
        if type(dialogData) == "table" then
            table.sort(dialogData, function(a, b) return tonumber(a.order) < tonumber(b.order) end)
            for i, v in ipairs(dialogData) do
                LoadPrefabDialog(loadType, v.path, v.order, unpack(v.args, 1, v.argc))
            end
        end
    end

    local function CreateScene()
        local viewPath = ctrlClass.viewPath
        clr.coroutine(function()
            if string.sub(viewPath, -6) == '.unity' then
                local loadinfo = ResManager.LoadSceneAsync(viewPath)
                if loadinfo then
                    while not loadinfo.isDone do
                        unity.waitForNextEndOfFrame()
                    end
                    res.curSceneInfo.view = cache.removeGlobalTempData("MainManager")
                else
                    local mainManager
                    repeat
                        mainManager = cache.removeGlobalTempData("MainManager")
                        unity.waitForNextEndOfFrame()
                    until mainManager
                    res.curSceneInfo.view = mainManager
                end
            else
                local prefab = res.LoadRes(viewPath)
                if prefab then
                    local obj = Object.Instantiate(prefab)
                    local camera = ResManager.CreateCameraAndEventSystem()
                    res.SetUICamera(obj, camera)
                    res.curSceneInfo.view = res.GetLuaScript(obj)
                end
            end

            res.curSceneInfo.ctrl = ctrlClass.new(res.curSceneInfo.view, unpack(args, 1, argc))
            res.curSceneInfo.ctrl.__loadType = loadType
            res.curSceneInfo.ctrl:Refresh(unpack(args, 1, argc))
            if isBlur then
                res.curSceneInfo.blur = true
                if res.NeedDialogCameraBlur() then
                    res.SetMainCameraBlur()
                end
            end
            CreateDialogs()

            if res.curSceneInfo.ctrl and type(res.curSceneInfo.ctrl.OnLoadComplete) == "function" then
                res.curSceneInfo.ctrl:OnLoadComplete()
            end
        end)
    end

    if type(cachedSceneInfo) == "table" then
        if not res.CacheObjIsClrNull(cachedSceneInfo.obj) then
            res.curSceneInfo.ctrl = cachedSceneInfo.ctrl
            res.curSceneInfo.ctrl.__loadType = loadType
            ResManager.UnpackSceneObj(cachedSceneInfo.obj,true)
            res.curSceneInfo.view = cachedSceneInfo.view

            local isDialogData = res.IsClrNull(res.GetLastSCDAndUDs()) and type(dialogData) == "table" and #dialogData > 0
            res.curSceneInfo.ctrl.IsCheckCurrUIDialog = isDialogData
            res.curSceneInfo.ctrl:Refresh(unpack(args, 1, argc))
            res.curSceneInfo.ctrl.IsCheckCurrUIDialog = false
            
            if res.NeedDialogCameraBlur() then
                if not isDialogData then
                    res.SetMainCameraBlurOver()
                else
                    res.SetMainCameraBlur()
                end
            end

            CreateDialogs()
            if res.curSceneInfo.ctrl and type(res.curSceneInfo.ctrl.OnLoadComplete) == "function" then
                res.curSceneInfo.ctrl:OnLoadComplete()
            end
        else
            CreateScene()
        end
    else
        CreateScene()
    end

    return res.curSceneInfo.ctrl
end

local function LoadPrefabSceneAsync(loadType, ctrlPath, isBlur, dialogData, disableOrDestroySceneFunc, cacheToDontDestroyRootFun, ...)
    require("ui.control.button.LuaButton").frameCount = math.max_int32 - 3
    -- 记录当前场景信息res.curSceneInfo
    res.curSceneInfo = {
        path = ctrlPath,
    }
    local cachedSceneInfo = res.sceneCache[ctrlPath]
    res.sceneCache[ctrlPath] = nil
    local ctrlClass = require(ctrlPath)

    local args = {...}
    local argc = select('#', ...)

    local waitHandle = {}

    local function CreateDialogs()
        if type(dialogData) == "table" then
            table.sort(dialogData, function(a, b) return a.order < b.order end)
            for i, v in ipairs(dialogData) do
                LoadPrefabDialog(loadType, v.path, v.order, unpack(v.args, 1, v.argc))
            end
        end
    end

    local function CreateScene()
        clr.coroutine(function()
            unity.waitForEndOfFrame()
            local viewPath = ctrlClass.viewPath
            local isLoadScene = string.sub(viewPath, -6) == ".unity" 
            if isLoadScene then
                if type(cacheToDontDestroyRootFun) == "function" then cacheToDontDestroyRootFun() end
                local loadinfo = ResManager.LoadSceneAsync(viewPath)
                if loadinfo then
                    while not loadinfo.isDone do
                        unity.waitForNextEndOfFrame()
                    end
                    res.curSceneInfo.view = cache.removeGlobalTempData("MainManager")
                    res.curSceneInfo.ctrl = ctrlClass.new(res.curSceneInfo.view, unpack(args, 1, argc))
                    res.curSceneInfo.ctrl.__loadType = loadType
                    res.curSceneInfo.ctrl:Refresh(unpack(args, 1, argc))
                    waitHandle.ctrl = res.curSceneInfo.ctrl
                else
                    local mainManager
                    repeat
                        mainManager = cache.removeGlobalTempData("MainManager")
                        unity.waitForNextEndOfFrame()
                    until mainManager

                    res.curSceneInfo.view = mainManager
                    res.curSceneInfo.ctrl = ctrlClass.new(res.curSceneInfo.view, unpack(args, 1, argc))
                    res.curSceneInfo.ctrl.__loadType = loadType
                    res.curSceneInfo.ctrl:Refresh(unpack(args, 1, argc))
                    waitHandle.ctrl = res.curSceneInfo.ctrl
                end
            else
                local loadinfo = ResManager.LoadResAsync(ctrlClass.viewPath)
                if loadinfo then
                    while not loadinfo.isDone do
                        unity.waitForNextEndOfFrame()
                    end
                    local prefab = loadinfo.asset
                    if prefab then
                        local obj = Object.Instantiate(prefab)
                        local camera = ResManager.CreateCameraAndEventSystem()
                        res.SetUICamera(obj, camera)
                        res.curSceneInfo.view = res.GetLuaScript(obj)
                        res.curSceneInfo.ctrl = ctrlClass.new(res.curSceneInfo.view, unpack(args, 1, argc))
                        res.curSceneInfo.ctrl.__loadType = loadType
                        res.curSceneInfo.ctrl:Refresh(unpack(args, 1, argc))
                        waitHandle.ctrl = res.curSceneInfo.ctrl
                    end
                end
            end

            if isBlur then
                res.curSceneInfo.blur = true
                if res.NeedDialogCameraBlur() then
                    res.SetMainCameraBlur()
                end
            end

            if type(disableOrDestroySceneFunc) == "function" then
                disableOrDestroySceneFunc(isLoadScene)
            end

            CreateDialogs()

            waitHandle.done = true

            if res.curSceneInfo.ctrl and type(res.curSceneInfo.ctrl.OnLoadComplete) == "function" then
                res.curSceneInfo.ctrl:OnLoadComplete()
            end

            require("ui.control.button.LuaButton").frameCount = clr.UnityEngine.Time.frameCount
        end)
    end

    if type(cachedSceneInfo) == "table" then
        if not res.CacheObjIsClrNull(cachedSceneInfo.obj) then
            ResManager.UnpackSceneObj(cachedSceneInfo.obj,true)
            if type(disableOrDestroySceneFunc) == "function" then disableOrDestroySceneFunc() end
            res.curSceneInfo.view = cachedSceneInfo.view
            res.curSceneInfo.ctrl = cachedSceneInfo.ctrl
            res.curSceneInfo.ctrl.__loadType = loadType

            local isDialogData = res.IsClrNull(res.GetLastSCDAndUDs()) and type(dialogData) == "table" and #dialogData > 0
            res.curSceneInfo.ctrl.IsCheckCurrUIDialog = isDialogData
            res.curSceneInfo.ctrl:Refresh(unpack(args, 1, argc))
            res.curSceneInfo.ctrl.IsCheckCurrUIDialog = false

            if res.NeedDialogCameraBlur() then
                if not isDialogData then
                    res.SetMainCameraBlurOver()
                else
                    res.SetMainCameraBlur()
                end
            end
            CreateDialogs()
            waitHandle.done = true
            waitHandle.ctrl = res.curSceneInfo.ctrl

            if res.curSceneInfo.ctrl and type(res.curSceneInfo.ctrl.OnLoadComplete) == "function" then
                res.curSceneInfo.ctrl:OnLoadComplete()
            end
        else
            CreateScene()
        end
    else
        CreateScene()
    end

    return waitHandle
end

function res.ClearSceneCache()
    for k, v in pairs(res.sceneCache) do
        res.DestroyGameObjectList(v.obj)
        v.obj = nil
    end
    res.sceneCache = {}
    res.sceneSeq = 0
end

function res.ClearCtrlStack()
    res.ctrlStack = {}
end

function res.CacheHandle()
    SaveCurrentStatusData()
    local disableOrDestroySceneFunc = SaveCurrentSceneInfo()
    disableOrDestroySceneFunc()
    ClearCurrentSceneInfo()
end

function res.LoadSceneImmediate(name, ...)
    SaveCurrentStatusData()
    local disableOrDestroySceneFunc = SaveCurrentSceneInfo()
    ClearCurrentSceneInfo()
    if string.sub(name, -6) == '.unity' then
        ResManager.LoadSceneImmediate(name)
        disableOrDestroySceneFunc(true)
    else
        local prefab = res.LoadRes(name)
        if prefab then
            local obj = Object.Instantiate(prefab)
            disableOrDestroySceneFunc()
            local camera = ResManager.CreateCameraAndEventSystem()
            res.SetUICamera(obj, camera)
            return res.GetLuaScript(obj)
        end
    end
end

function res.LoadSceneAsync(name, ...)
    SaveCurrentStatusData()
    local disableOrDestroySceneFunc, cacheToDontDestroyRootFun = SaveCurrentSceneInfo()
    ClearCurrentSceneInfo()
    local waitHandle = {}
    clr.coroutine(function()
        unity.waitForEndOfFrame()
        local isLoadScene = string.sub(name, -6) == ".unity" 
        if isLoadScene then
            if type(cacheToDontDestroyRootFun) == "function" then cacheToDontDestroyRootFun() end
            local loadinfo = ResManager.LoadSceneAsync(name)
            if loadinfo then
                while not loadinfo.isDone do
                    unity.waitForNextEndOfFrame()
                end
            end
        else
            local prefab
            local loadinfo = ResManager.LoadResAsync(name)
            if loadinfo then
                while not loadinfo.isDone do
                    unity.waitForNextEndOfFrame()
                end
                prefab = loadinfo.asset
            end
            if prefab then
                local obj = Object.Instantiate(prefab)
                local camera = ResManager.CreateCameraAndEventSystem()
                res.SetUICamera(obj, camera)
            end
        end
        disableOrDestroySceneFunc(isLoadScene)
        waitHandle.done = true
    end)
    return waitHandle
end

function res.LoadScene(name, ...)
    local args = {...}
    local argc = select('#', ...)
    clr.coroutine(function()
        unity.waitForNextEndOfFrame()
        SaveCurrentStatusData()
        local disableOrDestroySceneFunc = SaveCurrentSceneInfo()
        ClearCurrentSceneInfo()
        if string.sub(name, -6) == ".unity" then
            ResManager.LoadSceneImmediate(name)
            unity.waitForNextEndOfFrame()
            disableOrDestroySceneFunc(true)
        else
            local prefab = res.LoadRes(name)
            if prefab then
                local obj = Object.Instantiate(prefab)
                local camera = ResManager.CreateCameraAndEventSystem()
                unity.waitForNextEndOfFrame()
                disableOrDestroySceneFunc()
                res.SetUICamera(obj, camera)
                return res.GetLuaScript(obj)
            end
        end
    end)
end

function res.PushSceneImmediate(ctrlPath, ...)
    SaveCurrentStatusData()
    local disableOrDestroySceneFunc = SaveCurrentSceneInfo()
    disableOrDestroySceneFunc()
    ClearCurrentSceneInfo()

    return LoadPrefabScene(res.LoadType.Push, ctrlPath, nil, nil, ...)
end

function res.PushSceneAsync(ctrlPath, ...)
    SaveCurrentStatusData()
    local disableOrDestroySceneFunc, cacheToDontDestroyRootFun = SaveCurrentSceneInfo()
    ClearCurrentSceneInfo()

    return LoadPrefabSceneAsync(res.LoadType.Push, ctrlPath, nil, nil, disableOrDestroySceneFunc, cacheToDontDestroyRootFun, ...)
end

function res.PushScene(ctrlPath, ...)
    local args = {...}
    local argc = select('#', ...)
    clr.coroutine(function()
        unity.waitForEndOfFrame()
        res.PushSceneImmediate(ctrlPath, unpack(args, 1, argc))
    end)
end

local unmanagedDialogs = {}
local unmanagedBlockDialogs =
{
    ["Assets/CapstonesRes/Game/UI/Common/Template/Loading/WaitForPost.prefab"] = true,
}

local function CloseDialog()
    if type(res.curSceneInfo) == "table" and type(res.curSceneInfo.dialogs) == "table" and #res.curSceneInfo.dialogs > 0 then
        local maxIndex = 0
        local maxOrder = -1
        for i, v in ipairs(res.curSceneInfo.dialogs) do
            local order = v.order
            if maxOrder < order then
                maxOrder = order
                maxIndex = i
            end
        end
        if maxIndex > 0 then
            local dialog = res.curSceneInfo.dialogs[maxIndex]
            if type(dialog) == "table" and dialog.view and dialog.view ~= clr.null and type(dialog.view.closeDialog) == "function" then
                dialog.view:closeDialog()
                return true
            end
        end
    end
end

function res.CommonOnBackDialog()
    for i = #unmanagedDialogs, 1, -1 do
        local dialog = unmanagedDialogs[i].dialog
        if not dialog or dialog == clr.null or not dialog.isActiveAndEnabled then
            unmanagedDialogs[i] = nil
        else
            if not unmanagedDialogs[i].block then
                local ccomp = dialog.contentcomp
                if ccomp and ccomp ~= clr.null and type(ccomp.OnBack) == "function" then
                    ccomp.OnBack()
                else
                    dialog.closeDialog()
                end
            end
            return true
        end
    end

    if CloseDialog() then
        return true
    else
        return false
    end
end

function res.CommonOnBack()
    if res.CommonOnBackDialog() then
        return true
    else
        return res.PopSceneWithoutCurrentImmediate()
    end
end

-- 如果当前最上层的是一个窗口，则只关闭这个窗口，否则关闭整个场景
function res.PopSceneImmediate(...)
    if not CloseDialog() then
        return res.PopSceneWithCurrentSceneImmediate(...)
    end
end

function res.PopSceneAsync(...)
    if not CloseDialog() then
        return res.PopSceneWithCurrentSceneAsync(...)
    end
end

function res.PopScene(...)
    if not CloseDialog() then
        return res.PopSceneWithCurrentScene(...)
    end
end

function res.PopSceneWithCurrentSceneImmediate(...)
    if #res.ctrlStack == 0 then return end

    local disableOrDestroySceneFunc = SaveCurrentSceneInfo()
    disableOrDestroySceneFunc()

    ClearCurrentSceneInfo()

    -- restore old info
    local ctrlInfo = table.remove(res.ctrlStack)
    local ctrlPath = ctrlInfo.path
    local argc = select('#', ...)
    local args = {...}
    if argc == 0 then
        args = ctrlInfo.args
        argc = ctrlInfo.argc
    end
    local isBlur = ctrlInfo.blur

    return LoadPrefabScene(res.LoadType.Pop, ctrlPath, isBlur, ctrlInfo.dialogs, unpack(args, 1, argc))
end

function res.PopSceneWithCurrentSceneAsync(...)
    if #res.ctrlStack == 0 then return end

    local disableOrDestroySceneFunc, cacheToDontDestroyRootFun = SaveCurrentSceneInfo()

    ClearCurrentSceneInfo()

    -- restore old info
    local ctrlInfo = table.remove(res.ctrlStack)
    local ctrlPath = ctrlInfo.path
    local argc = select('#', ...)
    local args = {...}
    if argc == 0 then
        args = ctrlInfo.args
        argc = ctrlInfo.argc
    end
    local isBlur = ctrlInfo.blur

    return LoadPrefabSceneAsync(res.LoadType.Pop, ctrlPath, isBlur, ctrlInfo.dialogs, disableOrDestroySceneFunc, cacheToDontDestroyRootFun, unpack(args, 1, argc))
end

function res.PopSceneWithCurrentScene(...)
    local args = {...}
    local argc = select('#', ...)
    clr.coroutine(function()
        unity.waitForEndOfFrame()
        res.PopSceneWithCurrentSceneImmediate(unpack(args, 1, argc))
    end)
end

function res.PopSceneWithoutCurrentImmediate(...)
    if #res.ctrlStack == 0 then return end

    local sgos = ResManager.PackSceneObj()
    res.DestroyGameObjectList(sgos)
    -- restore old info
    local ctrlInfo = table.remove(res.ctrlStack)
    local ctrlPath = ctrlInfo.path
    local argc = select('#', ...)
    local args = {...}
    if argc == 0 then
        args = ctrlInfo.args
        argc = ctrlInfo.argc
    end
    local isBlur = ctrlInfo.blur

    return LoadPrefabScene(res.LoadType.Pop, ctrlPath, isBlur, ctrlInfo.dialogs, unpack(args, 1, argc))
end

function res.PopSceneWithoutCurrentAsync(...)
    if #res.ctrlStack == 0 then return end

    local sgos = ResManager.PackSceneObj()
    local disableOrDestroySceneFunc = function ()
        res.DestroyGameObjectList(sgos)
    end
    local callBackFun = nil
    -- restore old info
    local ctrlInfo = table.remove(res.ctrlStack)
    local ctrlPath = ctrlInfo.path
    local argc = select('#', ...)
    local args = {...}
    if argc == 0 then
        args = ctrlInfo.args
        argc = ctrlInfo.argc
    end
    local isBlur = ctrlInfo.blur

    return LoadPrefabSceneAsync(res.LoadType.Pop, ctrlPath, isBlur, ctrlInfo.dialogs, disableOrDestroySceneFunc, callBackFun, unpack(args, 1, argc))
end

function res.PopSceneWithoutCurrent(...)
    local args = {...}
    local argc = select('#', ...)
    clr.coroutine(function()
        unity.waitForEndOfFrame()
        res.PopSceneWithoutCurrentImmediate(unpack(args, 1, argc))
    end)
end

function res.ChangeSceneImmediate(ctrlPath, ...)
    SaveCurrentStatusData()
    local disableOrDestroySceneFunc = SaveCurrentSceneInfo()
    disableOrDestroySceneFunc()
    res.ClearSceneCache()
    ClearCurrentSceneInfo()

    return LoadPrefabScene(res.LoadType.Change, ctrlPath, nil, nil, ...)
end

function res.ChangeSceneAsync(ctrlPath, ...)
    SaveCurrentStatusData()
    local disableOrDestroySceneFunc, cacheToDontDestroyRootFun = SaveCurrentSceneInfo()
    res.ClearSceneCache()
    ClearCurrentSceneInfo()

    return LoadPrefabSceneAsync(res.LoadType.Change, ctrlPath, nil, nil, disableOrDestroySceneFunc, cacheToDontDestroyRootFun, ...)
end

function res.ChangeScene(ctrlPath, ...)
    local args = {...}
    local argc = select('#', ...)
    clr.coroutine(function()
        unity.waitForEndOfFrame()
        res.ChangeSceneImmediate(ctrlPath, unpack(args, 1, argc))
    end)
end

function res.PushDialogImmediate(ctrlPath, ...)
    return LoadPrefabDialog(res.LoadType.Push, ctrlPath, nil, ...)
end

function res.PushDialog(ctrlPath, ...)
    local args = {...}
    local argc = select('#', ...)
    clr.coroutine(function()
        unity.waitForEndOfFrame()
        res.PushDialogImmediate(ctrlPath, unpack(args, 1, argc))
    end)
end

function res.GetLastCtrlPath()
    if #res.ctrlStack > 0 then
        return res.ctrlStack[#res.ctrlStack].path
    end
end

function res.RemoveLastSceneData()
    if #res.ctrlStack > 0 then
        res.ctrlStack[#res.ctrlStack] = nil
    end
end

function res.RemoveCurrentSceneDialogsInfo()
    if type(res.curSceneInfo) == "table" then
        res.curSceneInfo.dialogs = nil
    end
end

function res.SetUICamera(obj, camera)
    if obj then
        local canvas = obj:GetComponent(Canvas)
        if canvas and canvas ~= clr.null then
            canvas.worldCamera = camera
        end
    end
end

function res.ChangeGameObjectLayer(dialog, layer)
    ResManager.ChangeGameObjectLayer(dialog, layer)
end

function res.GetDialogCamera()
    return ResManager.GetDialogCamera()
end

function res.GetTopCtrl()
    if type(res.curSceneInfo) == "table" then
        if type(res.curSceneInfo.dialogs) == "table" then
            if #res.curSceneInfo.dialogs > 0 then
                return res.curSceneInfo.dialogs[#res.curSceneInfo.dialogs].ctrl
            end
        end
        return res.curSceneInfo.ctrl
    end
end

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
            local canvas = obj:GetComponent(Canvas)
            if canvas and canvas ~= clr.null then
                res.SetUICamera(obj, ResManager.FindUICamera())
            end
            return obj, res.GetLuaScript(obj)
        end
    end
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

-- 是否需要开启弹出窗口背景模糊效果
function res.NeedDialogCameraBlur()
    return true
    --return device.level ~= "low"
end

-- 设置由MainCamera渲染的UI界面模糊
function res.SetMainCameraBlur()
    local loadingType = cache.getGlobalTempData("LoadingPrefabDialog")
    if loadingType then
        if type(res.curSceneInfo) == "table" then
            res.curSceneInfo.blur = true
        end
    end
    return res.SetCameraBlur(Camera.main)
end
function res.SetCameraBlur(camera)
    assert(camera)
    local rapidBlurEffect = camera.gameObject:GetComponent(RapidBlurEffect)
    if not rapidBlurEffect then
        rapidBlurEffect = camera.gameObject:AddComponent(RapidBlurEffect)
    end
    rapidBlurEffect.isLockBlurIterations = false
    rapidBlurEffect.DownSampleNum = 3
    rapidBlurEffect.BlurSpreadSize = 4
    rapidBlurEffect.BlurIterations = 2
    local blurColor = require("ui.common.EffectConstants").CameraBlurColor
    rapidBlurEffect.color = UnityEngine.Color(blurColor[1], blurColor[2], blurColor[3], blurColor[4])
    rapidBlurEffect.enabled = true
end
-- 关闭模糊特效
function res.SetMainCameraBlurOver()
    if type(res.curSceneInfo) == "table" then
        res.curSceneInfo.blur = nil
    end
    return res.SetCameraBlurOver(Camera.main)
end
function res.SetCameraBlurOver(camera)
    assert(camera)
    local rapidBlurEffect = camera.gameObject:GetComponent(RapidBlurEffect)
    if not rapidBlurEffect then
        return
    end
    rapidBlurEffect.enabled = false
end

-- 获取最上层的带有shadow的camera dialog及其上面的所有不带shadow的camera dialog，并且不带shadow的camera dialog是按照order从小到大排好序的
-- withoutCurrent代表是否不包括当前最顶层CameraDialog
-- 这个方法应该只在顶层是带有shadow的camera dialog是调用才有意义
function res.GetLastSCDAndUDs(withoutCurrent)
    local canvases = clr.table(Object.FindObjectsOfType(Canvas))
    local cameraCanvas = {}
    for i, v in ipairs(canvases) do
        if (v.transform.parent == nil or v.transform.parent == clr.null) and v.renderMode == RenderMode.ScreenSpaceCamera and v.sortingLayerName == "Dialog" then
            table.insert(cameraCanvas, v)
        end
    end

    table.sort(cameraCanvas, function(a, b) return a.sortingOrder > b.sortingOrder end)

    local scd = nil
    local uds = {}
    local startIndex = withoutCurrent and 2 or 1
    for i = startIndex, #cameraCanvas do
        local v = cameraCanvas[i]
        if res.GetLuaScript(v).withShadow then
            scd = v.gameObject
            break
        else
            table.insert(uds, 1, v.gameObject)
        end
    end

    return scd, uds
end

function res.ChangeCameraDialogToUI(dialog)
    res.SetUICamera(dialog, ResManager.FindUICamera())
    res.ChangeGameObjectLayer(dialog, 5)
end

function res.ChangeCameraDialogToDialog(dialog)
    res.SetUICamera(dialog, res.GetDialogCamera())
    res.ChangeGameObjectLayer(dialog, 19)
end

function res.JudgeShowDialog(withCtrl)
    local canvases = clr.table(Object.FindObjectsOfType(Canvas))
    for i, v in ipairs(canvases) do
        if (v.transform.parent == nil or v.transform.parent == clr.null) and v.renderMode == RenderMode.ScreenSpaceCamera and v.sortingLayerName == "Dialog" then
            if res.GetLuaScript(v).withCtrl ~= withCtrl then
                return false
            end
        end
    end
    return true
end

function res.AdjustDialogCamera(scd, uds, dialog, withShadow)
    if withShadow then
        res.ChangeCameraDialogToDialog(dialog)
        if scd and scd ~= clr.null then
            res.ChangeCameraDialogToUI(scd)
        end
        for i, v in ipairs(uds) do
            if v and v ~= clr.null then
                res.ChangeCameraDialogToUI(v)
            end
        end
    else
        if scd and scd ~= clr.null then
            res.ChangeCameraDialogToDialog(dialog)
        else
            res.ChangeCameraDialogToUI(dialog)
        end
    end
end

res.InstanceCache = {}
function res.AddCache(cachePath)
    if not res.InstanceCache[cachePath] then
        res.InstanceCache[cachePath] = ResManager.LoadRes(cachePath)
    end
end

function res.RemoveCache(cachePath)
    if res.InstanceCache[cachePath] then 
        res.InstanceCache[cachePath] = nil
    end
end

function res.ShowDialog(content, renderMode, touchClose, withShadow, unblockRaycast, withCtrl, overlaySortingOrder)
    local loadingType = cache.getGlobalTempData("LoadingPrefabDialog")
    local loadingInfo = { dialog = {} }
    if not loadingType then
        if unmanagedBlockDialogs[content] then
            loadingInfo.block = true
        end
        for i = #unmanagedDialogs, 1, -1 do
            local dialog = unmanagedDialogs[i].dialog
            if not dialog or dialog == clr.null then
                table.remove(unmanagedDialogs, i)
            end
        end

        unmanagedDialogs[#unmanagedDialogs + 1] = loadingInfo
    end

    local dialog, dummydialog, blockdialog, diagcomp, dummycomp, scd, uds

    if renderMode and renderMode ~= 'overlay' then
        --[[
        if not res.JudgeShowDialog(withCtrl) then
            dump("Camera dialogs of different type can't be opened together!")
            return
        end
        --]]
        scd, uds = res.GetLastSCDAndUDs(false)
        dialog = res.Instantiate('Assets/CapstonesRes/Game/UI/Control/Dialog/CameraDialog.prefab')

        cache.setGlobalTempData(true, "isDummyDialog")
        dummydialog = res.Instantiate('Assets/CapstonesRes/Game/UI/Control/Dialog/OverlayDialog.prefab')
        cache.removeGlobalTempData("isDummyDialog")
        local dummycanvas = dummydialog:GetComponent(Canvas)
        dummycanvas:GetComponent(CapsUnityLuaBehav):setShadow(withShadow)
        diagcomp = dialog:GetComponent(CapsUnityLuaBehav)
        dummycomp = dummydialog:GetComponent(CapsUnityLuaBehav)
        diagcomp.withCtrl = withCtrl
        if withShadow then
            diagcomp:setShadow(true)
            if res.NeedDialogCameraBlur() then
                res.SetMainCameraBlur()
            else
                dummycanvas:GetComponent(CapsUnityLuaBehav):enableShadow()
                diagcomp:enableShadow()

                if scd then
                    scdcomp = scd:GetComponent(CapsUnityLuaBehav)
                    if scdcomp.withShadow then
                        scdcomp:disableShadow()
                    end
                end
            end
        else
            diagcomp:setShadow(false)
        end
    else
        if overlaySortingOrder then
            cache.setGlobalTempData(overlaySortingOrder, "overlaySortingOrder")
        end
        dialog = res.Instantiate('Assets/CapstonesRes/Game/UI/Control/Dialog/OverlayDialog.prefab')
        cache.removeGlobalTempData("overlaySortingOrder")
        diagcomp = dialog:GetComponent(CapsUnityLuaBehav)
        diagcomp.withCtrl = withCtrl
        if withShadow then
            diagcomp:setShadow(true)
            diagcomp:enableShadow()
        else
            diagcomp:setShadow(false)
        end
    end

    local objcontent
    if type(content) == 'string' then
        objcontent = res.InstanceCache[content]

        if objcontent and objcontent ~= clr.null then
            objcontent = Object.Instantiate(objcontent)
        else
            objcontent = res.Instantiate(content)
        end

        objcontent.transform:SetParent(dummycomp and dummycomp.safeArea or diagcomp and diagcomp.safeArea, false)
        if objcontent then
            diagcomp.content = objcontent
            local compcontent = objcontent:GetComponent(CapsUnityLuaBehav)
            if compcontent then
                diagcomp.contentcomp = compcontent
                compcontent.dialog = diagcomp
                compcontent.closeDialog = diagcomp.closeDialog
            end
        end
    end

    if dummydialog then
        dummycomp:coroutine(function()
            unity.waitForNextEndOfFrame()
            if dialog ~= nil and dialog ~= clr.null then
                if objcontent then
                    objcontent.transform:SetParent(diagcomp.safeArea, false)
                    res.AdjustDialogCamera(scd, uds, dialog, withShadow)
                end
            else
                Object.Destroy(objcontent)
            end
            Object.Destroy(dummydialog)
        end)
    end

    if touchClose then
        -- 点击之后关闭当前dialog
        if type(diagcomp.contentcomp.Close) == "function" then
            diagcomp:regOnButtonClick(function ()
                diagcomp.contentcomp:Close()
            end)
        else
            diagcomp:regOnButtonClick(diagcomp.closeDialog)
        end
    end
    if unblockRaycast then
        diagcomp.___ex.canvasGroup.blocksRaycasts = false
    end

    if not loadingType then
        for i = #unmanagedDialogs, 1, -1 do
            local dialog = unmanagedDialogs[i].dialog
            if not dialog or dialog == clr.null then
                table.remove(unmanagedDialogs, i)
            end
        end

        loadingInfo.dialog = diagcomp
    end

    return dialog, diagcomp
end

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

function res.SetSceneLightmaps(paths)
    local lightmapTable = {}
    for i, path in ipairs(paths) do
        local lightmapData = LightmapData()
        lightmapData.lightmapLight = res.LoadRes(path)
        table.insert(lightmapTable, lightmapData)
    end
    local lightmaps = clr.array(lightmapTable, LightmapData)
    LightmapSettings.lightmaps = lightmaps
end

function res.ShowDebugInfo(data)
    local result = vardump(data)
    local str = table.concat(result, "\n")
    local dialog, dialogcomp = res.ShowDialog("Assets/CapstonesRes/Game/UI/Control/Dialog/DebugDialog.prefab", "overlay", false, true)
    dialogcomp.contentcomp:setText(str)
end

function res.DontDestroyOnLoad(obj)
    ResManager.DontDestroyOnLoad(obj)
    ResManager.CanDestroyAll(obj)
end
function res.DontDestroyOnLoadAndDestroyAll(obj)
    ResManager.DontDestroyOnLoad(obj)
end
function res.DestroyAll()
    ResManager.DestroyAll()
end
function res.DestroyAllHard()
    ResManager.DestroyAllHard()
end
function res.SaveCurObjects()
    ResManager.SaveCurObjects()
end
function res.DestroyAllExceptSaved()
    ResManager.DestroyAllExceptSaved()
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

function res.UnloadAllRes(keepReferencedAssets)
    dump("res.UnloadAllRes==========")
    ResManager.UnloadAllRes(not not keepReferencedAssets)
end

function res.UnloadUnusedRes()
    dump("res.UnloadUnusedRes==========")
    UnityEngine.Resources.UnloadUnusedAssets();
    ResManager.UnloadUnusedRes()
end

function res.UnloadUnusedResAsync()
    dump("res.UnloadUnusedResAsync==========")
    local op = UnityEngine.Resources.UnloadUnusedAssets();
    coroutine.yield(op)
    ResManager.UnloadUnusedRes()
end

function res.UnloadAllBundleSoft()
    --ResManager.UnloadAllBundleSoft()
end

function res.GetLuaMemory()
    local memory = collectgarbage("count")
    return string.format("%.2fM", (memory * 0.001))
end

function res.UnloadUnusedResDeep(funcDone)
    local m = res.GetLuaMemory()
    dump("res.UnloadUnusedResDeep========>>>" .. m)
    clr.coroutine(function()
        for i = 1, 3 do
            collectgarbage("collect");
            coroutine.yield()
        end
        clr.System.GC.Collect()
        res.UnloadUnusedResAsync()
        coroutine.yield(clr.UnityEngine.WaitForEndOfFrame())
        dump("res.UnloadUnusedResDeep========>>>" .. m .. " ===>> " .. res.GetLuaMemory())
        if type(funcDone) == 'function' then
            funcDone()
        end
    end)
end

function res.CollectGarbageDeep(funcDone)
    dump("<<<<<<<<<<<<<======res.CollectGarbageDeep========>>>>>>>>>>>>>>>>>")
    res.CollectGarbage(function()
        if funcDone ~= nil and type(funcDone) == "function" then funcDone() end
    end, true)
end

local _currRunGCTime = -1
function res.CollectGarbage(callfun,isImmediately)
    local m = res.GetLuaMemory()
    dump("res.CollectGarbage========>>>" .. m)
    collectgarbage()
    collectgarbage()
    collectgarbage()
    clr.coroutine(function()
        if isImmediately ~= true and _currRunGCTime > 0 and (Time.realtimeSinceStartup - _currRunGCTime) < delayRunGCTime then

        else
            _currRunGCTime = Time.realtimeSinceStartup
            unity.waitForEndOfFrame()
            clr.System.GC.Collect()
            unity.waitForEndOfFrame()
            coroutine.yield(UnityEngine.Resources.UnloadUnusedAssets())
        end
        dump("res.CollectGarbage========>>>" .. m  .. " ===>> " .. res.GetLuaMemory())
        if callfun ~= nil and type(callfun) == "function" then callfun() end
    end)
end

local ResCache = {}

function res.CacheRes(name)
	local handle = ResCache[name]
	if handle then
		handle.AddRef()  --Lua assist checked flag
	else
		local ai = ResManager.PreloadRes(name)
		if ai then
			local handle = {}
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
				ai:Release()
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

function res.GetMobcastUserAgentAppendStr()
    local appName = luaevt.trig('SDK_GetAppName')
    if appName then
        return format("[CMM_IAB/%s;]", appName)
    end
end

function res.ShowIPhoneX()
    if clr.UnityEngine.Application.isEditor then
        local isShowiPhoneXMask = clr.UnityEngine.PlayerPrefs.GetInt("AdapteriPhoneXOpen") == 1
        local iPhoneXAdapterGO = clr.UnityEngine.GameObject.Find("iPhoneXAdapter")
        if isShowiPhoneXMask and (iPhoneXAdapterGO == null or iPhoneXAdapterGO == clr.null) then
            iPhoneXAdapterGO = res.Instantiate("Assets/Scenes/Develop/AdapteriPhoneX/iPhoneXAdapter.prefab")
            res.DontDestroyOnLoadAndDestroyAll(iPhoneXAdapterGO)
        end
    end
end

function res.SetCurrentEventSystemEnabled(enabled)
    local eventSystem = res.GetCurrentEventSystem()
    res.SetEventSystemEnabled(eventSystem, enabled)
end

function res.GetCurrentEventSystem()
    -- local eventSystemComp = EventSystem.current
    -- if res.IsClrNull(eventSystemComp) then
        local esObj = GameObject.Find("/EventSystem")
        if res.IsClrNull(esObj) then
            esObj = GameObject("EventSystem")
            esObj:AddComponent("EventSystem")
            esObj:AddComponent("StandaloneInputModule")
        end
        eventSystemComp = esObj:GetComponent("EventSystem")
    -- end
    return eventSystemComp
end

function res.SetEventSystemEnabled(eventSystemComp, enabled)
    if eventSystemComp then
        eventSystemComp.enabled = enabled
    end
end

return res
