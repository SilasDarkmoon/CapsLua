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
        [ThreadStatic] private static HashSet<IntPtr> _ReadyStates;
        [ThreadStatic] private static IntPtr _ThreadedLuaState;
        [ThreadStatic] private static IntPtr _CallerLuaState;
        private static volatile int _PackageVer = -1;

        public static IntPtr GetLuaStateForHotFix()
        {
#if UNITY_EDITOR
            if (_ReadyStates == null && SafeInitializerUtils.IsInitializingInUnityCtor)
            {
                return IntPtr.Zero;
            }
#endif
            if (_ReadyStates == null)
            {
                _ReadyStates = new HashSet<IntPtr>();
                if (ThreadSafeValues.IsMainThread)
                {
#if UNITY_EDITOR
#if DEBUG_LUA_HOTFIX_IN_EDITOR
                    _PackageVer = 0;
#else
#endif
#else
                    int packageVer;
                    GlobalLua.L.L.GetGlobalTable(out packageVer, "___resver", "package");
                    _PackageVer = packageVer;
#endif
                }
            }
            var running = LuaHub.RunningLuaState;
            if (running == IntPtr.Zero)
            {
                if (_ThreadedLuaState == IntPtr.Zero)
                {
                    if (ThreadSafeValues.IsMainThread)
                    {
                        _ThreadedLuaState = running = GlobalLua.L;
                    }
                    else
                    {
                        _ThreadedLuaState = running = new LuaState();
                        IntPtr l = running;
                        Assembly2Lua.Init(l);
                        Json2Lua.Init(l);
                        LuaFramework.Init(l);
                        // should we init other libs (maybe in other package)? for example: lua-protobuf?
                        // currently these are enough.
                        // and calling a func with hotfix in non-main thread rarely happens.
                    }
                    running.SetGlobal("hotfixver", _PackageVer);
                }
                else
                {
                    running = _ThreadedLuaState;
                }
            }
            else
            {
                if (_CallerLuaState != running)
                {
                    _CallerLuaState = running;
                    if (_ReadyStates.Add(running.Indicator()))
                    {
                        running.SetGlobal("hotfixver", _PackageVer);
                    }
                }
            }
            return running;
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
#if UNITY_EDITOR
            if (l == IntPtr.Zero)
            {
                result = default(TOut);
                return false;
            }
#endif
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

        public static bool CallHotFixN<TIn, TOut>(long token, TIn args, out TOut result)
            where TIn : struct, ILuaPack
            where TOut : struct, ILuaPack
        {
#if UNITY_EDITOR && !DEBUG_LUA_HOTFIX_IN_EDITOR
            result = default(TOut);
            return false;
#else
            result = default(TOut);
            var l = GetLuaStateForHotFix();
#if UNITY_EDITOR
            if (l == IntPtr.Zero)
            {
                result = default(TOut);
                return false;
            }
#endif
            using (var lr = l.CreateStackRecover())
            {
                if (l.TryRequire("hotfix").IsValid)
                {
                    if (l.istable(-1))
                    {
                        l.pushnumber(token); // hotfix token
                        l.gettable(-2); // hotfix func
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

        #region Method Hash
        private static readonly Dictionary<string, long> _DesignatedHash = new Dictionary<string, long>();
        public static long GetTokenHash(string token)
        {
            if (token == null) return 0;
            string mainpart = token;
            bool istail = false;
            if (token.EndsWith(" tail"))
            {
                istail = true;
                mainpart = token.Substring(0, token.Length - " tail".Length);
            }
            else if (token.EndsWith(" head"))
            {
                mainpart = token.Substring(0, token.Length - " head".Length);
            }
            long hash = 0;
            if (!_DesignatedHash.TryGetValue(mainpart, out hash))
            {
                int criticalindex = mainpart.IndexOf(' ');
                if (criticalindex >= 0 && criticalindex + 1 < mainpart.Length)
                {
                    ++criticalindex;
                }
                else
                {
                    criticalindex = -1;
                }
                hash = ExtendedStringHash.GetHashCodeEx(mainpart, 0, 1, criticalindex, 0);
            }
            if (istail)
            {
                hash = -hash;
            }
            return hash;
        }
        public static void LoadDesignatedHash(string lib)
        {
            if (!ThreadSafeValues.IsMainThread)
            {
                return;
            }
            _DesignatedHash.Clear();
            var l = GlobalLua.L.L;
            if (l.TryRequire(lib).IsValid)
            {
                l.ForEach<string, long>(-1, (str, hash) => _DesignatedHash.Add(str, hash));
                l.pop(1);
            }
        }
        #endregion
    }
}