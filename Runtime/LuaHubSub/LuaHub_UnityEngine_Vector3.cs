#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Vector3 : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.Vector3>
        {
            public TypeHubPrecompiled_UnityEngine_Vector3()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHubC.Ready)
                {
                    LuaHubC.capslua_setTypeVector3(r);
                }
                #endif
                #region REG_I_FUNC
                _InstanceMethods["Normalize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Normalize"]._Method, _Precompiled = ___fm_Normalize };
                _InstanceMethods["ToString"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToString"]._Method, _Precompiled = ___fm_ToString };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["normalized"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["normalized"]._Method, _Precompiled = ___gf_normalized };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                _IndexAccessor["get"] = new LuaMetaCallWithPrecompiled() { _Precompiled = ___gfi_Index };
                _IndexAccessor["set"] = new LuaMetaCallWithPrecompiled() { _Precompiled = ___sfi_Index };
                #endregion // REG_I_INDEX
            }
            public override void RegPrecompiledStatic()
            {
                #region REG_I_CTOR
                _Ctor._Precompiled = ___fm_ctor;
                #endregion // REG_I_CTOR
                #region REG_S_FUNC
                _StaticMethods["Normalize"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Normalize"]._Method, _Precompiled = ___sfm_Normalize };
                _StaticMethods["Distance"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Distance"]._Method, _Precompiled = ___sfm_Distance };
                _StaticMethods["Dot"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Dot"]._Method, _Precompiled = ___sfm_Dot };
                _StaticMethods["Lerp"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Lerp"]._Method, _Precompiled = ___sfm_Lerp };
                _StaticMethods["Magnitude"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Magnitude"]._Method, _Precompiled = ___sfm_Magnitude };
                _StaticMethods["op_Multiply"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Multiply"]._Method, _Precompiled = ___sfm_op_Multiply };
                _StaticMethods["op_Subtraction"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Subtraction"]._Method, _Precompiled = ___sfm_op_Subtraction };
                _StaticMethods["op_Addition"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Addition"]._Method, _Precompiled = ___sfm_op_Addition };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                _StaticFieldsIndex["up"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["up"]._Method, _Precompiled = ___sgf_up };
                _StaticFieldsIndex["one"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["one"]._Method, _Precompiled = ___sgf_one };
                _StaticFieldsIndex["left"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["left"]._Method, _Precompiled = ___sgf_left };
                _StaticFieldsIndex["down"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["down"]._Method, _Precompiled = ___sgf_down };
                _StaticFieldsIndex["back"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["back"]._Method, _Precompiled = ___sgf_back };
                _StaticFieldsIndex["forward"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["forward"]._Method, _Precompiled = ___sgf_forward };
                _StaticFieldsIndex["zero"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["zero"]._Method, _Precompiled = ___sgf_zero };
                _StaticFieldsIndex["right"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["right"]._Method, _Precompiled = ___sgf_right };
                _StaticFieldsIndex["fwd"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["fwd"]._Method, _Precompiled = ___sgf_fwd };
                #endregion // REG_S_PROP
                #region REG_G_S_FUNC
                #endregion // REG_G_S_FUNC
                #region REG_S_OP
                _Ops["__mul"] = new LuaMetaCallWithPrecompiled() { _Method = _Ops["__mul"]._Method, _Precompiled = ___opf__mul };
                _Ops["__sub"] = new LuaMetaCallWithPrecompiled() { _Method = _Ops["__sub"]._Method, _Precompiled = ___opf__sub };
                _Ops["__add"] = new LuaMetaCallWithPrecompiled() { _Method = _Ops["__add"]._Method, _Precompiled = ___opf__add };
                #endregion // REG_S_OP
                #region REG_S_CONV
                #endregion // REG_S_CONV
                #region REG_G_GTYPES
                #endregion // REG_G_GTYPES
            }
            
            #region DEL_I_CTOR
            private static readonly lua.CFunction ___fm_ctor = new lua.CFunction(___mm_ctor);
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            private static readonly lua.CFunction ___fm_Normalize = new lua.CFunction(___mm_Normalize);
            private static readonly lua.CFunction ___fm_ToString = new lua.CFunction(___mm_ToString);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_normalized = new lua.CFunction(___gm_normalized);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_Normalize = new lua.CFunction(___smm_Normalize);
            private static readonly lua.CFunction ___sfm_Distance = new lua.CFunction(___smm_Distance);
            private static readonly lua.CFunction ___sfm_Dot = new lua.CFunction(___smm_Dot);
            private static readonly lua.CFunction ___sfm_Lerp = new lua.CFunction(___smm_Lerp);
            private static readonly lua.CFunction ___sfm_Magnitude = new lua.CFunction(___smm_Magnitude);
            private static readonly lua.CFunction ___sfm_op_Multiply = new lua.CFunction(___smm_op_Multiply);
            private static readonly lua.CFunction ___sfm_op_Subtraction = new lua.CFunction(___smm_op_Subtraction);
            private static readonly lua.CFunction ___sfm_op_Addition = new lua.CFunction(___smm_op_Addition);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_up = new lua.CFunction(___sgm_up);
            private static readonly lua.CFunction ___sgf_one = new lua.CFunction(___sgm_one);
            private static readonly lua.CFunction ___sgf_left = new lua.CFunction(___sgm_left);
            private static readonly lua.CFunction ___sgf_down = new lua.CFunction(___sgm_down);
            private static readonly lua.CFunction ___sgf_back = new lua.CFunction(___sgm_back);
            private static readonly lua.CFunction ___sgf_forward = new lua.CFunction(___sgm_forward);
            private static readonly lua.CFunction ___sgf_zero = new lua.CFunction(___sgm_zero);
            private static readonly lua.CFunction ___sgf_right = new lua.CFunction(___sgm_right);
            private static readonly lua.CFunction ___sgf_fwd = new lua.CFunction(___sgm_fwd);
            #endregion // DEL_S_PROP
            #region DEL_G_I_FUNC
            #endregion // DEL_G_I_FUNC
            #region DEL_I_INDEX
            private static readonly lua.CFunction ___gfi_Index = new lua.CFunction(___gmi_Index);
            private static readonly lua.CFunction ___sfi_Index = new lua.CFunction(___smi_Index);
            #endregion // DEL_I_INDEX
            #region DEL_G_S_FUNC
            #endregion // DEL_G_S_FUNC
            #region DEL_S_OP
            private static readonly lua.CFunction ___opf__mul = new lua.CFunction(___opm__mul);
            private static readonly lua.CFunction ___opf__sub = new lua.CFunction(___opm__sub);
            private static readonly lua.CFunction ___opf__add = new lua.CFunction(___opm__add);
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
                            else if (oldtop == 3)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            var rv = new UnityEngine.Vector3(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            var rv = new UnityEngine.Vector3(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            var rv = default(UnityEngine.Vector3);
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
            private static int ___mm_Normalize(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    p0 = GetLuaChecked(l, 1);
                    p0.Normalize();
                    SetDataRaw(l, 1, p0);
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
                            UnityEngine.Vector3 p0;
                            p0 = GetLuaChecked(l, 1);
                            var rv = p0.ToString();
                            l.PushLua(rv);
                            //SetDataRaw(l, 1, p0);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Vector3 p0;
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
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_normalized(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.normalized;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            #endregion // FUNC_I_PROP
            #region FUNC_S_FUNC
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Normalize(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.Vector3.Normalize(p0);
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
            private static int ___smm_Distance(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector3 p1;
                    l.GetLua(2, out p1);
                    var rv = UnityEngine.Vector3.Distance(p0, p1);
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
            private static int ___smm_Dot(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector3 p1;
                    l.GetLua(2, out p1);
                    var rv = UnityEngine.Vector3.Dot(p0, p1);
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
            private static int ___smm_Lerp(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector3 p1;
                    l.GetLua(2, out p1);
                    System.Single p2;
                    l.GetLua(3, out p2);
                    var rv = UnityEngine.Vector3.Lerp(p0, p1, p2);
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
            private static int ___smm_Magnitude(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.Vector3.Magnitude(p0);
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
                    {
                        {
                            {
                                {
                                    var ___lt0 = l.type(1);
                                    if (___lt0 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_20;
                                    }
                                    var ___lt1 = l.type(2);
                                    if (___lt1 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_10;
                                    }
                                    {
                                        var ___ot0 = l.GetType(1);
                                        if (___ot0 == typeof(System.Single))
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
                            UnityEngine.Vector3 p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            var rv = p0 * p1;
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Single p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            var rv = p0 * p1;
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
            private static int ___smm_op_Subtraction(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector3 p1;
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
            private static int ___smm_op_Addition(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector3 p1;
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
            #endregion // FUNC_S_FUNC
            #region FUNC_S_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_up(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector3.up;
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
            private static int ___sgm_one(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector3.one;
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
            private static int ___sgm_left(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector3.left;
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
            private static int ___sgm_down(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector3.down;
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
            private static int ___sgm_back(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector3.back;
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
            private static int ___sgm_forward(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector3.forward;
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
            private static int ___sgm_zero(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector3.zero;
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
            private static int ___sgm_right(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector3.right;
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
            private static int ___sgm_fwd(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector3.fwd;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gmi_Index(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    p0 = GetLuaChecked(l, 1);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    var rv = p0[p1];
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
            private static int ___smi_Index(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector3 p0;
                    p0 = GetLuaChecked(l, 1);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    System.Single p2;
                    l.GetLua(3, out p2);
                    p0[p1] = p2;
                    SetDataRaw(l, 1, p0);
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            #endregion // FUNC_I_INDEX
            #region FUNC_G_S_FUNC
            #endregion // FUNC_G_S_FUNC
            #region FUNC_S_OP
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
            #endregion // FUNC_S_OP
            #region FUNC_S_CONV
            #endregion // FUNC_S_CONV
            #region FUNC_G_GTYPES
            #endregion // FUNC_G_GTYPES
            
            #region NESTED_TYPE_HUB
            #endregion // NESTED_TYPE_HUB
            
            public static readonly LuaString LS_X = new LuaString("x");
            public static readonly LuaString LS_Y = new LuaString("y");
            public static readonly LuaString LS_Z = new LuaString("z");
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.Vector3)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.Vector3)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.Vector3 GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.Vector3);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.Vector3 val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHubC.Ready)
                {
                    LuaHubC.capslua_pushVector3(l, val.x, val.y, val.z);
                }
                else
                #endif
                {
                    l.checkstack(3);
                    l.newtable(); // ud
                    SetDataRaw(l, -1, val);
                    //l.pushlightuserdata(LuaConst.LRKEY_TYPE_TRANS); // ud #trans
                    //l.pushlightuserdata(r); // ud #trans trans
                    //l.rawset(-3); // ud
                    
                    PushToLuaCached(l); // ud type
                    l.pushlightuserdata(LuaConst.LRKEY_OBJ_META); // ud type #meta
                    l.rawget(-2); // ud type meta
                    l.setmetatable(-3); // ud type
                    l.pop(1); // ud
                }
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, UnityEngine.Vector3 val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.Vector3 GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.Vector3 val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHubC.Ready)
                {
                    LuaHubC.capslua_setVector3(l, index, val.x, val.y, val.z);
                }
                else
                #endif
                {
                    l.checkstack(3);
                    l.pushvalue(index); // otab
                    l.PushString(LS_X); // otab "x"
                    l.pushnumber(val.x); // otab "x" x
                    l.rawset(-3); // otab
                    l.PushString(LS_Y);
                    l.pushnumber(val.y);
                    l.rawset(-3);
                    l.PushString(LS_Z);
                    l.pushnumber(val.z);
                    l.rawset(-3);
                    l.pop(1);
                }
            }
            public static UnityEngine.Vector3 GetLuaRaw(IntPtr l, int index)
            {
                UnityEngine.Vector3 rv = new UnityEngine.Vector3();
                #if !DISABLE_LUA_HUB_C
                if (LuaHubC.Ready)
                {
                    LuaHubC.capslua_getVector3(l, index, out rv.x, out rv.y, out rv.z);
                }
                else
                #endif
                {
                    l.checkstack(2);
                    l.pushvalue(index); // otab
                    l.PushString(LS_X); // otab "x"
                    l.rawget(-2); // otab x
                    l.GetLua(-1, out rv.x);
                    l.pop(1); // otab
                    l.PushString(LS_Y); // otab "y"
                    l.rawget(-2); // otab y
                    l.GetLua(-1, out rv.y);
                    l.pop(1); // otab
                    l.PushString(LS_Z); // otab "z"
                    l.rawget(-2); // otab z
                    l.GetLua(-1, out rv.z);
                    l.pop(2); // X
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_Vector3 ___tp_UnityEngine_Vector3 = new TypeHubPrecompiled_UnityEngine_Vector3();
        public static void PushLua(this IntPtr l, UnityEngine.Vector3 val)
        {
            ___tp_UnityEngine_Vector3.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Vector3 val)
        {
            val = TypeHubPrecompiled_UnityEngine_Vector3.GetLuaChecked(l, index);
        }
    }
}
#endif
