#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_System_IntPtr : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<System.IntPtr>, ILuaNative, ILuaConvert
        {
            public TypeHubPrecompiled_System_IntPtr()
            {
                #region REG_I_FUNC
                _InstanceMethods["Equals"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Equals"]._Method, _Precompiled = ___fm_Equals };
                _InstanceMethods["GetHashCode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetHashCode"]._Method, _Precompiled = ___fm_GetHashCode };
                _InstanceMethods["ToInt32"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToInt32"]._Method, _Precompiled = ___fm_ToInt32 };
                _InstanceMethods["ToInt64"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToInt64"]._Method, _Precompiled = ___fm_ToInt64 };
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
                _StaticMethods["op_Equality"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Equality"]._Method, _Precompiled = ___sfm_op_Equality };
                _StaticMethods["op_Inequality"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Inequality"]._Method, _Precompiled = ___sfm_op_Inequality };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                _StaticFieldsIndex["Size"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["Size"]._Method, _Precompiled = ___sgf_Size };
                _StaticFieldsIndex["Zero"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["Zero"]._Method, _Precompiled = ___sgf_Zero };
                #endregion // REG_S_PROP
                #region REG_G_S_FUNC
                #endregion // REG_G_S_FUNC
                #region REG_S_OP
                #endregion // REG_S_OP
                #region REG_S_CONV
                _ConvertFuncs[typeof(System.Int32)] = ___convm_System_Int32;
                _ConvertFuncs[typeof(System.Int64)] = ___convm_System_Int64;
                #endregion // REG_S_CONV
                #region REG_G_GTYPES
                #endregion // REG_G_GTYPES
            }
            
            #region DEL_I_CTOR
            private static readonly lua.CFunction ___fm_ctor = new lua.CFunction(___mm_ctor);
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            private static readonly lua.CFunction ___fm_Equals = new lua.CFunction(___mm_Equals);
            private static readonly lua.CFunction ___fm_GetHashCode = new lua.CFunction(___mm_GetHashCode);
            private static readonly lua.CFunction ___fm_ToInt32 = new lua.CFunction(___mm_ToInt32);
            private static readonly lua.CFunction ___fm_ToInt64 = new lua.CFunction(___mm_ToInt64);
            private static readonly lua.CFunction ___fm_ToString = new lua.CFunction(___mm_ToString);
            private static readonly lua.CFunction ___fm_GetType = new lua.CFunction(___mm_GetType);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_op_Equality = new lua.CFunction(___smm_op_Equality);
            private static readonly lua.CFunction ___sfm_op_Inequality = new lua.CFunction(___smm_op_Inequality);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_Size = new lua.CFunction(___sgm_Size);
            private static readonly lua.CFunction ___sgf_Zero = new lua.CFunction(___sgm_Zero);
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
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 1)
                            {
                                goto Label_30;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Double))
                                        {
                                            goto Label_20;
                                        }
                                        if (___ot1 == typeof(System.Int64))
                                        {
                                            goto Label_20;
                                        }
                                        if (___ot1 == typeof(System.Int32))
                                        {
                                            goto Label_10;
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
                            var rv = new System.IntPtr(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Int64 p1;
                            l.GetLua(2, out p1);
                            var rv = new System.IntPtr(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            var rv = default(System.IntPtr);
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
            private static int ___mm_Equals(IntPtr l)
            {
                try
                {
                    System.IntPtr p0;
                    p0 = GetLuaChecked(l, 1);
                    System.Object p1;
                    l.GetLua(2, out p1);
                    var rv = p0.Equals(p1);
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
            private static int ___mm_GetHashCode(IntPtr l)
            {
                try
                {
                    System.IntPtr p0;
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
            private static int ___mm_ToInt32(IntPtr l)
            {
                try
                {
                    System.IntPtr p0;
                    p0 = GetLuaChecked(l, 1);
                    var rv = p0.ToInt32();
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
            private static int ___mm_ToInt64(IntPtr l)
            {
                try
                {
                    System.IntPtr p0;
                    p0 = GetLuaChecked(l, 1);
                    var rv = p0.ToInt64();
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
                            else if (oldtop >= 2)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.IntPtr p0;
                            p0 = GetLuaChecked(l, 1);
                            var rv = p0.ToString();
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.IntPtr p0;
                            p0 = GetLuaChecked(l, 1);
                            System.String p1;
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
                    System.IntPtr p0;
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
            private static int ___smm_op_Equality(IntPtr l)
            {
                try
                {
                    System.IntPtr p0;
                    l.GetLua(1, out p0);
                    System.IntPtr p1;
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
            private static int ___smm_op_Inequality(IntPtr l)
            {
                try
                {
                    System.IntPtr p0;
                    l.GetLua(1, out p0);
                    System.IntPtr p1;
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
            #endregion // FUNC_S_FUNC
            #region FUNC_S_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_Size(IntPtr l)
            {
                try
                {
                    var rv = System.IntPtr.Size;
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
            private static int ___sgm_Zero(IntPtr l)
            {
                try
                {
                    var rv = System.IntPtr.Zero;
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
            private static int ___convm_System_Int32(IntPtr l, int index)
            {
                try
                {
                    System.IntPtr p0;
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
            private static int ___convm_System_Int64(IntPtr l, int index)
            {
                try
                {
                    System.IntPtr p0;
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
            #endregion // FUNC_S_CONV
            #region FUNC_G_GTYPES
            #endregion // FUNC_G_GTYPES
            
            #region NESTED_TYPE_HUB
            #endregion // NESTED_TYPE_HUB
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (System.IntPtr)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (System.IntPtr)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public override IntPtr PushLua(IntPtr l, System.IntPtr val)
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
            public override void SetData(IntPtr l, int index, System.IntPtr val)
            {
                SetDataRaw(l, index, val);
            }
            public override System.IntPtr GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public void Wrap(IntPtr l, int index)
            {
                System.IntPtr val;
                l.GetLua(index, out val);
                PushLua(l, val);
            }
            public void Unwrap(IntPtr l, int index)
            {
                var val = GetLuaRaw(l, index);
                l.PushLua(val);
            }
            
            public static void SetDataRaw(IntPtr l, int index, System.IntPtr val)
            {
                l.checkstack(3);
                l.pushvalue(index); // otab
                l.pushlightuserdata(LuaConst.LRKEY_TARGET); // otab #tar
                l.PushLua(val); // otab #tar val
                l.rawset(-3); // otab
                l.pop(1);
            }
            public static System.IntPtr GetLuaRaw(IntPtr l, int index)
            {
                System.IntPtr rv;
                l.checkstack(2);
                l.pushvalue(index); // otab
                l.pushlightuserdata(LuaConst.LRKEY_TARGET); // otab #tar
                l.rawget(-2); // otab val
                l.GetLua(-1, out rv);
                l.pop(2); // X
                return rv;
            }
            public static System.IntPtr GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(System.IntPtr);
            }
        }
        private static TypeHubPrecompiled_System_IntPtr ___tp_System_IntPtr = new TypeHubPrecompiled_System_IntPtr();
    }
}
#endif
