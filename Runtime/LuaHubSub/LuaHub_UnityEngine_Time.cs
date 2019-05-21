#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Time : Capstones.LuaLib.LuaTypeHub.TypeHubCommonPrecompiled
        {
            public TypeHubPrecompiled_UnityEngine_Time() : this(typeof(UnityEngine.Time)) { }
            public TypeHubPrecompiled_UnityEngine_Time(Type type) : base(type)
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
                _StaticFieldsIndex["frameCount"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["frameCount"]._Method, _Precompiled = ___sgf_frameCount };
                _StaticFieldsIndex["realtimeSinceStartup"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["realtimeSinceStartup"]._Method, _Precompiled = ___sgf_realtimeSinceStartup };
                _StaticFieldsIndex["timeScale"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["timeScale"]._Method, _Precompiled = ___sgf_timeScale };
                _StaticFieldsNewIndex["timeScale"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsNewIndex["timeScale"]._Method, _Precompiled = ___ssf_timeScale };
                _StaticFieldsIndex["unscaledTime"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["unscaledTime"]._Method, _Precompiled = ___sgf_unscaledTime };
                _StaticFieldsIndex["time"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["time"]._Method, _Precompiled = ___sgf_time };
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
            private static readonly lua.CFunction ___sgf_frameCount = new lua.CFunction(___sgm_frameCount);
            private static readonly lua.CFunction ___sgf_realtimeSinceStartup = new lua.CFunction(___sgm_realtimeSinceStartup);
            private static readonly lua.CFunction ___sgf_timeScale = new lua.CFunction(___sgm_timeScale);
            private static readonly lua.CFunction ___ssf_timeScale = new lua.CFunction(___ssm_timeScale);
            private static readonly lua.CFunction ___sgf_unscaledTime = new lua.CFunction(___sgm_unscaledTime);
            private static readonly lua.CFunction ___sgf_time = new lua.CFunction(___sgm_time);
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
            private static int ___sgm_frameCount(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Time.frameCount;
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
            private static int ___sgm_realtimeSinceStartup(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Time.realtimeSinceStartup;
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
            private static int ___sgm_timeScale(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Time.timeScale;
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
            private static int ___ssm_timeScale(IntPtr l)
            {
                try
                {
                    System.Single val;
                    l.GetLua(1, out val);
                    UnityEngine.Time.timeScale = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_unscaledTime(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Time.unscaledTime;
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
            private static int ___sgm_time(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Time.time;
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
        private static TypeHubPrecompiled_UnityEngine_Time ___tp_UnityEngine_Time = new TypeHubPrecompiled_UnityEngine_Time();
        public static void PushLua(this IntPtr l, UnityEngine.Time val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_Time.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Time val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Time;
        }
    }
}
#endif
