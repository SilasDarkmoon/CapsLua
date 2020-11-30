using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Capstones.LuaLib;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaWrap
{
    public static partial class LuaFuncExHelper
    {
        public static int PushPackedArgsAndCallRaw<TIn>(this IntPtr l, TIn args)
            where TIn : struct, ILuaPack
        {
            var oldtop = l.gettop();
            args.PushToLua(l);
            return LuaFuncHelper.CallInternal(l, oldtop);
        }
        public static int PushPackedArgsAndCallRawSingleReturn<TIn>(this IntPtr l, TIn args)
            where TIn : struct, ILuaPack
        {
            var oldtop = l.gettop();
            args.PushToLua(l);
            return LuaFuncHelper.CallInternalSingleReturn(l, oldtop);
        }
        public static int CallPackedArgsRaw<TIn>(this IntPtr l, int index, string func, TIn args)
            where TIn : struct, ILuaPack
        {
            var oldtop = l.gettop();
            l.GetField(index, func);
            args.PushToLua(l);
            var code = LuaFuncHelper.CallInternal(l, oldtop + 1);
            if (code != 0)
            {
                l.pop(1);
            }
            return l.gettop() - oldtop;
        }
        public static int CallPackedArgsRawSingleReturn<TIn>(this IntPtr l, int index, string func, TIn args)
            where TIn : struct, ILuaPack
        {
            l.GetField(index, func);
            return l.PushPackedArgsAndCallRawSingleReturn(args);
        }

        public static bool NewTable<TIn>(this IntPtr l, string luafile, TIn args)
            where TIn : struct, ILuaPack
        {
            l.Require(luafile); // class
            if (!l.istable(-1))
            {
                l.pop(1); // X
                l.pushnil(); // nil
                return false;
            }
            if (l.CallPackedArgsRawSingleReturn(-1, "new", args) != 0) // class obj
            {
                l.pop(2); // X
                l.pushnil(); // nil
                return false;
            }
            l.remove(-2); // obj
            return true;
        }

        public static TOut PushArgsAndCall<TIn, TOut>(this IntPtr l, TIn args)
            where TIn : struct, ILuaPack
            where TOut : struct, ILuaPack
        {
            TOut result;
            PushArgsAndCall(l, args, out result);
            return result;
        }
        public static void PushArgsAndCall<TIn, TOut>(this IntPtr l, TIn args, out TOut result)
            where TIn : struct, ILuaPack
            where TOut : struct, ILuaPack
        {
            result = default(TOut);
            if (l != IntPtr.Zero)
            {
                var oldtop = l.gettop(); // func
                l.pushcfunction(LuaHub.LuaFuncOnError); // func error
                l.insert(oldtop); // error func
                var argc = args.ElementCount;
                args.PushToLua(l); // error func args
                var code = l.pcall(argc, result.ElementCount, oldtop); // error results
                if (code == 0)
                {
                    int onstackcnt = result.OnStackCount();
                    if (onstackcnt > 0)
                    {
                        l.remove(oldtop); // results
                        result.GetFromLua(l);
                        int popcnt = result.ElementCount - onstackcnt;
                        if (popcnt > 0)
                        {
                            l.pop(popcnt);
                        }
                    }
                    else
                    {
                        result.GetFromLua(l);
                        l.settop(oldtop - 1); // X
                    }
                }
                else
                {
                    l.settop(oldtop - 1); // X
                }
            }
        }
        public static void PushArgsAndCallSelf<TIn, TOut, TSelf>(this IntPtr l, TSelf self, TIn args, out TOut result)
            where TIn : struct, ILuaPack
            where TOut : struct, ILuaPack
        {
            result = default(TOut);
            if (l != IntPtr.Zero)
            {
                var oldtop = l.gettop(); // func
                l.pushcfunction(LuaHub.LuaFuncOnError); // func error
                l.insert(oldtop); // error func
                l.PushLua(self); // error func self
                var argc = args.ElementCount;
                args.PushToLua(l); // error func self args
                var code = l.pcall(argc + 1, result.ElementCount, oldtop); // error results
                if (code == 0)
                {
                    int onstackcnt = result.OnStackCount();
                    if (onstackcnt > 0)
                    {
                        l.remove(oldtop); // results
                        result.GetFromLua(l);
                        int popcnt = result.ElementCount - onstackcnt;
                        if (popcnt > 0)
                        {
                            l.pop(popcnt);
                        }
                    }
                    else
                    {
                        result.GetFromLua(l);
                        l.settop(oldtop - 1); // X
                    }
                }
                else
                {
                    l.settop(oldtop - 1); // X
                }
            }
        }
        public static TOut CallGlobal<TIn, TOut>(this IntPtr l, string name, TIn args)
            where TIn : struct, ILuaPack
            where TOut : struct, ILuaPack
        {
            TOut result;
            CallGlobal(l, name, args, out result);
            return result;
        }
        public static void CallGlobal<TIn, TOut>(this IntPtr l, string name, TIn args, out TOut result)
            where TIn : struct, ILuaPack
            where TOut : struct, ILuaPack
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                l.PushArgsAndCall(args, out result);
            }
            else
            {
                result = default(TOut);
            }
        }
        public static TOut CallGlobalHierarchical<TIn, TOut>(this IntPtr l, string name, TIn args)
            where TIn : struct, ILuaPack
            where TOut : struct, ILuaPack
        {
            TOut result;
            CallGlobalHierarchical(l, name, args, out result);
            return result;
        }
        public static void CallGlobalHierarchical<TIn, TOut>(this IntPtr l, string name, TIn args, out TOut result)
            where TIn : struct, ILuaPack
            where TOut : struct, ILuaPack
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    l.PushArgsAndCall(args, out result);
                    return;
                }
            }
            result = default(TOut);
        }

        public static int DoString(this IntPtr l, string chunk)
        {
            int result = l.loadstring(chunk);
            if (result != 0)
                return result;

            return l.PushArgsAndCallRaw();
        }
        public static void DoString<TOut>(this IntPtr l, string chunk, out TOut result)
            where TOut : struct, ILuaPack
        {
            int code = l.loadstring(chunk);
            if (code != 0)
            {
                result = default(TOut);
                l.pop(1);
                return;
            }
            l.PushArgsAndCall<LuaPack, TOut>(default(LuaPack), out result);
        }
        public static TOut DoString<TOut>(this IntPtr l, string chunk)
            where TOut : struct, ILuaPack
        {
            TOut result;
            DoString(l, chunk, out result);
            return result;
        }
        public static int DoFile(this IntPtr l, string path)
        {
            int result = l.loadfile(path);
            if (result != 0)
                return result;

            return l.PushArgsAndCallRaw();
        }
        public static void DoFile<TOut>(this IntPtr l, string path, out TOut result)
            where TOut : struct, ILuaPack
        {
            int code = l.loadfile(path);
            if (code != 0)
            {
                result = default(TOut);
                l.pop(1);
                return;
            }
            l.PushArgsAndCall<LuaPack, TOut>(default(LuaPack), out result);
        }
        public static TOut DoFile<TOut>(this IntPtr l, string path)
            where TOut : struct, ILuaPack
        {
            TOut result;
            DoFile(l, path, out result);
            return result;
        }

        public static TOut GetTable<TOut>(this IntPtr l, int index, params string[] fields)
               where TOut : struct, ILuaPack
        {
            TOut result;
            GetTable(l, index, out result, fields);
            return result;
        }
        public static void GetTable<TOut>(this IntPtr l, int index, out TOut result, params string[] fields)
            where TOut : struct, ILuaPack
        {
            result = default(TOut);
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    var rindex = l.NormalizeIndex(index);
                    var oldtop = l.gettop();
                    l.checkstack(result.ElementCount + 1);
                    if (fields == null || fields.Length == 0)
                    {
                        // array.
                        for (int i = 0; i < result.ElementCount; ++i)
                        {
                            l.pushnumber(i + 1);
                            l.gettable(rindex);
                        }
                        result.GetFromLua(l);
                    }
                    else
                    {
                        for (int i = 0; i < result.ElementCount; ++i)
                        {
                            if (fields.Length > i)
                            {
                                l.PushLua(fields[i]);
                                l.gettable(rindex);
                            }
                            else
                            {
                                l.pushnil();
                            }
                        }
                        result.GetFromLua(l);
                    }
                    l.settop(oldtop + result.OnStackCount());
                }
            }
        }
        public static void GetTableAndRemove<TOut>(this IntPtr l, int index, out TOut result, params string[] fields)
            where TOut : struct, ILuaPack
        {
            result = default(TOut);
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    var rindex = l.NormalizeIndex(index);
                    var oldtop = l.gettop();
                    l.checkstack(result.ElementCount + 1);
                    if (fields == null || fields.Length == 0)
                    {
                        // array.
                        for (int i = 0; i < result.ElementCount; ++i)
                        {
                            l.pushnumber(i + 1);
                            l.gettable(rindex);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < result.ElementCount; ++i)
                        {
                            if (fields.Length > i)
                            {
                                l.PushLua(fields[i]);
                                l.gettable(rindex);
                            }
                            else
                            {
                                l.pushnil();
                            }
                        }
                    }
                    l.remove(rindex);
                    result.GetFromLua(l);
                    l.settop(oldtop + result.OnStackCount() - 1);
                }
                else
                {
                    l.remove(index);
                }
            }
        }
        public static void SetTable<TIn>(this IntPtr l, int index, TIn args, params string[] fields)
            where TIn : struct, ILuaPack
        {
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    var rindex = l.NormalizeIndex(index);
                    using (var lr = l.CreateStackRecover())
                    {
                        l.checkstack(args.ElementCount + 2);
                        args.PushToLua(l);
                        if (fields == null || fields.Length == 0)
                        {
                            // array.
                            for (int i = 0; i < args.ElementCount; ++i)
                            {
                                l.pushnumber(i + 1);
                                l.pushvalue(i - args.ElementCount - 1);
                                l.settable(rindex);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < args.ElementCount; ++i)
                            {
                                if (fields.Length > i)
                                {
                                    l.PushLua(fields[i]);
                                    l.pushvalue(i - args.ElementCount - 1);
                                    l.settable(rindex);
                                }
                                //else
                                //{
                                //    // Nothing to do...
                                //}
                            }
                        }
                    }
                }
            }
        }
        public static TOut GetTable<TOut>(this IntPtr l, int index, string fieldname, params string[] fields)
               where TOut : struct, ILuaPack
        {
            TOut result;
            GetTable(l, index, fieldname, out result, fields);
            return result;
        }
        public static void GetTable<TOut>(this IntPtr l, int index, string fieldname, out TOut result, params string[] fields)
            where TOut : struct, ILuaPack
        {
            result = default(TOut);
            if (string.IsNullOrEmpty(fieldname))
            {
                GetTable(l, index, out result, fields);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        l.GetField(index, fieldname);
                        GetTableAndRemove(l, -1, out result, fields);
                    }
                }
            }
        }
        public static void SetTable<TIn>(this IntPtr l, int index, string fieldname, TIn args, params string[] fields)
            where TIn : struct, ILuaPack
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                SetTable(l, index, args, fields);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        l.GetField(index, fieldname);
                        if (l.isnoneornil(-1))
                        {
                            l.pop(1);
                            var rindex = l.NormalizeIndex(index);
                            l.newtable();
                            l.pushvalue(-1);
                            l.SetField(rindex, fieldname);
                        }
                        SetTable(l, -1, args, fields);
                        l.pop(1);
                    }
                }
            }
        }
        public static TOut GetTableHierarchical<TOut>(this IntPtr l, int index, string fieldname, params string[] fields)
               where TOut : struct, ILuaPack
        {
            TOut result;
            GetTableHierarchical(l, index, fieldname, out result, fields);
            return result;
        }
        public static void GetTableHierarchical<TOut>(this IntPtr l, int index, string fieldname, out TOut result, params string[] fields)
            where TOut : struct, ILuaPack
        {
            result = default(TOut);
            if (string.IsNullOrEmpty(fieldname))
            {
                GetTable(l, index, out result, fields);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        if (l.GetHierarchicalRaw(index, fieldname))
                        {
                            GetTableAndRemove(l, -1, out result, fields);
                        }
                    }
                }
            }
        }
        public static void SetTableHierarchical<TIn>(this IntPtr l, int index, string fieldname, TIn args, params string[] fields)
            where TIn : struct, ILuaPack
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                SetTable(l, index, args, fields);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        if (l.GetHierarchicalRaw(index, fieldname))
                        {
                            if (l.isnoneornil(-1))
                            {
                                l.pop(1);
                                var rindex = l.NormalizeIndex(index);
                                l.newtable();
                                l.SetHierarchicalRaw(rindex, fieldname, -1);
                            }
                            SetTable(l, -1, args, fields);
                            l.pop(1);
                        }
                    }
                }
            }
        }
        public static TOut GetGlobalTable<TOut>(this IntPtr l, string name, params string[] fields)
            where TOut : struct, ILuaPack
        {
            TOut result;
            GetGlobalTable(l, name, out result, fields);
            return result;
        }
        public static void GetGlobalTable<TOut>(this IntPtr l, string name, out TOut result, params string[] fields)
            where TOut : struct, ILuaPack
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                GetTableAndRemove(l, -1, out result, fields);
            }
            else
            {
                result = default(TOut);
            }
        }
        public static void SetGlobalTable<TIn>(this IntPtr l, string name, TIn args, params string[] fields)
            where TIn : struct, ILuaPack
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                if (l.isnoneornil(-1))
                {
                    l.pop(1);
                    l.newtable();
                    l.pushvalue(-1);
                    l.SetGlobal(name);
                }
                SetTable(l, -1, args, fields);
                l.pop(1);
            }
        }
        public static TOut GetGlobalTableHierarchical<TOut>(this IntPtr l, string name, params string[] fields)
            where TOut : struct, ILuaPack
        {
            TOut result;
            GetGlobalTableHierarchical(l, name, out result, fields);
            return result;
        }
        public static void GetGlobalTableHierarchical<TOut>(this IntPtr l, string name, out TOut result, params string[] fields)
            where TOut : struct, ILuaPack
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    GetTableAndRemove(l, -1, out result, fields);
                    return;
                }
            }
            result = default(TOut);
        }
        public static void SetGlobalTableHierarchical<TIn>(this IntPtr l, string name, TIn args, params string[] fields)
            where TIn : struct, ILuaPack
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    if (l.isnoneornil(-1))
                    {
                        l.pop(1);
                        l.newtable();
                        l.SetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name, -1);
                    }
                    SetTable(l, -1, args, fields);
                    l.pop(1);
                }
            }
        }

        public static Dictionary<TKey, TVal> GetDict<TKey, TVal>(this IntPtr l, int index)
        {
            Dictionary<TKey, TVal> dict = new Dictionary<TKey, TVal>();
            GetDict(l, index, dict);
            return dict;
        }
        public static void GetDict<TKey, TVal>(this IntPtr l, int index, IDictionary<TKey, TVal> dict)
        {
            dict.Clear();
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    using (var lr = l.CreateStackRecover())
                    {
                        l.pushvalue(index);
                        {
                            l.pushnil();
                            while (l.next(-2))
                            {
                                TKey key;
                                TVal val;
                                l.GetLua(-2, out key);
                                l.GetLua(-1, out val);
                                dict[key] = val;
                                l.pop(1);
                            }
                        }
                        l.pop(1);
                    }
                }
            }
        }
        public static void SetDict<TKey, TVal>(this IntPtr l, int index, IDictionary<TKey, TVal> dict)
        {
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    using (var lr = l.CreateStackRecover())
                    {
                        l.pushvalue(index);
                        foreach (var kvp in dict)
                        {
                            l.PushLua(kvp.Key);
                            l.PushLua(kvp.Value);
                            l.settable(-3);
                        }
                    }
                }
            }
        }
        public static Dictionary<TKey, TVal> GetDict<TKey, TVal>(this IntPtr l, int index, string fieldname)
        {
            Dictionary<TKey, TVal> dict = new Dictionary<TKey, TVal>();
            GetDict(l, index, fieldname, dict);
            return dict;
        }
        public static void GetDict<TKey, TVal>(this IntPtr l, int index, string fieldname, IDictionary<TKey, TVal> dict)
        {
            dict.Clear();
            if (string.IsNullOrEmpty(fieldname))
            {
                GetDict(l, index, dict);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        l.GetField(index, fieldname);
                        GetDict(l, -1, dict);
                        l.pop(1);
                    }
                }
            }
        }
        public static void SetDict<TKey, TVal>(this IntPtr l, int index, string fieldname, IDictionary<TKey, TVal> dict)
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                SetDict(l, index, dict);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        l.GetField(index, fieldname);
                        if (l.isnoneornil(-1))
                        {
                            l.pop(1);
                            var rindex = l.NormalizeIndex(index);
                            l.newtable();
                            l.pushvalue(-1);
                            l.SetField(rindex, fieldname);
                        }
                        SetDict(l, -1, dict);
                        l.pop(1);
                    }
                }
            }
        }
        public static Dictionary<TKey, TVal> GetDictHierarchical<TKey, TVal>(this IntPtr l, int index, string fieldname)
        {
            Dictionary<TKey, TVal> dict = new Dictionary<TKey, TVal>();
            GetDictHierarchical(l, index, fieldname, dict);
            return dict;
        }
        public static void GetDictHierarchical<TKey, TVal>(this IntPtr l, int index, string fieldname, IDictionary<TKey, TVal> dict)
        {
            dict.Clear();
            if (string.IsNullOrEmpty(fieldname))
            {
                GetDict(l, index, dict);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        if (l.GetHierarchicalRaw(index, fieldname))
                        {
                            GetDict(l, -1, dict);
                            l.pop(1);
                        }
                    }
                }
            }
        }
        public static void SetDictHierarchical<TKey, TVal>(this IntPtr l, int index, string fieldname, IDictionary<TKey, TVal> dict)
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                SetDict(l, index, dict);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        if (l.GetHierarchicalRaw(index, fieldname))
                        {
                            if (l.isnoneornil(-1))
                            {
                                l.pop(1);
                                var rindex = l.NormalizeIndex(index);
                                l.newtable();
                                l.SetHierarchicalRaw(rindex, fieldname, -1);
                            }
                            SetDict(l, -1, dict);
                            l.pop(1);
                        }
                    }
                }
            }
        }
        public static Dictionary<TKey, TVal> GetGlobalDict<TKey, TVal>(this IntPtr l, string name)
        {
            Dictionary<TKey, TVal> dict = new Dictionary<TKey, TVal>();
            GetGlobalDict(l, name, dict);
            return dict;
        }
        public static void GetGlobalDict<TKey, TVal>(this IntPtr l, string name, IDictionary<TKey, TVal> dict)
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                GetDict(l, -1, dict);
                l.pop(1);
            }
            else
            {
                dict.Clear();
            }
        }
        public static void SetGlobalDict<TKey, TVal>(this IntPtr l, string name, IDictionary<TKey, TVal> dict)
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                if (l.isnoneornil(-1))
                {
                    l.pop(1);
                    l.newtable();
                    l.pushvalue(-1);
                    l.SetGlobal(name);
                }
                SetDict(l, -1, dict);
                l.pop(1);
            }
        }
        public static Dictionary<TKey, TVal> GetGlobalDictHierarchical<TKey, TVal>(this IntPtr l, string name)
        {
            Dictionary<TKey, TVal> dict = new Dictionary<TKey, TVal>();
            GetGlobalDictHierarchical(l, name, dict);
            return dict;
        }
        public static void GetGlobalDictHierarchical<TKey, TVal>(this IntPtr l, string name, IDictionary<TKey, TVal> dict)
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    GetDict(l, -1, dict);
                    l.pop(1);
                    return;
                }
            }
            dict.Clear();
        }
        public static void SetGlobalDictHierarchical<TKey, TVal>(this IntPtr l, string name, IDictionary<TKey, TVal> dict)
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    if (l.isnoneornil(-1))
                    {
                        l.pop(1);
                        l.newtable();
                        l.SetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name, -1);
                    }
                    SetDict(l, -1, dict);
                    l.pop(1);
                }
            }
        }

        public static T[] GetArray<T>(this IntPtr l, int index)
        {
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    using (var lr = l.CreateStackRecover())
                    {
                        l.pushvalue(index);
                        var cnt = l.getn(-1);
                        var array = new T[cnt];

                        for (int i = 1; i <= cnt; ++i)
                        {
                            l.pushnumber(i);
                            l.gettable(-2);
                            var val = l.GetLua<T>(-1);
                            array[i - 1] = val;
                            l.pop(1);
                        }

                        return array;
                    }
                }
            }
            return null;
        }
        public static Capstones.UnityEngineEx.ValueList<T> GetList<T>(this IntPtr l, int index)
        {
            Capstones.UnityEngineEx.ValueList<T> list = new Capstones.UnityEngineEx.ValueList<T>();
            GetList(l, index, ref list);
            return list;
        }
        public static void GetList<T>(this IntPtr l, int index, IList<T> list)
        {
            GetList<T, IList<T>>(l, index, list);
        }
        public static void GetList<T>(this IntPtr l, int index, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            GetList<T, Capstones.UnityEngineEx.ValueList<T>>(l, index, ref list);
        }
        public static void GetList<T, L>(this IntPtr l, int index, L list)
            where L : IList<T>
        {
            GetList<T, L>(l, index, ref list);
        }
        public static void GetList<T, L>(this IntPtr l, int index, ref L list)
            where L : IList<T>
        {
            list.Clear();
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    using (var lr = l.CreateStackRecover())
                    {
                        l.pushvalue(index);
                        var cnt = l.getn(-1);

                        for (int i = 1; i <= cnt; ++i)
                        {
                            l.pushnumber(i);
                            l.gettable(-2);
                            var val = l.GetLua<T>(-1);
                            list.Add(val);
                            l.pop(1);
                        }
                    }
                }
            }
        }
        public static void SetList<T>(this IntPtr l, int index, IList<T> list)
        {
            SetList<T, IList<T>>(l, index, list);
        }
        public static void SetList<T>(this IntPtr l, int index, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            SetList<T, Capstones.UnityEngineEx.ValueList<T>>(l, index, ref list);
        }
        public static void SetList<T, L>(this IntPtr l, int index, L list)
            where L : IList<T>
        {
            SetList<T, L>(l, index, ref list);
        }
        public static void SetList<T, L>(this IntPtr l, int index, ref L list)
            where L : IList<T>
        {
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    using (var lr = l.CreateStackRecover())
                    {
                        l.pushvalue(index);
                        var cnt = list.Count;
                        for (int i = 0; i < cnt; ++i)
                        {
                            l.pushnumber(i + 1);
                            l.PushLua(list[i]);
                            l.settable(-3);
                        }
                        var lcnt = l.getn(-1);
                        for (int i = cnt + 1; i <= lcnt; ++i)
                        {
                            l.pushnumber(i);
                            l.pushnil();
                            l.settable(-3);
                        }
                    }
                }
            }
        }

        public static T[] GetArray<T>(this IntPtr l, int index, string fieldname)
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                return GetArray<T>(l, index);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        l.GetField(index, fieldname);
                        var rv = GetArray<T>(l, -1);
                        l.pop(1);
                        return rv;
                    }
                }
            }
            return null;
        }
        public static Capstones.UnityEngineEx.ValueList<T> GetList<T>(this IntPtr l, int index, string fieldname)
        {
            Capstones.UnityEngineEx.ValueList<T> list = new Capstones.UnityEngineEx.ValueList<T>();
            GetList(l, index, fieldname, ref list);
            return list;
        }
        public static void GetList<T>(this IntPtr l, int index, string fieldname, IList<T> list)
        {
            GetList<T, IList<T>>(l, index, fieldname, list);
        }
        public static void GetList<T>(this IntPtr l, int index, string fieldname, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            GetList<T, Capstones.UnityEngineEx.ValueList<T>>(l, index, fieldname, ref list);
        }
        public static void GetList<T, L>(this IntPtr l, int index, string fieldname, L list)
            where L : IList<T>
        {
            GetList<T, L>(l, index, fieldname, ref list);
        }
        public static void GetList<T, L>(this IntPtr l, int index, string fieldname, ref L list)
            where L : IList<T>
        {
            list.Clear();
            if (string.IsNullOrEmpty(fieldname))
            {
                GetList<T, L>(l, index, ref list);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        l.GetField(index, fieldname);
                        GetList<T, L>(l, -1, ref list);
                        l.pop(1);
                    }
                }
            }
        }
        public static void SetList<T>(this IntPtr l, int index, string fieldname, IList<T> list)
        {
            SetList<T, IList<T>>(l, index, fieldname, list);
        }
        public static void SetList<T>(this IntPtr l, int index, string fieldname, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            SetList<T, Capstones.UnityEngineEx.ValueList<T>>(l, index, fieldname, ref list);
        }
        public static void SetList<T, L>(this IntPtr l, int index, string fieldname, L list)
            where L : IList<T>
        {
            SetList<T, L>(l, index, fieldname, ref list);
        }
        public static void SetList<T, L>(this IntPtr l, int index, string fieldname, ref L list)
            where L : IList<T>
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                SetList<T, L>(l, index, ref list);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        l.GetField(index, fieldname);
                        if (l.isnoneornil(-1))
                        {
                            l.pop(1);
                            var rindex = l.NormalizeIndex(index);
                            l.newtable();
                            l.pushvalue(-1);
                            l.SetField(rindex, fieldname);
                        }
                        SetList<T, L>(l, -1, ref list);
                        l.pop(1);
                    }
                }
            }
        }

        public static T[] GetArrayHierarchical<T>(this IntPtr l, int index, string fieldname)
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                return GetArray<T>(l, index);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        if (l.GetHierarchicalRaw(index, fieldname))
                        {
                            var rv = GetArray<T>(l, -1);
                            l.pop(1);
                            return rv;
                        }
                    }
                }
            }
            return null;
        }
        public static Capstones.UnityEngineEx.ValueList<T> GetListHierarchical<T>(this IntPtr l, int index, string fieldname)
        {
            Capstones.UnityEngineEx.ValueList<T> list = new Capstones.UnityEngineEx.ValueList<T>();
            GetListHierarchical(l, index, fieldname, ref list);
            return list;
        }
        public static void GetListHierarchical<T>(this IntPtr l, int index, string fieldname, IList<T> list)
        {
            GetListHierarchical<T, IList<T>>(l, index, fieldname, list);
        }
        public static void GetListHierarchical<T>(this IntPtr l, int index, string fieldname, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            GetListHierarchical<T, Capstones.UnityEngineEx.ValueList<T>>(l, index, fieldname, ref list);
        }
        public static void GetListHierarchical<T, L>(this IntPtr l, int index, string fieldname, L list)
            where L : IList<T>
        {
            GetListHierarchical<T, L>(l, index, fieldname, ref list);
        }
        public static void GetListHierarchical<T, L>(this IntPtr l, int index, string fieldname, ref L list)
            where L : IList<T>
        {
            list.Clear();
            if (string.IsNullOrEmpty(fieldname))
            {
                GetList<T, L>(l, index, ref list);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        if (l.GetHierarchicalRaw(index, fieldname))
                        {
                            GetList<T, L>(l, -1, ref list);
                            l.pop(1);
                        }
                    }
                }
            }
        }
        public static void SetListHierarchical<T>(this IntPtr l, int index, string fieldname, IList<T> list)
        {
            SetListHierarchical<T, IList<T>>(l, index, fieldname, list);
        }
        public static void SetListHierarchical<T>(this IntPtr l, int index, string fieldname, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            SetListHierarchical<T, Capstones.UnityEngineEx.ValueList<T>>(l, index, fieldname, ref list);
        }
        public static void SetListHierarchical<T, L>(this IntPtr l, int index, string fieldname, L list)
            where L : IList<T>
        {
            SetListHierarchical<T, L>(l, index, fieldname, ref list);
        }
        public static void SetListHierarchical<T, L>(this IntPtr l, int index, string fieldname, ref L list)
            where L : IList<T>
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                SetList<T, L>(l, index, ref list);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        if (l.GetHierarchicalRaw(index, fieldname))
                        {
                            if (l.isnoneornil(-1))
                            {
                                l.pop(1);
                                var rindex = l.NormalizeIndex(index);
                                l.newtable();
                                l.SetHierarchicalRaw(rindex, fieldname, -1);
                            }
                            SetList<T, L>(l, -1, ref list);
                            l.pop(1);
                        }
                    }
                }
            }
        }

        public static T[] GetGlobalArray<T>(this IntPtr l, string name)
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                var rv = GetArray<T>(l, -1);
                l.pop(1);
                return rv;
            }
            else
            {
                return null;
            }
        }
        public static Capstones.UnityEngineEx.ValueList<T> GetGlobalList<T>(this IntPtr l, string name)
        {
            Capstones.UnityEngineEx.ValueList<T> list = new Capstones.UnityEngineEx.ValueList<T>();
            GetGlobalList(l, name, ref list);
            return list;
        }
        public static void GetGlobalList<T>(this IntPtr l, string name, IList<T> list)
        {
            GetGlobalList<T, IList<T>>(l, name, list);
        }
        public static void GetGlobalList<T>(this IntPtr l, string name, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            GetGlobalList<T, Capstones.UnityEngineEx.ValueList<T>>(l, name, ref list);
        }
        public static void GetGlobalList<T, L>(this IntPtr l, string name, L list)
            where L : IList<T>
        {
            GetGlobalList<T, L>(l, name, ref list);
        }
        public static void GetGlobalList<T, L>(this IntPtr l, string name, ref L list)
            where L : IList<T>
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                GetList<T, L>(l, -1, ref list);
                l.pop(1);
            }
            else
            {
                list.Clear();
            }
        }
        public static void SetGlobalList<T>(this IntPtr l, string name, IList<T> list)
        {
            SetGlobalList<T, IList<T>>(l, name, list);
        }
        public static void SetGlobalList<T>(this IntPtr l, string name, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            SetGlobalList<T, Capstones.UnityEngineEx.ValueList<T>>(l, name, ref list);
        }
        public static void SetGlobalList<T, L>(this IntPtr l, string name, L list)
            where L : IList<T>
        {
            SetGlobalList<T, L>(l, name, ref list);
        }
        public static void SetGlobalList<T, L>(this IntPtr l, string name, ref L list)
            where L : IList<T>
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                if (l.isnoneornil(-1))
                {
                    l.pop(1);
                    l.newtable();
                    l.pushvalue(-1);
                    l.SetGlobal(name);
                }
                SetList<T, L>(l, -1, ref list);
                l.pop(1);
            }
        }

        public static T[] GetGlobalArrayHierarchical<T>(this IntPtr l, string name)
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    var rv = GetArray<T>(l, -1);
                    l.pop(1);
                    return rv;
                }
            }
            return null;
        }
        public static Capstones.UnityEngineEx.ValueList<T> GetGlobalListHierarchical<T>(this IntPtr l, string name)
        {
            Capstones.UnityEngineEx.ValueList<T> list = new Capstones.UnityEngineEx.ValueList<T>();
            GetGlobalListHierarchical(l, name, ref list);
            return list;
        }
        public static void GetGlobalListHierarchical<T>(this IntPtr l, string name, IList<T> list)
        {
            GetGlobalListHierarchical<T, IList<T>>(l, name, list);
        }
        public static void GetGlobalListHierarchical<T>(this IntPtr l, string name, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            GetGlobalListHierarchical<T, Capstones.UnityEngineEx.ValueList<T>>(l, name, ref list);
        }
        public static void GetGlobalListHierarchical<T, L>(this IntPtr l, string name, L list)
            where L : IList<T>
        {
            GetGlobalListHierarchical<T, L>(l, name, ref list);
        }
        public static void GetGlobalListHierarchical<T, L>(this IntPtr l, string name, ref L list)
            where L : IList<T>
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    GetList<T, L>(l, -1, ref list);
                    l.pop(1);
                    return;
                }
            }
            list.Clear();
        }
        public static void SetGlobalListHierarchical<T>(this IntPtr l, string name, IList<T> list)
        {
            SetGlobalListHierarchical<T, IList<T>>(l, name, list);
        }
        public static void SetGlobalListHierarchical<T>(this IntPtr l, string name, ref Capstones.UnityEngineEx.ValueList<T> list)
        {
            SetGlobalListHierarchical<T, Capstones.UnityEngineEx.ValueList<T>>(l, name, ref list);
        }
        public static void SetGlobalListHierarchical<T, L>(this IntPtr l, string name, L list)
            where L : IList<T>
        {
            SetGlobalListHierarchical<T, L>(l, name, ref list);
        }
        public static void SetGlobalListHierarchical<T, L>(this IntPtr l, string name, ref L list)
            where L : IList<T>
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    if (l.isnoneornil(-1))
                    {
                        l.pop(1);
                        l.newtable();
                        l.SetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name, -1);
                    }
                    SetList<T, L>(l, -1, ref list);
                    l.pop(1);
                }
            }
        }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static void GetList<T>(this IntPtr l, int index, ref System.Span<T> list)
        {
            list.Clear();
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    using (var lr = l.CreateStackRecover())
                    {
                        l.pushvalue(index);
                        var cnt = l.getn(-1);

                        for (int i = 1; i <= cnt; ++i)
                        {
                            l.pushnumber(i);
                            l.gettable(-2);
                            var val = l.GetLua<T>(-1);
                            list[i - 1] = val;
                            l.pop(1);
                        }
                    }
                }
            }
        }
        public static void SetList<T>(this IntPtr l, int index, ref System.Span<T> list)
        {
            if (l != IntPtr.Zero)
            {
                if (l.istable(index) || l.IsUserData(index))
                {
                    using (var lr = l.CreateStackRecover())
                    {
                        l.pushvalue(index);
                        var cnt = list.Length;
                        for (int i = 0; i < cnt; ++i)
                        {
                            l.pushnumber(i + 1);
                            l.PushLua(list[i]);
                            l.settable(-3);
                        }
                        var lcnt = l.getn(-1);
                        for (int i = cnt + 1; i <= lcnt; ++i)
                        {
                            l.pushnumber(i);
                            l.pushnil();
                            l.settable(-3);
                        }
                    }
                }
            }
        }
        public static void GetList<T>(this IntPtr l, int index, string fieldname, ref System.Span<T> list)
        {
            list.Clear();
            if (string.IsNullOrEmpty(fieldname))
            {
                GetList<T>(l, index, ref list);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        l.GetField(index, fieldname);
                        GetList<T>(l, -1, ref list);
                        l.pop(1);
                    }
                }
            }
        }
        public static void SetList<T>(this IntPtr l, int index, string fieldname, ref System.Span<T> list)
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                SetList<T>(l, index, ref list);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        l.GetField(index, fieldname);
                        if (l.isnoneornil(-1))
                        {
                            l.pop(1);
                            var rindex = l.NormalizeIndex(index);
                            l.newtable();
                            l.pushvalue(-1);
                            l.SetField(rindex, fieldname);
                        }
                        SetList<T>(l, -1, ref list);
                        l.pop(1);
                    }
                }
            }
        }
        public static void GetListHierarchical<T>(this IntPtr l, int index, string fieldname, ref System.Span<T> list)
        {
            list.Clear();
            if (string.IsNullOrEmpty(fieldname))
            {
                GetList<T>(l, index, ref list);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        if (l.GetHierarchicalRaw(index, fieldname))
                        {
                            GetList<T>(l, -1, ref list);
                            l.pop(1);
                        }
                    }
                }
            }
        }
        public static void SetListHierarchical<T>(this IntPtr l, int index, string fieldname, ref System.Span<T> list)
        {
            if (string.IsNullOrEmpty(fieldname))
            {
                SetList<T>(l, index, ref list);
            }
            else
            {
                if (l != IntPtr.Zero)
                {
                    if (l.istable(index) || l.IsUserData(index))
                    {
                        if (l.GetHierarchicalRaw(index, fieldname))
                        {
                            if (l.isnoneornil(-1))
                            {
                                l.pop(1);
                                var rindex = l.NormalizeIndex(index);
                                l.newtable();
                                l.SetHierarchicalRaw(rindex, fieldname, -1);
                            }
                            SetList<T>(l, -1, ref list);
                            l.pop(1);
                        }
                    }
                }
            }
        }
        public static void GetGlobalList<T>(this IntPtr l, string name, ref System.Span<T> list)
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                GetList<T>(l, -1, ref list);
                l.pop(1);
            }
            else
            {
                list.Clear();
            }
        }
        public static void SetGlobalList<T>(this IntPtr l, string name, ref System.Span<T> list)
        {
            if (l != IntPtr.Zero)
            {
                l.GetGlobal(name);
                if (l.isnoneornil(-1))
                {
                    l.pop(1);
                    l.newtable();
                    l.pushvalue(-1);
                    l.SetGlobal(name);
                }
                SetList<T>(l, -1, ref list);
                l.pop(1);
            }
        }
        public static void GetGlobalListHierarchical<T>(this IntPtr l, string name, ref System.Span<T> list)
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    GetList<T>(l, -1, ref list);
                    l.pop(1);
                    return;
                }
            }
            list.Clear();
        }
        public static void SetGlobalListHierarchical<T>(this IntPtr l, string name, ref System.Span<T> list)
        {
            if (l != IntPtr.Zero)
            {
                if (l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name))
                {
                    if (l.isnoneornil(-1))
                    {
                        l.pop(1);
                        l.newtable();
                        l.SetHierarchicalRaw(lua.LUA_GLOBALSINDEX, name, -1);
                    }
                    SetList<T>(l, -1, ref list);
                    l.pop(1);
                }
            }
        }
