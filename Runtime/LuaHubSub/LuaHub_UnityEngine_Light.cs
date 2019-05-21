#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Light : LuaHub.TypeHubPrecompiled_UnityEngine_Behaviour
        {
            public TypeHubPrecompiled_UnityEngine_Light() : this(typeof(UnityEngine.Light)) { }
            public TypeHubPrecompiled_UnityEngine_Light(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["intensity"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["intensity"]._Method, _Precompiled = ___gf_intensity };
                _InstanceFieldsNewIndex["intensity"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["intensity"]._Method, _Precompiled = ___sf_intensity };
                _InstanceFieldsIndex["color"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["color"]._Method, _Precompiled = ___gf_color };
                _InstanceFieldsNewIndex["color"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["color"]._Method, _Precompiled = ___sf_color };
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
            private static readonly lua.CFunction ___gf_intensity = new lua.CFunction(___gm_intensity);
            private static readonly lua.CFunction ___sf_intensity = new lua.CFunction(___sm_intensity);
            private static readonly lua.CFunction ___gf_color = new lua.CFunction(___gm_color);
            private static readonly lua.CFunction ___sf_color = new lua.CFunction(___sm_color);
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
            private static int ___gm_intensity(IntPtr l)
            {
                try
                {
                    UnityEngine.Light tar;
                    l.GetLua(1, out tar);
                    var rv = tar.intensity;
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
            private static int ___sm_intensity(IntPtr l)
            {
                try
                {
                    UnityEngine.Light tar;
                    l.GetLua(1, out tar);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.intensity = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_color(IntPtr l)
            {
                try
                {
                    UnityEngine.Light tar;
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
                    UnityEngine.Light tar;
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
        private static TypeHubPrecompiled_UnityEngine_Light ___tp_UnityEngine_Light = new TypeHubPrecompiled_UnityEngine_Light();
        public static void PushLua(this IntPtr l, UnityEngine.Light val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_Light.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Light val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Light;
        }
    }
}
#endif
