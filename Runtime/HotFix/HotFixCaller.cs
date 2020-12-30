using System;
using System.Collections.Generic;
using UnityEngine;
using Capstones.UnityEngineEx;
using Capstones.LuaLib;
using Capstones.LuaExt;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaWrap
{
    public static class HotFixCaller
    {
        [ThreadStatic] private static IntPtr _LuaState;
        public static IntPtr GetLuaStateForHotFix()
        {
            if (_LuaState == IntPtr.Zero)
            {
                if (ThreadSafeValues.IsMainThread)
                {
                    _LuaState = GlobalLua.L;
                }
                else
                {
                    IntPtr l = _LuaState = new LuaState();
                    Assembly2Lua.Init(l);
                    Json2Lua.Init(l);
                    LuaFramework.Init(l);
                    // should we init other libs (maybe in other package)? for example: lua-protobuf?
                    // currently these are enough.
                    // and calling a func with hotfix in non-main thread rarely happens.
                }
            }
            return _LuaState;
        }
        public static bool CallHotFix<TIn, TOut>(string token, TIn args, out TOut result)
            where TIn : struct, ILuaPack
            where TOut : struct, ILuaPack
        {
#if UNITY_EDITOR && !DEBUG_LUA_HOTFIX_IN_EDITOR
            result = default(TOut);
            return false;
#else
            result = default(TOut);
            var l = GetLuaStateForHotFix();
            using (var lr = l.CreateStackRecover())
            {
                if (l.TryRequire("hotfix").IsValid)
                {
                    if (l.istable(-1))
                    {
                        l.GetField(-1, token); // hotfix func
                        if (l.isfunction(-1))
                        {
                            var oldtop = l.gettop();
                            l.pushcfunction(LuaHub.LuaFuncOnError); // hotfix func error
                            l.insert(-2); // hotfix error func
                            var argc = args.Length;
                            args.PushToLua(l); // hotfix error func args
                            var code = l.pcall(argc, result.Length + 1, oldtop); // hotfix error success results
                            if (code == 0)
                            {
                                if (l.toboolean(oldtop + 1))
                                {
                                    result.GetFromLua(l);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
#endif
        }
    }
}