#endif

        public static LuaStackPos Require(this IntPtr l, string lib)
        {
            l.GetGlobal("require");
            l.PushArgsAndCallRawSingleReturn(lib);
            return l.OnStackTop();
        }
        public static TOut Require<TOut>(this IntPtr l, string name, params string[] fields)
            where TOut : struct, ILuaPack
        {
            TOut result;
            Require(l, name, out result, fields);
            return result;
        }
        public static void Require<TOut>(this IntPtr l, string name, out TOut result, params string[] fields)
            where TOut : struct, ILuaPack
        {
            if (l != IntPtr.Zero)
            {
                l.Require(name);
                GetTableAndRemove(l, -1, out result, fields);
            }
            else
            {
                result = default(TOut);
            }
        }

        public static void ForEach(this IntPtr l, int index, Action action)
        {
            if (l != IntPtr.Zero && action != null)
            {
                l.pushvalue(index);
                if (l.istable(index) || l.IsUserData(index))
                {
                    l.pushnil();
                    while (l.next(-2))
                    {
                        action();
                        l.pop(1);
                    }
                }
                l.pop(1);
            }
        }
        public static void ForEach(this IntPtr l, int index, Action<IntPtr> action)
        {
            if (l != IntPtr.Zero && action != null)
            {
                l.pushvalue(index);
                if (l.istable(index) || l.IsUserData(index))
                {
                    l.pushnil();
                    while (l.next(-2))
                    {
                        action(l);
                        l.pop(1);
                    }
                }
                l.pop(1);
            }
        }
        public static void ForEach<TKey, TVal>(this IntPtr l, int index, Action<TKey, TVal> action)
        {
            if (l != IntPtr.Zero && action != null)
            {
                l.pushvalue(index);
                if (l.istable(index) || l.IsUserData(index))
                {
                    l.pushnil();
                    while (l.next(-2))
                    {
                        TKey key;
                        TVal val;
                        l.GetLua(-2, out key);
                        l.GetLua(-1, out val);
                        action(key, val);
                        l.pop(1);
                    }
                }
                l.pop(1);
            }
        }
        public static void ForEachIndex(this IntPtr l, int index, Action action)
        {
            if (l != IntPtr.Zero && action != null)
            {
                l.pushvalue(index);
                if (l.istable(index) || l.IsUserData(index))
                {
                    var cnt = l.getn(-1);
                    for (int i = 1; i <= cnt; ++i)
                    {
                        l.pushnumber(i);
                        l.pushvalue(-1);
                        l.gettable(-3);
                        action();
                        l.pop(2);
                    }
                }
                l.pop(1);
            }
        }
        public static void ForEachIndex(this IntPtr l, int index, Action<int> action)
        {
            if (l != IntPtr.Zero && action != null)
            {
                l.pushvalue(index);
                if (l.istable(index) || l.IsUserData(index))
                {
                    var cnt = l.getn(-1);
                    for (int i = 1; i <= cnt; ++i)
                    {
                        l.pushnumber(i);
                        l.gettable(-2);
                        action(i);
                        l.pop(1);
                    }
                }
                l.pop(1);
            }
        }
        public static void ForEachIndex(this IntPtr l, int index, Action<IntPtr, int> action)
        {
            if (l != IntPtr.Zero && action != null)
            {
                l.pushvalue(index);
                if (l.istable(index) || l.IsUserData(index))
                {
                    var cnt = l.getn(-1);
                    for (int i = 1; i <= cnt; ++i)
                    {
                        l.pushnumber(i);
                        l.gettable(-2);
                        action(l, i);
                        l.pop(1);
                    }
                }
                l.pop(1);
            }
        }
        public static void ForEachIndex<TVal>(this IntPtr l, int index, Action<int, TVal> action)
        {
            if (l != IntPtr.Zero && action != null)
            {
                l.pushvalue(index);
                if (l.istable(index) || l.IsUserData(index))
                {
                    var cnt = l.getn(-1);
                    for (int i = 1; i <= cnt; ++i)
                    {
                        l.pushnumber(i);
                        l.gettable(-2);
                        TVal val;
                        l.GetLua(-1, out val);
                        action(i, val);
                        l.pop(1);
                    }
                }
                l.pop(1);
            }
        }
    }
}

