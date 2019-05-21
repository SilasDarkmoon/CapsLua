#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_PlayerPrefs : Capstones.LuaLib.LuaTypeHub.TypeHubCommonPrecompiled
        {
            public TypeHubPrecompiled_UnityEngine_PlayerPrefs() : this(typeof(UnityEngine.PlayerPrefs)) { }
            public TypeHubPrecompiled_UnityEngine_PlayerPrefs(Type type) : base(type)
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
                _StaticMethods["GetString"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetString"]._Method, _Precompiled = ___sfm_GetString };
                _StaticMethods["DeleteKey"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["DeleteKey"]._Method, _Precompiled = ___sfm_DeleteKey };
                _StaticMethods["Save"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Save"]._Method, _Precompiled = ___sfm_Save };
                _StaticMethods["SetString"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["SetString"]._Method, _Precompiled = ___sfm_SetString };
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
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_GetString = new lua.CFunction(___smm_GetString);
            private static readonly lua.CFunction ___sfm_DeleteKey = new lua.CFunction(___smm_DeleteKey);
            private static readonly lua.CFunction ___sfm_Save = new lua.CFunction(___smm_Save);
            private static readonly lua.CFunction ___sfm_SetString = new lua.CFunction(___smm_SetString);
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
            #endregion // FUNC_I_PROP
            #region FUNC_S_FUNC
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_GetString(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 1)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 2)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = UnityEngine.PlayerPrefs.GetString(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            var rv = UnityEngine.PlayerPrefs.GetString(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_DeleteKey(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    UnityEngine.PlayerPrefs.DeleteKey(p0);
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
            private static int ___smm_Save(IntPtr l)
            {
                try
                {
                    UnityEngine.PlayerPrefs.Save();
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
            private static int ___smm_SetString(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    UnityEngine.PlayerPrefs.SetString(p0, p1);
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
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
        private static TypeHubPrecompiled_UnityEngine_PlayerPrefs ___tp_UnityEngine_PlayerPrefs = new TypeHubPrecompiled_UnityEngine_PlayerPrefs();
        public static void PushLua(this IntPtr l, UnityEngine.PlayerPrefs val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_PlayerPrefs.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.PlayerPrefs val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.PlayerPrefs;
        }
    }
}
#endif
