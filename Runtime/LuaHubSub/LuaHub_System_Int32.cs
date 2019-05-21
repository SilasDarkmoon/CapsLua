#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_System_Int32 : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<System.Int32>, ILuaNative, ILuaConvert
        {
            public TypeHubPrecompiled_System_Int32()
            {
                #region REG_I_FUNC
                _InstanceMethods["CompareTo"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["CompareTo"]._Method, _Precompiled = ___fm_CompareTo };
                _InstanceMethods["Equals"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Equals"]._Method, _Precompiled = ___fm_Equals };
                _InstanceMethods["GetHashCode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetHashCode"]._Method, _Precompiled = ___fm_GetHashCode };
                _InstanceMethods["ToString"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToString"]._Method, _Precompiled = ___fm_ToString };
                _InstanceMethods["GetTypeCode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetTypeCode"]._Method, _Precompiled = ___fm_GetTypeCode };
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
                _StaticMethods["Parse"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Parse"]._Method, _Precompiled = ___sfm_Parse };
                _StaticMethods["TryParse"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["TryParse"]._Method, _Precompiled = ___sfm_TryParse };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                _StaticFieldsIndex["MaxValue"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["MaxValue"]._Method, _Precompiled = ___sgf_MaxValue };
                _StaticFieldsIndex["MinValue"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["MinValue"]._Method, _Precompiled = ___sgf_MinValue };
                #endregion // REG_S_PROP
                #region REG_G_S_FUNC
                #endregion // REG_G_S_FUNC
                #region REG_S_OP
                #endregion // REG_S_OP
                #region REG_S_CONV
                _ConvertFuncs[typeof(System.Decimal)] = ___convm_System_Decimal;
                _ConvertFuncs[typeof(System.IntPtr)] = ___convm_System_IntPtr;
                #endregion // REG_S_CONV
                #region REG_G_GTYPES
                #endregion // REG_G_GTYPES
            }
            
            #region DEL_I_CTOR
            private static readonly lua.CFunction ___fm_ctor = new lua.CFunction(___mm_ctor);
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            private static readonly lua.CFunction ___fm_CompareTo = new lua.CFunction(___mm_CompareTo);
            private static readonly lua.CFunction ___fm_Equals = new lua.CFunction(___mm_Equals);
            private static readonly lua.CFunction ___fm_GetHashCode = new lua.CFunction(___mm_GetHashCode);
            private static readonly lua.CFunction ___fm_ToString = new lua.CFunction(___mm_ToString);
            private static readonly lua.CFunction ___fm_GetTypeCode = new lua.CFunction(___mm_GetTypeCode);
            private static readonly lua.CFunction ___fm_GetType = new lua.CFunction(___mm_GetType);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_Parse = new lua.CFunction(___smm_Parse);
            private static readonly lua.CFunction ___sfm_TryParse = new lua.CFunction(___smm_TryParse);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_MaxValue = new lua.CFunction(___sgm_MaxValue);
            private static readonly lua.CFunction ___sgf_MinValue = new lua.CFunction(___sgm_MinValue);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_ctor(IntPtr l)
            {
                try
                {
                    var rv = default(System.Int32);
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
            #endregion // FUNC_I_CTOR
            #region FUNC_I_FUNC
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
                                        if (___ot1 == typeof(System.Int32))
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
                            System.Int32 p0;
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
                            System.Int32 p0;
                            p0 = GetLuaChecked(l, 1);
                            System.Int32 p1;
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
                                        if (___ot1 == typeof(System.Int32))
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
                            System.Int32 p0;
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
                            System.Int32 p0;
                            p0 = GetLuaChecked(l, 1);
                            System.Int32 p1;
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
            private static int ___mm_GetHashCode(IntPtr l)
            {
                try
                {
                    System.Int32 p0;
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
            private static int ___mm_ToString(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 1)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 3)
                            {
                                goto Label_40;
                            }
                            else
                            {
                                {
                                    var ___lt1 = l.type(2);
                                    if (___lt1 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_30;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.String))
                                        {
                                            goto Label_30;
                                        }
                                        goto Label_20;
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.Int32 p0;
                            p0 = GetLuaChecked(l, 1);
                            var rv = p0.ToString();
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Int32 p0;
                            p0 = GetLuaChecked(l, 1);
                            System.IFormatProvider p1;
                            l.GetLua(2, out p1);
                            var rv = p0.ToString(p1);
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.Int32 p0;
                            p0 = GetLuaChecked(l, 1);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = p0.ToString(p1);
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.Int32 p0;
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
            private static int ___mm_GetTypeCode(IntPtr l)
            {
                try
                {
                    System.Int32 p0;
                    p0 = GetLuaChecked(l, 1);
                    var rv = p0.GetTypeCode();
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
            private static int ___mm_GetType(IntPtr l)
            {
                try
                {
                    System.Int32 p0;
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
            private static int ___smm_Parse(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 1)
                            {
                                goto Label_30;
                            }
                            else if (oldtop >= 3)
                            {
                                goto Label_40;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Globalization.NumberStyles))
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
                            System.IFormatProvider p1;
                            l.GetLua(2, out p1);
                            var rv = System.Int32.Parse(p0, p1);
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
                            var rv = System.Int32.Parse(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            var rv = System.Int32.Parse(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Globalization.NumberStyles p1;
                            l.GetLua(2, out p1);
                            System.IFormatProvider p2;
                            l.GetLua(3, out p2);
                            var rv = System.Int32.Parse(p0, p1, p2);
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
            private static int ___smm_TryParse(IntPtr l)
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
                            else if (oldtop >= 4)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            var rv = System.Int32.TryParse(p0, out p1);
                            l.PushLua(rv);
                            l.PushLua(p1);
                            return 2;
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
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            var rv = System.Int32.TryParse(p0, p1, p2, out p3);
                            l.PushLua(rv);
                            l.PushLua(p3);
                            return 2;
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
            private static int ___sgm_MaxValue(IntPtr l)
            {
                try
                {
                    var rv = System.Int32.MaxValue;
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
            private static int ___sgm_MinValue(IntPtr l)
            {
                try
                {
                    var rv = System.Int32.MinValue;
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
            private static int ___convm_System_Decimal(IntPtr l, int index)
            {
                try
                {
                    System.Int32 p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.Decimal>((System.Decimal)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            private static int ___convm_System_IntPtr(IntPtr l, int index)
            {
                try
                {
                    System.Int32 p0;
                    p0 = GetLuaChecked(l, index);
                    l.PushLuaExplicit<System.IntPtr>((System.IntPtr)p0);
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
                PushLua(l, (System.Int32)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (System.Int32)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public override IntPtr PushLua(IntPtr l, System.Int32 val)
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
            public override void SetData(IntPtr l, int index, System.Int32 val)
            {
                SetDataRaw(l, index, val);
            }
            public override System.Int32 GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public void Wrap(IntPtr l, int index)
            {
                System.Int32 val;
                l.GetLua(index, out val);
                PushLua(l, val);
            }
            public void Unwrap(IntPtr l, int index)
            {
                var val = GetLuaRaw(l, index);
                l.PushLua(val);
            }
            
            public static void SetDataRaw(IntPtr l, int index, System.Int32 val)
            {
                l.checkstack(3);
                l.pushvalue(index); // otab
                l.pushlightuserdata(LuaConst.LRKEY_TARGET); // otab #tar
                l.PushLua(val); // otab #tar val
                l.rawset(-3); // otab
                l.pop(1);
            }
            public static System.Int32 GetLuaRaw(IntPtr l, int index)
            {
                System.Int32 rv;
                l.checkstack(2);
                l.pushvalue(index); // otab
                l.pushlightuserdata(LuaConst.LRKEY_TARGET); // otab #tar
                l.rawget(-2); // otab val
                l.GetLua(-1, out rv);
                l.pop(2); // X
                return rv;
            }
            public static System.Int32 GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(System.Int32);
            }
        }
        private static TypeHubPrecompiled_System_Int32 ___tp_System_Int32 = new TypeHubPrecompiled_System_Int32();
    }
}
#endif
