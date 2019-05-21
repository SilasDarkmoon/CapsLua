#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_System_String : Capstones.LuaLib.LuaTypeHub.TypeHubCommonPrecompiled
        {
            public TypeHubPrecompiled_System_String() : this(typeof(System.String)) { }
            public TypeHubPrecompiled_System_String(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["Equals"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Equals"]._Method, _Precompiled = ___fm_Equals };
                _InstanceMethods["Clone"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Clone"]._Method, _Precompiled = ___fm_Clone };
                _InstanceMethods["CopyTo"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["CopyTo"]._Method, _Precompiled = ___fm_CopyTo };
                _InstanceMethods["ToCharArray"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToCharArray"]._Method, _Precompiled = ___fm_ToCharArray };
                _InstanceMethods["Substring"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Substring"]._Method, _Precompiled = ___fm_Substring };
                _InstanceMethods["Trim"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Trim"]._Method, _Precompiled = ___fm_Trim };
                _InstanceMethods["TrimStart"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["TrimStart"]._Method, _Precompiled = ___fm_TrimStart };
                _InstanceMethods["TrimEnd"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["TrimEnd"]._Method, _Precompiled = ___fm_TrimEnd };
                _InstanceMethods["CompareTo"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["CompareTo"]._Method, _Precompiled = ___fm_CompareTo };
                _InstanceMethods["EndsWith"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["EndsWith"]._Method, _Precompiled = ___fm_EndsWith };
                _InstanceMethods["IndexOfAny"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["IndexOfAny"]._Method, _Precompiled = ___fm_IndexOfAny };
                _InstanceMethods["LastIndexOfAny"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["LastIndexOfAny"]._Method, _Precompiled = ___fm_LastIndexOfAny };
                _InstanceMethods["Contains"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Contains"]._Method, _Precompiled = ___fm_Contains };
                _InstanceMethods["PadLeft"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["PadLeft"]._Method, _Precompiled = ___fm_PadLeft };
                _InstanceMethods["PadRight"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["PadRight"]._Method, _Precompiled = ___fm_PadRight };
                _InstanceMethods["StartsWith"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["StartsWith"]._Method, _Precompiled = ___fm_StartsWith };
                _InstanceMethods["Replace"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Replace"]._Method, _Precompiled = ___fm_Replace };
                _InstanceMethods["Remove"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Remove"]._Method, _Precompiled = ___fm_Remove };
                _InstanceMethods["ToLower"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToLower"]._Method, _Precompiled = ___fm_ToLower };
                _InstanceMethods["ToLowerInvariant"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToLowerInvariant"]._Method, _Precompiled = ___fm_ToLowerInvariant };
                _InstanceMethods["ToUpper"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToUpper"]._Method, _Precompiled = ___fm_ToUpper };
                _InstanceMethods["ToUpperInvariant"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToUpperInvariant"]._Method, _Precompiled = ___fm_ToUpperInvariant };
                _InstanceMethods["ToString"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToString"]._Method, _Precompiled = ___fm_ToString };
                _InstanceMethods["Insert"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Insert"]._Method, _Precompiled = ___fm_Insert };
                _InstanceMethods["Split"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Split"]._Method, _Precompiled = ___fm_Split };
                _InstanceMethods["IndexOf"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["IndexOf"]._Method, _Precompiled = ___fm_IndexOf };
                _InstanceMethods["LastIndexOf"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["LastIndexOf"]._Method, _Precompiled = ___fm_LastIndexOf };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["Length"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["Length"]._Method, _Precompiled = ___gf_Length };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                _IndexAccessor["get"] = new LuaMetaCallWithPrecompiled() { _Precompiled = ___gfi_Index };
                #endregion // REG_I_INDEX
            }
            public override void RegPrecompiledStatic()
            {
                #region REG_I_CTOR
                _Ctor._Precompiled = ___fm_ctor;
                #endregion // REG_I_CTOR
                #region REG_S_FUNC
                _StaticMethods["Equals"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Equals"]._Method, _Precompiled = ___sfm_Equals };
                _StaticMethods["Compare"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Compare"]._Method, _Precompiled = ___sfm_Compare };
                _StaticMethods["CompareOrdinal"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["CompareOrdinal"]._Method, _Precompiled = ___sfm_CompareOrdinal };
                _StaticMethods["IsNullOrEmpty"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["IsNullOrEmpty"]._Method, _Precompiled = ___sfm_IsNullOrEmpty };
                _StaticMethods["Format"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Format"]._Method, _Precompiled = ___sfm_Format };
                _StaticMethods["Intern"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Intern"]._Method, _Precompiled = ___sfm_Intern };
                _StaticMethods["IsInterned"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["IsInterned"]._Method, _Precompiled = ___sfm_IsInterned };
                _StaticMethods["Join"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Join"]._Method, _Precompiled = ___sfm_Join };
                _StaticMethods["op_Equality"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Equality"]._Method, _Precompiled = ___sfm_op_Equality };
                _StaticMethods["op_Inequality"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Inequality"]._Method, _Precompiled = ___sfm_op_Inequality };
                _StaticMethods["Concat"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Concat"]._Method, _Precompiled = ___sfm_Concat };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                _StaticFieldsIndex["Empty"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["Empty"]._Method, _Precompiled = ___sgf_Empty };
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
            private static readonly lua.CFunction ___fm_ctor = new lua.CFunction(___mm_ctor);
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            private static readonly lua.CFunction ___fm_Equals = new lua.CFunction(___mm_Equals);
            private static readonly lua.CFunction ___fm_Clone = new lua.CFunction(___mm_Clone);
            private static readonly lua.CFunction ___fm_CopyTo = new lua.CFunction(___mm_CopyTo);
            private static readonly lua.CFunction ___fm_ToCharArray = new lua.CFunction(___mm_ToCharArray);
            private static readonly lua.CFunction ___fm_Substring = new lua.CFunction(___mm_Substring);
            private static readonly lua.CFunction ___fm_Trim = new lua.CFunction(___mm_Trim);
            private static readonly lua.CFunction ___fm_TrimStart = new lua.CFunction(___mm_TrimStart);
            private static readonly lua.CFunction ___fm_TrimEnd = new lua.CFunction(___mm_TrimEnd);
            private static readonly lua.CFunction ___fm_CompareTo = new lua.CFunction(___mm_CompareTo);
            private static readonly lua.CFunction ___fm_EndsWith = new lua.CFunction(___mm_EndsWith);
            private static readonly lua.CFunction ___fm_IndexOfAny = new lua.CFunction(___mm_IndexOfAny);
            private static readonly lua.CFunction ___fm_LastIndexOfAny = new lua.CFunction(___mm_LastIndexOfAny);
            private static readonly lua.CFunction ___fm_Contains = new lua.CFunction(___mm_Contains);
            private static readonly lua.CFunction ___fm_PadLeft = new lua.CFunction(___mm_PadLeft);
            private static readonly lua.CFunction ___fm_PadRight = new lua.CFunction(___mm_PadRight);
            private static readonly lua.CFunction ___fm_StartsWith = new lua.CFunction(___mm_StartsWith);
            private static readonly lua.CFunction ___fm_Replace = new lua.CFunction(___mm_Replace);
            private static readonly lua.CFunction ___fm_Remove = new lua.CFunction(___mm_Remove);
            private static readonly lua.CFunction ___fm_ToLower = new lua.CFunction(___mm_ToLower);
            private static readonly lua.CFunction ___fm_ToLowerInvariant = new lua.CFunction(___mm_ToLowerInvariant);
            private static readonly lua.CFunction ___fm_ToUpper = new lua.CFunction(___mm_ToUpper);
            private static readonly lua.CFunction ___fm_ToUpperInvariant = new lua.CFunction(___mm_ToUpperInvariant);
            private static readonly lua.CFunction ___fm_ToString = new lua.CFunction(___mm_ToString);
            private static readonly lua.CFunction ___fm_Insert = new lua.CFunction(___mm_Insert);
            private static readonly lua.CFunction ___fm_Split = new lua.CFunction(___mm_Split);
            private static readonly lua.CFunction ___fm_IndexOf = new lua.CFunction(___mm_IndexOf);
            private static readonly lua.CFunction ___fm_LastIndexOf = new lua.CFunction(___mm_LastIndexOf);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_Length = new lua.CFunction(___gm_Length);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_Equals = new lua.CFunction(___smm_Equals);
            private static readonly lua.CFunction ___sfm_Compare = new lua.CFunction(___smm_Compare);
            private static readonly lua.CFunction ___sfm_CompareOrdinal = new lua.CFunction(___smm_CompareOrdinal);
            private static readonly lua.CFunction ___sfm_IsNullOrEmpty = new lua.CFunction(___smm_IsNullOrEmpty);
            private static readonly lua.CFunction ___sfm_Format = new lua.CFunction(___smm_Format);
            private static readonly lua.CFunction ___sfm_Intern = new lua.CFunction(___smm_Intern);
            private static readonly lua.CFunction ___sfm_IsInterned = new lua.CFunction(___smm_IsInterned);
            private static readonly lua.CFunction ___sfm_Join = new lua.CFunction(___smm_Join);
            private static readonly lua.CFunction ___sfm_op_Equality = new lua.CFunction(___smm_op_Equality);
            private static readonly lua.CFunction ___sfm_op_Inequality = new lua.CFunction(___smm_op_Inequality);
            private static readonly lua.CFunction ___sfm_Concat = new lua.CFunction(___smm_Concat);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_Empty = new lua.CFunction(___sgm_Empty);
            #endregion // DEL_S_PROP
            #region DEL_G_I_FUNC
            #endregion // DEL_G_I_FUNC
            #region DEL_I_INDEX
            private static readonly lua.CFunction ___gfi_Index = new lua.CFunction(___gmi_Index);
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
                            if (oldtop == 2)
                            {
                                goto Label_20;
                            }
                            else if (oldtop == 3)
                            {
                                goto Label_30;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            var rv = new System.String(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            var rv = new System.String(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.Char p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = new System.String(p1, p2);
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
                    {
                        {
                            {
                                {
                                    var ___lt1 = l.type(2);
                                    if (___lt1 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.String))
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
                            System.Object p1;
                            l.GetLua(2, out p1);
                            var rv = p0.Equals(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = p0.Equals(p1);
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
            private static int ___mm_Clone(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = p0.Clone();
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
            private static int ___mm_CopyTo(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    System.Char[] p2;
                    l.GetLua(3, out p2);
                    System.Int32 p3;
                    l.GetLua(4, out p3);
                    System.Int32 p4;
                    l.GetLua(5, out p4);
                    p0.CopyTo(p1, p2, p3, p4);
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
            private static int ___mm_ToCharArray(IntPtr l)
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
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            var rv = p0.ToCharArray();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = p0.ToCharArray(p1, p2);
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
            private static int ___mm_Substring(IntPtr l)
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
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            var rv = p0.Substring(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = p0.Substring(p1, p2);
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
            private static int ___mm_Trim(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop > 1)
                            {
                                goto Label_22;
                            }
                            else
                            {
                                if (oldtop == 1)
                                {
                                    goto Label_10;
                                }
                                else
                                {
                                    goto Label_20;
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            var rv = p0.Trim();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            var ltype = l.GetType(2);
                            if (ltype == typeof(System.Char[])) goto Label_21;
                            else goto Label_22;
                        }
                        goto Label_default;
                        Label_21:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            var rv = p0.Trim(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_22:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            var paramscnt = l.gettop() - 1;
                            paramscnt = paramscnt < 0 ? 0 : paramscnt;
                            p1 = new System.Char[paramscnt];
                            for (int i = 0; i < paramscnt; ++i)
                            {
                                System.Char paramval;
                                l.GetLua(i + 2, out paramval);
                                p1[i] = paramval;
                            }
                            var rv = p0.Trim(p1);
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
            private static int ___mm_TrimStart(IntPtr l)
            {
                try
                {
                    var ltype = l.GetType(2);
                    if (ltype == typeof(System.Char[]))
                    {
                        System.String p0;
                        l.GetLua(1, out p0);
                        System.Char[] p1;
                        l.GetLua(2, out p1);
                        var rv = p0.TrimStart(p1);
                        l.PushLua(rv);
                        return 1;
                    }
                    else
                    {
                        System.String p0;
                        l.GetLua(1, out p0);
                        System.Char[] p1;
                        var paramscnt = l.gettop() - 1;
                        paramscnt = paramscnt < 0 ? 0 : paramscnt;
                        p1 = new System.Char[paramscnt];
                        for (int i = 0; i < paramscnt; ++i)
                        {
                            System.Char paramval;
                            l.GetLua(i + 2, out paramval);
                            p1[i] = paramval;
                        }
                        var rv = p0.TrimStart(p1);
                        l.PushLua(rv);
                        return 1;
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
            private static int ___mm_TrimEnd(IntPtr l)
            {
                try
                {
                    var ltype = l.GetType(2);
                    if (ltype == typeof(System.Char[]))
                    {
                        System.String p0;
                        l.GetLua(1, out p0);
                        System.Char[] p1;
                        l.GetLua(2, out p1);
                        var rv = p0.TrimEnd(p1);
                        l.PushLua(rv);
                        return 1;
                    }
                    else
                    {
                        System.String p0;
                        l.GetLua(1, out p0);
                        System.Char[] p1;
                        var paramscnt = l.gettop() - 1;
                        paramscnt = paramscnt < 0 ? 0 : paramscnt;
                        p1 = new System.Char[paramscnt];
                        for (int i = 0; i < paramscnt; ++i)
                        {
                            System.Char paramval;
                            l.GetLua(i + 2, out paramval);
                            p1[i] = paramval;
                        }
                        var rv = p0.TrimEnd(p1);
                        l.PushLua(rv);
                        return 1;
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
                                    if (___lt1 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.String))
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
                            System.Object p1;
                            l.GetLua(2, out p1);
                            var rv = p0.CompareTo(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = p0.CompareTo(p1);
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
            private static int ___mm_EndsWith(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    var rv = p0.EndsWith(p1);
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
            private static int ___mm_IndexOfAny(IntPtr l)
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
                            else if (oldtop == 3)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_30;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            var rv = p0.IndexOfAny(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = p0.IndexOfAny(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            var rv = p0.IndexOfAny(p1, p2, p3);
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
            private static int ___mm_LastIndexOfAny(IntPtr l)
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
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            var rv = p0.LastIndexOfAny(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = p0.LastIndexOfAny(p1, p2);
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
            private static int ___mm_Contains(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    var rv = p0.Contains(p1);
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
            private static int ___mm_PadLeft(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    System.Char p2;
                    l.GetLua(3, out p2);
                    var rv = p0.PadLeft(p1, p2);
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
            private static int ___mm_PadRight(IntPtr l)
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
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            var rv = p0.PadRight(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Char p2;
                            l.GetLua(3, out p2);
                            var rv = p0.PadRight(p1, p2);
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
            private static int ___mm_StartsWith(IntPtr l)
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
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = p0.StartsWith(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.StringComparison p2;
                            l.GetLua(3, out p2);
                            var rv = p0.StartsWith(p1, p2);
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
            private static int ___mm_Replace(IntPtr l)
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
                                        goto Label_10;
                                    }
                                    else if (___lt1 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_20;
                                    }
                                    var ___lt2 = l.type(3);
                                    if (___lt2 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_10;
                                    }
                                    else if (___lt2 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.String))
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
                            System.Char p1;
                            l.GetLua(2, out p1);
                            System.Char p2;
                            l.GetLua(3, out p2);
                            var rv = p0.Replace(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.String p2;
                            l.GetLua(3, out p2);
                            var rv = p0.Replace(p1, p2);
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
            private static int ___mm_Remove(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    System.Int32 p2;
                    l.GetLua(3, out p2);
                    var rv = p0.Remove(p1, p2);
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
            private static int ___mm_ToLower(IntPtr l)
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
                            System.String p0;
                            l.GetLua(1, out p0);
                            var rv = p0.ToLower();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Globalization.CultureInfo p1;
                            l.GetLua(2, out p1);
                            var rv = p0.ToLower(p1);
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
            private static int ___mm_ToLowerInvariant(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = p0.ToLowerInvariant();
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
            private static int ___mm_ToUpper(IntPtr l)
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
                            System.String p0;
                            l.GetLua(1, out p0);
                            var rv = p0.ToUpper();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Globalization.CultureInfo p1;
                            l.GetLua(2, out p1);
                            var rv = p0.ToUpper(p1);
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
            private static int ___mm_ToUpperInvariant(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = p0.ToUpperInvariant();
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
                            System.String p0;
                            l.GetLua(1, out p0);
                            var rv = p0.ToString();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.IFormatProvider p1;
                            l.GetLua(2, out p1);
                            var rv = p0.ToString(p1);
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
            private static int ___mm_Insert(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    System.String p2;
                    l.GetLua(3, out p2);
                    var rv = p0.Insert(p1, p2);
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
            private static int ___mm_Split(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop >= 1 && oldtop < 3)
                            {
                                goto Label_12;
                            }
                            else if (oldtop > 4)
                            {
                                goto Label_12;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.String[]))
                                        {
                                            var ___ot2 = l.GetType(3);
                                            if (___ot2 == typeof(System.StringSplitOptions))
                                            {
                                                goto Label_60;
                                            }
                                            goto Label_40;
                                        }
                                        {
                                            var ___ot2 = l.GetType(3);
                                            if (___ot2 == typeof(System.StringSplitOptions))
                                            {
                                                goto Label_50;
                                            }
                                            var ___ot3 = l.GetType(4);
                                            if (___ot3 == typeof(System.StringSplitOptions))
                                            {
                                                goto Label_30;
                                            }
                                            goto Label_20;
                                        }
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            var ltype = l.GetType(2);
                            if (ltype == typeof(System.Char[])) goto Label_11;
                            else goto Label_12;
                        }
                        goto Label_default;
                        Label_11:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            var rv = p0.Split(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_12:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            var paramscnt = l.gettop() - 1;
                            paramscnt = paramscnt < 0 ? 0 : paramscnt;
                            p1 = new System.Char[paramscnt];
                            for (int i = 0; i < paramscnt; ++i)
                            {
                                System.Char paramval;
                                l.GetLua(i + 2, out paramval);
                                p1[i] = paramval;
                            }
                            var rv = p0.Split(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = p0.Split(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.StringSplitOptions p3;
                            l.GetLua(4, out p3);
                            var rv = p0.Split(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String[] p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.StringSplitOptions p3;
                            l.GetLua(4, out p3);
                            var rv = p0.Split(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char[] p1;
                            l.GetLua(2, out p1);
                            System.StringSplitOptions p2;
                            l.GetLua(3, out p2);
                            var rv = p0.Split(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String[] p1;
                            l.GetLua(2, out p1);
                            System.StringSplitOptions p2;
                            l.GetLua(3, out p2);
                            var rv = p0.Split(p1, p2);
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
            private static int ___mm_IndexOf(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop >= 5)
                            {
                                goto Label_20;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(System.StringComparison))
                                        {
                                            goto Label_10;
                                        }
                                        var ___ot3 = l.GetType(4);
                                        if (___ot3 == typeof(System.Double) || ___ot3 == typeof(System.Int32))
                                        {
                                            var ___ot1 = l.GetType(2);
                                            if (___ot1 == typeof(System.String))
                                            {
                                                goto Label_80;
                                            }
                                            goto Label_50;
                                        }
                                        {
                                            var ___ot1 = l.GetType(2);
                                            if (___ot1 == typeof(System.String))
                                            {
                                                if (___ot2 == typeof(System.Double) || ___ot2 == typeof(System.Int32))
                                                {
                                                    goto Label_70;
                                                }
                                                goto Label_60;
                                            }
                                            {
                                                if (___ot2 == typeof(System.Double) || ___ot2 == typeof(System.Int32))
                                                {
                                                    goto Label_40;
                                                }
                                                goto Label_30;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.StringComparison p2;
                            l.GetLua(3, out p2);
                            var rv = p0.IndexOf(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            System.StringComparison p4;
                            l.GetLua(5, out p4);
                            var rv = p0.IndexOf(p1, p2, p3, p4);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char p1;
                            l.GetLua(2, out p1);
                            var rv = p0.IndexOf(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = p0.IndexOf(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            var rv = p0.IndexOf(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = p0.IndexOf(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_70:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = p0.IndexOf(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_80:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            var rv = p0.IndexOf(p1, p2, p3);
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
            private static int ___mm_LastIndexOf(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 3)
                            {
                                goto Label_20;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.String))
                                        {
                                            var ___ot2 = l.GetType(3);
                                            if (___ot2 == typeof(System.Double) || ___ot2 == typeof(System.Int32))
                                            {
                                                goto Label_50;
                                            }
                                            goto Label_40;
                                        }
                                        {
                                            var ___ot2 = l.GetType(3);
                                            if (___ot2 == typeof(System.Double) || ___ot2 == typeof(System.Int32))
                                            {
                                                goto Label_30;
                                            }
                                            goto Label_10;
                                        }
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char p1;
                            l.GetLua(2, out p1);
                            var rv = p0.LastIndexOf(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = p0.LastIndexOf(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Char p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            var rv = p0.LastIndexOf(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = p0.LastIndexOf(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            var rv = p0.LastIndexOf(p1, p2, p3);
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
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_Length(IntPtr l)
            {
                try
                {
                    System.String tar;
                    l.GetLua(1, out tar);
                    var rv = tar.Length;
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
            private static int ___smm_Equals(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    var rv = System.String.Equals(p0, p1);
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
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop == 3)
                            {
                                goto Label_20;
                            }
                            else if (oldtop == 4)
                            {
                                goto Label_30;
                            }
                            else if (oldtop >= 7)
                            {
                                goto Label_40;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = System.String.Compare(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Boolean p2;
                            l.GetLua(3, out p2);
                            var rv = System.String.Compare(p0, p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Boolean p2;
                            l.GetLua(3, out p2);
                            System.Globalization.CultureInfo p3;
                            l.GetLua(4, out p3);
                            var rv = System.String.Compare(p0, p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.String p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            System.Int32 p4;
                            l.GetLua(5, out p4);
                            System.Boolean p5;
                            l.GetLua(6, out p5);
                            System.Globalization.CultureInfo p6;
                            l.GetLua(7, out p6);
                            var rv = System.String.Compare(p0, p1, p2, p3, p4, p5, p6);
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
            private static int ___smm_CompareOrdinal(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    System.String p2;
                    l.GetLua(3, out p2);
                    System.Int32 p3;
                    l.GetLua(4, out p3);
                    System.Int32 p4;
                    l.GetLua(5, out p4);
                    var rv = System.String.CompareOrdinal(p0, p1, p2, p3, p4);
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
            private static int ___smm_IsNullOrEmpty(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = System.String.IsNullOrEmpty(p0);
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
            private static int ___smm_Format(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 1)
                            {
                                goto Label_40;
                            }
                            else
                            {
                                {
                                    var ___lt1 = l.type(2);
                                    if (___lt1 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_50;
                                    }
                                    {
                                        var ___ot0 = l.GetType(1);
                                        if (___ot0 == typeof(System.IFormatProvider) || typeof(System.IFormatProvider).IsAssignableFrom(___ot0))
                                        {
                                            goto Label_50;
                                        }
                                        var ___ot3 = l.GetType(4);
                                        if (___ot3 == typeof(System.Object) || typeof(System.Object).IsAssignableFrom(___ot3))
                                        {
                                            goto Label_30;
                                        }
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(System.Object) || typeof(System.Object).IsAssignableFrom(___ot2))
                                        {
                                            goto Label_20;
                                        }
                                        goto Label_10;
                                        if (___ot2 == typeof(System.Object[]))
                                        {
                                            goto Label_51;
                                        }
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Object p1;
                            l.GetLua(2, out p1);
                            var rv = System.String.Format(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Object p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            var rv = System.String.Format(p0, p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Object p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            System.Object p3;
                            l.GetLua(4, out p3);
                            var rv = System.String.Format(p0, p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            var ltype = l.GetType(2);
                            if (ltype == typeof(System.Object[])) goto Label_41;
                            else goto Label_42;
                        }
                        goto Label_default;
                        Label_41:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Object[] p1;
                            l.GetLua(2, out p1);
                            var rv = System.String.Format(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_42:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Object[] p1;
                            var paramscnt = l.gettop() - 1;
                            paramscnt = paramscnt < 0 ? 0 : paramscnt;
                            p1 = new System.Object[paramscnt];
                            for (int i = 0; i < paramscnt; ++i)
                            {
                                System.Object paramval;
                                l.GetLua(i + 2, out paramval);
                                p1[i] = paramval;
                            }
                            var rv = System.String.Format(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            var ltype = l.GetType(3);
                            if (ltype == typeof(System.Object[])) goto Label_51;
                            else goto Label_52;
                        }
                        goto Label_default;
                        Label_51:
                        {
                            System.IFormatProvider p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object[] p2;
                            l.GetLua(3, out p2);
                            var rv = System.String.Format(p0, p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_52:
                        {
                            System.IFormatProvider p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object[] p2;
                            var paramscnt = l.gettop() - 2;
                            paramscnt = paramscnt < 0 ? 0 : paramscnt;
                            p2 = new System.Object[paramscnt];
                            for (int i = 0; i < paramscnt; ++i)
                            {
                                System.Object paramval;
                                l.GetLua(i + 3, out paramval);
                                p2[i] = paramval;
                            }
                            var rv = System.String.Format(p0, p1, p2);
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
            private static int ___smm_Intern(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = System.String.Intern(p0);
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
            private static int ___smm_IsInterned(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = System.String.IsInterned(p0);
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
            private static int ___smm_Join(IntPtr l)
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
                            System.String[] p1;
                            l.GetLua(2, out p1);
                            var rv = System.String.Join(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String[] p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            var rv = System.String.Join(p0, p1, p2, p3);
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
            private static int ___smm_op_Equality(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.String p1;
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
                    System.String p0;
                    l.GetLua(1, out p0);
                    System.String p1;
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
            private static int ___smm_Concat(IntPtr l)
            {
                try
                {
                    {
                        {
                            {
                                {
                                    var ___lt3 = l.type(4);
                                    if (___lt3 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_50;
                                    }
                                    {
                                        var ___ot3 = l.GetType(4);
                                        if (___ot3 == typeof(System.String))
                                        {
                                            goto Label_50;
                                        }
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(System.String))
                                        {
                                            goto Label_40;
                                        }
                                        var ___ot0 = l.GetType(1);
                                        if (___ot0 == typeof(System.String))
                                        {
                                            goto Label_30;
                                        }
                                        if (___ot2 == typeof(System.Object) || typeof(System.Object).IsAssignableFrom(___ot2))
                                        {
                                            goto Label_20;
                                        }
                                        if (___ot0 == typeof(System.Object) || typeof(System.Object).IsAssignableFrom(___ot0))
                                        {
                                            goto Label_10;
                                        }
                                        if (___ot0 == typeof(System.String[]))
                                        {
                                            goto Label_71;
                                        }
                                        if (___ot0 == typeof(System.Object[]))
                                        {
                                            goto Label_61;
                                        }
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.Object p0;
                            l.GetLua(1, out p0);
                            System.Object p1;
                            l.GetLua(2, out p1);
                            var rv = System.String.Concat(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Object p0;
                            l.GetLua(1, out p0);
                            System.Object p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            var rv = System.String.Concat(p0, p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = System.String.Concat(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.String p2;
                            l.GetLua(3, out p2);
                            var rv = System.String.Concat(p0, p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.String p2;
                            l.GetLua(3, out p2);
                            System.String p3;
                            l.GetLua(4, out p3);
                            var rv = System.String.Concat(p0, p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            var ltype = l.GetType(1);
                            if (ltype == typeof(System.Object[])) goto Label_61;
                            else goto Label_62;
                        }
                        goto Label_default;
                        Label_61:
                        {
                            System.Object[] p0;
                            l.GetLua(1, out p0);
                            var rv = System.String.Concat(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_62:
                        {
                            System.Object[] p0;
                            var paramscnt = l.gettop() - 0;
                            paramscnt = paramscnt < 0 ? 0 : paramscnt;
                            p0 = new System.Object[paramscnt];
                            for (int i = 0; i < paramscnt; ++i)
                            {
                                System.Object paramval;
                                l.GetLua(i + 1, out paramval);
                                p0[i] = paramval;
                            }
                            var rv = System.String.Concat(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_70:
                        {
                            var ltype = l.GetType(1);
                            if (ltype == typeof(System.String[])) goto Label_71;
                            else goto Label_72;
                        }
                        goto Label_default;
                        Label_71:
                        {
                            System.String[] p0;
                            l.GetLua(1, out p0);
                            var rv = System.String.Concat(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_72:
                        {
                            System.String[] p0;
                            var paramscnt = l.gettop() - 0;
                            paramscnt = paramscnt < 0 ? 0 : paramscnt;
                            p0 = new System.String[paramscnt];
                            for (int i = 0; i < paramscnt; ++i)
                            {
                                System.String paramval;
                                l.GetLua(i + 1, out paramval);
                                p0[i] = paramval;
                            }
                            var rv = System.String.Concat(p0);
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
            private static int ___sgm_Empty(IntPtr l)
            {
                try
                {
                    var rv = System.String.Empty;
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
                    System.String p0;
                    l.GetLua(1, out p0);
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
        private static TypeHubPrecompiled_System_String ___tp_System_String = new TypeHubPrecompiled_System_String();
    }
}
#endif
