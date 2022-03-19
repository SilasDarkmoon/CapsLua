using System;
using System.Collections.Generic;
using System.Reflection;
using Capstones.UnityEngineEx;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static class CapsLuaTypeNonPublicReflector
    {
        private static readonly lua.CFunction LuaFuncInstanceIndex = new lua.CFunction(LuaMetaInstanceIndex);
        private static readonly lua.CFunction LuaFuncInstanceNewIndex = new lua.CFunction(LuaMetaInstanceNewIndex);
        private static readonly lua.CFunction LuaFuncStaticIndex = new lua.CFunction(LuaMetaStaticIndex);
        private static readonly lua.CFunction LuaFuncStaticNewIndex = new lua.CFunction(LuaMetaStaticNewIndex);
        private static readonly lua.CFunction LuaFuncStaticCall = new lua.CFunction(LuaMetaStaticCall);
        public static readonly lua.CFunction LuaFuncCreateInstanceReflector = new lua.CFunction(LuaMetaCreateInstanceReflector);
        public static readonly lua.CFunction LuaFuncCreateStaticReflector = new lua.CFunction(LuaMetaCreateStaticReflector);
        public static readonly lua.CFunction LuaFuncReflectorlIndex = new lua.CFunction(LuaMetaReflectorlIndex);
        public static readonly lua.CFunction LuaFuncCreateReflector = new lua.CFunction(LuaMetaCreateReflector);

        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaMetaInstanceIndex(IntPtr l)
        {
            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // #tar
            l.rawget(1); // tar
            var tar = l.GetLua(-1);
            Type type = l.GetType(-1);
            l.pop(1); // X
            string name;
            l.GetLua(2, out name);
            if (string.IsNullOrEmpty(name))
            {
                return 0;
            }
            var searchingType = type;
            MemberInfo[] members = null;
            while ((members == null || members.Length == 0) && searchingType != null)
            {
                members = searchingType.GetMember(name, BindingFlags.Instance | BindingFlags.NonPublic);
                searchingType = searchingType.BaseType;
            }
            if (members == null || members.Length == 0)
            {
                return 0;
            }
            switch (members[0].MemberType)
            {
                case MemberTypes.Field:
                    {
                        if (tar == null)
                        {
                            return 0;
                        }
                        var fi = members[0] as FieldInfo;
                        var result = fi.GetValue(tar);
                        l.PushLua(result);
                    }
                    return 1;
                case MemberTypes.Property:
                    {
                        if (tar == null)
                        {
                            return 0;
                        }
                        var pi = members[0] as PropertyInfo;
                        var result = pi.GetValue(tar);
                        l.PushLua(result);
                    }
                    return 1;
                case MemberTypes.Method:
                    {
                        List<MethodBase> fmethods = new List<MethodBase>();
                        List<MethodBase> gmethods = new List<MethodBase>();
                        for (int i = 0; i < members.Length; ++i)
                        {
                            var method = members[i] as MethodInfo;
                            if (method.ContainsGenericParameters)
                            {
                                gmethods.Add(method);
                            }
                            else
                            {
                                fmethods.Add(method);
                            }
                        }
                        var meta = GenericMethodMeta.CreateMethodMeta(fmethods.ToArray(), gmethods.ToArray(), type.IsValueType);
                        l.PushFunction(meta);
                        meta.WrapFunctionByTable(l);
                    }
                    return 1;
                case MemberTypes.Event: // TODO: events?
                default:
                    return 0;
            }
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaMetaInstanceNewIndex(IntPtr l)
        {
            var val = l.GetLua(3);
            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // #tar
            l.rawget(1); // tar
            var tar = l.GetLua(-1);
            l.pop(1); // X
            if (tar == null)
            {
                return 0;
            }
            var type = tar.GetType();
            string name;
            l.GetLua(2, out name);
            if (string.IsNullOrEmpty(name))
            {
                return 0;
            }
            var searchingType = type;
            MemberInfo[] members = null;
            while ((members == null || members.Length == 0) && searchingType != null)
            {
                members = searchingType.GetMember(name, BindingFlags.Instance | BindingFlags.NonPublic);
                searchingType = searchingType.BaseType;
            }
            if (members == null || members.Length == 0)
            {
                return 0;
            }
            switch (members[0].MemberType)
            {
                case MemberTypes.Field:
                    {
                        var fi = members[0] as FieldInfo;
                        fi.SetValue(tar, val.ConvertTypeRaw(fi.FieldType));
                    }
                    return 0;
                case MemberTypes.Property:
                    {
                        var pi = members[0] as PropertyInfo;
                        pi.SetValue(tar, val.ConvertTypeRaw(pi.PropertyType));
                    }
                    return 0;
                default:
                    return 0;
            }
        }

        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaMetaStaticNewIndex(IntPtr l)
        {
            var val = l.GetLua(3);
            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // #tar
            l.rawget(1); // tar
            Type type;
            l.GetLua(-1, out type);
            l.pop(1); // X
            if (type == null)
            {
                return 0;
            }
            string name;
            l.GetLua(2, out name);
            if (string.IsNullOrEmpty(name))
            {
                return 0;
            }
            var members = type.GetMember(name, BindingFlags.Static | BindingFlags.NonPublic);
            if (members == null || members.Length == 0)
            {
                return 0;
            }
            switch (members[0].MemberType)
            {
                case MemberTypes.Field:
                    {
                        var fi = members[0] as FieldInfo;
                        fi.SetValue(null, val.ConvertTypeRaw(fi.FieldType));
                    }
                    return 0;
                case MemberTypes.Property:
                    {
                        var pi = members[0] as PropertyInfo;
                        pi.SetValue(null, val.ConvertTypeRaw(pi.PropertyType));
                    }
                    return 0;
                default:
                    return 0;
            }
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaMetaStaticIndex(IntPtr l)
        {
            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // #tar
            l.rawget(1); // tar
            Type type;
            l.GetLua(-1, out type);
            l.pop(1); // X
            if (type == null)
            {
                return 0;
            }
            string name;
            l.GetLua(2, out name);
            if (string.IsNullOrEmpty(name))
            {
                return 0;
            }
            var members = type.GetMember(name, BindingFlags.Static | BindingFlags.NonPublic);
            if (members == null || members.Length == 0)
            {
                return 0;
            }
            switch (members[0].MemberType)
            {
                case MemberTypes.Field:
                    {
                        var fi = members[0] as FieldInfo;
                        var result = fi.GetValue(null);
                        l.PushLua(result);
                    }
                    return 1;
                case MemberTypes.Property:
                    {
                        var pi = members[0] as PropertyInfo;
                        var result = pi.GetValue(null);
                        l.PushLua(result);
                    }
                    return 1;
                case MemberTypes.Method:
                    {
                        List<MethodBase> fmethods = new List<MethodBase>();
                        List<MethodBase> gmethods = new List<MethodBase>();
                        for (int i = 0; i < members.Length; ++i)
                        {
                            var method = members[i] as MethodInfo;
                            if (method.ContainsGenericParameters)
                            {
                                gmethods.Add(method);
                            }
                            else
                            {
                                fmethods.Add(method);
                            }
                        }
                        var meta = GenericMethodMeta.CreateMethodMeta(fmethods.ToArray(), gmethods.ToArray(), type.IsValueType);
                        l.PushFunction(meta);
                        meta.WrapFunctionByTable(l);
                    }
                    return 1;
                case MemberTypes.NestedType:
                    {
                        var nt = members[0] as Type;
                        l.PushLua(nt);
                    }
                    return 1;
                case MemberTypes.Event: // TODO: events?
                default:
                    return 0;
            }
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaMetaStaticCall(IntPtr l)
        {
            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // #tar
            l.rawget(1); // tar
            Type type;
            l.GetLua(-1, out type);
            l.pop(1); // X
            if (type == null)
            {
                return 0;
            }
            var members = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            if (members == null || members.Length == 0)
            {
                return 0;
            }
            var meta = PackedMethodMeta.CreateMethodMeta(members, null, false);
            if (meta == null)
            {
                return 0;
            }
            var oldtop = l.gettop();
            meta.call(l, null);
            return l.gettop() - oldtop;
        }
        public static BaseUniqueMethodMeta FindNonPublicCtor(Type type, Types args)
        {
            var members = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            if (members == null || members.Length == 0)
            {
                return null;
            }
            var meta = PackedMethodMeta.CreateMethodMeta(members, null, false);
            if (meta == null)
            {
                return null;
            }
            if (meta is BaseUniqueMethodMeta)
            {
                return (BaseUniqueMethodMeta)meta;
            }
            else if (meta is BaseOverloadedMethodMeta)
            {
                return ((BaseOverloadedMethodMeta)meta).FindAppropriate(args);
            }
            return null;
        }

        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaMetaCreateInstanceReflector(IntPtr l)
        {
            l.newtable(); // reflector
            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // refl #tar
            l.pushvalue(1); // refl #tar tar
            l.rawset(-3); // refl
            l.pushlightuserdata(LuaConst.LRKEY_TYPE_TRANS); // refl #trans
            l.pushlightuserdata(LuaExtend.LuaTransExtend.Instance.r); // refl #trans trans
            l.rawset(-3); // refl
            l.newtable(); // refl meta
            l.pushcfunction(LuaFuncInstanceIndex); // refl meta index
            l.RawSet(-2, LuaConst.LS_META_KEY_INDEX); // refl meta
            l.pushcfunction(LuaFuncInstanceNewIndex); // refl meta newindex
            l.RawSet(-2, LuaConst.LS_META_KEY_NINDEX); // refl meta
            l.setmetatable(-2); // refl
            return 1;
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaMetaCreateStaticReflector(IntPtr l)
        {
            l.newtable(); // reflector
            l.PushString(LuaConst.LS_SP_KEY_NONPUBLIC);
            l.pushboolean(true);
            l.rawset(-3); // refl["@npub"] = true
            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // refl #tar
            l.pushvalue(lua.upvalueindex(1)); // refl #tar tar
            l.rawset(-3); // refl
            l.pushlightuserdata(LuaConst.LRKEY_TYPE_TRANS); // refl #trans
            l.pushlightuserdata(LuaExtend.LuaTransExtend.Instance.r); // refl #trans trans
            l.rawset(-3); // refl
            l.newtable(); // refl meta
            l.pushcfunction(LuaFuncStaticIndex); // refl meta index
            l.RawSet(-2, LuaConst.LS_META_KEY_INDEX); // refl meta
            l.pushcfunction(LuaFuncStaticNewIndex); // refl meta newindex
            l.RawSet(-2, LuaConst.LS_META_KEY_NINDEX); // refl meta
            l.pushcfunction(LuaFuncStaticCall); // refl meta call
            l.RawSet(-2, LuaConst.LS_META_KEY_CALL); // refl meta
            l.setmetatable(-2); // refl
            return 1;
        }

        // Reflector
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaMetaReflectorlIndex(IntPtr l)
        {
            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // #tar
            l.rawget(1); // tar
            Type type;
            l.GetLua(-1, out type);
            l.pop(1); // X
            if (type == null)
            {
                return 0;
            }
            string name;
            l.GetLua(2, out name);
            if (string.IsNullOrEmpty(name))
            {
                return 0;
            }
            var members = type.GetMember(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (members == null || members.Length == 0)
            {
                return 0;
            }
            switch (members[0].MemberType)
            {
                case MemberTypes.Field:
                    {
                        var fi = members[0] as FieldInfo;
                        l.PushLuaObject(fi);
                    }
                    return 1;
                case MemberTypes.Property:
                    {
                        var pi = members[0] as PropertyInfo;
                        l.PushLuaObject(pi);
                    }
                    return 1;
                case MemberTypes.Method:
                    {
                        List<MethodBase> fmethods = new List<MethodBase>();
                        List<MethodBase> gmethods = new List<MethodBase>();
                        for (int i = 0; i < members.Length; ++i)
                        {
                            var method = members[i] as MethodInfo;
                            if (method.ContainsGenericParameters)
                            {
                                gmethods.Add(method);
                            }
                            else
                            {
                                fmethods.Add(method);
                            }
                        }
                        var meta = GenericMethodMeta.CreateMethodMeta(fmethods.ToArray(), gmethods.ToArray(), type.IsValueType);
                        l.PushFunction(meta);
                        meta.WrapFunctionByTable(l);
                    }
                    return 1;
                case MemberTypes.Event:
                    {
                        var ei = members[0] as EventInfo;
                        l.PushLuaObject(ei);
                    }
                    return 1;
                case MemberTypes.Constructor:
                    {
                        List<MethodBase> fmethods = new List<MethodBase>();
                        for (int i = 0; i < members.Length; ++i)
                        {
                            var method = members[i] as ConstructorInfo;
                            fmethods.Add(method);
                        }
                        var meta = PackedMethodMeta.CreateMethodMeta(fmethods, null, false);
                        l.PushFunction(meta);
                        meta.WrapFunctionByTable(l);
                    }
                    return 1;
                default:
                    return 0;
            }
        }

        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaMetaCreateReflector(IntPtr l)
        {
            l.newtable(); // reflector
            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // refl #tar
            l.pushvalue(lua.upvalueindex(1)); // refl #tar tar
            l.rawset(-3); // refl
            l.pushlightuserdata(LuaConst.LRKEY_TYPE_TRANS); // refl #trans
            l.pushlightuserdata(LuaExtend.LuaTransExtend.Instance.r); // refl #trans trans
            l.rawset(-3); // refl
            l.newtable(); // refl meta
            l.pushcfunction(LuaFuncReflectorlIndex); // refl meta index
            l.RawSet(-2, LuaConst.LS_META_KEY_INDEX); // refl meta
            l.setmetatable(-2); // refl
            return 1;
        }
    }
}