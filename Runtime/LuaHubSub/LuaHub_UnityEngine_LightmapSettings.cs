#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_LightmapSettings : LuaHub.TypeHubPrecompiled_UnityEngine_Object
        {
            public TypeHubPrecompiled_UnityEngine_LightmapSettings() : this(typeof(UnityEngine.LightmapSettings)) { }
            public TypeHubPrecompiled_UnityEngine_LightmapSettings(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
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
                _StaticFieldsIndex["lightmapsMode"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["lightmapsMode"]._Method, _Precompiled = ___sgf_lightmapsMode };
                _StaticFieldsNewIndex["lightmapsMode"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsNewIndex["lightmapsMode"]._Method, _Precompiled = ___ssf_lightmapsMode };
                _StaticFieldsIndex["lightmaps"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["lightmaps"]._Method, _Precompiled = ___sgf_lightmaps };
                _StaticFieldsNewIndex["lightmaps"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsNewIndex["lightmaps"]._Method, _Precompiled = ___ssf_lightmaps };
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
            private static readonly lua.CFunction ___sgf_lightmapsMode = new lua.CFunction(___sgm_lightmapsMode);
            private static readonly lua.CFunction ___ssf_lightmapsMode = new lua.CFunction(___ssm_lightmapsMode);
            private static readonly lua.CFunction ___sgf_lightmaps = new lua.CFunction(___sgm_lightmaps);
            private static readonly lua.CFunction ___ssf_lightmaps = new lua.CFunction(___ssm_lightmaps);
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
            private static int ___sgm_lightmapsMode(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.LightmapSettings.lightmapsMode;
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
            private static int ___ssm_lightmapsMode(IntPtr l)
            {
                try
                {
                    UnityEngine.LightmapsMode val;
                    l.GetLua(1, out val);
                    UnityEngine.LightmapSettings.lightmapsMode = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_lightmaps(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.LightmapSettings.lightmaps;
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
            private static int ___ssm_lightmaps(IntPtr l)
            {
                try
                {
                    UnityEngine.LightmapData[] val;
                    l.GetLua(1, out val);
                    UnityEngine.LightmapSettings.lightmaps = val;
                    return 0;
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
        private static TypeHubPrecompiled_UnityEngine_LightmapSettings ___tp_UnityEngine_LightmapSettings = new TypeHubPrecompiled_UnityEngine_LightmapSettings();
        public static void PushLua(this IntPtr l, UnityEngine.LightmapSettings val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_LightmapSettings.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.LightmapSettings val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.LightmapSettings;
        }
    }
}
#endif