namespace Capstones.LuaWrap
{
    public interface ILuaPack
    {
        int ElementCount { get; }
        void PushToLua(IntPtr l);
        void GetFromLua(IntPtr l);
        object this[int index] { get; set; }
        Type GetType(int index);
    }
    public static class LuaPackExtensions
    {
        public static object[] ToArray<TLuaPack>(this ref TLuaPack pack) where TLuaPack : struct, ILuaPack
        {
            var cnt = pack.ElementCount;
            var arr = new object[cnt];
            for (int i = 0; i < cnt; ++i)
            {
                arr[i] = pack[i];
            }
            return arr;
        }
        public static bool IsOnStack(this Type type)
        {
            return type == typeof(LuaStackPos) || type.IsSubclassOf(typeof(BaseLuaOnStack));
        }
        public static bool HasOnStack<TLuaPack>(this ref TLuaPack pack) where TLuaPack : struct, ILuaPack
        {
            for (int i = 0; i < pack.ElementCount; ++i)
            {
                var type = pack.GetType(i);
                if (type.IsOnStack())
                {
                    return true;
                }
            }
            return false;
        }
        public static int OnStackCount<TLuaPack>(this ref TLuaPack pack) where TLuaPack : struct, ILuaPack
        {
            int cnt = 0;
            for (int i = 0; i < pack.ElementCount; ++i)
            {
                var type = pack.GetType(i);
                if (type.IsOnStack())
                {
                    ++cnt;
                }
            }
            return cnt;
        }
    }
    public struct LuaPackIndexAccessor<TLuaPack> where TLuaPack : struct, ILuaPack
    {
        public delegate object DelGetter(ref TLuaPack thiz);
        public delegate void DelSetter(ref TLuaPack thiz, object val);

