#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_System_Reflection_MemberInfo : Capstones.LuaLib.LuaTypeHub.TypeHubCommonPrecompiled
        {
            public TypeHubPrecompiled_System_Reflection_MemberInfo() : this(typeof(System.Reflection.MemberInfo)) { }
            public TypeHubPrecompiled_System_Reflection_MemberInfo(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["IsDefined"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["IsDefined"]._Method, _Precompiled = ___fm_IsDefined };
                _InstanceMethods["GetCustomAttributes"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetCustomAttributes"]._Method, _Precompiled = ___fm_GetCustomAttributes };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["DeclaringType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["DeclaringType"]._Method, _Precompiled = ___gf_DeclaringType };
                _InstanceFieldsIndex["MemberType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["MemberType"]._Method, _Precompiled = ___gf_MemberType };
                _InstanceFieldsIndex["Module"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["Module"]._Method, _Precompiled = ___gf_Module };
                _InstanceFieldsIndex["ReflectedType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["ReflectedType"]._Method, _Precompiled = ___gf_ReflectedType };
                _InstanceFieldsIndex["Name"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["Name"]._Method, _Precompiled = ___gf_Name };
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
            private static readonly lua.CFunction ___fm_IsDefined = new lua.CFunction(___mm_IsDefined);
            private static readonly lua.CFunction ___fm_GetCustomAttributes = new lua.CFunction(___mm_GetCustomAttributes);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_DeclaringType = new lua.CFunction(___gm_DeclaringType);
            private static readonly lua.CFunction ___gf_MemberType = new lua.CFunction(___gm_MemberType);
            private static readonly lua.CFunction ___gf_Module = new lua.CFunction(___gm_Module);
            private static readonly lua.CFunction ___gf_ReflectedType = new lua.CFunction(___gm_ReflectedType);
            private static readonly lua.CFunction ___gf_Name = new lua.CFunction(___gm_Name);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
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
            private static int ___mm_IsDefined(IntPtr l)
            {
                try
                {
                    System.Reflection.MemberInfo p0;
                    l.GetLua(1, out p0);
                    System.Type p1;
                    l.GetLua(2, out p1);
                    System.Boolean p2;
                    l.GetLua(3, out p2);
                    var rv = p0.IsDefined(p1, p2);
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
            private static int ___mm_GetCustomAttributes(IntPtr l)
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
                            System.Reflection.MemberInfo p0;
                            l.GetLua(1, out p0);
                            System.Boolean p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetCustomAttributes(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Reflection.MemberInfo p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            System.Boolean p2;
                            l.GetLua(3, out p2);
                            var rv = p0.GetCustomAttributes(p1, p2);
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
            private static int ___gm_DeclaringType(IntPtr l)
            {
                try
                {
                    System.Reflection.MemberInfo tar;
                    l.GetLua(1, out tar);
                    var rv = tar.DeclaringType;
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
            private static int ___gm_MemberType(IntPtr l)
            {
                try
                {
                    System.Reflection.MemberInfo tar;
                    l.GetLua(1, out tar);
                    var rv = tar.MemberType;
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
            private static int ___gm_Module(IntPtr l)
            {
                try
                {
                    System.Reflection.MemberInfo tar;
                    l.GetLua(1, out tar);
                    var rv = tar.Module;
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
            private static int ___gm_ReflectedType(IntPtr l)
            {
                try
                {
                    System.Reflection.MemberInfo tar;
                    l.GetLua(1, out tar);
                    var rv = tar.ReflectedType;
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
            private static int ___gm_Name(IntPtr l)
            {
                try
                {
                    System.Reflection.MemberInfo tar;
                    l.GetLua(1, out tar);
                    var rv = tar.Name;
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
        private static TypeHubPrecompiled_System_Reflection_MemberInfo ___tp_System_Reflection_MemberInfo = new TypeHubPrecompiled_System_Reflection_MemberInfo();
        public static void PushLua(this IntPtr l, System.Reflection.MemberInfo val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out System.Reflection.MemberInfo val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as System.Reflection.MemberInfo;
        }
    }
}
#endif
