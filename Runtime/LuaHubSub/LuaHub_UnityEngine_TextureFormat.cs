#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_TextureFormat : Capstones.LuaLib.LuaTypeHub.TypeHubEnumPrecompiled<UnityEngine.TextureFormat>
        {
            public TypeHubPrecompiled_UnityEngine_TextureFormat()
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
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
                _StaticFieldsIndex["ARGB32"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["ARGB32"]._Method, _Precompiled = ___sgf_ARGB32 };
                _StaticFieldsIndex["RGB24"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["RGB24"]._Method, _Precompiled = ___sgf_RGB24 };
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
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_ARGB32 = new lua.CFunction(___sgm_ARGB32);
            private static readonly lua.CFunction ___sgf_RGB24 = new lua.CFunction(___sgm_RGB24);
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
            #endregion // FUNC_I_PROP
            #region FUNC_S_FUNC
            #endregion // FUNC_S_FUNC
            #region FUNC_S_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_ARGB32(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.TextureFormat.ARGB32;
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
            private static int ___sgm_RGB24(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.TextureFormat.RGB24;
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
            
            public override UnityEngine.TextureFormat ConvertFromNum(double val)
            {
                return (UnityEngine.TextureFormat)val;
            }
            public override double ConvertToNum(UnityEngine.TextureFormat val)
            {
                return (double)val;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_TextureFormat ___tp_UnityEngine_TextureFormat = new TypeHubPrecompiled_UnityEngine_TextureFormat();
        public static void PushLua(this IntPtr l, UnityEngine.TextureFormat val)
        {
            ___tp_UnityEngine_TextureFormat.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.TextureFormat val)
        {
            val = ___tp_UnityEngine_TextureFormat.GetLuaChecked(l, index);
        }
    }
}
#endif