        public DelGetter Getter;
        public DelSetter Setter;
    }
    public class LuaPackIndexAccessorList<TLuaPack> : List<LuaPackIndexAccessor<TLuaPack>> where TLuaPack : struct, ILuaPack
    {
        public void Add(LuaPackIndexAccessor<TLuaPack>.DelGetter getter, LuaPackIndexAccessor<TLuaPack>.DelSetter setter)
        {
            Add(new LuaPackIndexAccessor<TLuaPack>() { Getter = getter, Setter = setter });
        }
        public object GetItem(ref TLuaPack thiz, int index)
        {
            return this[index].Getter(ref thiz);
        }
        public void SetItem(ref TLuaPack thiz, int index, object val)
        {
            this[index].Setter(ref thiz, val);
        }
    }
    public partial struct LuaPack : ILuaPack
    { // the dummy. it mean the func have no return values / no parameters.
        public int ElementCount { get { return 0; } }
        public void GetFromLua(IntPtr l)
        {
        }
        public void PushToLua(IntPtr l)
        {
        }
        public object this[int index]
        {
            get { throw new IndexOutOfRangeException(); }
            set { throw new IndexOutOfRangeException(); }
        }
        public void Deconstruct() { }
        public static LuaPack Default { get { return new LuaPack(); } }
        public static LuaPack Pack() { return Default; }
        public Type GetType(int index) { throw new IndexOutOfRangeException(); }
    }
    public struct LuaPack<T0> : ILuaPack
    {
        public static implicit operator T0(LuaPack<T0> pack)
        {
            return pack.t0;
        }
        public static implicit operator LuaPack<T0>(T0 val)
        {
            return new LuaPack<T0>(val);
        }
        public T0 t0;
        public LuaPack(T0 p0)
        {
            t0 = p0;
        }

