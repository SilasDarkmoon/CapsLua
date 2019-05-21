#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_System_Decimal : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<System.Decimal>, ILuaNative, ILuaConvert
        {
            public TypeHubPrecompiled_System_Decimal()
            {
                #region REG_I_FUNC
                _InstanceMethods["GetHashCode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetHashCode"]._Method, _Precompiled = ___fm_GetHashCode };
                _InstanceMethods["Equals"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Equals"]._Method, _Precompiled = ___fm_Equals };
                _InstanceMethods["CompareTo"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["CompareTo"]._Method, _Precompiled = ___fm_CompareTo };
                _InstanceMethods["ToString"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToString"]._Method, _Precompiled = ___fm_ToString };
                _InstanceMethods["GetType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetType"]._Method, _Precompiled = ___fm_GetType };
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
                _Ctor._Precompiled = ___fm_ctor;
                #endregion // REG_I_CTOR
                #region REG_S_FUNC
                _StaticMethods["GetBits"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetBits"]._Method, _Precompiled = ___sfm_GetBits };
                _StaticMethods["Add"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Add"]._Method, _Precompiled = ___sfm_Add };
                _StaticMethods["Subtract"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Subtract"]._Method, _Precompiled = ___sfm_Subtract };
                _StaticMethods["Equals"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Equals"]._Method, _Precompiled = ___sfm_Equals };
                _StaticMethods["Floor"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Floor"]._Method, _Precompiled = ___sfm_Floor };
                _StaticMethods["Multiply"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Multiply"]._Method, _Precompiled = ___sfm_Multiply };
                _StaticMethods["Divide"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Divide"]._Method, _Precompiled = ___sfm_Divide };
                _StaticMethods["Compare"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Compare"]._Method, _Precompiled = ___sfm_Compare };
                _StaticMethods["Parse"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Parse"]._Method, _Precompiled = ___sfm_Parse };
                _StaticMethods["op_Addition"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Addition"]._Method, _Precompiled = ___sfm_op_Addition };
                _StaticMethods["op_Increment"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Increment"]._Method, _Precompiled = ___sfm_op_Increment };
                _StaticMethods["op_Subtraction"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Subtraction"]._Method, _Precompiled = ___sfm_op_Subtraction };
                _StaticMethods["op_Multiply"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Multiply"]._Method, _Precompiled = ___sfm_op_Multiply };
                _StaticMethods["op_Division"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Division"]._Method, _Precompiled = ___sfm_op_Division };
                _StaticMethods["op_Inequality"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Inequality"]._Method, _Precompiled = ___sfm_op_Inequality };
                _StaticMethods["op_Equality"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Equality"]._Method, _Precompiled = ___sfm_op_Equality };
                _StaticMethods["op_GreaterThan"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_GreaterThan"]._Method, _Precompiled = ___sfm_op_GreaterThan };
                _StaticMethods["op_LessThan"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_LessThan"]._Method, _Precompiled = ___sfm_op_LessThan };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                _StaticFieldsIndex["MinValue"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["MinValue"]._Method, _Precompiled = ___sgf_MinValue };
                _StaticFieldsIndex["MaxValue"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["MaxValue"]._Method, _Precompiled = ___sgf_MaxValue };
                _StaticFieldsIndex["MinusOne"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["MinusOne"]._Method, _Precompiled = ___sgf_MinusOne };
                _StaticFieldsIndex["One"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["One"]._Method, _Precompiled = ___sgf_One };
                #endregion // REG_S_PROP
                #region REG_G_S_FUNC
                #endregion // REG_G_S_FUNC
                #region REG_S_OP
                _Ops["__add"] = new LuaMetaCallWithPrecompiled() { _Method = _Ops["__add"]._Method, _Precompiled = ___opf__add };
                _Ops["__sub"] = new LuaMetaCallWithPrecompiled() { _Method = _Ops["__sub"]._Method, _Precompiled = ___opf__sub };
                _Ops["__mul"] = new LuaMetaCallWithPrecompiled() { _Method = _Ops["__mul"]._Method, _Precompiled = ___opf__mul };
                _Ops["__div"] = new LuaMetaCallWithPrecompiled() { _Method = _Ops["__div"]._Method, _Precompiled = ___opf__div };
                #endregion // REG_S_OP
                #region REG_S_CONV
                _ConvertFuncs[typeof(System.Byte)] = ___convm_System_Byte;
                _ConvertFuncs[typeof(System.SByte)] = ___convm_System_SByte;
                _ConvertFuncs[typeof(System.Int16)] = ___convm_System_Int16;
                _ConvertFuncs[typeof(System.UInt16)] = ___convm_System_UInt16;
                _ConvertFuncs[typeof(System.Int32)] = ___convm_System_Int32;
                _ConvertFuncs[typeof(System.UInt32)] = ___convm_System_UInt32;
                _ConvertFuncs[typeof(System.Int64)] = ___convm_System_Int64;
                _ConvertFuncs[typeof(System.UInt64)] = ___convm_System_UInt64;
                _ConvertFuncs[typeof(System.Single)] = ___convm_System_Single;
                _ConvertFuncs[typeof(System.Double)] = ___convm_System_Double;
                #endregion // REG_S_CONV
                #region REG_G_GTYPES
                #endregion // REG_G_GTYPES
            }
            
            #region DEL_I_CTOR
            private static readonly lua.CFunction ___fm_ctor = new lua.CFunction(___mm_ctor);
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            private static readonly lua.CFunction ___fm_GetHashCode = new lua.CFunction(___mm_GetHashCode);
            private static readonly lua.CFunction ___fm_Equals = new lua.CFunction(___mm_Equals);
            private static readonly lua.CFunction ___fm_CompareTo = new lua.CFunction(___mm_CompareTo);
            private static readonly lua.CFunction ___fm_ToString = new lua.CFunction(___mm_ToString);
            private static readonly lua.CFunction ___fm_GetType = new lua.CFunction(___mm_GetType);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_GetBits = new lua.CFunction(___smm_GetBits);
            private static readonly lua.CFunction ___sfm_Add = new lua.CFunction(___smm_Add);
            private static readonly lua.CFunction ___sfm_Subtract = new lua.CFunction(___smm_Subtract);
            private static readonly lua.CFunction ___sfm_Equals = new lua.CFunction(___smm_Equals);
            private static readonly lua.CFunction ___sfm_Floor = new lua.CFunction(___smm_Floor);
            private static readonly lua.CFunction ___sfm_Multiply = new lua.CFunction(___smm_Multiply);
            private static readonly lua.CFunction ___sfm_Divide = new lua.CFunction(___smm_Divide);
            private static readonly lua.CFunction ___sfm_Compare = new lua.CFunction(___smm_Compare);
            private static readonly lua.CFunction ___sfm_Parse = new lua.CFunction(___smm_Parse);
            private static readonly lua.CFunction ___sfm_op_Addition = new lua.CFunction(___smm_op_Addition);
            private static readonly lua.CFunction ___sfm_op_Increment = new lua.CFunction(___smm_op_Increment);
            private static readonly lua.CFunction ___sfm_op_Subtraction = new lua.CFunction(___smm_op_Subtraction);
            private static readonly lua.CFunction ___sfm_op_Multiply = new lua.CFunction(___smm_op_Multiply);
            private static readonly lua.CFunction ___sfm_op_Division = new lua.CFunction(___smm_op_Division);
            private static readonly lua.CFunction ___sfm_op_Inequality = new lua.CFunction(___smm_op_Inequality);
            private static readonly lua.CFunction ___sfm_op_Equality = new lua.CFunction(___smm_op_Equality);
            private static readonly lua.CFunction ___sfm_op_GreaterThan = new lua.CFunction(___smm_op_GreaterThan);
            private static readonly lua.CFunction ___sfm_op_LessThan = new lua.CFunction(___smm_op_LessThan);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_MinValue = new lua.CFunction(___sgm_MinValue);
            private static readonly lua.CFunction ___sgf_MaxValue = new lua.CFunction(___sgm_MaxValue);
            private static readonly lua.CFunction ___sgf_MinusOne = new lua.CFunction(___sgm_MinusOne);
            private static readonly lua.CFunction ___sgf_One = new lua.CFunction(___sgm_One);
            #endregion // DEL_S_PROP
            #region DEL_G_I_FUNC
            #endregion // DEL_G_I_FUNC
            #region DEL_I_INDEX
            #endregion // DEL_I_INDEX
            #region DEL_G_S_FUNC
            #endregion // DEL_G_S_FUNC
            #region DEL_S_OP
            private static readonly lua.CFunction ___opf__add = new lua.CFunction(___opm__add);
            private static readonly lua.CFunction ___opf__sub = new lua.CFunction(___opm__sub);
            private static readonly lua.CFunction ___opf__mul = new lua.CFunction(___opm__mul);
            private static readonly lua.CFunction ___opf__div = new lua.CFunction(___opm__div);
            #endregion // DEL_S_OP
            #region DEL_S_CONV
            #endregion // DEL_S_CONV
            #region DEL_G_GTYPES
            #endregion // DEL_G_GTYPES
            
            #region FUNC_I_CTOR
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_ctor(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 1)
                            {
                                goto Label_80;
                            }
                            else if (oldtop >= 6)
                            {
                                goto Label_10;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Double))
                                        {
                                            goto Label_70;
                                        }
                                        if (___ot1 == typeof(System.UInt64))
                                        {
                                            goto Label_50;
                                        }
                                        if (___ot1 == typeof(System.Int64))
                                        {
                                            goto Label_40;
                                        }
                                        if (___ot1 == typeof(System.Single))
                                        {
                                            goto Label_60;
                                        }
                                        if (___ot1 == typeof(System.UInt32))
                                        {
                                            goto Label_30;
                                        }
                                        if (___ot1 == typeof(System.Int32))
                                        {
                                            goto Label_20;
                                        }
                                        {
                                        }
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            System.Boolean p4;
                            l.GetLua(5, out p4);
                            System.Byte p5;
                            l.GetLua(6, out p5);
                            var rv = new System.Decimal(p1, p2, p3, p4, p5);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            var rv = new System.Decimal(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.UInt32 p1;
                            l.GetLua(2, out p1);
                            var rv = new System.Decimal(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.Int64 p1;
                            l.GetLua(2, out p1);
                            var rv = new System.Decimal(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            System.UInt64 p1;
                            l.GetLua(2, out p1);
                            var rv = new System.Decimal(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            System.Single p1;
                            l.GetLua(2, out p1);
                            var rv = new System.Decimal(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_70:
                        {
                            System.Double p1;
                            l.GetLua(2, out p1);
                            var rv = new System.Decimal(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_80:
                        {
                            var rv = default(System.Decimal);
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
            #endregion // FUNC_I_CTOR
            #region FUNC_I_FUNC
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetHashCode(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, 1);
                    var rv = p0.GetHashCode();
                    l.PushLua(rv);
                    //SetDataRaw(l, 1, p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_Equals(IntPtr l)
            {
                try
                {
                    {
                        {
                            {
                                {
                                    var ___lt1 = l.type(2);
                                    if (___lt1 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Decimal))
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
                            System.Decimal p0;
                            p0 = GetLuaChecked(l, 1);
                            System.Object p1;
                            l.GetLua(2, out p1);
                            var rv = p0.Equals(p1);
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Decimal p0;
                            p0 = GetLuaChecked(l, 1);
                            System.Decimal p1;
                            l.GetLua(2, out p1);
                            var rv = p0.Equals(p1);
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
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
            private static int ___mm_CompareTo(IntPtr l)
            {
                try
                {
                    {
                        {
                            {
                                {
                                    var ___lt1 = l.type(2);
                                    if (___lt1 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Decimal))
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
                            System.Decimal p0;
                            p0 = GetLuaChecked(l, 1);
                            System.Object p1;
                            l.GetLua(2, out p1);
                            var rv = p0.CompareTo(p1);
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Decimal p0;
                            p0 = GetLuaChecked(l, 1);
                            System.Decimal p1;
                            l.GetLua(2, out p1);
                            var rv = p0.CompareTo(p1);
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
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
            private static int ___mm_ToString(IntPtr l)
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
                            else if (oldtop == 2)
                            {
                                goto Label_30;
                            }
                            else if (oldtop >= 3)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.Decimal p0;
                            p0 = GetLuaChecked(l, 1);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.IFormatProvider p2;
                            l.GetLua(3, out p2);
                            var rv = p0.ToString(p1, p2);
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Decimal p0;
                            p0 = GetLuaChecked(l, 1);
                            var rv = p0.ToString();
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.Decimal p0;
                            p0 = GetLuaChecked(l, 1);
                            System.IFormatProvider p1;
                            l.GetLua(2, out p1);
                            var rv = p0.ToString(p1);
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
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
            private static int ___mm_GetType(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, 1);
                    var rv = p0.GetType();
                    l.PushLua(rv);
                    //SetDataRaw(l, 1, p0);
                    return 1;
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
            #endregion // FUNC_I_PROP
            #region FUNC_S_FUNC
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_GetBits(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    var rv = System.Decimal.GetBits(p0);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Add(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = System.Decimal.Add(p0, p1);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Subtract(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = System.Decimal.Subtract(p0, p1);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Equals(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = System.Decimal.Equals(p0, p1);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Floor(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    var rv = System.Decimal.Floor(p0);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Multiply(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = System.Decimal.Multiply(p0, p1);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Divide(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = System.Decimal.Divide(p0, p1);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Compare(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = System.Decimal.Compare(p0, p1);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Parse(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 3)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.IFormatProvider p1;
                            l.GetLua(2, out p1);
                            var rv = System.Decimal.Parse(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Globalization.NumberStyles p1;
                            l.GetLua(2, out p1);
                            System.IFormatProvider p2;
                            l.GetLua(3, out p2);
                            var rv = System.Decimal.Parse(p0, p1, p2);
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
            private static int ___smm_op_Addition(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = p0 + p1;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_op_Increment(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    var rv = ++p0;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_op_Subtraction(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = p0 - p1;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_op_Multiply(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = p0 * p1;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_op_Division(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = p0 / p1;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_op_Inequality(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = p0 != p1;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_op_Equality(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = p0 == p1;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_op_GreaterThan(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = p0 > p1;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_op_LessThan(IntPtr l)
            {
                try
                {
                    System.Decimal p0;
                    l.GetLua(1, out p0);
                    System.Decimal p1;
                    l.GetLua(2, out p1);
                    var rv = p0 < p1;
                    l.PushLua(rv);
                    return 1;
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
            private static int ___sgm_MinValue(IntPtr l)
            {
                try
                {
                    var rv = System.Decimal.MinValue;
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
            private static int ___sgm_MaxValue(IntPtr l)
            {
                try
                {
                    var rv = System.Decimal.MaxValue;
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
            private static int ___sgm_MinusOne(IntPtr l)
            {
                try
                {
                    var rv = System.Decimal.MinusOne;
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
            private static int ___sgm_One(IntPtr l)
            {
                try
                {
                    var rv = System.Decimal.One;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___opm__add(IntPtr l)
            {
                var rv = ___smm_op_Addition(l);
                if (rv == 0)
                {
                    l.pushnil();
                    l.pushboolean(true);
                    return 2;
                }
                return rv;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___opm__sub(IntPtr l)
            {
                var rv = ___smm_op_Subtraction(l);
                if (rv == 0)
                {
                    l.pushnil();
                    l.pushboolean(true);
                    return 2;
                }
                return rv;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___opm__mul(IntPtr l)
            {
                var rv = ___smm_op_Multiply(l);
                if (rv == 0)
                {
                    l.pushnil();
                    l.pushboolean(true);
                    return 2;
                }
                return rv;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___opm__div(IntPtr l)
            {
                var rv = ___smm_op_Division(l);
                if (rv == 0)
                {
                    l.pushnil();
                    l.pushboolean(true);
                    return 2;
                }
                return rv;
            }
            #endregion // FUNC_S_OP
            #region FUNC_S_CONV
            private static int ___convm_System_Byte(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.Byte>((System.Byte)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_SByte(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.SByte>((System.SByte)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_Int16(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.Int16>((System.Int16)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_UInt16(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.UInt16>((System.UInt16)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_Int32(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.Int32>((System.Int32)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_UInt32(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.UInt32>((System.UInt32)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_Int64(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.Int64>((System.Int64)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_UInt64(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.UInt64>((System.UInt64)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_Single(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.Single>((System.Single)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_Double(IntPtr l, int index)
            {
                try
                {
                    System.Decimal p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.Double>((System.Double)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            #endregion // FUNC_S_CONV
            #region FUNC_G_GTYPES
            #endregion // FUNC_G_GTYPES
            
            #region NESTED_TYPE_HUB
            #endregion // NESTED_TYPE_HUB
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (System.Decimal)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (System.Decimal)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public override IntPtr PushLua(IntPtr l, System.Decimal val)
            {
                l.checkstack(3);
                l.newtable(); // ud
                SetDataRaw(l, -1, val);
                l.pushlightuserdata(LuaConst.LRKEY_TYPE_TRANS); // ud #trans
                l.pushlightuserdata(r); // ud #trans trans
                l.rawset(-3); // ud
                
                PushToLuaCached(l); // ud type
                l.pushlightuserdata(LuaConst.LRKEY_OBJ_META); // ud type #meta
                l.rawget(-2); // ud type meta
                l.setmetatable(-3); // ud type
                l.pop(1); // ud
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, System.Decimal val)
            {
                SetDataRaw(l, index, val);
            }
            public override System.Decimal GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public void Wrap(IntPtr l, int index)
            {
                System.Decimal val;
                l.GetLua(index, out val);
                PushLua(l, val);
            }
            public void Unwrap(IntPtr l, int index)
            {
                var val = GetLuaRaw(l, index);
                l.PushLua(val);
            }
            
            public static void SetDataRaw(IntPtr l, int index, System.Decimal val)
            {
                l.checkstack(3);
                l.pushvalue(index); // otab
                l.pushlightuserdata(LuaConst.LRKEY_TARGET); // otab #tar
                l.PushLua(val); // otab #tar val
                l.rawset(-3); // otab
                l.pop(1);
            }
            public static System.Decimal GetLuaRaw(IntPtr l, int index)
            {
                System.Decimal rv;
                l.checkstack(2);
                l.pushvalue(index); // otab
                l.pushlightuserdata(LuaConst.LRKEY_TARGET); // otab #tar
                l.rawget(-2); // otab val
                l.GetLua(-1, out rv);
                l.pop(2); // X
                return rv;
            }
            public static System.Decimal GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(System.Decimal);
            }
        }
        private static TypeHubPrecompiled_System_Decimal ___tp_System_Decimal = new TypeHubPrecompiled_System_Decimal();
    }
}
#endif
