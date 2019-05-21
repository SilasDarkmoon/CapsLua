#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_System_Type : TypeHubPrecompiled_System_Reflection_MemberInfo
        {
            public TypeHubPrecompiled_System_Type() : this(typeof(System.Type)) { }
            public TypeHubPrecompiled_System_Type(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["Equals"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Equals"]._Method, _Precompiled = ___fm_Equals };
                _InstanceMethods["GetType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetType"]._Method, _Precompiled = ___fm_GetType };
                _InstanceMethods["IsSubclassOf"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["IsSubclassOf"]._Method, _Precompiled = ___fm_IsSubclassOf };
                _InstanceMethods["GetInterfaces"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetInterfaces"]._Method, _Precompiled = ___fm_GetInterfaces };
                _InstanceMethods["IsAssignableFrom"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["IsAssignableFrom"]._Method, _Precompiled = ___fm_IsAssignableFrom };
                _InstanceMethods["IsInstanceOfType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["IsInstanceOfType"]._Method, _Precompiled = ___fm_IsInstanceOfType };
                _InstanceMethods["GetArrayRank"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetArrayRank"]._Method, _Precompiled = ___fm_GetArrayRank };
                _InstanceMethods["GetElementType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetElementType"]._Method, _Precompiled = ___fm_GetElementType };
                _InstanceMethods["GetEvent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetEvent"]._Method, _Precompiled = ___fm_GetEvent };
                _InstanceMethods["GetEvents"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetEvents"]._Method, _Precompiled = ___fm_GetEvents };
                _InstanceMethods["GetField"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetField"]._Method, _Precompiled = ___fm_GetField };
                _InstanceMethods["GetFields"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetFields"]._Method, _Precompiled = ___fm_GetFields };
                _InstanceMethods["GetMembers"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetMembers"]._Method, _Precompiled = ___fm_GetMembers };
                _InstanceMethods["GetMethod"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetMethod"]._Method, _Precompiled = ___fm_GetMethod };
                _InstanceMethods["GetMethods"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetMethods"]._Method, _Precompiled = ___fm_GetMethods };
                _InstanceMethods["GetNestedTypes"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetNestedTypes"]._Method, _Precompiled = ___fm_GetNestedTypes };
                _InstanceMethods["GetProperties"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetProperties"]._Method, _Precompiled = ___fm_GetProperties };
                _InstanceMethods["GetProperty"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetProperty"]._Method, _Precompiled = ___fm_GetProperty };
                _InstanceMethods["GetConstructor"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetConstructor"]._Method, _Precompiled = ___fm_GetConstructor };
                _InstanceMethods["GetConstructors"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetConstructors"]._Method, _Precompiled = ___fm_GetConstructors };
                _InstanceMethods["FindMembers"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["FindMembers"]._Method, _Precompiled = ___fm_FindMembers };
                _InstanceMethods["InvokeMember"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["InvokeMember"]._Method, _Precompiled = ___fm_InvokeMember };
                _InstanceMethods["GetGenericArguments"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetGenericArguments"]._Method, _Precompiled = ___fm_GetGenericArguments };
                _InstanceMethods["GetGenericTypeDefinition"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetGenericTypeDefinition"]._Method, _Precompiled = ___fm_GetGenericTypeDefinition };
                _InstanceMethods["MakeGenericType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["MakeGenericType"]._Method, _Precompiled = ___fm_MakeGenericType };
                _InstanceMethods["MakeByRefType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["MakeByRefType"]._Method, _Precompiled = ___fm_MakeByRefType };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["Assembly"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["Assembly"]._Method, _Precompiled = ___gf_Assembly };
                _InstanceFieldsIndex["AssemblyQualifiedName"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["AssemblyQualifiedName"]._Method, _Precompiled = ___gf_AssemblyQualifiedName };
                _InstanceFieldsIndex["Attributes"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["Attributes"]._Method, _Precompiled = ___gf_Attributes };
                _InstanceFieldsIndex["BaseType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["BaseType"]._Method, _Precompiled = ___gf_BaseType };
                _InstanceFieldsIndex["FullName"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["FullName"]._Method, _Precompiled = ___gf_FullName };
                _InstanceFieldsIndex["HasElementType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["HasElementType"]._Method, _Precompiled = ___gf_HasElementType };
                _InstanceFieldsIndex["IsAbstract"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsAbstract"]._Method, _Precompiled = ___gf_IsAbstract };
                _InstanceFieldsIndex["IsArray"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsArray"]._Method, _Precompiled = ___gf_IsArray };
                _InstanceFieldsIndex["IsByRef"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsByRef"]._Method, _Precompiled = ___gf_IsByRef };
                _InstanceFieldsIndex["IsClass"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsClass"]._Method, _Precompiled = ___gf_IsClass };
                _InstanceFieldsIndex["IsContextful"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsContextful"]._Method, _Precompiled = ___gf_IsContextful };
                _InstanceFieldsIndex["IsEnum"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsEnum"]._Method, _Precompiled = ___gf_IsEnum };
                _InstanceFieldsIndex["IsExplicitLayout"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsExplicitLayout"]._Method, _Precompiled = ___gf_IsExplicitLayout };
                _InstanceFieldsIndex["IsInterface"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsInterface"]._Method, _Precompiled = ___gf_IsInterface };
                _InstanceFieldsIndex["IsMarshalByRef"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsMarshalByRef"]._Method, _Precompiled = ___gf_IsMarshalByRef };
                _InstanceFieldsIndex["IsPointer"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsPointer"]._Method, _Precompiled = ___gf_IsPointer };
                _InstanceFieldsIndex["IsPrimitive"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsPrimitive"]._Method, _Precompiled = ___gf_IsPrimitive };
                _InstanceFieldsIndex["IsSealed"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsSealed"]._Method, _Precompiled = ___gf_IsSealed };
                _InstanceFieldsIndex["IsSerializable"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsSerializable"]._Method, _Precompiled = ___gf_IsSerializable };
                _InstanceFieldsIndex["IsValueType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsValueType"]._Method, _Precompiled = ___gf_IsValueType };
                _InstanceFieldsIndex["Namespace"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["Namespace"]._Method, _Precompiled = ___gf_Namespace };
                _InstanceFieldsIndex["TypeHandle"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["TypeHandle"]._Method, _Precompiled = ___gf_TypeHandle };
                _InstanceFieldsIndex["UnderlyingSystemType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["UnderlyingSystemType"]._Method, _Precompiled = ___gf_UnderlyingSystemType };
                _InstanceFieldsIndex["ContainsGenericParameters"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["ContainsGenericParameters"]._Method, _Precompiled = ___gf_ContainsGenericParameters };
                _InstanceFieldsIndex["IsGenericTypeDefinition"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsGenericTypeDefinition"]._Method, _Precompiled = ___gf_IsGenericTypeDefinition };
                _InstanceFieldsIndex["IsGenericType"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsGenericType"]._Method, _Precompiled = ___gf_IsGenericType };
                _InstanceFieldsIndex["IsGenericParameter"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsGenericParameter"]._Method, _Precompiled = ___gf_IsGenericParameter };
                _InstanceFieldsIndex["IsNested"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["IsNested"]._Method, _Precompiled = ___gf_IsNested };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
                _InstanceMethods_DirectFromBase.Add("IsDefined");
                _InstanceMethods_DirectFromBase.Add("GetCustomAttributes");
                #endif
            }
            public override void RegPrecompiledStatic()
            {
                #region REG_I_CTOR
                #endregion // REG_I_CTOR
                #region REG_S_FUNC
                _StaticMethods["GetType"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetType"]._Method, _Precompiled = ___sfm_GetType };
                _StaticMethods["GetTypeCode"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetTypeCode"]._Method, _Precompiled = ___sfm_GetTypeCode };
                _StaticMethods["GetTypeFromHandle"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetTypeFromHandle"]._Method, _Precompiled = ___sfm_GetTypeFromHandle };
                _StaticMethods["GetTypeHandle"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetTypeHandle"]._Method, _Precompiled = ___sfm_GetTypeHandle };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                _StaticFieldsIndex["Delimiter"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["Delimiter"]._Method, _Precompiled = ___sgf_Delimiter };
                _StaticFieldsIndex["EmptyTypes"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["EmptyTypes"]._Method, _Precompiled = ___sgf_EmptyTypes };
                _StaticFieldsIndex["FilterAttribute"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["FilterAttribute"]._Method, _Precompiled = ___sgf_FilterAttribute };
                _StaticFieldsIndex["FilterName"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["FilterName"]._Method, _Precompiled = ___sgf_FilterName };
                _StaticFieldsIndex["FilterNameIgnoreCase"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["FilterNameIgnoreCase"]._Method, _Precompiled = ___sgf_FilterNameIgnoreCase };
                _StaticFieldsIndex["Missing"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["Missing"]._Method, _Precompiled = ___sgf_Missing };
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
            private static readonly lua.CFunction ___fm_Equals = new lua.CFunction(___mm_Equals);
            private static readonly lua.CFunction ___fm_GetType = new lua.CFunction(___mm_GetType);
            private static readonly lua.CFunction ___fm_IsSubclassOf = new lua.CFunction(___mm_IsSubclassOf);
            private static readonly lua.CFunction ___fm_GetInterfaces = new lua.CFunction(___mm_GetInterfaces);
            private static readonly lua.CFunction ___fm_IsAssignableFrom = new lua.CFunction(___mm_IsAssignableFrom);
            private static readonly lua.CFunction ___fm_IsInstanceOfType = new lua.CFunction(___mm_IsInstanceOfType);
            private static readonly lua.CFunction ___fm_GetArrayRank = new lua.CFunction(___mm_GetArrayRank);
            private static readonly lua.CFunction ___fm_GetElementType = new lua.CFunction(___mm_GetElementType);
            private static readonly lua.CFunction ___fm_GetEvent = new lua.CFunction(___mm_GetEvent);
            private static readonly lua.CFunction ___fm_GetEvents = new lua.CFunction(___mm_GetEvents);
            private static readonly lua.CFunction ___fm_GetField = new lua.CFunction(___mm_GetField);
            private static readonly lua.CFunction ___fm_GetFields = new lua.CFunction(___mm_GetFields);
            private static readonly lua.CFunction ___fm_GetMembers = new lua.CFunction(___mm_GetMembers);
            private static readonly lua.CFunction ___fm_GetMethod = new lua.CFunction(___mm_GetMethod);
            private static readonly lua.CFunction ___fm_GetMethods = new lua.CFunction(___mm_GetMethods);
            private static readonly lua.CFunction ___fm_GetNestedTypes = new lua.CFunction(___mm_GetNestedTypes);
            private static readonly lua.CFunction ___fm_GetProperties = new lua.CFunction(___mm_GetProperties);
            private static readonly lua.CFunction ___fm_GetProperty = new lua.CFunction(___mm_GetProperty);
            private static readonly lua.CFunction ___fm_GetConstructor = new lua.CFunction(___mm_GetConstructor);
            private static readonly lua.CFunction ___fm_GetConstructors = new lua.CFunction(___mm_GetConstructors);
            private static readonly lua.CFunction ___fm_FindMembers = new lua.CFunction(___mm_FindMembers);
            private static readonly lua.CFunction ___fm_InvokeMember = new lua.CFunction(___mm_InvokeMember);
            private static readonly lua.CFunction ___fm_GetGenericArguments = new lua.CFunction(___mm_GetGenericArguments);
            private static readonly lua.CFunction ___fm_GetGenericTypeDefinition = new lua.CFunction(___mm_GetGenericTypeDefinition);
            private static readonly lua.CFunction ___fm_MakeGenericType = new lua.CFunction(___mm_MakeGenericType);
            private static readonly lua.CFunction ___fm_MakeByRefType = new lua.CFunction(___mm_MakeByRefType);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_Assembly = new lua.CFunction(___gm_Assembly);
            private static readonly lua.CFunction ___gf_AssemblyQualifiedName = new lua.CFunction(___gm_AssemblyQualifiedName);
            private static readonly lua.CFunction ___gf_Attributes = new lua.CFunction(___gm_Attributes);
            private static readonly lua.CFunction ___gf_BaseType = new lua.CFunction(___gm_BaseType);
            private static readonly lua.CFunction ___gf_FullName = new lua.CFunction(___gm_FullName);
            private static readonly lua.CFunction ___gf_HasElementType = new lua.CFunction(___gm_HasElementType);
            private static readonly lua.CFunction ___gf_IsAbstract = new lua.CFunction(___gm_IsAbstract);
            private static readonly lua.CFunction ___gf_IsArray = new lua.CFunction(___gm_IsArray);
            private static readonly lua.CFunction ___gf_IsByRef = new lua.CFunction(___gm_IsByRef);
            private static readonly lua.CFunction ___gf_IsClass = new lua.CFunction(___gm_IsClass);
            private static readonly lua.CFunction ___gf_IsContextful = new lua.CFunction(___gm_IsContextful);
            private static readonly lua.CFunction ___gf_IsEnum = new lua.CFunction(___gm_IsEnum);
            private static readonly lua.CFunction ___gf_IsExplicitLayout = new lua.CFunction(___gm_IsExplicitLayout);
            private static readonly lua.CFunction ___gf_IsInterface = new lua.CFunction(___gm_IsInterface);
            private static readonly lua.CFunction ___gf_IsMarshalByRef = new lua.CFunction(___gm_IsMarshalByRef);
            private static readonly lua.CFunction ___gf_IsPointer = new lua.CFunction(___gm_IsPointer);
            private static readonly lua.CFunction ___gf_IsPrimitive = new lua.CFunction(___gm_IsPrimitive);
            private static readonly lua.CFunction ___gf_IsSealed = new lua.CFunction(___gm_IsSealed);
            private static readonly lua.CFunction ___gf_IsSerializable = new lua.CFunction(___gm_IsSerializable);
            private static readonly lua.CFunction ___gf_IsValueType = new lua.CFunction(___gm_IsValueType);
            private static readonly lua.CFunction ___gf_Namespace = new lua.CFunction(___gm_Namespace);
            private static readonly lua.CFunction ___gf_TypeHandle = new lua.CFunction(___gm_TypeHandle);
            private static readonly lua.CFunction ___gf_UnderlyingSystemType = new lua.CFunction(___gm_UnderlyingSystemType);
            private static readonly lua.CFunction ___gf_ContainsGenericParameters = new lua.CFunction(___gm_ContainsGenericParameters);
            private static readonly lua.CFunction ___gf_IsGenericTypeDefinition = new lua.CFunction(___gm_IsGenericTypeDefinition);
            private static readonly lua.CFunction ___gf_IsGenericType = new lua.CFunction(___gm_IsGenericType);
            private static readonly lua.CFunction ___gf_IsGenericParameter = new lua.CFunction(___gm_IsGenericParameter);
            private static readonly lua.CFunction ___gf_IsNested = new lua.CFunction(___gm_IsNested);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_GetType = new lua.CFunction(___smm_GetType);
            private static readonly lua.CFunction ___sfm_GetTypeCode = new lua.CFunction(___smm_GetTypeCode);
            private static readonly lua.CFunction ___sfm_GetTypeFromHandle = new lua.CFunction(___smm_GetTypeFromHandle);
            private static readonly lua.CFunction ___sfm_GetTypeHandle = new lua.CFunction(___smm_GetTypeHandle);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_Delimiter = new lua.CFunction(___sgm_Delimiter);
            private static readonly lua.CFunction ___sgf_EmptyTypes = new lua.CFunction(___sgm_EmptyTypes);
            private static readonly lua.CFunction ___sgf_FilterAttribute = new lua.CFunction(___sgm_FilterAttribute);
            private static readonly lua.CFunction ___sgf_FilterName = new lua.CFunction(___sgm_FilterName);
            private static readonly lua.CFunction ___sgf_FilterNameIgnoreCase = new lua.CFunction(___sgm_FilterNameIgnoreCase);
            private static readonly lua.CFunction ___sgf_Missing = new lua.CFunction(___sgm_Missing);
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
            private static int ___mm_Equals(IntPtr l)
            {
                try
                {
                    {
                        {
                            {
                                {
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Type) || typeof(System.Type).IsAssignableFrom(___ot1))
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
                            System.Type p0;
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
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
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
            private static int ___mm_GetType(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetType();
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
            private static int ___mm_IsSubclassOf(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    System.Type p1;
                    l.GetLua(2, out p1);
                    var rv = p0.IsSubclassOf(p1);
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
            private static int ___mm_GetInterfaces(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetInterfaces();
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
            private static int ___mm_IsAssignableFrom(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    System.Type p1;
                    l.GetLua(2, out p1);
                    var rv = p0.IsAssignableFrom(p1);
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
            private static int ___mm_IsInstanceOfType(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    System.Object p1;
                    l.GetLua(2, out p1);
                    var rv = p0.IsInstanceOfType(p1);
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
            private static int ___mm_GetArrayRank(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetArrayRank();
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
            private static int ___mm_GetElementType(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetElementType();
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
            private static int ___mm_GetEvent(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    System.Reflection.BindingFlags p2;
                    l.GetLua(3, out p2);
                    var rv = p0.GetEvent(p1, p2);
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
            private static int ___mm_GetEvents(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    System.Reflection.BindingFlags p1;
                    l.GetLua(2, out p1);
                    var rv = p0.GetEvents(p1);
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
            private static int ___mm_GetField(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    System.Reflection.BindingFlags p2;
                    l.GetLua(3, out p2);
                    var rv = p0.GetField(p1, p2);
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
            private static int ___mm_GetFields(IntPtr l)
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
                            System.Type p0;
                            l.GetLua(1, out p0);
                            var rv = p0.GetFields();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Reflection.BindingFlags p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetFields(p1);
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
            private static int ___mm_GetMembers(IntPtr l)
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
                            System.Type p0;
                            l.GetLua(1, out p0);
                            var rv = p0.GetMembers();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Reflection.BindingFlags p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetMembers(p1);
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
            private static int ___mm_GetMethod(IntPtr l)
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
                            else if (oldtop == 6)
                            {
                                goto Label_40;
                            }
                            else if (oldtop >= 7)
                            {
                                goto Label_50;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(System.Type[]))
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
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetMethod(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Reflection.BindingFlags p2;
                            l.GetLua(3, out p2);
                            var rv = p0.GetMethod(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Type[] p2;
                            l.GetLua(3, out p2);
                            var rv = p0.GetMethod(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Reflection.BindingFlags p2;
                            l.GetLua(3, out p2);
                            System.Reflection.Binder p3;
                            l.GetLua(4, out p3);
                            System.Type[] p4;
                            l.GetLua(5, out p4);
                            System.Reflection.ParameterModifier[] p5;
                            l.GetLua(6, out p5);
                            var rv = p0.GetMethod(p1, p2, p3, p4, p5);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Reflection.BindingFlags p2;
                            l.GetLua(3, out p2);
                            System.Reflection.Binder p3;
                            l.GetLua(4, out p3);
                            System.Reflection.CallingConventions p4;
                            l.GetLua(5, out p4);
                            System.Type[] p5;
                            l.GetLua(6, out p5);
                            System.Reflection.ParameterModifier[] p6;
                            l.GetLua(7, out p6);
                            var rv = p0.GetMethod(p1, p2, p3, p4, p5, p6);
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
            private static int ___mm_GetMethods(IntPtr l)
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
                            System.Type p0;
                            l.GetLua(1, out p0);
                            var rv = p0.GetMethods();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Reflection.BindingFlags p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetMethods(p1);
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
            private static int ___mm_GetNestedTypes(IntPtr l)
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
                            System.Type p0;
                            l.GetLua(1, out p0);
                            var rv = p0.GetNestedTypes();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Reflection.BindingFlags p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetNestedTypes(p1);
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
            private static int ___mm_GetProperties(IntPtr l)
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
                            System.Type p0;
                            l.GetLua(1, out p0);
                            var rv = p0.GetProperties();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Reflection.BindingFlags p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetProperties(p1);
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
            private static int ___mm_GetProperty(IntPtr l)
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
                            else if (oldtop == 4)
                            {
                                goto Label_40;
                            }
                            else if (oldtop >= 7)
                            {
                                goto Label_50;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(System.Type) || typeof(System.Type).IsAssignableFrom(___ot2))
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
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetProperty(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Reflection.BindingFlags p2;
                            l.GetLua(3, out p2);
                            var rv = p0.GetProperty(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Type p2;
                            l.GetLua(3, out p2);
                            var rv = p0.GetProperty(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Type p2;
                            l.GetLua(3, out p2);
                            System.Type[] p3;
                            l.GetLua(4, out p3);
                            var rv = p0.GetProperty(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Reflection.BindingFlags p2;
                            l.GetLua(3, out p2);
                            System.Reflection.Binder p3;
                            l.GetLua(4, out p3);
                            System.Type p4;
                            l.GetLua(5, out p4);
                            System.Type[] p5;
                            l.GetLua(6, out p5);
                            System.Reflection.ParameterModifier[] p6;
                            l.GetLua(7, out p6);
                            var rv = p0.GetProperty(p1, p2, p3, p4, p5, p6);
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
            private static int ___mm_GetConstructor(IntPtr l)
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
                            else if (oldtop == 5)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 6)
                            {
                                goto Label_30;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Type[] p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetConstructor(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Reflection.BindingFlags p1;
                            l.GetLua(2, out p1);
                            System.Reflection.Binder p2;
                            l.GetLua(3, out p2);
                            System.Type[] p3;
                            l.GetLua(4, out p3);
                            System.Reflection.ParameterModifier[] p4;
                            l.GetLua(5, out p4);
                            var rv = p0.GetConstructor(p1, p2, p3, p4);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Reflection.BindingFlags p1;
                            l.GetLua(2, out p1);
                            System.Reflection.Binder p2;
                            l.GetLua(3, out p2);
                            System.Reflection.CallingConventions p3;
                            l.GetLua(4, out p3);
                            System.Type[] p4;
                            l.GetLua(5, out p4);
                            System.Reflection.ParameterModifier[] p5;
                            l.GetLua(6, out p5);
                            var rv = p0.GetConstructor(p1, p2, p3, p4, p5);
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
            private static int ___mm_GetConstructors(IntPtr l)
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
                            System.Type p0;
                            l.GetLua(1, out p0);
                            var rv = p0.GetConstructors();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Type p0;
                            l.GetLua(1, out p0);
                            System.Reflection.BindingFlags p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetConstructors(p1);
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
            private static int ___mm_FindMembers(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    System.Reflection.MemberTypes p1;
                    l.GetLua(2, out p1);
                    System.Reflection.BindingFlags p2;
                    l.GetLua(3, out p2);
                    System.Reflection.MemberFilter p3;
                    l.GetLua(4, out p3);
                    System.Object p4;
                    l.GetLua(5, out p4);
                    var rv = p0.FindMembers(p1, p2, p3, p4);
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
            private static int ___mm_InvokeMember(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    System.Reflection.BindingFlags p2;
                    l.GetLua(3, out p2);
                    System.Reflection.Binder p3;
                    l.GetLua(4, out p3);
                    System.Object p4;
                    l.GetLua(5, out p4);
                    System.Object[] p5;
                    l.GetLua(6, out p5);
                    System.Reflection.ParameterModifier[] p6;
                    l.GetLua(7, out p6);
                    System.Globalization.CultureInfo p7;
                    l.GetLua(8, out p7);
                    System.String[] p8;
                    l.GetLua(9, out p8);
                    var rv = p0.InvokeMember(p1, p2, p3, p4, p5, p6, p7, p8);
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
            private static int ___mm_GetGenericArguments(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetGenericArguments();
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
            private static int ___mm_GetGenericTypeDefinition(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetGenericTypeDefinition();
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
            private static int ___mm_MakeGenericType(IntPtr l)
            {
                try
                {
                    var ltype = l.GetType(2);
                    if (ltype == typeof(System.Type[]))
                    {
                        System.Type p0;
                        l.GetLua(1, out p0);
                        System.Type[] p1;
                        l.GetLua(2, out p1);
                        var rv = p0.MakeGenericType(p1);
                        l.PushLua(rv);
                        return 1;
                    }
                    else
                    {
                        System.Type p0;
                        l.GetLua(1, out p0);
                        System.Type[] p1;
                        var paramscnt = l.gettop() - 1;
                        paramscnt = paramscnt < 0 ? 0 : paramscnt;
                        p1 = new System.Type[paramscnt];
                        for (int i = 0; i < paramscnt; ++i)
                        {
                            System.Type paramval;
                            l.GetLua(i + 2, out paramval);
                            p1[i] = paramval;
                        }
                        var rv = p0.MakeGenericType(p1);
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
            private static int ___mm_MakeByRefType(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = p0.MakeByRefType();
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
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_Assembly(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.Assembly;
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
            private static int ___gm_AssemblyQualifiedName(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.AssemblyQualifiedName;
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
            private static int ___gm_Attributes(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.Attributes;
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
            private static int ___gm_BaseType(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.BaseType;
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
            private static int ___gm_FullName(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.FullName;
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
            private static int ___gm_HasElementType(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.HasElementType;
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
            private static int ___gm_IsAbstract(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsAbstract;
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
            private static int ___gm_IsArray(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsArray;
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
            private static int ___gm_IsByRef(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsByRef;
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
            private static int ___gm_IsClass(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsClass;
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
            private static int ___gm_IsContextful(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsContextful;
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
            private static int ___gm_IsEnum(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsEnum;
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
            private static int ___gm_IsExplicitLayout(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsExplicitLayout;
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
            private static int ___gm_IsInterface(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsInterface;
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
            private static int ___gm_IsMarshalByRef(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsMarshalByRef;
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
            private static int ___gm_IsPointer(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsPointer;
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
            private static int ___gm_IsPrimitive(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsPrimitive;
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
            private static int ___gm_IsSealed(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsSealed;
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
            private static int ___gm_IsSerializable(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsSerializable;
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
            private static int ___gm_IsValueType(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsValueType;
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
            private static int ___gm_Namespace(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.Namespace;
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
            private static int ___gm_TypeHandle(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.TypeHandle;
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
            private static int ___gm_UnderlyingSystemType(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.UnderlyingSystemType;
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
            private static int ___gm_ContainsGenericParameters(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.ContainsGenericParameters;
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
            private static int ___gm_IsGenericTypeDefinition(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsGenericTypeDefinition;
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
            private static int ___gm_IsGenericType(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsGenericType;
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
            private static int ___gm_IsGenericParameter(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsGenericParameter;
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
            private static int ___gm_IsNested(IntPtr l)
            {
                try
                {
                    System.Type tar;
                    l.GetLua(1, out tar);
                    var rv = tar.IsNested;
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
            private static int ___smm_GetType(IntPtr l)
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
                            var rv = System.Type.GetType(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.String p0;
                            l.GetLua(1, out p0);
                            System.Boolean p1;
                            l.GetLua(2, out p1);
                            var rv = System.Type.GetType(p0, p1);
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
            private static int ___smm_GetTypeCode(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = System.Type.GetTypeCode(p0);
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
            private static int ___smm_GetTypeFromHandle(IntPtr l)
            {
                try
                {
                    System.RuntimeTypeHandle p0;
                    l.GetLua(1, out p0);
                    var rv = System.Type.GetTypeFromHandle(p0);
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
            private static int ___smm_GetTypeHandle(IntPtr l)
            {
                try
                {
                    System.Object p0;
                    l.GetLua(1, out p0);
                    var rv = System.Type.GetTypeHandle(p0);
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
            private static int ___sgm_Delimiter(IntPtr l)
            {
                try
                {
                    var rv = System.Type.Delimiter;
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
            private static int ___sgm_EmptyTypes(IntPtr l)
            {
                try
                {
                    var rv = System.Type.EmptyTypes;
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
            private static int ___sgm_FilterAttribute(IntPtr l)
            {
                try
                {
                    var rv = System.Type.FilterAttribute;
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
            private static int ___sgm_FilterName(IntPtr l)
            {
                try
                {
                    var rv = System.Type.FilterName;
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
            private static int ___sgm_FilterNameIgnoreCase(IntPtr l)
            {
                try
                {
                    var rv = System.Type.FilterNameIgnoreCase;
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
            private static int ___sgm_Missing(IntPtr l)
            {
                try
                {
                    var rv = System.Type.Missing;
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
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                var type = val as Type;
                if (type == null)
                l.pushnil();
                else
                l.PushLuaType(type);
                return IntPtr.Zero;
            }
        }
        private static TypeHubPrecompiled_System_Type ___tp_System_Type = new TypeHubPrecompiled_System_Type();
    }
}
#endif
