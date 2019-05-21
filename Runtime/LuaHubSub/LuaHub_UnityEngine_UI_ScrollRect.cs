#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_UI_ScrollRect : LuaHub.TypeHubPrecompiled_UnityEngine_EventSystems_UIBehaviour
        {
            public TypeHubPrecompiled_UnityEngine_UI_ScrollRect() : this(typeof(UnityEngine.UI.ScrollRect)) { }
            public TypeHubPrecompiled_UnityEngine_UI_ScrollRect(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["horizontal"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["horizontal"]._Method, _Precompiled = ___gf_horizontal };
                _InstanceFieldsNewIndex["horizontal"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["horizontal"]._Method, _Precompiled = ___sf_horizontal };
                _InstanceFieldsIndex["horizontalNormalizedPosition"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["horizontalNormalizedPosition"]._Method, _Precompiled = ___gf_horizontalNormalizedPosition };
                _InstanceFieldsNewIndex["horizontalNormalizedPosition"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["horizontalNormalizedPosition"]._Method, _Precompiled = ___sf_horizontalNormalizedPosition };
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
            private static readonly lua.CFunction ___gf_horizontal = new lua.CFunction(___gm_horizontal);
            private static readonly lua.CFunction ___sf_horizontal = new lua.CFunction(___sm_horizontal);
            private static readonly lua.CFunction ___gf_horizontalNormalizedPosition = new lua.CFunction(___gm_horizontalNormalizedPosition);
            private static readonly lua.CFunction ___sf_horizontalNormalizedPosition = new lua.CFunction(___sm_horizontalNormalizedPosition);
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
            private static int ___gm_horizontal(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.ScrollRect tar;
                    l.GetLua(1, out tar);
                    var rv = tar.horizontal;
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
            private static int ___sm_horizontal(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.ScrollRect tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.horizontal = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_horizontalNormalizedPosition(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.ScrollRect tar;
                    l.GetLua(1, out tar);
                    var rv = tar.horizontalNormalizedPosition;
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
            private static int ___sm_horizontalNormalizedPosition(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.ScrollRect tar;
                    l.GetLua(1, out tar);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.horizontalNormalizedPosition = val;
                    return 0;
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
        private static TypeHubPrecompiled_UnityEngine_UI_ScrollRect ___tp_UnityEngine_UI_ScrollRect = new TypeHubPrecompiled_UnityEngine_UI_ScrollRect();
        public static void PushLua(this IntPtr l, UnityEngine.UI.ScrollRect val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.UI.ScrollRect val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.UI.ScrollRect;
        }
    }
}
#endif