        public int ElementCount { get { return 1; } }
        public void GetFromLua(IntPtr l)
        {
            l.GetLua(-1, out t0);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0>>
        {
            { (ref LuaPack<T0> thiz) => thiz.t0, (ref LuaPack<T0> thiz, object val) => thiz.t0 = (T0)val },
        };
        public void Deconstruct(out T0 o0)
        {
            o0 = t0;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0>(ValueTuple<T0> t)
        {
            return new LuaPack<T0>(t.Item1);
        }
        public static implicit operator ValueTuple<T0>(LuaPack<T0> p)
        {
            return new ValueTuple<T0>(p.t0);
        }
#endif
    }
    public struct LuaPack<T0, T1> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public LuaPack(T0 p0, T1 p1)
        {
            t0 = p0;
            t1 = p1;
        }

        public int ElementCount { get { return 2; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -2 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -2 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -2 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t1);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1>>
        {
            { (ref LuaPack<T0, T1> thiz) => thiz.t0, (ref LuaPack<T0, T1> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1> thiz) => thiz.t1, (ref LuaPack<T0, T1> thiz, object val) => thiz.t1 = (T1)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1)
        {
            o0 = t0;
            o1 = t1;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1>(ValueTuple<T0, T1> t)
        {
            return new LuaPack<T0, T1>(t.Item1, t.Item2);
        }
        public static implicit operator ValueTuple<T0, T1>(LuaPack<T0, T1> p)
        {
            return new ValueTuple<T0, T1>(p.t0, p.t1);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public LuaPack(T0 p0, T1 p1, T2 p2)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
        }

        public int ElementCount { get { return 3; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -3 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -3 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -3 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -3 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -3 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t2);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2>>
        {
            { (ref LuaPack<T0, T1, T2> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2> thiz, object val) => thiz.t2 = (T2)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2>(ValueTuple<T0, T1, T2> t)
        {
            return new LuaPack<T0, T1, T2>(t.Item1, t.Item2, t.Item3);
        }
        public static implicit operator ValueTuple<T0, T1, T2>(LuaPack<T0, T1, T2> p)
        {
            return new ValueTuple<T0, T1, T2>(p.t0, p.t1, p.t2);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
        }

        public int ElementCount { get { return 4; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -4 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -4 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -4 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -4 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -4 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -4 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -4 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t3);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3>>
        {
            { (ref LuaPack<T0, T1, T2, T3> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3> thiz, object val) => thiz.t3 = (T3)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3>(ValueTuple<T0, T1, T2, T3> t)
        {
            return new LuaPack<T0, T1, T2, T3>(t.Item1, t.Item2, t.Item3, t.Item4);
        }
        public static implicit operator ValueTuple<T0, T1, T2, T3>(LuaPack<T0, T1, T2, T3> p)
        {
            return new ValueTuple<T0, T1, T2, T3>(p.t0, p.t1, p.t2, p.t3);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
        }

        public int ElementCount { get { return 5; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -5 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -5 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -5 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -5 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -5 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -5 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -5 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -5 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -5 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t4);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4> thiz, object val) => thiz.t4 = (T4)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4>(ValueTuple<T0, T1, T2, T3, T4> t)
        {
            return new LuaPack<T0, T1, T2, T3, T4>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5);
        }
        public static implicit operator ValueTuple<T0, T1, T2, T3, T4>(LuaPack<T0, T1, T2, T3, T4> p)
        {
            return new ValueTuple<T0, T1, T2, T3, T4>(p.t0, p.t1, p.t2, p.t3, p.t4);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
        }

        public int ElementCount { get { return 6; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -6 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -6 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -6 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -6 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -6 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -6 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -6 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -6 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -6 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -6 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -6 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t5);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5> thiz, object val) => thiz.t5 = (T5)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5>(ValueTuple<T0, T1, T2, T3, T4, T5> t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6);
        }
        public static implicit operator ValueTuple<T0, T1, T2, T3, T4, T5>(LuaPack<T0, T1, T2, T3, T4, T5> p)
        {
            return new ValueTuple<T0, T1, T2, T3, T4, T5>(p.t0, p.t1, p.t2, p.t3, p.t4, p.t5);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
        }

        public int ElementCount { get { return 7; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -7 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -7 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -7 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -7 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -7 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -7 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -7 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -7 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -7 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -7 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -7 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -7 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -7 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t6);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6> thiz, object val) => thiz.t6 = (T6)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6>(ValueTuple<T0, T1, T2, T3, T4, T5, T6> t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7);
        }
        public static implicit operator ValueTuple<T0, T1, T2, T3, T4, T5, T6>(LuaPack<T0, T1, T2, T3, T4, T5, T6> p)
        {
            return new ValueTuple<T0, T1, T2, T3, T4, T5, T6>(p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
        }

        public int ElementCount { get { return 8; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -8 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -8 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -8 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -8 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -8 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -8 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -8 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -8 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -8 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -8 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -8 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -8 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -8 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -8 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -8 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t7);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> thiz, object val) => thiz.t7 = (T7)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7>((T0, T1, T2, T3, T4, T5, T6, T7) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public T8 t8;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
            t8 = p8;
        }

        public int ElementCount { get { return 9; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -9 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -9 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -9 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -9 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -9 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -9 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -9 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -9 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -9 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -9 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -9 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -9 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -9 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -9 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -9 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t7);

            pos = -9 + 8;
            if (ElementTypes[8].IsOnStack())
            {
                if (onstackcnt < 8)
                {
                    var newpos = -9 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t8);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
            l.PushLua(t8);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz, object val) => thiz.t7 = (T7)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz) => thiz.t8, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> thiz, object val) => thiz.t8 = (T8)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7, out T8 o8)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
            o8 = t8;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8>((T0, T1, T2, T3, T4, T5, T6, T7, T8) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8, t.Item9);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7, p.t8);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public T8 t8;
        public T9 t9;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
            t8 = p8;
            t9 = p9;
        }

        public int ElementCount { get { return 10; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -10 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -10 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -10 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -10 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -10 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -10 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -10 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -10 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -10 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -10 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -10 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -10 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -10 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -10 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -10 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t7);

            pos = -10 + 8;
            if (ElementTypes[8].IsOnStack())
            {
                if (onstackcnt < 8)
                {
                    var newpos = -10 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t8);

            pos = -10 + 9;
            if (ElementTypes[9].IsOnStack())
            {
                if (onstackcnt < 9)
                {
                    var newpos = -10 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t9);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
            l.PushLua(t8);
            l.PushLua(t9);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t7 = (T7)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t8, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t8 = (T8)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz) => thiz.t9, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> thiz, object val) => thiz.t9 = (T9)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7, out T8 o8, out T9 o9)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
            o8 = t8;
            o9 = t9;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8, t.Item9, t.Item10);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7, p.t8, p.t9);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public T8 t8;
        public T9 t9;
        public T10 t10;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
            t8 = p8;
            t9 = p9;
            t10 = p10;
        }

        public int ElementCount { get { return 11; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -11 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -11 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -11 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -11 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -11 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -11 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -11 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -11 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t7);

            pos = -11 + 8;
            if (ElementTypes[8].IsOnStack())
            {
                if (onstackcnt < 8)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t8);

            pos = -11 + 9;
            if (ElementTypes[9].IsOnStack())
            {
                if (onstackcnt < 9)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t9);

            pos = -11 + 10;
            if (ElementTypes[10].IsOnStack())
            {
                if (onstackcnt < 10)
                {
                    var newpos = -11 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t10);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
            l.PushLua(t8);
            l.PushLua(t9);
            l.PushLua(t10);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t7 = (T7)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t8, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t8 = (T8)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t9, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t9 = (T9)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz) => thiz.t10, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> thiz, object val) => thiz.t10 = (T10)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7, out T8 o8, out T9 o9, out T10 o10)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
            o8 = t8;
            o9 = t9;
            o10 = t10;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8, t.Item9, t.Item10, t.Item11);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7, p.t8, p.t9, p.t10);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public T8 t8;
        public T9 t9;
        public T10 t10;
        public T11 t11;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
            t8 = p8;
            t9 = p9;
            t10 = p10;
            t11 = p11;
        }

        public int ElementCount { get { return 12; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -12 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -12 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -12 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -12 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -12 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -12 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -12 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -12 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t7);

            pos = -12 + 8;
            if (ElementTypes[8].IsOnStack())
            {
                if (onstackcnt < 8)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t8);

            pos = -12 + 9;
            if (ElementTypes[9].IsOnStack())
            {
                if (onstackcnt < 9)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t9);

            pos = -12 + 10;
            if (ElementTypes[10].IsOnStack())
            {
                if (onstackcnt < 10)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t10);

            pos = -12 + 11;
            if (ElementTypes[11].IsOnStack())
            {
                if (onstackcnt < 11)
                {
                    var newpos = -12 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t11);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
            l.PushLua(t8);
            l.PushLua(t9);
            l.PushLua(t10);
            l.PushLua(t11);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t7 = (T7)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t8, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t8 = (T8)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t9, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t9 = (T9)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t10, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t10 = (T10)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz) => thiz.t11, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> thiz, object val) => thiz.t11 = (T11)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7, out T8 o8, out T9 o9, out T10 o10, out T11 o11)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
            o8 = t8;
            o9 = t9;
            o10 = t10;
            o11 = t11;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8, t.Item9, t.Item10, t.Item11, t.Item12);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7, p.t8, p.t9, p.t10, p.t11);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public T8 t8;
        public T9 t9;
        public T10 t10;
        public T11 t11;
        public T12 t12;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
            t8 = p8;
            t9 = p9;
            t10 = p10;
            t11 = p11;
            t12 = p12;
        }

        public int ElementCount { get { return 13; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -13 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -13 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -13 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -13 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -13 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -13 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -13 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -13 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t7);

            pos = -13 + 8;
            if (ElementTypes[8].IsOnStack())
            {
                if (onstackcnt < 8)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t8);

            pos = -13 + 9;
            if (ElementTypes[9].IsOnStack())
            {
                if (onstackcnt < 9)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t9);

            pos = -13 + 10;
            if (ElementTypes[10].IsOnStack())
            {
                if (onstackcnt < 10)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t10);

            pos = -13 + 11;
            if (ElementTypes[11].IsOnStack())
            {
                if (onstackcnt < 11)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t11);

            pos = -13 + 12;
            if (ElementTypes[12].IsOnStack())
            {
                if (onstackcnt < 12)
                {
                    var newpos = -13 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t12);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
            l.PushLua(t8);
            l.PushLua(t9);
            l.PushLua(t10);
            l.PushLua(t11);
            l.PushLua(t12);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t7 = (T7)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t8, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t8 = (T8)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t9, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t9 = (T9)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t10, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t10 = (T10)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t11, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t11 = (T11)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz) => thiz.t12, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> thiz, object val) => thiz.t12 = (T12)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7, out T8 o8, out T9 o9, out T10 o10, out T11 o11, out T12 o12)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
            o8 = t8;
            o9 = t9;
            o10 = t10;
            o11 = t11;
            o12 = t12;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8, t.Item9, t.Item10, t.Item11, t.Item12, t.Item13);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7, p.t8, p.t9, p.t10, p.t11, p.t12);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public T8 t8;
        public T9 t9;
        public T10 t10;
        public T11 t11;
        public T12 t12;
        public T13 t13;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
            t8 = p8;
            t9 = p9;
            t10 = p10;
            t11 = p11;
            t12 = p12;
            t13 = p13;
        }

        public int ElementCount { get { return 14; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -14 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -14 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -14 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -14 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -14 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -14 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -14 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -14 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t7);

            pos = -14 + 8;
            if (ElementTypes[8].IsOnStack())
            {
                if (onstackcnt < 8)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t8);

            pos = -14 + 9;
            if (ElementTypes[9].IsOnStack())
            {
                if (onstackcnt < 9)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t9);

            pos = -14 + 10;
            if (ElementTypes[10].IsOnStack())
            {
                if (onstackcnt < 10)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t10);

            pos = -14 + 11;
            if (ElementTypes[11].IsOnStack())
            {
                if (onstackcnt < 11)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t11);

            pos = -14 + 12;
            if (ElementTypes[12].IsOnStack())
            {
                if (onstackcnt < 12)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t12);

            pos = -14 + 13;
            if (ElementTypes[13].IsOnStack())
            {
                if (onstackcnt < 13)
                {
                    var newpos = -14 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t13);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
            l.PushLua(t8);
            l.PushLua(t9);
            l.PushLua(t10);
            l.PushLua(t11);
            l.PushLua(t12);
            l.PushLua(t13);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t7 = (T7)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t8, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t8 = (T8)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t9, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t9 = (T9)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t10, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t10 = (T10)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t11, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t11 = (T11)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t12, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t12 = (T12)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz) => thiz.t13, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> thiz, object val) => thiz.t13 = (T13)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7, out T8 o8, out T9 o9, out T10 o10, out T11 o11, out T12 o12, out T13 o13)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
            o8 = t8;
            o9 = t9;
            o10 = t10;
            o11 = t11;
            o12 = t12;
            o13 = t13;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8, t.Item9, t.Item10, t.Item11, t.Item12, t.Item13, t.Item14);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7, p.t8, p.t9, p.t10, p.t11, p.t12, p.t13);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public T8 t8;
        public T9 t9;
        public T10 t10;
        public T11 t11;
        public T12 t12;
        public T13 t13;
        public T14 t14;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
            t8 = p8;
            t9 = p9;
            t10 = p10;
            t11 = p11;
            t12 = p12;
            t13 = p13;
            t14 = p14;
        }

        public int ElementCount { get { return 15; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -15 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -15 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -15 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -15 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -15 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -15 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -15 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -15 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t7);

            pos = -15 + 8;
            if (ElementTypes[8].IsOnStack())
            {
                if (onstackcnt < 8)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t8);

            pos = -15 + 9;
            if (ElementTypes[9].IsOnStack())
            {
                if (onstackcnt < 9)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t9);

            pos = -15 + 10;
            if (ElementTypes[10].IsOnStack())
            {
                if (onstackcnt < 10)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t10);

            pos = -15 + 11;
            if (ElementTypes[11].IsOnStack())
            {
                if (onstackcnt < 11)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t11);

            pos = -15 + 12;
            if (ElementTypes[12].IsOnStack())
            {
                if (onstackcnt < 12)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t12);

            pos = -15 + 13;
            if (ElementTypes[13].IsOnStack())
            {
                if (onstackcnt < 13)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t13);

            pos = -15 + 14;
            if (ElementTypes[14].IsOnStack())
            {
                if (onstackcnt < 14)
                {
                    var newpos = -15 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t14);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
            l.PushLua(t8);
            l.PushLua(t9);
            l.PushLua(t10);
            l.PushLua(t11);
            l.PushLua(t12);
            l.PushLua(t13);
            l.PushLua(t14);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t7 = (T7)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t8, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t8 = (T8)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t9, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t9 = (T9)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t10, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t10 = (T10)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t11, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t11 = (T11)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t12, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t12 = (T12)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t13, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t13 = (T13)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz) => thiz.t14, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> thiz, object val) => thiz.t14 = (T14)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7, out T8 o8, out T9 o9, out T10 o10, out T11 o11, out T12 o12, out T13 o13, out T14 o14)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
            o8 = t8;
            o9 = t9;
            o10 = t10;
            o11 = t11;
            o12 = t12;
            o13 = t13;
            o14 = t14;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8, t.Item9, t.Item10, t.Item11, t.Item12, t.Item13, t.Item14, t.Item15);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7, p.t8, p.t9, p.t10, p.t11, p.t12, p.t13, p.t14);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public T8 t8;
        public T9 t9;
        public T10 t10;
        public T11 t11;
        public T12 t12;
        public T13 t13;
        public T14 t14;
        public T15 t15;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
            t8 = p8;
            t9 = p9;
            t10 = p10;
            t11 = p11;
            t12 = p12;
            t13 = p13;
            t14 = p14;
            t15 = p15;
        }

        public int ElementCount { get { return 16; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -16 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -16 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -16 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -16 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -16 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -16 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -16 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -16 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t7);

            pos = -16 + 8;
            if (ElementTypes[8].IsOnStack())
            {
                if (onstackcnt < 8)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t8);

            pos = -16 + 9;
            if (ElementTypes[9].IsOnStack())
            {
                if (onstackcnt < 9)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t9);

            pos = -16 + 10;
            if (ElementTypes[10].IsOnStack())
            {
                if (onstackcnt < 10)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t10);

            pos = -16 + 11;
            if (ElementTypes[11].IsOnStack())
            {
                if (onstackcnt < 11)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t11);

            pos = -16 + 12;
            if (ElementTypes[12].IsOnStack())
            {
                if (onstackcnt < 12)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t12);

            pos = -16 + 13;
            if (ElementTypes[13].IsOnStack())
            {
                if (onstackcnt < 13)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t13);

            pos = -16 + 14;
            if (ElementTypes[14].IsOnStack())
            {
                if (onstackcnt < 14)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t14);

            pos = -16 + 15;
            if (ElementTypes[15].IsOnStack())
            {
                if (onstackcnt < 15)
                {
                    var newpos = -16 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t15);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
            l.PushLua(t8);
            l.PushLua(t9);
            l.PushLua(t10);
            l.PushLua(t11);
            l.PushLua(t12);
            l.PushLua(t13);
            l.PushLua(t14);
            l.PushLua(t15);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t7 = (T7)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t8, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t8 = (T8)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t9, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t9 = (T9)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t10, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t10 = (T10)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t11, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t11 = (T11)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t12, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t12 = (T12)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t13, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t13 = (T13)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t14, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t14 = (T14)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz) => thiz.t15, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> thiz, object val) => thiz.t15 = (T15)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7, out T8 o8, out T9 o9, out T10 o10, out T11 o11, out T12 o12, out T13 o13, out T14 o14, out T15 o15)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
            o8 = t8;
            o9 = t9;
            o10 = t10;
            o11 = t11;
            o12 = t12;
            o13 = t13;
            o14 = t14;
            o15 = t15;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8, t.Item9, t.Item10, t.Item11, t.Item12, t.Item13, t.Item14, t.Item15, t.Item16);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7, p.t8, p.t9, p.t10, p.t11, p.t12, p.t13, p.t14, p.t15);
        }
