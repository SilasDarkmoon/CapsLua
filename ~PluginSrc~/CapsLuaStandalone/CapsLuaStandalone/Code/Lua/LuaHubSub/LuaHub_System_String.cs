#pragma warning disable CS0162
#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHubEx
    {
        public class TypeHubPrecompiled_System_String : Capstones.LuaLib.LuaTypeHub.TypeHubCommonPrecompiled
        {
            public TypeHubPrecompiled_System_String() : this(typeof(System.String)) { }
            public TypeHubPrecompiled_System_String(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["ToString"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ToString"]._Method, _Precompiled = ___fm_ToString };
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
                _StaticMethods["Format"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Format"]._Method, _Precompiled = ___sfm_Format };
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
            private static readonly lua.CFunction ___fm_ToString = new lua.CFunction(___mm_ToString);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_Format = new lua.CFunction(___smm_Format);
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
                            else if (oldtop == 2)
                            {
                                goto Label_20;
                            }
                            else
                            {
                                int ___lt1;
                                var ___ot1 = l.GetType(2, out ___lt1);
                                if (___ot1 == typeof(System.IFormatProvider) || typeof(System.IFormatProvider).IsAssignableFrom(___ot1))
                                {
                                    goto Label_20;
                                }
                                goto Label_10;
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
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            #endregion // FUNC_I_PROP
            #region FUNC_S_FUNC
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
                                goto Label_42;
                            }
                            else
                            {
                                int ___lt0;
                                var ___ot0 = l.GetType(1, out ___lt0);
                                if (___ot0 == typeof(System.IFormatProvider) || typeof(System.IFormatProvider).IsAssignableFrom(___ot0))
                                {
                                    int ___lt3;
                                    var ___ot3 = l.GetType(4, out ___lt3);
                                    if (___ot3 != null)
                                    {
                                        int ___lt4;
                                        var ___ot4 = l.GetType(5, out ___lt4);
                                        if (___ot4 != null)
                                        {
                                            int ___lt5;
                                            var ___ot5 = l.GetType(6, out ___lt5);
                                            if (___ot5 != null)
                                            {
                                                goto Label_82;
                                            }
                                            goto Label_70;
                                        }
                                        {
                                            goto Label_60;
                                        }
                                    }
                                    {
                                        int ___lt2;
                                        var ___ot2 = l.GetType(3, out ___lt2);
                                        if (___ot2 == typeof(System.Object[]))
                                        {
                                            goto Label_81;
                                        }
                                        if (___ot2 != null)
                                        {
                                            goto Label_50;
                                        }
                                        {
                                            goto Label_82;
                                        }
                                    }
                                }
                                {
                                    int ___lt2;
                                    var ___ot2 = l.GetType(3, out ___lt2);
                                    if (___ot2 != null)
                                    {
                                        int ___lt3;
                                        var ___ot3 = l.GetType(4, out ___lt3);
                                        if (___ot3 != null)
                                        {
                                            int ___lt4;
                                            var ___ot4 = l.GetType(5, out ___lt4);
                                            if (___ot4 != null)
                                            {
                                                goto Label_42;
                                            }
                                            {
                                                goto Label_30;
                                            }
                                        }
                                        {
                                            goto Label_20;
                                        }
                                    }
                                    {
                                        int ___lt1;
                                        var ___ot1 = l.GetType(2, out ___lt1);
                                        if (___ot1 == typeof(System.Object[]))
                                        {
                                            goto Label_41;
                                        }
                                        if (___ot1 != null)
                                        {
                                            goto Label_10;
                                        }
                                        {
                                            goto Label_42;
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
                            System.IFormatProvider p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            var rv = System.String.Format(p0, p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            System.IFormatProvider p0;
                            l.GetLua(1, out p0);
                            System.String p1;
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
                        Label_70:
                        {
                            System.IFormatProvider p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            System.Object p3;
                            l.GetLua(4, out p3);
                            System.Object p4;
                            l.GetLua(5, out p4);
                            var rv = System.String.Format(p0, p1, p2, p3, p4);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_80:
                        {
                            var ltype = l.GetType(3);
                            if (ltype == typeof(System.Object[])) goto Label_81;
                            else goto Label_82;
                        }
                        goto Label_default;
                        Label_81:
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
                        Label_82:
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
        private static Capstones.LuaLib.LuaTypeHub.TypeHubCreator<TypeHubPrecompiled_System_String> ___tp_System_String = new Capstones.LuaLib.LuaTypeHub.TypeHubCreator<TypeHubPrecompiled_System_String>(typeof(System.String));
    }
}
#endif
#pragma warning restore CS0162
