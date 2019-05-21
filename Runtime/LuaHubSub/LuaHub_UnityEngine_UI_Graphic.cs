#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_UI_Graphic : LuaHub.TypeHubPrecompiled_UnityEngine_EventSystems_UIBehaviour
        {
            public TypeHubPrecompiled_UnityEngine_UI_Graphic() : this(typeof(UnityEngine.UI.Graphic)) { }
            public TypeHubPrecompiled_UnityEngine_UI_Graphic(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["SetNativeSize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetNativeSize"]._Method, _Precompiled = ___fm_SetNativeSize };
                _InstanceMethods["SetAllDirty"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetAllDirty"]._Method, _Precompiled = ___fm_SetAllDirty };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["color"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["color"]._Method, _Precompiled = ___gf_color };
                _InstanceFieldsNewIndex["color"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["color"]._Method, _Precompiled = ___sf_color };
                _InstanceFieldsIndex["material"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["material"]._Method, _Precompiled = ___gf_material };
                _InstanceFieldsNewIndex["material"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["material"]._Method, _Precompiled = ___sf_material };
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
            private static readonly lua.CFunction ___fm_SetNativeSize = new lua.CFunction(___mm_SetNativeSize);
            private static readonly lua.CFunction ___fm_SetAllDirty = new lua.CFunction(___mm_SetAllDirty);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_color = new lua.CFunction(___gm_color);
            private static readonly lua.CFunction ___sf_color = new lua.CFunction(___sm_color);
            private static readonly lua.CFunction ___gf_material = new lua.CFunction(___gm_material);
            private static readonly lua.CFunction ___sf_material = new lua.CFunction(___sm_material);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_SetNativeSize(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Graphic p0;
                    l.GetLua(1, out p0);
                    p0.SetNativeSize();
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_SetAllDirty(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Graphic p0;
                    l.GetLua(1, out p0);
                    p0.SetAllDirty();
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_color(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Graphic tar;
                    l.GetLua(1, out tar);
                    var rv = tar.color;
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
            private static int ___sm_color(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Graphic tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Color val;
                    l.GetLua(2, out val);
                    tar.color = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_material(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Graphic tar;
                    l.GetLua(1, out tar);
                    var rv = tar.material;
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
            private static int ___sm_material(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Graphic tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Material val;
                    l.GetLua(2, out val);
                    tar.material = val;
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
        private static TypeHubPrecompiled_UnityEngine_UI_Graphic ___tp_UnityEngine_UI_Graphic = new TypeHubPrecompiled_UnityEngine_UI_Graphic();
        public static void PushLua(this IntPtr l, UnityEngine.UI.Graphic val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.UI.Graphic val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.UI.Graphic;
        }
    }
}
#endif