#endif
    }
    public struct LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public T7 t7;
        public T8 t8;
        public T9 t9;
        public T10 t10;
        public T11 t11;
        public T12 t12;
        public T13 t13;
        public T14 t14;
        public T15 t15;
        public T16 t16;
        public LuaPack(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            t7 = p7;
            t8 = p8;
            t9 = p9;
            t10 = p10;
            t11 = p11;
            t12 = p12;
            t13 = p13;
            t14 = p14;
            t15 = p15;
            t16 = p16;
        }

        public int ElementCount { get { return 17; } }
        public void GetFromLua(IntPtr l)
        {
            int onstackcnt = 0;
            int pos;

            pos = -17 + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = -17 + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = -17 + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = -17 + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = -17 + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = -17 + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = -17 + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);

            pos = -17 + 7;
            if (ElementTypes[7].IsOnStack())
            {
                if (onstackcnt < 7)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t7);

            pos = -17 + 8;
            if (ElementTypes[8].IsOnStack())
            {
                if (onstackcnt < 8)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t8);

            pos = -17 + 9;
            if (ElementTypes[9].IsOnStack())
            {
                if (onstackcnt < 9)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t9);

            pos = -17 + 10;
            if (ElementTypes[10].IsOnStack())
            {
                if (onstackcnt < 10)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t10);

            pos = -17 + 11;
            if (ElementTypes[11].IsOnStack())
            {
                if (onstackcnt < 11)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t11);

            pos = -17 + 12;
            if (ElementTypes[12].IsOnStack())
            {
                if (onstackcnt < 12)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t12);

            pos = -17 + 13;
            if (ElementTypes[13].IsOnStack())
            {
                if (onstackcnt < 13)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t13);

            pos = -17 + 14;
            if (ElementTypes[14].IsOnStack())
            {
                if (onstackcnt < 14)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t14);

            pos = -17 + 15;
            if (ElementTypes[15].IsOnStack())
            {
                if (onstackcnt < 15)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t15);

            pos = -17 + 16;
            if (ElementTypes[16].IsOnStack())
            {
                if (onstackcnt < 16)
                {
                    var newpos = -17 + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
            }
            l.GetLua(pos, out t16);
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            l.PushLua(t7);
            l.PushLua(t8);
            l.PushLua(t9);
            l.PushLua(t10);
            l.PushLua(t11);
            l.PushLua(t12);
            l.PushLua(t13);
            l.PushLua(t14);
            l.PushLua(t15);
            l.PushLua(t16);
        }
        public object this[int index]
        {
            get { return _IndexAccessors.GetItem(ref this, index); }
            set { _IndexAccessors.SetItem(ref this, index, value); }
        }
        private static LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>
        {
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t0, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t1, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t2, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t3, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t4, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t5, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t6, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t6 = (T6)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t7, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t7 = (T7)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t8, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t8 = (T8)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t9, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t9 = (T9)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t10, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t10 = (T10)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t11, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t11 = (T11)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t12, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t12 = (T12)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t13, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t13 = (T13)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t14, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t14 = (T14)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t15, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t15 = (T15)val },
            { (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz) => thiz.t16, (ref LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> thiz, object val) => thiz.t16 = (T16)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out T7 o7, out T8 o8, out T9 o9, out T10 o10, out T11 o11, out T12 o12, out T13 o13, out T14 o14, out T15 o15, out T16 o16)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            o7 = t7;
            o8 = t8;
            o9 = t9;
            o10 = t10;
            o11 = t11;
            o12 = t12;
            o13 = t13;
            o14 = t14;
            o15 = t15;
            o16 = t16;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16) };
        public Type GetType(int index) { return ElementTypes[index]; }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16) t)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Item8, t.Item9, t.Item10, t.Item11, t.Item12, t.Item13, t.Item14, t.Item15, t.Item16, t.Item17);
        }
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> p)
        {
            return (p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.t7, p.t8, p.t9, p.t10, p.t11, p.t12, p.t13, p.t14, p.t15, p.t16);
        }
