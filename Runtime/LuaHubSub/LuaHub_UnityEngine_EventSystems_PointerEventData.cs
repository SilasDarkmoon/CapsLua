#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_EventSystems_PointerEventData : LuaHub.TypeHubPrecompiled_UnityEngine_EventSystems_BaseEventData
        {
            public TypeHubPrecompiled_UnityEngine_EventSystems_PointerEventData() : this(typeof(UnityEngine.EventSystems.PointerEventData)) { }
            public TypeHubPrecompiled_UnityEngine_EventSystems_PointerEventData(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["pointerCurrentRaycast"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["pointerCurrentRaycast"]._Method, _Precompiled = ___gf_pointerCurrentRaycast };
                _InstanceFieldsNewIndex["pointerCurrentRaycast"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["pointerCurrentRaycast"]._Method, _Precompiled = ___sf_pointerCurrentRaycast };
                _InstanceFieldsIndex["pointerPress"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["pointerPress"]._Method, _Precompiled = ___gf_pointerPress };
                _InstanceFieldsNewIndex["pointerPress"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["pointerPress"]._Method, _Precompiled = ___sf_pointerPress };
                _InstanceFieldsIndex["eligibleForClick"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["eligibleForClick"]._Method, _Precompiled = ___gf_eligibleForClick };
                _InstanceFieldsNewIndex["eligibleForClick"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["eligibleForClick"]._Method, _Precompiled = ___sf_eligibleForClick };
                _InstanceFieldsIndex["dragging"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["dragging"]._Method, _Precompiled = ___gf_dragging };
                _InstanceFieldsNewIndex["dragging"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["dragging"]._Method, _Precompiled = ___sf_dragging };
                _InstanceFieldsIndex["delta"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["delta"]._Method, _Precompiled = ___gf_delta };
                _InstanceFieldsNewIndex["delta"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["delta"]._Method, _Precompiled = ___sf_delta };
                _InstanceFieldsIndex["pointerEnter"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["pointerEnter"]._Method, _Precompiled = ___gf_pointerEnter };
                _InstanceFieldsNewIndex["pointerEnter"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["pointerEnter"]._Method, _Precompiled = ___sf_pointerEnter };
                _InstanceFieldsIndex["position"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["position"]._Method, _Precompiled = ___gf_position };
                _InstanceFieldsNewIndex["position"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["position"]._Method, _Precompiled = ___sf_position };
                _InstanceFieldsIndex["pressEventCamera"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["pressEventCamera"]._Method, _Precompiled = ___gf_pressEventCamera };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
            }
            public override void RegPrecompiledStatic()
            {
                #region REG_I_CTOR
                #endregion // REG_I_CTOR
                #region REG_S_FUNC
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
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_pointerCurrentRaycast = new lua.CFunction(___gm_pointerCurrentRaycast);
            private static readonly lua.CFunction ___sf_pointerCurrentRaycast = new lua.CFunction(___sm_pointerCurrentRaycast);
            private static readonly lua.CFunction ___gf_pointerPress = new lua.CFunction(___gm_pointerPress);
            private static readonly lua.CFunction ___sf_pointerPress = new lua.CFunction(___sm_pointerPress);
            private static readonly lua.CFunction ___gf_eligibleForClick = new lua.CFunction(___gm_eligibleForClick);
            private static readonly lua.CFunction ___sf_eligibleForClick = new lua.CFunction(___sm_eligibleForClick);
            private static readonly lua.CFunction ___gf_dragging = new lua.CFunction(___gm_dragging);
            private static readonly lua.CFunction ___sf_dragging = new lua.CFunction(___sm_dragging);
            private static readonly lua.CFunction ___gf_delta = new lua.CFunction(___gm_delta);
            private static readonly lua.CFunction ___sf_delta = new lua.CFunction(___sm_delta);
            private static readonly lua.CFunction ___gf_pointerEnter = new lua.CFunction(___gm_pointerEnter);
            private static readonly lua.CFunction ___sf_pointerEnter = new lua.CFunction(___sm_pointerEnter);
            private static readonly lua.CFunction ___gf_position = new lua.CFunction(___gm_position);
            private static readonly lua.CFunction ___sf_position = new lua.CFunction(___sm_position);
            private static readonly lua.CFunction ___gf_pressEventCamera = new lua.CFunction(___gm_pressEventCamera);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
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
            #endregion // FUNC_I_CTOR
            #region FUNC_I_FUNC
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_pointerCurrentRaycast(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    var rv = tar.pointerCurrentRaycast;
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
            private static int ___sm_pointerCurrentRaycast(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    UnityEngine.EventSystems.RaycastResult val;
                    l.GetLua(2, out val);
                    tar.pointerCurrentRaycast = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_pointerPress(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    var rv = tar.pointerPress;
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
            private static int ___sm_pointerPress(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    UnityEngine.GameObject val;
                    l.GetLua(2, out val);
                    tar.pointerPress = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_eligibleForClick(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    var rv = tar.eligibleForClick;
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
            private static int ___sm_eligibleForClick(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.eligibleForClick = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_dragging(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    var rv = tar.dragging;
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
            private static int ___sm_dragging(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.dragging = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_delta(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    var rv = tar.delta;
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
            private static int ___sm_delta(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.delta = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_pointerEnter(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    var rv = tar.pointerEnter;
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
            private static int ___sm_pointerEnter(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    UnityEngine.GameObject val;
                    l.GetLua(2, out val);
                    tar.pointerEnter = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_position(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    var rv = tar.position;
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
            private static int ___sm_position(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.position = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_pressEventCamera(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.PointerEventData tar;
                    l.GetLua(1, out tar);
                    var rv = tar.pressEventCamera;
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
        private static TypeHubPrecompiled_UnityEngine_EventSystems_PointerEventData ___tp_UnityEngine_EventSystems_PointerEventData = new TypeHubPrecompiled_UnityEngine_EventSystems_PointerEventData();
        public static void PushLua(this IntPtr l, UnityEngine.EventSystems.PointerEventData val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.EventSystems.PointerEventData val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.EventSystems.PointerEventData;
        }
    }
}
#endif
