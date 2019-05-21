#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Canvas : TypeHubPrecompiled_UnityEngine_Behaviour
        {
            public TypeHubPrecompiled_UnityEngine_Canvas() : this(typeof(UnityEngine.Canvas)) { }
            public TypeHubPrecompiled_UnityEngine_Canvas(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["renderMode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["renderMode"]._Method, _Precompiled = ___gf_renderMode };
                _InstanceFieldsNewIndex["renderMode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["renderMode"]._Method, _Precompiled = ___sf_renderMode };
                _InstanceFieldsIndex["isRootCanvas"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["isRootCanvas"]._Method, _Precompiled = ___gf_isRootCanvas };
                _InstanceFieldsIndex["worldCamera"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["worldCamera"]._Method, _Precompiled = ___gf_worldCamera };
                _InstanceFieldsNewIndex["worldCamera"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["worldCamera"]._Method, _Precompiled = ___sf_worldCamera };
                _InstanceFieldsIndex["pixelRect"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["pixelRect"]._Method, _Precompiled = ___gf_pixelRect };
                _InstanceFieldsIndex["scaleFactor"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["scaleFactor"]._Method, _Precompiled = ___gf_scaleFactor };
                _InstanceFieldsNewIndex["scaleFactor"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["scaleFactor"]._Method, _Precompiled = ___sf_scaleFactor };
                _InstanceFieldsIndex["referencePixelsPerUnit"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["referencePixelsPerUnit"]._Method, _Precompiled = ___gf_referencePixelsPerUnit };
                _InstanceFieldsNewIndex["referencePixelsPerUnit"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["referencePixelsPerUnit"]._Method, _Precompiled = ___sf_referencePixelsPerUnit };
                _InstanceFieldsIndex["overridePixelPerfect"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["overridePixelPerfect"]._Method, _Precompiled = ___gf_overridePixelPerfect };
                _InstanceFieldsNewIndex["overridePixelPerfect"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["overridePixelPerfect"]._Method, _Precompiled = ___sf_overridePixelPerfect };
                _InstanceFieldsIndex["pixelPerfect"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["pixelPerfect"]._Method, _Precompiled = ___gf_pixelPerfect };
                _InstanceFieldsNewIndex["pixelPerfect"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["pixelPerfect"]._Method, _Precompiled = ___sf_pixelPerfect };
                _InstanceFieldsIndex["planeDistance"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["planeDistance"]._Method, _Precompiled = ___gf_planeDistance };
                _InstanceFieldsNewIndex["planeDistance"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["planeDistance"]._Method, _Precompiled = ___sf_planeDistance };
                _InstanceFieldsIndex["renderOrder"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["renderOrder"]._Method, _Precompiled = ___gf_renderOrder };
                _InstanceFieldsIndex["overrideSorting"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["overrideSorting"]._Method, _Precompiled = ___gf_overrideSorting };
                _InstanceFieldsNewIndex["overrideSorting"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["overrideSorting"]._Method, _Precompiled = ___sf_overrideSorting };
                _InstanceFieldsIndex["sortingOrder"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sortingOrder"]._Method, _Precompiled = ___gf_sortingOrder };
                _InstanceFieldsNewIndex["sortingOrder"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sortingOrder"]._Method, _Precompiled = ___sf_sortingOrder };
                _InstanceFieldsIndex["targetDisplay"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["targetDisplay"]._Method, _Precompiled = ___gf_targetDisplay };
                _InstanceFieldsNewIndex["targetDisplay"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["targetDisplay"]._Method, _Precompiled = ___sf_targetDisplay };
                _InstanceFieldsIndex["sortingGridNormalizedSize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sortingGridNormalizedSize"]._Method, _Precompiled = ___gf_sortingGridNormalizedSize };
                _InstanceFieldsNewIndex["sortingGridNormalizedSize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sortingGridNormalizedSize"]._Method, _Precompiled = ___sf_sortingGridNormalizedSize };
                _InstanceFieldsIndex["normalizedSortingGridSize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["normalizedSortingGridSize"]._Method, _Precompiled = ___gf_normalizedSortingGridSize };
                _InstanceFieldsNewIndex["normalizedSortingGridSize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["normalizedSortingGridSize"]._Method, _Precompiled = ___sf_normalizedSortingGridSize };
                _InstanceFieldsIndex["sortingLayerID"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sortingLayerID"]._Method, _Precompiled = ___gf_sortingLayerID };
                _InstanceFieldsNewIndex["sortingLayerID"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sortingLayerID"]._Method, _Precompiled = ___sf_sortingLayerID };
                _InstanceFieldsIndex["cachedSortingLayerValue"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["cachedSortingLayerValue"]._Method, _Precompiled = ___gf_cachedSortingLayerValue };
                _InstanceFieldsIndex["additionalShaderChannels"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["additionalShaderChannels"]._Method, _Precompiled = ___gf_additionalShaderChannels };
                _InstanceFieldsNewIndex["additionalShaderChannels"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["additionalShaderChannels"]._Method, _Precompiled = ___sf_additionalShaderChannels };
                _InstanceFieldsIndex["sortingLayerName"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sortingLayerName"]._Method, _Precompiled = ___gf_sortingLayerName };
                _InstanceFieldsNewIndex["sortingLayerName"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sortingLayerName"]._Method, _Precompiled = ___sf_sortingLayerName };
                _InstanceFieldsIndex["rootCanvas"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["rootCanvas"]._Method, _Precompiled = ___gf_rootCanvas };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
                _InstanceMethods_DirectFromBase.Add("GetComponent");
                _InstanceMethods_DirectFromBase.Add("GetComponentInChildren");
                _InstanceMethods_DirectFromBase.Add("GetComponentsInChildren");
                _InstanceMethods_DirectFromBase.Add("GetComponentInParent");
                _InstanceMethods_DirectFromBase.Add("GetComponentsInParent");
                _InstanceMethods_DirectFromBase.Add("GetComponents");
                _InstanceMethods_DirectFromBase.Add("CompareTag");
                _InstanceMethods_DirectFromBase.Add("SendMessageUpwards");
                _InstanceMethods_DirectFromBase.Add("SendMessage");
                _InstanceMethods_DirectFromBase.Add("BroadcastMessage");
                _InstanceMethods_DirectFromBase.Add("GetInstanceID");
                #endif
            }
            public override void RegPrecompiledStatic()
            {
                #region REG_I_CTOR
                _Ctor._Precompiled = ___fm_ctor;
                #endregion // REG_I_CTOR
                #region REG_S_FUNC
                _StaticMethods["GetDefaultCanvasMaterial"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetDefaultCanvasMaterial"]._Method, _Precompiled = ___sfm_GetDefaultCanvasMaterial };
                _StaticMethods["GetETC1SupportedCanvasMaterial"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetETC1SupportedCanvasMaterial"]._Method, _Precompiled = ___sfm_GetETC1SupportedCanvasMaterial };
                _StaticMethods["GetDefaultCanvasTextMaterial"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetDefaultCanvasTextMaterial"]._Method, _Precompiled = ___sfm_GetDefaultCanvasTextMaterial };
                _StaticMethods["ForceUpdateCanvases"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["ForceUpdateCanvases"]._Method, _Precompiled = ___sfm_ForceUpdateCanvases };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                #endregion // REG_S_PROP
                #region REG_G_S_FUNC
                #endregion // REG_G_S_FUNC
                #region REG_S_OP
                #endregion // REG_S_OP
                #region REG_S_CONV
                #endregion // REG_S_CONV
                #region REG_G_GTYPES
                #endregion // REG_G_GTYPES
            }
            
            #region DEL_I_CTOR
            private static readonly lua.CFunction ___fm_ctor = new lua.CFunction(___mm_ctor);
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_renderMode = new lua.CFunction(___gm_renderMode);
            private static readonly lua.CFunction ___sf_renderMode = new lua.CFunction(___sm_renderMode);
            private static readonly lua.CFunction ___gf_isRootCanvas = new lua.CFunction(___gm_isRootCanvas);
            private static readonly lua.CFunction ___gf_worldCamera = new lua.CFunction(___gm_worldCamera);
            private static readonly lua.CFunction ___sf_worldCamera = new lua.CFunction(___sm_worldCamera);
            private static readonly lua.CFunction ___gf_pixelRect = new lua.CFunction(___gm_pixelRect);
            private static readonly lua.CFunction ___gf_scaleFactor = new lua.CFunction(___gm_scaleFactor);
            private static readonly lua.CFunction ___sf_scaleFactor = new lua.CFunction(___sm_scaleFactor);
            private static readonly lua.CFunction ___gf_referencePixelsPerUnit = new lua.CFunction(___gm_referencePixelsPerUnit);
            private static readonly lua.CFunction ___sf_referencePixelsPerUnit = new lua.CFunction(___sm_referencePixelsPerUnit);
            private static readonly lua.CFunction ___gf_overridePixelPerfect = new lua.CFunction(___gm_overridePixelPerfect);
            private static readonly lua.CFunction ___sf_overridePixelPerfect = new lua.CFunction(___sm_overridePixelPerfect);
            private static readonly lua.CFunction ___gf_pixelPerfect = new lua.CFunction(___gm_pixelPerfect);
            private static readonly lua.CFunction ___sf_pixelPerfect = new lua.CFunction(___sm_pixelPerfect);
            private static readonly lua.CFunction ___gf_planeDistance = new lua.CFunction(___gm_planeDistance);
            private static readonly lua.CFunction ___sf_planeDistance = new lua.CFunction(___sm_planeDistance);
            private static readonly lua.CFunction ___gf_renderOrder = new lua.CFunction(___gm_renderOrder);
            private static readonly lua.CFunction ___gf_overrideSorting = new lua.CFunction(___gm_overrideSorting);
            private static readonly lua.CFunction ___sf_overrideSorting = new lua.CFunction(___sm_overrideSorting);
            private static readonly lua.CFunction ___gf_sortingOrder = new lua.CFunction(___gm_sortingOrder);
            private static readonly lua.CFunction ___sf_sortingOrder = new lua.CFunction(___sm_sortingOrder);
            private static readonly lua.CFunction ___gf_targetDisplay = new lua.CFunction(___gm_targetDisplay);
            private static readonly lua.CFunction ___sf_targetDisplay = new lua.CFunction(___sm_targetDisplay);
            private static readonly lua.CFunction ___gf_sortingGridNormalizedSize = new lua.CFunction(___gm_sortingGridNormalizedSize);
            private static readonly lua.CFunction ___sf_sortingGridNormalizedSize = new lua.CFunction(___sm_sortingGridNormalizedSize);
            private static readonly lua.CFunction ___gf_normalizedSortingGridSize = new lua.CFunction(___gm_normalizedSortingGridSize);
            private static readonly lua.CFunction ___sf_normalizedSortingGridSize = new lua.CFunction(___sm_normalizedSortingGridSize);
            private static readonly lua.CFunction ___gf_sortingLayerID = new lua.CFunction(___gm_sortingLayerID);
            private static readonly lua.CFunction ___sf_sortingLayerID = new lua.CFunction(___sm_sortingLayerID);
            private static readonly lua.CFunction ___gf_cachedSortingLayerValue = new lua.CFunction(___gm_cachedSortingLayerValue);
            private static readonly lua.CFunction ___gf_additionalShaderChannels = new lua.CFunction(___gm_additionalShaderChannels);
            private static readonly lua.CFunction ___sf_additionalShaderChannels = new lua.CFunction(___sm_additionalShaderChannels);
            private static readonly lua.CFunction ___gf_sortingLayerName = new lua.CFunction(___gm_sortingLayerName);
            private static readonly lua.CFunction ___sf_sortingLayerName = new lua.CFunction(___sm_sortingLayerName);
            private static readonly lua.CFunction ___gf_rootCanvas = new lua.CFunction(___gm_rootCanvas);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_GetDefaultCanvasMaterial = new lua.CFunction(___smm_GetDefaultCanvasMaterial);
            private static readonly lua.CFunction ___sfm_GetETC1SupportedCanvasMaterial = new lua.CFunction(___smm_GetETC1SupportedCanvasMaterial);
            private static readonly lua.CFunction ___sfm_GetDefaultCanvasTextMaterial = new lua.CFunction(___smm_GetDefaultCanvasTextMaterial);
            private static readonly lua.CFunction ___sfm_ForceUpdateCanvases = new lua.CFunction(___smm_ForceUpdateCanvases);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            #endregion // DEL_S_PROP
            #region DEL_G_I_FUNC
            #endregion // DEL_G_I_FUNC
            #region DEL_I_INDEX
            #endregion // DEL_I_INDEX
            #region DEL_G_S_FUNC
            #endregion // DEL_G_S_FUNC
            #region DEL_S_OP
            #endregion // DEL_S_OP
            #region DEL_S_CONV
            #endregion // DEL_S_CONV
            #region DEL_G_GTYPES
            #endregion // DEL_G_GTYPES
            
            #region FUNC_I_CTOR
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_ctor(IntPtr l)
            {
                try
                {
                    var rv = new UnityEngine.Canvas();
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            #endregion // FUNC_I_CTOR
            #region FUNC_I_FUNC
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_renderMode(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.renderMode;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_renderMode(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    UnityEngine.RenderMode val;
                    l.GetLua(2, out val);
                    tar.renderMode = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_isRootCanvas(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.isRootCanvas;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_worldCamera(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.worldCamera;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_worldCamera(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Camera val;
                    l.GetLua(2, out val);
                    tar.worldCamera = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_pixelRect(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.pixelRect;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_scaleFactor(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.scaleFactor;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_scaleFactor(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.scaleFactor = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_referencePixelsPerUnit(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.referencePixelsPerUnit;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_referencePixelsPerUnit(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.referencePixelsPerUnit = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_overridePixelPerfect(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.overridePixelPerfect;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_overridePixelPerfect(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.overridePixelPerfect = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_pixelPerfect(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.pixelPerfect;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_pixelPerfect(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.pixelPerfect = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_planeDistance(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.planeDistance;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_planeDistance(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.planeDistance = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_renderOrder(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.renderOrder;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_overrideSorting(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.overrideSorting;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_overrideSorting(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.overrideSorting = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sortingOrder(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sortingOrder;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_sortingOrder(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.sortingOrder = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_targetDisplay(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.targetDisplay;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_targetDisplay(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.targetDisplay = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sortingGridNormalizedSize(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sortingGridNormalizedSize;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_sortingGridNormalizedSize(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.sortingGridNormalizedSize = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_normalizedSortingGridSize(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.normalizedSortingGridSize;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_normalizedSortingGridSize(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.normalizedSortingGridSize = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sortingLayerID(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sortingLayerID;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_sortingLayerID(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.sortingLayerID = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_cachedSortingLayerValue(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.cachedSortingLayerValue;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_additionalShaderChannels(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.additionalShaderChannels;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_additionalShaderChannels(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    UnityEngine.AdditionalCanvasShaderChannels val;
                    l.GetLua(2, out val);
                    tar.additionalShaderChannels = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sortingLayerName(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sortingLayerName;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_sortingLayerName(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    System.String val;
                    l.GetLua(2, out val);
                    tar.sortingLayerName = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_rootCanvas(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas tar;
                    l.GetLua(1, out tar);
                    var rv = tar.rootCanvas;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            #endregion // FUNC_I_PROP
            #region FUNC_S_FUNC
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_GetDefaultCanvasMaterial(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Canvas.GetDefaultCanvasMaterial();
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_GetETC1SupportedCanvasMaterial(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Canvas.GetETC1SupportedCanvasMaterial();
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_GetDefaultCanvasTextMaterial(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Canvas.GetDefaultCanvasTextMaterial();
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_ForceUpdateCanvases(IntPtr l)
            {
                try
                {
                    UnityEngine.Canvas.ForceUpdateCanvases();
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            #endregion // FUNC_S_FUNC
            #region FUNC_S_PROP
            #endregion // FUNC_S_PROP
            #region FUNC_G_I_FUNC
            #endregion // FUNC_G_I_FUNC
            #region FUNC_I_INDEX
            #endregion // FUNC_I_INDEX
            #region FUNC_G_S_FUNC
            #endregion // FUNC_G_S_FUNC
            #region FUNC_S_OP
            #endregion // FUNC_S_OP
            #region FUNC_S_CONV
            #endregion // FUNC_S_CONV
            #region FUNC_G_GTYPES
            #endregion // FUNC_G_GTYPES
            
            #region NESTED_TYPE_HUB
            #endregion // NESTED_TYPE_HUB
        }
        private static TypeHubPrecompiled_UnityEngine_Canvas ___tp_UnityEngine_Canvas = new TypeHubPrecompiled_UnityEngine_Canvas();
        public static void PushLua(this IntPtr l, UnityEngine.Canvas val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_Canvas.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Canvas val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Canvas;
        }
    }
}
#endif
