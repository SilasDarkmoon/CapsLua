using System;

using Capstones.LuaExt;
using Capstones.LuaLib;
using Capstones.LuaWrap;
using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static class LuaCrossTransfer
    {
        public static void Transfer(this IntPtr from, int index, IntPtr to)
        {
            switch (from.type(index))
            {
                case lua.LUA_TNONE:
                case lua.LUA_TNIL:
                    to.pushnil();
                    break;
                case lua.LUA_TBOOLEAN:
                    to.pushboolean(from.toboolean(index));
                    break;
                case lua.LUA_TLIGHTUSERDATA:
                    to.pushlightuserdata(from.touserdata(index));
                    break;
                case lua.LUA_TNUMBER:
                    to.pushnumber(from.tonumber(index));
                    break;
                case lua.LUA_TSTRING:
                    to.pushstring(from.tolstring(index));
                    break;
                case lua.LUA_TTABLE:
                    {
                        from.checkstack(3);
                        to.checkstack(3);
                        to.newtable();
                        from.pushvalue(index);
                        from.pushnil();
                        while (from.next(-2))
                        {
                            Transfer(from, -2, to);
                            Transfer(from, -1, to);
                            to.settable(-3);
                            from.pop(1);
                        }
                        from.pop(1);
                    }
                    // TODO: metatable.
                    break;
                case lua.LUA_TFUNCTION:
                case lua.LUA_TUSERDATA:
                case lua.LUA_TTHREAD:
                    // TODO: can these values be copied?
                    break;
                default:
                    break;
            }
        }
        public static BaseLua Transfer(this BaseLua from, IntPtr to)
        {
            var froml = from.L;
            froml.PushLua(from);
            Transfer(froml, -1, to);
            froml.pop(1);
            return new BaseLua(to, to.refer());
        }

        private static void TransferSafe(this IntPtr from, int index, IntPtr to, int mapindex)
        {
            switch (from.type(index))
            {
                case lua.LUA_TNONE:
                case lua.LUA_TNIL:
                    to.pushnil();
                    break;
                case lua.LUA_TBOOLEAN:
                    to.pushboolean(from.toboolean(index));
                    break;
                case lua.LUA_TLIGHTUSERDATA:
                    to.pushlightuserdata(from.touserdata(index));
                    break;
                case lua.LUA_TNUMBER:
                    to.pushnumber(from.tonumber(index));
                    break;
                case lua.LUA_TSTRING:
                    to.pushstring(from.tolstring(index));
                    break;
                case lua.LUA_TTABLE:
                    TransferTableSafe(from, index, to, mapindex);
                    // TODO: metatable.
                    break;
                case lua.LUA_TFUNCTION:
                case lua.LUA_TUSERDATA:
                case lua.LUA_TTHREAD:
                    // TODO: can these values be copied?
                    break;
                default:
                    break;
            }
        }
        private static void TransferTableSafe(this IntPtr from, int index, IntPtr to, int mapindex)
        {
            to.checkstack(3);
            var p = from.topointer(index);
            to.pushlightuserdata(p);
            to.gettable(mapindex);
            if (to.istable(-1))
            {
                return;
            }

            from.checkstack(3);
            to.newtable();
            from.pushvalue(index);
            from.pushnil();
            while (from.next(-2))
            {
                TransferSafe(from, -2, to, mapindex);
                TransferSafe(from, -1, to, mapindex);
                to.settable(-3);
                from.pop(1);
            }
            from.pop(1);

            to.pushlightuserdata(p);
            to.pushvalue(-2);
            to.settable(mapindex);
        }
        public static void TransferSafe(this IntPtr from, int index, IntPtr to)
        {
            switch (from.type(index))
            {
                case lua.LUA_TNONE:
                case lua.LUA_TNIL:
                    to.pushnil();
                    break;
                case lua.LUA_TBOOLEAN:
                    to.pushboolean(from.toboolean(index));
                    break;
                case lua.LUA_TLIGHTUSERDATA:
                    to.pushlightuserdata(from.touserdata(index));
                    break;
                case lua.LUA_TNUMBER:
                    to.pushnumber(from.tonumber(index));
                    break;
                case lua.LUA_TSTRING:
                    to.pushstring(from.tolstring(index));
                    break;
                case lua.LUA_TTABLE:
                    {
                        to.newtable();
                        var mapindex = to.NormalizeIndex(-1);
                        TransferTableSafe(from, index, to, mapindex);
                        to.remove(mapindex);
                    }
                    // TODO: metatable.
                    break;
                case lua.LUA_TFUNCTION:
                case lua.LUA_TUSERDATA:
                case lua.LUA_TTHREAD:
                    // TODO: can these values be copied?
                    break;
                default:
                    break;
            }
        }
        public static BaseLua TransferSafe(this BaseLua from, IntPtr to)
        {
            var froml = from.L;
            froml.PushLua(from);
            TransferSafe(froml, -1, to);
            froml.pop(1);
            return new BaseLua(to, to.refer());
        }
    }
}