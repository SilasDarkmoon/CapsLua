#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_MeshRenderer : LuaHub.TypeHubPrecompiled_UnityEngine_Renderer
        {
            public TypeHubPrecompiled_UnityEngine_MeshRenderer() : this(typeof(UnityEngine.MeshRenderer)) { }
            public TypeHubPrecompiled_UnityEngine_MeshRenderer(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["sharedMaterial"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sharedMaterial"]._Method, _Precompiled = ___gf_sharedMaterial };
                _InstanceFieldsNewIndex["sharedMaterial"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sharedMaterial"]._Method, _Precompiled = ___sf_sharedMaterial };
                _InstanceFieldsIndex["material"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["material"]._Method, _Precompiled = ___gf_material };
                _InstanceFieldsNewIndex["material"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["material"]._Method, _Precompiled = ___sf_material };
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
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
            private static readonly lua.CFunction ___gf_sharedMaterial = new lua.CFunction(___gm_sharedMaterial);
            private static readonly lua.CFunction ___sf_sharedMaterial = new lua.CFunction(___sm_sharedMaterial);
            private static readonly lua.CFunction ___gf_material = new lua.CFunction(___gm_material);
            private static readonly lua.CFunction ___sf_material = new lua.CFunction(___sm_material);
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
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
            private static int ___gm_sharedMaterial(IntPtr l)
            {
                try
                {
                    UnityEngine.MeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sharedMaterial;
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
            private static int ___sm_sharedMaterial(IntPtr l)
            {
                try
                {
                    UnityEngine.MeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Material val;
                    l.GetLua(2, out val);
                    tar.sharedMaterial = val;
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
                    UnityEngine.MeshRenderer tar;
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
                    UnityEngine.MeshRenderer tar;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_gameObject(IntPtr l)
            {
                try
                {
                    UnityEngine.MeshRenderer tar;
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
        private static TypeHubPrecompiled_UnityEngine_MeshRenderer ___tp_UnityEngine_MeshRenderer = new TypeHubPrecompiled_UnityEngine_MeshRenderer();
        public static void PushLua(this IntPtr l, UnityEngine.MeshRenderer val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_MeshRenderer.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.MeshRenderer val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.MeshRenderer;
        }
    }
}
#endif
