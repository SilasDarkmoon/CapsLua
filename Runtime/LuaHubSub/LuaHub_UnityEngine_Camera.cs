#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Camera : LuaHub.TypeHubPrecompiled_UnityEngine_Behaviour
        {
            public TypeHubPrecompiled_UnityEngine_Camera() : this(typeof(UnityEngine.Camera)) { }
            public TypeHubPrecompiled_UnityEngine_Camera(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["Render"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Render"]._Method, _Precompiled = ___fm_Render };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
                _InstanceFieldsIndex["depthTextureMode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["depthTextureMode"]._Method, _Precompiled = ___gf_depthTextureMode };
                _InstanceFieldsNewIndex["depthTextureMode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["depthTextureMode"]._Method, _Precompiled = ___sf_depthTextureMode };
                _InstanceFieldsIndex["targetTexture"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["targetTexture"]._Method, _Precompiled = ___gf_targetTexture };
                _InstanceFieldsNewIndex["targetTexture"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["targetTexture"]._Method, _Precompiled = ___sf_targetTexture };
                _InstanceFieldsIndex["enabled"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["enabled"]._Method, _Precompiled = ___gf_enabled };
                _InstanceFieldsNewIndex["enabled"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["enabled"]._Method, _Precompiled = ___sf_enabled };
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
                _StaticFieldsIndex["main"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["main"]._Method, _Precompiled = ___sgf_main };
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
            private static readonly lua.CFunction ___fm_Render = new lua.CFunction(___mm_Render);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
            private static readonly lua.CFunction ___gf_depthTextureMode = new lua.CFunction(___gm_depthTextureMode);
            private static readonly lua.CFunction ___sf_depthTextureMode = new lua.CFunction(___sm_depthTextureMode);
            private static readonly lua.CFunction ___gf_targetTexture = new lua.CFunction(___gm_targetTexture);
            private static readonly lua.CFunction ___sf_targetTexture = new lua.CFunction(___sm_targetTexture);
            private static readonly lua.CFunction ___gf_enabled = new lua.CFunction(___gm_enabled);
            private static readonly lua.CFunction ___sf_enabled = new lua.CFunction(___sm_enabled);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_main = new lua.CFunction(___sgm_main);
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
            private static int ___mm_Render(IntPtr l)
            {
                try
                {
                    UnityEngine.Camera p0;
                    l.GetLua(1, out p0);
                    p0.Render();
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
            private static int ___gm_gameObject(IntPtr l)
            {
                try
                {
                    UnityEngine.Camera tar;
                    l.GetLua(1, out tar);
                    var rv = tar.gameObject;
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
            private static int ___gm_depthTextureMode(IntPtr l)
            {
                try
                {
                    UnityEngine.Camera tar;
                    l.GetLua(1, out tar);
                    var rv = tar.depthTextureMode;
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
            private static int ___sm_depthTextureMode(IntPtr l)
            {
                try
                {
                    UnityEngine.Camera tar;
                    l.GetLua(1, out tar);
                    UnityEngine.DepthTextureMode val;
                    l.GetLua(2, out val);
                    tar.depthTextureMode = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_targetTexture(IntPtr l)
            {
                try
                {
                    UnityEngine.Camera tar;
                    l.GetLua(1, out tar);
                    var rv = tar.targetTexture;
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
            private static int ___sm_targetTexture(IntPtr l)
            {
                try
                {
                    UnityEngine.Camera tar;
                    l.GetLua(1, out tar);
                    UnityEngine.RenderTexture val;
                    l.GetLua(2, out val);
                    tar.targetTexture = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_enabled(IntPtr l)
            {
                try
                {
                    UnityEngine.Camera tar;
                    l.GetLua(1, out tar);
                    var rv = tar.enabled;
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
            private static int ___sm_enabled(IntPtr l)
            {
                try
                {
                    UnityEngine.Camera tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.enabled = val;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_main(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Camera.main;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
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
        private static TypeHubPrecompiled_UnityEngine_Camera ___tp_UnityEngine_Camera = new TypeHubPrecompiled_UnityEngine_Camera();
        public static void PushLua(this IntPtr l, UnityEngine.Camera val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_Camera.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Camera val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Camera;
        }
    }
}
#endif