#endif
    }
    public struct LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> : ILuaPack where TRest : struct, ILuaPack
    {
        public T0 t0;
        public T1 t1;
        public T2 t2;
        public T3 t3;
        public T4 t4;
        public T5 t5;
        public T6 t6;
        public TRest trest;
        public LuaPackEx(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, TRest prest)
        {
            t0 = p0;
            t1 = p1;
            t2 = p2;
            t3 = p3;
            t4 = p4;
            t5 = p5;
            t6 = p6;
            trest = prest;
        }

        public int ElementCount { get { return 7 + trest.ElementCount; } }
        public void GetFromLua(IntPtr l)
        {
            var cnt = ElementCount;
            var top = l.gettop();
            var bottom = top - cnt + 1;

            int onstackcnt = 0;
            int pos;

            pos = bottom + 0;
            if (ElementTypes[0].IsOnStack())
            {
                ++onstackcnt;
            }
            l.GetLua(pos, out t0);

            pos = bottom + 1;
            if (ElementTypes[1].IsOnStack())
            {
                if (onstackcnt < 1)
                {
                    var newpos = bottom + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t1);

            pos = bottom + 2;
            if (ElementTypes[2].IsOnStack())
            {
                if (onstackcnt < 2)
                {
                    var newpos = bottom + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t2);

            pos = bottom + 3;
            if (ElementTypes[3].IsOnStack())
            {
                if (onstackcnt < 3)
                {
                    var newpos = bottom + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t3);

            pos = bottom + 4;
            if (ElementTypes[4].IsOnStack())
            {
                if (onstackcnt < 4)
                {
                    var newpos = bottom + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t4);

            pos = bottom + 5;
            if (ElementTypes[5].IsOnStack())
            {
                if (onstackcnt < 5)
                {
                    var newpos = bottom + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t5);

            pos = bottom + 6;
            if (ElementTypes[6].IsOnStack())
            {
                if (onstackcnt < 6)
                {
                    var newpos = bottom + onstackcnt;
                    l.pushvalue(pos);
                    l.replace(newpos - 1);
                    pos = newpos;
                }
                ++onstackcnt;
            }
            l.GetLua(pos, out t6);
            
            if (onstackcnt > 0)
            {
                // first, we remove those who are not on-stack
                for (int i = onstackcnt; i < 7; ++i)
                {
                    l.remove(bottom + onstackcnt);
                }
            }
            trest.GetFromLua(l);
            if (onstackcnt > 0)
            {
                // and then we add the non-on-stack value back in order to keep the stack in corrent count.
                var restonstackcnt = trest.OnStackCount();
                for (int i = onstackcnt; i < 7; ++i)
                {
                    l.pushnil(); // TODO: push real value...
                    l.insert(bottom + onstackcnt + restonstackcnt);
                }
            }
        }
        public void PushToLua(IntPtr l)
        {
            l.PushLua(t0);
            l.PushLua(t1);
            l.PushLua(t2);
            l.PushLua(t3);
            l.PushLua(t4);
            l.PushLua(t5);
            l.PushLua(t6);
            trest.PushToLua(l);
        }
        public object this[int index]
        {
            get
            {
                if (index < 7)
                {
                    return _IndexAccessors.GetItem(ref this, index);
                }
                else
                {
                    return trest[index - 7];
                }
            }
            set
            {
                if (index < 7)
                {
                    _IndexAccessors.SetItem(ref this, index, value);
                }
                else
                {
                    trest[index - 7] = value;
                }
            }
        }
        private static LuaPackIndexAccessorList<LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest>> _IndexAccessors = new LuaPackIndexAccessorList<LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest>>
        {
            { (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz) => thiz.t0, (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz, object val) => thiz.t0 = (T0)val },
            { (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz) => thiz.t1, (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz, object val) => thiz.t1 = (T1)val },
            { (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz) => thiz.t2, (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz, object val) => thiz.t2 = (T2)val },
            { (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz) => thiz.t3, (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz, object val) => thiz.t3 = (T3)val },
            { (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz) => thiz.t4, (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz, object val) => thiz.t4 = (T4)val },
            { (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz) => thiz.t5, (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz, object val) => thiz.t5 = (T5)val },
            { (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz) => thiz.t6, (ref LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> thiz, object val) => thiz.t6 = (T6)val },
        };
        public void Deconstruct(out T0 o0, out T1 o1, out T2 o2, out T3 o3, out T4 o4, out T5 o5, out T6 o6, out TRest orest)
        {
            o0 = t0;
            o1 = t1;
            o2 = t2;
            o3 = t3;
            o4 = t4;
            o5 = t5;
            o6 = t6;
            orest = trest;
        }
        private static Type[] ElementTypes = new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
        public Type GetType(int index)
        {
            if (index < 7)
            {
                return ElementTypes[index];
            }
            else
            {
                return trest.GetType(index - 7);
            }
        }

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
        public static implicit operator LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest>(ValueTuple<T0, T1, T2, T3, T4, T5, T6, TRest> t)
        {
            return new LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7, t.Rest);
        }
        public static implicit operator ValueTuple<T0, T1, T2, T3, T4, T5, T6, TRest>(LuaPackEx<T0, T1, T2, T3, T4, T5, T6, TRest> p)
        {
            return new ValueTuple<T0, T1, T2, T3, T4, T5, T6, TRest>(p.t0, p.t1, p.t2, p.t3, p.t4, p.t5, p.t6, p.trest);
        }
#endif
    }
}

#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0
namespace Capstones.LuaWrap
{
    public partial struct LuaPack
    {
        public static LuaPack<T0> Pack<T0>(T0 p0)
        {
            return new LuaPack<T0>(p0);
        }
        public static LuaPack<T0> Pack<T0>(ValueTuple<T0> t)
        {
            return t;
        }
        public static T0 Unpack<T0>(LuaPack<T0> p)
        {
            return p;
        }

        public static LuaPack<T0, T1> Pack<T0, T1>(T0 p0, T1 p1)
        {
            return new LuaPack<T0, T1>(p0, p1);
        }
        public static LuaPack<T0, T1> Pack<T0, T1>((T0, T1) t)
        {
            return t;
        }
        public static (T0, T1) Unpack<T0, T1>(LuaPack<T0, T1> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2> Pack<T0, T1, T2>(T0 p0, T1 p1, T2 p2)
        {
            return new LuaPack<T0, T1, T2>(p0, p1, p2);
        }
        public static LuaPack<T0, T1, T2> Pack<T0, T1, T2>((T0, T1, T2) t)
        {
            return t;
        }
        public static (T0, T1, T2) Unpack<T0, T1, T2>(LuaPack<T0, T1, T2> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3> Pack<T0, T1, T2, T3>(T0 p0, T1 p1, T2 p2, T3 p3)
        {
            return new LuaPack<T0, T1, T2, T3>(p0, p1, p2, p3);
        }
        public static LuaPack<T0, T1, T2, T3> Pack<T0, T1, T2, T3>((T0, T1, T2, T3) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3) Unpack<T0, T1, T2, T3>(LuaPack<T0, T1, T2, T3> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4> Pack<T0, T1, T2, T3, T4>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            return new LuaPack<T0, T1, T2, T3, T4>(p0, p1, p2, p3, p4);
        }
        public static LuaPack<T0, T1, T2, T3, T4> Pack<T0, T1, T2, T3, T4>((T0, T1, T2, T3, T4) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4) Unpack<T0, T1, T2, T3, T4>(LuaPack<T0, T1, T2, T3, T4> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5> Pack<T0, T1, T2, T3, T4, T5>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5>(p0, p1, p2, p3, p4, p5);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5> Pack<T0, T1, T2, T3, T4, T5>((T0, T1, T2, T3, T4, T5) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5) Unpack<T0, T1, T2, T3, T4, T5>(LuaPack<T0, T1, T2, T3, T4, T5> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6> Pack<T0, T1, T2, T3, T4, T5, T6>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6>(p0, p1, p2, p3, p4, p5, p6);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6> Pack<T0, T1, T2, T3, T4, T5, T6>((T0, T1, T2, T3, T4, T5, T6) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6) Unpack<T0, T1, T2, T3, T4, T5, T6>(LuaPack<T0, T1, T2, T3, T4, T5, T6> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> Pack<T0, T1, T2, T3, T4, T5, T6, T7>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7>(p0, p1, p2, p3, p4, p5, p6, p7);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> Pack<T0, T1, T2, T3, T4, T5, T6, T7>((T0, T1, T2, T3, T4, T5, T6, T7) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7) Unpack<T0, T1, T2, T3, T4, T5, T6, T7>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8>(p0, p1, p2, p3, p4, p5, p6, p7, p8);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8>((T0, T1, T2, T3, T4, T5, T6, T7, T8) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7, T8) Unpack<T0, T1, T2, T3, T4, T5, T6, T7, T8>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9) Unpack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) Unpack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11) Unpack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12) Unpack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13) Unpack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14) Unpack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15) Unpack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> p)
        {
            return p;
        }

        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16)
        {
            return new LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);
        }
        public static LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Pack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16) t)
        {
            return t;
        }
        public static (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16) Unpack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> p)
        {
            return p;
        }
    }
}
#endif

