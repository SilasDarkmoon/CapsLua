#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_System_Convert : Capstones.LuaLib.LuaTypeHub.TypeHubCommonPrecompiled
        {
            public TypeHubPrecompiled_System_Convert() : this(typeof(System.Convert)) { }
            public TypeHubPrecompiled_System_Convert(Type type) : base(type)
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
                _StaticMethods["ToInt16"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["ToInt16"]._Method, _Precompiled = ___sfm_ToInt16 };
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
            private static readonly lua.CFunction ___sfm_ToInt16 = new lua.CFunction(___smm_ToInt16);
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
            private static int ___smm_ToInt16(IntPtr l)
            {
                try
                {
                    {
                        {
                            {
                                {
                                    var ___lt0 = l.type(1);
                                    if (___lt0 == LuaCoreLib.LUA_TBOOLEAN)
                                    {
                                        goto Label_10;
                                    }
                                    else if (___lt0 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_110;
                                    }
                                    {
                                        var ___ot0 = l.GetType(1);
                                        if (___ot0 == typeof(System.String))
                                        {
                                            goto Label_110;
                                        }
                                        if (___ot0 == typeof(System.Boolean))
                                        {
                                            goto Label_10;
                                        }
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.IFormatProvider) || typeof(System.IFormatProvider).IsAssignableFrom(___ot1))
                                        {
                                            goto Label_160;
                                        }
                                        if (___ot0 == typeof(System.Double))
                                        {
                                            goto Label_50;
                                        }
                                        if (___ot0 == typeof(System.Decimal))
                                        {
                                            goto Label_40;
                                        }
                                        if (___ot0 == typeof(System.UInt64))
                                        {
                                            goto Label_130;
                                        }
                                        if (___ot0 == typeof(System.Int64))
                                        {
                                            goto Label_80;
                                        }
                                        if (___ot0 == typeof(System.Single))
                                        {
                                            goto Label_60;
                                        }
                                        if (___ot0 == typeof(System.Int32))
                                        {
                                            goto Label_70;
                                        }
                                        if (___ot0 == typeof(System.UInt32))
                                        {
                                            goto Label_120;
                                        }
                                        if (___ot0 == typeof(System.UInt16))
                                        {
                                            goto Label_140;
                                        }
                                        if (___ot0 == typeof(System.Int16))
                                        {
                                            goto Label_100;
                                        }
                                        if (___ot0 == typeof(System.SByte))
                                        {
                                            goto Label_90;
                                        }
                                        if (___ot0 == typeof(System.Byte))
                                        {
                                            goto Label_20;
                                        }
                                        if (___ot0 == typeof(System.Char))
                                        {
                                            goto Label_30;
                                        }
                                        {
                                            goto Label_150;
                                        }
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.Boolean p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Byte p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.Char p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.Decimal p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            System.Double p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            System.Single p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_70:
                        {
                            System.Int32 p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_80:
                        {
                            System.Int64 p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_90:
                        {
                            System.SByte p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_100:
                        {
                            System.Int16 p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_110:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.IFormatProvider p1;
                            l.GetLua(2, out p1);
                            var rv = System.Convert.ToInt16(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_120:
                        {
                            System.UInt32 p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_130:
                        {
                            System.UInt64 p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_140:
                        {
                            System.UInt16 p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_150:
                        {
                            System.Object p0;
                            l.GetLua(1, out p0);
                            var rv = System.Convert.ToInt16(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_160:
                        {
                            System.Object p0;
                            l.GetLua(1, out p0);
                            System.IFormatProvider p1;
                            l.GetLua(2, out p1);
                            var rv = System.Convert.ToInt16(p0, p1);
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
        private static TypeHubPrecompiled_System_Convert ___tp_System_Convert = new TypeHubPrecompiled_System_Convert();
    }
}
#endif
