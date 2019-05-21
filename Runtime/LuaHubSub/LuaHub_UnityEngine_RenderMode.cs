#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_RenderMode : Capstones.LuaLib.LuaTypeHub.TypeHubEnumPrecompiled<UnityEngine.RenderMode>
        {
            public TypeHubPrecompiled_UnityEngine_RenderMode()
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
                _StaticFieldsIndex["ScreenSpaceOverlay"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["ScreenSpaceOverlay"]._Method, _Precompiled = ___sgf_ScreenSpaceOverlay };
                _StaticFieldsIndex["ScreenSpaceCamera"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["ScreenSpaceCamera"]._Method, _Precompiled = ___sgf_ScreenSpaceCamera };
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
            private static readonly lua.CFunction ___sgf_ScreenSpaceOverlay = new lua.CFunction(___sgm_ScreenSpaceOverlay);
            private static readonly lua.CFunction ___sgf_ScreenSpaceCamera = new lua.CFunction(___sgm_ScreenSpaceCamera);
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
            private static int ___sgm_ScreenSpaceOverlay(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.RenderMode.ScreenSpaceOverlay;
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
            private static int ___sgm_ScreenSpaceCamera(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.RenderMode.ScreenSpaceCamera;
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
            
            public override UnityEngine.RenderMode ConvertFromNum(double val)
            {
                return (UnityEngine.RenderMode)val;
            }
            public override double ConvertToNum(UnityEngine.RenderMode val)
            {
                return (double)val;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_RenderMode ___tp_UnityEngine_RenderMode = new TypeHubPrecompiled_UnityEngine_RenderMode();
        public static void PushLua(this IntPtr l, UnityEngine.RenderMode val)
        {
            ___tp_UnityEngine_RenderMode.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.RenderMode val)
        {
            val = ___tp_UnityEngine_RenderMode.GetLuaChecked(l, index);
        }
    }
}
#endif
