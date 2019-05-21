#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Input : Capstones.LuaLib.LuaTypeHub.TypeHubCommonPrecompiled
        {
            public TypeHubPrecompiled_UnityEngine_Input() : this(typeof(UnityEngine.Input)) { }
            public TypeHubPrecompiled_UnityEngine_Input(Type type) : base(type)
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
                _StaticMethods["GetKeyDown"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetKeyDown"]._Method, _Precompiled = ___sfm_GetKeyDown };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                _StaticFieldsIndex["mousePosition"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["mousePosition"]._Method, _Precompiled = ___sgf_mousePosition };
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
            private static readonly lua.CFunction ___sfm_GetKeyDown = new lua.CFunction(___smm_GetKeyDown);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_mousePosition = new lua.CFunction(___sgm_mousePosition);
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
            private static int ___smm_GetKeyDown(IntPtr l)
            {
                try
                {
                    {
                        {
                            {
                                {
                                    var ___lt0 = l.type(1);
                                    if (___lt0 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_10;
                                    }
                                    {
                                        var ___ot0 = l.GetType(1);
                                        if (___ot0 == typeof(UnityEngine.KeyCode))
                                        {
                                            goto Label_20;
                                        }
                                        goto Label_10;
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            var rv = UnityEngine.Input.GetKeyDown(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.KeyCode p0;
                            l.GetLua(1, out p0);
                            var rv = UnityEngine.Input.GetKeyDown(p0);
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
            #endregion // FUNC_S_FUNC
            #region FUNC_S_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_mousePosition(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Input.mousePosition;
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
        private static TypeHubPrecompiled_UnityEngine_Input ___tp_UnityEngine_Input = new TypeHubPrecompiled_UnityEngine_Input();
        public static void PushLua(this IntPtr l, UnityEngine.Input val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_Input.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Input val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Input;
        }
    }
}
#endif