namespace Capstones.LuaWrap
{
    public static partial class LuaFuncExHelper
    {
        public static void PushArgsAndCall<TIn>(this IntPtr l, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack pack;
            PushArgsAndCall(l, args, out pack);
        }
        public static void CallGlobal<TIn>(this IntPtr l, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack pack;
            CallGlobal(l, name, args, out pack);
        }
        public static void CallGlobalHierarchical<TIn>(this IntPtr l, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack pack;
            CallGlobalHierarchical(l, name, args, out pack);
        }
        public static void Call<TIn>(this IntPtr l, int index, string func, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
        }
        public static void Call<TIn>(this BaseLua lua, string func, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
        }
        public static void CallSelf<TIn>(this BaseLua lua, string func, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
        }

        public static void PushArgsAndCall<TIn, T0>(this IntPtr l, out T0 rv0, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0);
        }
        public static void CallGlobal<TIn, T0>(this IntPtr l, out T0 rv0, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0);
        }
        public static void CallGlobalHierarchical<TIn, T0>(this IntPtr l, out T0 rv0, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0);
        }
        public static void DoString<T0>(this IntPtr l, out T0 rv0, string chunk)
        {
            LuaPack<T0> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0);
        }
        public static void DoFile<T0>(this IntPtr l, out T0 rv0, string path)
        {
            LuaPack<T0> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0);
        }
        public static void GetTable<T0>(this IntPtr l, out T0 rv0, int index, params string[] fields)
        {
            LuaPack<T0> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0);
        }
        public static void GetSubTable<T0>(this IntPtr l, out T0 rv0, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0);
        }
        public static void GetTableHierarchical<T0>(this IntPtr l, out T0 rv0, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0);
        }
        public static void GetGlobalTable<T0>(this IntPtr l, out T0 rv0, string name, params string[] fields)
        {
            LuaPack<T0> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0);
        }
        public static void GetGlobalTableHierarchical<T0>(this IntPtr l, out T0 rv0, string name, params string[] fields)
        {
            LuaPack<T0> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0);
        }
        public static void Require<T0>(this IntPtr l, out T0 rv0, string name, params string[] fields)
        {
            LuaPack<T0> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0);
        }
        public static void Call<TIn, T0>(this IntPtr l, int index, string func, out T0 rv0, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0);
        }
        public static void Call<TIn, T0>(this BaseLua lua, string func, out T0 rv0, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0);
        }
        public static void CallSelf<TIn, T0>(this BaseLua lua, string func, out T0 rv0, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0);
        }

        public static void PushArgsAndCall<TIn, T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void CallGlobal<TIn, T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void DoString<T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, string chunk)
        {
            LuaPack<T0, T1> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void DoFile<T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, string path)
        {
            LuaPack<T0, T1> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void GetTable<T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, int index, params string[] fields)
        {
            LuaPack<T0, T1> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void GetSubTable<T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void GetTableHierarchical<T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void GetGlobalTable<T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, string name, params string[] fields)
        {
            LuaPack<T0, T1> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void GetGlobalTableHierarchical<T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, string name, params string[] fields)
        {
            LuaPack<T0, T1> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void Require<T0, T1>(this IntPtr l, out T0 rv0, out T1 rv1, string name, params string[] fields)
        {
            LuaPack<T0, T1> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void Call<TIn, T0, T1>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void Call<TIn, T0, T1>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1);
        }
        public static void CallSelf<TIn, T0, T1>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void CallGlobal<TIn, T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void DoString<T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, string chunk)
        {
            LuaPack<T0, T1, T2> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void DoFile<T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, string path)
        {
            LuaPack<T0, T1, T2> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void GetTable<T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void GetSubTable<T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void GetTableHierarchical<T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void GetGlobalTable<T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void Require<T0, T1, T2>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void Call<TIn, T0, T1, T2>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void Call<TIn, T0, T1, T2>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }
        public static void CallSelf<TIn, T0, T1, T2>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void DoString<T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, string chunk)
        {
            LuaPack<T0, T1, T2, T3> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void DoFile<T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, string path)
        {
            LuaPack<T0, T1, T2, T3> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void GetTable<T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void GetSubTable<T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void GetGlobalTable<T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void Require<T0, T1, T2, T3>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void Call<TIn, T0, T1, T2, T3>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void Call<TIn, T0, T1, T2, T3>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void DoString<T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void DoFile<T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, string path)
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void GetTable<T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void Require<T0, T1, T2, T3, T4>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void Require<T0, T1, T2, T3, T4, T5>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15);
        }

        public static void PushArgsAndCall<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void CallGlobal<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            CallGlobal(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void CallGlobalHierarchical<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, string name, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            CallGlobalHierarchical(l, name, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void DoString<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, string chunk)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            DoString(l, chunk, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void DoFile<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, string path)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            DoFile(l, path, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void GetTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, int index, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            GetTable(l, index, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void GetSubTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            GetTable(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void GetTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, int index, string fieldname, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            GetTableHierarchical(l, index, fieldname, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void GetGlobalTable<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            GetGlobalTable(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void GetGlobalTableHierarchical<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            GetGlobalTableHierarchical(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void Require<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, string name, params string[] fields)
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            Require(l, name, out pack, fields);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IntPtr l, int index, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            if (func == null)
            {
                l.pushvalue(index);
            }
            else
            {
                l.GetField(index, func);
            }
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void Call<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCall(l, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
        public static void CallSelf<TIn, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this BaseLua lua, string func, out T0 rv0, out T1 rv1, out T2 rv2, out T3 rv3, out T4 rv4, out T5 rv5, out T6 rv6, out T7 rv7, out T8 rv8, out T9 rv9, out T10 rv10, out T11 rv11, out T12 rv12, out T13 rv13, out T14 rv14, out T15 rv15, out T16 rv16, TIn args)
            where TIn : struct, ILuaPack
        {
            LuaPack<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> pack;
            var l = lua.L;
            l.getref(lua.Refid);
            l.GetField(-1, func);
            l.remove(-2);
            PushArgsAndCallSelf(l, lua, args, out pack);
            pack.Deconstruct(out rv0, out rv1, out rv2, out rv3, out rv4, out rv5, out rv6, out rv7, out rv8, out rv9, out rv10, out rv11, out rv12, out rv13, out rv14, out rv15, out rv16);
        }
    }
}
