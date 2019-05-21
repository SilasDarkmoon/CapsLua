using System;
using System.Collections.Generic;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public class LuaString
    {
        public readonly string Str;
        public readonly int Index;

        private static int NextIndex = -1;

        private static Dictionary<string, LuaString> CacheMap = new Dictionary<string, LuaString>();
        private static Dictionary<int, LuaString> CacheRevMap = new Dictionary<int, LuaString>();

        public LuaString(string str)
            : this(str, 0)
        {
        }
        public LuaString(string str, int index)
        {
            Str = str ?? "";
            LuaString old;
            if (CacheMap.TryGetValue(Str, out old))
            {
                Index = old.Index;
            }
            else
            {
                bool valid = true;
                if (index >= 0)
                {
                    valid = false;
                }
                else if (CacheRevMap.TryGetValue(index, out old))
                {
                    valid = false;
                }
                if (valid)
                {
                    Index = index;
                    if (NextIndex >= index)
                    {
                        NextIndex = index - 1;
                    }
                }
                else
                {
                    Index = NextIndex--;
                }
                CacheMap[Str] = this;
                CacheRevMap[Index] = this;
            }
        }

        public void PushString(IntPtr l)
        {
            l.checkstack(10);
            l.pushlightuserdata(LuaConst.LRKEY_STR_CACHE); // rkey
            l.gettable(lua.LUA_REGISTRYINDEX); // reg
            if (!l.istable(-1))
            {
                l.pop(1); // X
                l.newtable(); // reg
                l.pushlightuserdata(LuaConst.LRKEY_STR_CACHE); // reg rkey
                l.pushvalue(-2); // reg rkey reg
                l.settable(lua.LUA_REGISTRYINDEX); // reg
            }

            l.pushnumber(1); // reg 1
            l.gettable(-2); // reg map
            if (!l.istable(-1))
            {
                l.pop(1); // reg
                l.newtable(); // reg map
                l.pushnumber(1); // reg map 1
                l.pushvalue(-2); // reg map 1 map
                l.settable(-4); // reg map
            }

            l.pushnumber(Index); // reg map id
            l.gettable(-2); // reg map str
            if (l.IsString(-1))
            {
                l.insert(-3); // str reg map
                l.pop(2); // str
            }
            else
            {
                l.pop(1); // reg map
                l.pushnumber(2); // reg map 2
                l.gettable(-3); // reg map revmap
                if (!l.istable(-1))
                {
                    l.pop(1); // reg map
                    l.newtable(); // reg map revmap
                    l.pushnumber(2); // reg map revmap 2
                    l.pushvalue(-2); // reg map revmap 2 revmap
                    l.settable(-5); // reg map revmap
                }

                l.pushstring(Str); // reg map revmap str
                l.pushnumber(Index); // reg map revmap str id
                l.pushvalue(-2); // reg map revmap str id str
                l.pushvalue(-1); // reg map revmap str id str str
                l.pushvalue(-3); // reg map revmap str id str str id
                l.settable(-6); // reg map revmap str id str
                l.settable(-5); // reg map revmap str
                l.insert(-4); // str reg map revmap
                l.pop(3); // str
            }
        }

        public static LuaString GetString(string str)
        {
            if (str == null) return null;
            LuaString val;
            CacheMap.TryGetValue(str, out val);
            return val;
        }
        public static LuaString GetString(int index)
        {
            LuaString val;
            CacheRevMap.TryGetValue(index, out val);
            return val;
        }
    }

    public static class LuaStringTransHelper
    {
        private class LuaStringCache
        {
            public const int InternVisitCount = 100;
            public const int CacheMaxCount = 5000;
            public const int CachedStringMaxLen = 100;

            public IntPtr L = IntPtr.Zero;
            public int LastId = 0;
            public LinkedList<LuaCachedStringInfo> CacheList = new LinkedList<LuaCachedStringInfo>();
            public Dictionary<string, LuaCachedStringInfo> CacheMap = new Dictionary<string, LuaCachedStringInfo>();
            public Dictionary<int, LuaCachedStringInfo> CacheRevMap = new Dictionary<int, LuaCachedStringInfo>();
            public LinkedListNode<LuaCachedStringInfo>[] CacheIndexStartNode = new LinkedListNode<LuaCachedStringInfo>[InternVisitCount];

            public class LuaCachedStringInfo
            {
                public LuaStringCache Cache;
                public string Str;
                //public byte[] Coded;
                public int Id;
                public LinkedListNode<LuaCachedStringInfo> Node;
                public int VisitCount;
                public bool IsInterned;

                public void Intern()
                {
                    if (!IsInterned)
                    {
                        IsInterned = true;
                        Str = string.Intern(Str);

                        if (Node != null)
                        {
                            Cache.RemoveListNode(Node);
                            Node = null;
                        }
                    }
                }
                public void AddVisitCount()
                {
                    if (Node != null)
                    {
                        Cache.RemoveListNode(Node);
                    }
                    ++VisitCount;
                    if (!IsInterned)
                    {
                        if (VisitCount >= InternVisitCount)
                        {
                            Node = null;
                            Intern();
                        }
                    }
                    if (Node != null)
                    {
                        if (Cache.CacheIndexStartNode[VisitCount] != null)
                        {
                            Node = Cache.CacheList.AddBefore(Cache.CacheIndexStartNode[VisitCount], this);
                            Cache.CacheIndexStartNode[VisitCount] = Node;
                        }
                        else
                        {
                            int vi = VisitCount - 1;
                            for (; vi >= 0; --vi)
                            {
                                if (Cache.CacheIndexStartNode[vi] != null)
                                {
                                    break;
                                }
                            }
                            if (vi >= 0)
                            {
                                Node = Cache.CacheList.AddBefore(Cache.CacheIndexStartNode[vi], this);
                                Cache.CacheIndexStartNode[VisitCount] = Node;
                            }
                            else
                            {
                                Node = Cache.CacheList.AddLast(this);
                                Cache.CacheIndexStartNode[VisitCount] = Node;
                            }
                        }
                    }
                }
            }

            private void RemoveListNode(LinkedListNode<LuaCachedStringInfo> node)
            {
                if (node != null)
                {
                    var info = node.Value;
                    if (CacheIndexStartNode[info.VisitCount] == node)
                    {
                        CacheIndexStartNode[info.VisitCount] = null;
                        var next = node.Next;
                        if (next != null)
                        {
                            if (next.Value.VisitCount == info.VisitCount)
                            {
                                CacheIndexStartNode[info.VisitCount] = next;
                            }
                        }
                    }
                    CacheList.Remove(node);
                }
            }

            public bool TryGetCacheInfo(string val, out LuaCachedStringInfo info)
            {
                var found = CacheMap.TryGetValue(val, out info);
                if (found)
                {
                    info.AddVisitCount();
                }
                return found;
            }
            public bool TryGetCacheInfo(int id, out LuaCachedStringInfo info)
            {
                var found = CacheRevMap.TryGetValue(id, out info);
                if (found)
                {
                    info.AddVisitCount();
                }
                return found;
            }
            public LuaCachedStringInfo PutIntoCache(string str)
            {
                if (str == null)
                {
                    return null;
                }
                LuaCachedStringInfo rv;
                if (TryGetCacheInfo(str, out rv))
                {
                    return rv;
                }
                if (str.Length > CachedStringMaxLen)
                {
                    return null;
                }
                rv = new LuaCachedStringInfo();
                rv.Str = str;
                rv.Cache = this;
                rv.Id = ++LastId;

                if (string.IsInterned(str) != null)
                {
                    rv.IsInterned = true;
                }
                else
                {
                    if (CacheList.Count >= CacheMaxCount)
                    {
                        var last = CacheList.Last.Value;
                        RemoveFromCache(last);
                    }
                    rv.Node = CacheList.AddLast(rv);
                }
                CacheMap[str] = rv;
                CacheRevMap[rv.Id] = rv;
                rv.AddVisitCount();

                var id = rv.Id;
                var l = L;
                l.checkstack(8);
                l.pushlightuserdata(LuaConst.LRKEY_STR_CACHE); // rkey
                l.gettable(lua.LUA_REGISTRYINDEX); // reg
                if (l.istable(-1))
                {
                    l.pushnumber(1); // reg 1
                    l.gettable(-2); // reg map
                    if (!l.istable(-1))
                    {
                        l.pop(1); // reg
                        l.newtable(); // reg map
                        l.pushnumber(1); // reg map 1
                        l.pushvalue(-2); // reg map 1 map
                        l.settable(-4); // reg map
                    }
                    l.pushnumber(2); // reg map 2
                    l.gettable(-3); // reg map revmap
                    if (!l.istable(-1))
                    {
                        l.pop(1); // reg map
                        l.newtable(); // reg map revmap
                        l.pushnumber(2); // reg map revmap 2
                        l.pushvalue(-2); // reg map revmap 2 revmap
                        l.settable(-5); // reg map revmap
                    }

                    l.pushnumber(id); // reg map revmap id
                    l.pushstring(str); // reg map revmap id str
                    l.pushvalue(-1); // reg map revmap id str str
                    l.pushvalue(-3); // reg map revmap id str str id
                    l.settable(-5); // reg map revmap id str
                    l.settable(-4); // reg map revmap
                    l.pop(3); // X
                }
                else
                {
                    l.pop(1); // X
                }

                return rv;
            }
            public void RemoveFromCache(LuaCachedStringInfo info)
            {
                if (info.Node != null)
                {
                    RemoveListNode(info.Node);
                    info.Node = null;
                }
                CacheMap.Remove(info.Str);
                CacheRevMap.Remove(info.Id);

                var id = info.Id;
                var l = L;
                l.checkstack(8);
                l.pushlightuserdata(LuaConst.LRKEY_STR_CACHE); // rkey
                l.gettable(lua.LUA_REGISTRYINDEX); // reg
                if (l.istable(-1))
                {
                    l.pushnumber(1); // reg 1
                    l.gettable(-2); // reg map
                    l.pushnumber(2); // reg map 2
                    l.gettable(-3); // reg map revmap
                    if (l.istable(-2))
                    {
                        l.pushnumber(id); // reg map revmap id
                        l.pushvalue(-1); // reg map revmap id id
                        l.gettable(-4); // reg map revmap id str
                        l.pushvalue(-2); // reg map revmap id str id
                        l.pushnil(); // reg map revmap id str id nil
                        l.settable(-6); // reg map revmap id str
                        if (l.IsString(-1) && l.istable(-3))
                        {
                            l.pushnil(); // reg map revmap id str nil
                            l.settable(-4); // reg map revmap id
                            l.pop(1); // reg map revmap
                        }
                        else
                        {
                            l.pop(2); // reg map revmap
                        }
                    }
                    l.pop(3); // X
                }
                else
                {
                    l.pop(1); // X
                }
            }
        }

        public static void PushString(this IntPtr l, string str)
        {
            LuaString predefined = LuaString.GetString(str);
            if (predefined != null)
            {
                predefined.PushString(l);
                return;
            }

            l.checkstack(4);
            l.pushlightuserdata(LuaConst.LRKEY_STR_CACHE); // rkey
            l.gettable(lua.LUA_REGISTRYINDEX); // reg
            if (!l.istable(-1))
            {
                l.pop(1); // X
                l.newtable(); // reg
                l.pushlightuserdata(LuaConst.LRKEY_STR_CACHE); // reg rkey
                l.pushvalue(-2); // reg rkey reg
                l.settable(lua.LUA_REGISTRYINDEX);
            }

            l.pushnumber(0); // reg 0
            l.gettable(-2); // reg cache
            var cache = l.GetLuaObject(-1) as LuaStringCache;
            l.pop(1); // reg
            if (cache == null)
            {
                l.pushnumber(0); // reg 0
                cache = new LuaStringCache() { L = l };
                l.PushLuaRawObject(cache); // reg 0 cache
                l.settable(-3); // reg
            }
            else
            {
                cache.L = l;
            }

            var info = cache.PutIntoCache(str);
            if (info == null)
            {
                l.pop(1); // X
                l.pushstring(str); // str
            }
            else
            {
                l.pushnumber(1); // reg 1
                l.gettable(-2); // reg map
                if (!l.istable(-1))
                {
                    l.pop(1); // reg
                    l.newtable(); // reg map
                    l.pushnumber(1); // reg map 1
                    l.pushvalue(-2); // reg map 1 map
                    l.settable(-4); // reg map
                }

                l.pushnumber(info.Id); // reg map id
                l.gettable(-2); // reg map str
                if (l.IsString(-1))
                {
                    l.insert(-3); // str reg map
                    l.pop(2); // str
                }
                else
                {
                    l.pop(3); // X
                    l.pushstring(str); // str

                    //// this should not happen!
                    //l.pop(1); // reg map
                    //l.pushnumber(2); // reg map 2
                    //l.gettable(-3); // reg map revmap
                    //if (!l.istable(-1))
                    //{
                    //    l.pop(1); // reg map
                    //    l.newtable(); // reg map revmap
                    //    l.pushnumber(2); // reg map revmap 2
                    //    l.pushvalue(-2); // reg map revmap 2 revmap
                    //    l.settable(-5); // reg map revmap
                    //}

                    //l.pushstring(str); // reg map revmap str
                    //l.pushnumber(info.Id); // reg map revmap str id
                    //l.pushvalue(-2); // reg map revmap str id str
                    //l.pushvalue(-1); // reg map revmap str id str str
                    //l.pushvalue(-3); // reg map revmap str id str str id
                    //l.settable(-6); // reg map revmap str id str
                    //l.settable(-5); // reg map revmap str
                    //l.insert(-4); // str reg map revmap
                    //l.pop(3); // str
                }
            }
        }

        public static void PushString(this IntPtr l, LuaString str)
        {
            str.PushString(l);
        }

        public static string GetString(this IntPtr l, int index)
        {
            string rv = null;
            if (l.IsString(index))
            {
                l.checkstack(5);
                l.pushvalue(index); // lstr
                l.pushlightuserdata(LuaConst.LRKEY_STR_CACHE); // lstr rkey
                l.gettable(lua.LUA_REGISTRYINDEX); // lstr reg
                if (l.istable(-1))
                {
                    l.pushnumber(2); // lstr reg 2
                    l.gettable(-2); // lstr reg revmap

                    if (l.istable(-1))
                    {
                        l.pushvalue(-3); // lstr reg revmap lstr
                        l.gettable(-2); // lstr reg revmap id

                        if (l.isnumber(-1))
                        {
                            var id = (int)l.tonumber(-1);
                            if (id != 0)
                            {
                                if (id < 0)
                                {
                                    LuaString predefined = LuaString.GetString(id);
                                    if (predefined != null)
                                    {
                                        l.pop(4); // X
                                        return predefined.Str;
                                    }
                                }
                                l.pushnumber(0); // lstr reg revmap id 0
                                l.gettable(-4); // lstr reg revmap id cache
                                var cache = l.GetLuaObject(-1) as LuaStringCache;
                                l.pop(5); // X
                                if (cache != null)
                                {
                                    cache.L = l;
                                    LuaStringCache.LuaCachedStringInfo info;
                                    if (cache.TryGetCacheInfo(id, out info))
                                    {
                                        return info.Str;
                                    }
                                }
                            }
                            else
                            {
                                l.pop(4); // X
                            }
                        }
                        else
                        {
                            l.pop(4); // X
                        }
                    }
                    else
                    {
                        l.pop(3); // X
                    }
                }
                else
                {
                    l.pop(2); // X
                }

                // Not cached.
                rv = l.tostring(index);

                l.pushlightuserdata(LuaConst.LRKEY_STR_CACHE); // rkey
                l.gettable(lua.LUA_REGISTRYINDEX); // reg
                if (!l.istable(-1))
                {
                    l.pop(1); // X
                    l.newtable(); // reg
                    l.pushlightuserdata(LuaConst.LRKEY_STR_CACHE); // reg rkey
                    l.pushvalue(-2); // reg rkey reg
                    l.settable(lua.LUA_REGISTRYINDEX);
                }

                l.pushnumber(0); // reg 0
                l.gettable(-2); // reg cache
                {
                    var cache = l.GetLuaObject(-1) as LuaStringCache;
                    l.pop(1); // reg
                    if (cache == null)
                    {
                        l.pushnumber(0); // reg 0
                        cache = new LuaStringCache() { L = l };
                        l.PushLuaRawObject(cache); // reg 0 cache
                        l.settable(-3); // reg
                    }
                    else
                    {
                        cache.L = l;
                    }
                    l.pop(1); // X
                    cache.PutIntoCache(rv);
                }
            }
            return rv;
        }

        public static void GetField(this IntPtr l, int index, string key)
        {
            var top = l.gettop();
            if (index < 0 && -index <= top)
            {
                index = top + 1 + index;
            }

            l.PushString(key);
            l.gettable(index);
        }

        public static void GetField(this IntPtr l, int index, LuaString key)
        {
            var top = l.gettop();
            if (index < 0 && -index <= top)
            {
                index = top + 1 + index;
            }

            key.PushString(l);
            l.gettable(index);
        }

        public static void SetField(this IntPtr l, int index, string key)
        {
            var top = l.gettop();
            if (index < 0 && -index <= top)
            {
                index = top + 1 + index;
            }

            l.PushString(key);
            l.insert(-2);
            l.settable(index);
        }

        public static void SetField(this IntPtr l, int index, LuaString key)
        {
            var top = l.gettop();
            if (index < 0 && -index <= top)
            {
                index = top + 1 + index;
            }

            key.PushString(l);
            l.insert(-2);
            l.settable(index);
        }

        public static void GetGlobal(this IntPtr l, string key)
        {
            GetField(l, lua.LUA_GLOBALSINDEX, key);
        }

        public static void GetGlobal(this IntPtr l, LuaString key)
        {
            GetField(l, lua.LUA_GLOBALSINDEX, key);
        }

        public static void SetGlobal(this IntPtr l, string key)
        {
            SetField(l, lua.LUA_GLOBALSINDEX, key);
        }

        public static void SetGlobal(this IntPtr l, LuaString key)
        {
            SetField(l, lua.LUA_GLOBALSINDEX, key);
        }
    }
}