using System;
using System.Collections.Generic;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public class LuaObjCache
    {
        public static LuaObjCache GetObjCache(IntPtr l)
        {
            l.checkstack(1);
            l.pushlightuserdata(LuaConst.LRKEY_OBJ_CACHE); // key
            l.gettable(lua.LUA_REGISTRYINDEX); // cache
            var rv = l.GetLuaObject(-1) as LuaObjCache;
            l.pop(1);
            return rv;
        }

        public static LuaObjCache GetOrCreateObjCache(IntPtr l)
        {
            var rv = GetObjCache(l);
            if (rv == null)
            {
                l.checkstack(2);
                rv = new LuaObjCache();
                l.pushlightuserdata(LuaConst.LRKEY_OBJ_CACHE); // key
                l.PushLuaRawObject(rv); // key cache
                l.settable(lua.LUA_REGISTRYINDEX); // X
            }
            return rv;
        }

        public static void PushObjCacheReg(IntPtr l)
        {
            l.checkstack(1);
            l.pushlightuserdata(LuaConst.LRKEY_OBJ_CACHE_REG); // key
            l.gettable(lua.LUA_REGISTRYINDEX); // reg
        }

        public static void PushOrCreateObjCacheReg(IntPtr l)
        {
            l.checkstack(5);
            l.pushlightuserdata(LuaConst.LRKEY_OBJ_CACHE_REG); // key
            l.gettable(lua.LUA_REGISTRYINDEX); // reg
            if (!l.istable(-1))
            {
                l.pop(1); // X
                l.newtable(); // reg
                l.pushlightuserdata(LuaConst.LRKEY_OBJ_CACHE_REG); // reg key
                l.pushvalue(-2); // reg key reg
                l.settable(lua.LUA_REGISTRYINDEX); // reg
                l.newtable(); // reg meta
                l.PushString(LuaConst.LS_COMMON_V); // reg meta "v"
                l.SetField(-2, LuaConst.LS_META_KEY_MODE); // reg meta
                l.newtable(); // reg meta index
                l.SetField(-2, LuaConst.LS_META_KEY_INDEX); // reg meta
                l.setmetatable(-2); // reg
            }
        }

        public static bool PushObjFromCache(IntPtr l, object obj)
        {
            var cache = GetObjCache(l);
            if (cache != null)
            {
                IntPtr h;
                if (cache._Map.TryGetValue(obj, out h))
                {
                    l.checkstack(5);
                    PushObjCacheReg(l); // reg
                    if (!l.istable(-1))
                    {
                        l.pop(1);
                        return false;
                    }
                    l.pushlightuserdata(h); // reg h
                    l.gettable(-2); // reg ud
                    if (l.isnoneornil(-1))
                    {
                        l.pop(2); // X
                        return false;
                    }
                    l.remove(-2); // ud
                    return true;
                }
            }
            return false;
        }

        internal static void RegObj(IntPtr l, object obj, int index, IntPtr h)
        {
            //if (PushObjFromCache(l, obj))
            //{
            //    l.pop(1);
            //    return;
            //}

            var cache = GetOrCreateObjCache(l);
            cache._Map[obj] = h;

            l.checkstack(5);
            l.pushvalue(index); // ud
            PushOrCreateObjCacheReg(l); // ud reg
            l.insert(-2); // reg ud
            l.pushlightuserdata(h); // reg ud h
            l.insert(-2); // reg h ud
            l.settable(-3); // reg
            l.pop(1); // X
        }

        internal static void RegObjStrong(IntPtr l, object obj, int index, IntPtr h)
        {
            //if (PushObjFromCache(l, obj))
            //{
            //    l.pop(1);
            //    return;
            //}

            var cache = GetOrCreateObjCache(l);
            cache._Map[obj] = h;

            l.checkstack(5);
            l.pushvalue(index); // ud
            PushOrCreateObjCacheReg(l); // ud reg
            l.getmetatable(-1); // ud reg meta
            l.GetField(-1, LuaConst.LS_META_KEY_INDEX); // ud reg meta index
            l.insert(-4); // index ud reg meta
            l.pop(2); // index ud
            l.pushlightuserdata(h); // index ud h
            l.insert(-2); // index h ud
            l.settable(-3); // index
            l.pop(1); // X
        }

        private Dictionary<object, IntPtr> _Map = new Dictionary<object, IntPtr>();
        public void Remove(object obj)
        {
            _Map.Remove(obj);
        }

        public static void PushObjFromCache(IntPtr l, IntPtr index)
        {
            l.checkstack(2);
            PushObjCacheReg(l); // reg
            if (!l.istable(-1))
            {
                l.pop(1);
                l.pushnil();
                return;
            }
            l.pushlightuserdata(index); // reg h
            l.gettable(-2); // reg ud
            l.remove(-2); // ud
        }
    }
}
