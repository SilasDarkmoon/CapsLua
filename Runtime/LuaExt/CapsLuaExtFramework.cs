using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Capstones.LuaLib;
using Capstones.LuaWrap;
using Capstones.UnityEngineEx;
#if UNITY_ENGINE || UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaExt
{
    public static partial class LuaExLibs
    {
        private static LuaExLibItem _LuaExLib_Framework_Instance = new LuaExLibItem(LuaFramework.Init, 0);
#if UNITY_EDITOR
        private static LuaExLibItem _LuaExLib_LuaInit_Instance = new LuaExLibItem(LuaFramework.InitLua, 1000);
#endif
    }

    public static class LuaFramework
    {
        public static void Init(IntPtr L)
        {
            if (L != IntPtr.Zero)
            {
                L.atpanic(ClrDelPanic);

                ClrFuncReset(L);

                //using (var lr = new LuaStateRecover(L))
                {
                    // Capstones.UnityFramework.UnityLua.StartLuaCoroutine
                    L.GetGlobal("clr"); // clr
                    if (L.istable(-1))
                    {
#if UNITY_ENGINE || UNITY_5_3_OR_NEWER
                        L.pushcfunction(ClrDelCoroutine); // clr func
                        L.SetField(-2, "coroutine"); // clr
                        L.pushcfunction(ClrDelBehavCoroutine); // clr func
                        L.SetField(-2, "bcoroutine"); // clr
#endif
                        L.pushcfunction(ClrDelReset); // clr func
                        L.SetField(-2, "reset"); // clr
                        L.PushString(ThreadSafeValues.AppPlatform); // clr plat
                        L.SetField(-2, "plat"); // clr
                        L.pushcfunction(ClrDelGetCapID);
                        L.SetField(-2, "capid");
                        L.pushcfunction(ClrDelSplitStr);
                        L.SetField(-2, "splitstr");
                        L.PushString(ThreadSafeValues.UpdatePath);
                        L.SetField(-2, "updatepath");
                        L.pushcfunction(ClrDelGetLangValueOfUserDataType);
                        L.SetField(-2, "trans");
                        L.pushcfunction(ClrDelGetLangValueOfStringType);
                        L.SetField(-2, "transstr");
                        L.pushcfunction(ClrDelUpdateLanguageConverter);
                        L.SetField(-2, "updatetrans");
                    }
                    L.pop(1); // (empty)

                    // UnityEngine.Debug.Log
                    L.pushcfunction(LuaHub.LuaFuncOnInfo); // func
                    L.SetGlobal("print"); // (empty)
                    L.pushcfunction(LuaHub.LuaFuncOnInfo); // func
                    L.SetGlobal("printi"); // (empty)
                    L.pushcfunction(LuaHub.LuaFuncOnWarning); // func
                    L.SetGlobal("printw"); // (empty)
                    L.pushcfunction(LuaHub.LuaFuncOnError); // func
                    L.SetGlobal("printe"); // (empty)
                }

                for (int i = 0; i < FurtherInitFuncs.Count; ++i)
                {
                    var init = FurtherInitFuncs[i];
                    if (init != null)
                    {
                        init(L);
                    }
                }
            }
        }

        public delegate void InitDelegate(IntPtr l);
        public static readonly List<InitDelegate> FurtherInitFuncs = new List<InitDelegate>();
        public class FurtherInit
        {
            public FurtherInit(InitDelegate init)
            {
                if (init != null)
                {
                    FurtherInitFuncs.Add(init);
                }
            }
        }

        public static bool TryRequireLua(IntPtr l, string lib)
        {
            l.GetGlobal("require"); // require
            l.PushString(lib); // require "lib"
            if (l.pcall(1, 0, 0) == 0)
            {
                return true;
            }
            else
            {
                l.pop(1);
                return false;
            }
        }
        public static void InitLua_Critical(IntPtr l)
        {
            // mods
            var mods = CapsLuaFileManager.GetCriticalLuaMods();
            for (int i = 0; i < mods.Length; ++i)
            {
                var mod = mods[i];
                TryRequireLua(l, "?raw.mod.\"" + mod + "\".init");
            }

            TryRequireLua(l, "?raw.init");
        }
        public static void InitLua_Mods(IntPtr l)
        {
            var flags = ResManager.GetValidDistributeFlags();
            for (int i = 0; i < flags.Length; ++i)
            {
                var flag = flags[i];
                TryRequireLua(l, "?raw.mod.\"" + flag + "\".init");
            }
        }
        public static void InitLua_Dist(IntPtr l)
        {
            // distribute
            var flags = ResManager.GetValidDistributeFlags();
            for (int i = 0; i < flags.Length; ++i)
            {
                var flag = flags[i];
                TryRequireLua(l, "distribute." + flag);
            }
        }
        public static void InitLua_PreInit(IntPtr l)
        {
            TryRequireLua(l, "preinit");
        }
        public static void InitLua_PostInit(IntPtr l)
        {
            TryRequireLua(l, "postinit");
        }
        public static void InitLua(IntPtr l)
        {
            InitLua_PreInit(l);
            InitLua_Critical(l);
            InitLua_Mods(l);
            InitLua_Dist(l);
            InitLua_PostInit(l);
        }

#if UNITY_ENGINE || UNITY_5_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#endif
        private static void OnUnityStart()
        {
#if !UNITY_EDITOR && (UNITY_ENGINE || UNITY_5_3_OR_NEWER)
            ResManager.AddInitItem(ResManager.LifetimeOrders.PreEntrySceneDone, GlobalLuaInitLua);
#endif
        }
        private static void GlobalLuaInitLua()
        {
            GlobalLua.Init();
            InitLua(GlobalLua.L.L);
        }

#if UNITY_ENGINE || UNITY_5_3_OR_NEWER
        public static readonly lua.CFunction ClrDelCoroutine = new lua.CFunction(ClrFuncCoroutine);
        public static readonly lua.CFunction ClrDelBehavCoroutine = new lua.CFunction(ClrFuncBehavCoroutine);
#endif
        public static readonly lua.CFunction ClrDelPanic = new lua.CFunction(ClrFuncPanic);
        public static readonly lua.CFunction ClrDelReset = new lua.CFunction(ClrFuncReset);
        public static readonly lua.CFunction ClrDelApkLoader = new lua.CFunction(ClrFuncApkLoader);
        public static readonly lua.CFunction ClrDelGetCapID = new lua.CFunction(ClrFuncGetCapID);
        public static readonly lua.CFunction ClrDelSplitStr = new lua.CFunction(ClrFuncSplitStr);
        public static readonly lua.CFunction ClrDelGetLangValueOfUserDataType = new lua.CFunction(ClrFuncGetLangValueOfUserDataType);
        public static readonly lua.CFunction ClrDelGetLangValueOfStringType = new lua.CFunction(ClrFuncGetLangValueOfStringType);
        public static readonly lua.CFunction ClrDelUpdateLanguageConverter = new lua.CFunction(UpdateLanguageConverter);

#if UNITY_ENGINE || UNITY_5_3_OR_NEWER
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int ClrFuncCoroutine(IntPtr l)
        {
            var oldtop = l.gettop();

            if (l.isfunction(1))
            {
                var lfunc = new LuaOnStackFunc(l, 1);
                var co = GlobalLua.StartLuaCoroutine(lfunc);
                l.settop(oldtop);
                l.PushLua(co);
            }

            return l.gettop() - oldtop;
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int ClrFuncBehavCoroutine(IntPtr l)
        {
            var oldtop = l.gettop();

            if (l.IsObject(1) && l.isfunction(2))
            {
                var behav = l.GetLua<UnityEngine.MonoBehaviour>(1);
                var lfunc = new LuaOnStackFunc(l, 2);
                var co = GlobalLua.StartLuaCoroutineForBehav(behav, lfunc);
                l.settop(oldtop);
                l.PushLua(co);
            }

            return l.gettop() - oldtop;
        }
#endif

        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int ClrFuncPanic(IntPtr l)
        {
            var top = l.gettop();
            var error = l.GetLua(-1);
            string message = error == null ? "" : error.ToString();
            message = "Lua error at " + top + ": " + message;
            LuaHub.LogError(l, message);
            throw new LuaAtPanicException(message);
        }

        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int ClrFuncReset(IntPtr l)
        {
            l.GetGlobal("package"); // package
            if (l.istable(-1))
            {
                {
                    l.GetField(-1, "loaders"); // package loaders
                    if (l.istable(-1))
                    {
                        l.GetField(-1, "apkloader"); // package loaders apkloader
                        if (l.isnoneornil(-1))
                        {
                            l.pop(1); // package loaders
                            l.pushcfunction(ClrDelApkLoader); // package loaders apkloader
                            l.pushvalue(-1); // package loaders apkloader apkloader
                            l.SetField(-3, "apkloader"); // package loaders apkloader 
                        }
                        l.pushnumber(1); // package loaders apkloader 1
                        l.gettable(-3); // package loaders apkloader 1stloader
                        if (l.equal(-1, -2))
                        {
                            l.pop(2); // package loaders
                        }
                        else
                        {
                            l.pop(1); // package loaders apkloader
                            var cnt = l.getn(-2);
                            for (int i = cnt; i >= 1; --i)
                            {
                                l.pushnumber(i + 1); // package loaders apkloader i+1
                                l.pushnumber(i); // package loaders apkloader i+1 i
                                l.gettable(-4); // package loaders apkloader i+1 func
                                l.settable(-4); // package loaders apkloader
                            }
                            l.pushnumber(1); // package loaders apkloader 1
                            l.insert(-2); // package loaders 1 apkloader
                            l.settable(-3); // package loaders
                        }
                    }
                    l.pop(1); // package
                }
            }
            l.pop(1); // X

            // res version
            l.pushnil();
            l.SetGlobal("___resver");

            return 0;
        }

        [ThreadStatic] private static CapsLuaFileManager.LuaStreamReader _LuaStreamReader;
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int ClrFuncApkLoader(IntPtr l)
        {
            string mname = l.GetString(1);
            if (!string.IsNullOrEmpty(mname))
            {
                string location;
                System.IO.Stream stream = null;
                GCHandle? handle = null;
                try
                {
                    stream = CapsLuaFileManager.GetLuaStream(mname, out location);
                    if (stream != null)
                    {
                        if (_LuaStreamReader == null)
                        {
                            _LuaStreamReader = new CapsLuaFileManager.LuaStreamReader(null);
                        }
                        _LuaStreamReader.Reuse(stream, PlatDependant.CopyStreamBuffer);
                        handle = GCHandle.Alloc(_LuaStreamReader);
                        location = string.Format("{0}<{1}>", mname, location);
                        if (l.load(CapsLuaFileManager.LuaStreamReader.ReaderDel, (IntPtr)handle.Value, location) == 0)
                        {
                            return 1;
                        }
                        else
                        {
                            DynamicHelper.LogError(l.GetLua(-1));
                            l.pop(1);
                            return 0;
                        }
                    }
                }
                catch (Exception e)
                {
                    l.LogError(e);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                    }
                    if (handle != null)
                    {
                        handle.Value.Free();
                    }
                }
            }
            return 0;
        }

        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int ClrFuncGetCapID(IntPtr l)
        {
            var capID = ThreadSafeValues.Capid;
            l.PushString(capID);
            return 1;
        }
        private static void SplitStr(IntPtr l, string str)
        {
            l.newtable();
            int index = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                l.pushnumber(++index);
                System.Text.StringBuilder pstr = new System.Text.StringBuilder();
                var ch = str[i];
                pstr.Append(ch);
                if (ch >= 0xD800 && ch <= 0xDFFF)
                {
                    if (++i < str.Length)
                    {
                        pstr.Append(str[i]);
                    }
                }
                l.PushString(pstr.ToString());
                l.settable(-3);
            }
        }
        private static void SplitStr(IntPtr l, System.Text.StringBuilder str)
        {
            l.newtable();
            int index = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                l.pushnumber(++index);
                System.Text.StringBuilder pstr = new System.Text.StringBuilder();
                var ch = str[i];
                pstr.Append(ch);
                if (ch >= 0xD800 && ch <= 0xDFFF)
                {
                    if (++i < str.Length)
                    {
                        pstr.Append(str[i]);
                    }
                }
                l.PushString(pstr.ToString());
                l.settable(-3);
            }
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int ClrFuncSplitStr(IntPtr l)
        {
            if (l.isstring(1))
            {
                SplitStr(l, l.GetString(1));
            }
            else if (l.IsObject(1))
            {
                var inputStr = l.GetLua(1);
                if (inputStr is string)
                {
                    SplitStr(l, inputStr.ToString());
                }
                else if (inputStr is System.Text.StringBuilder)
                {
                    SplitStr(l, (System.Text.StringBuilder)inputStr);
                }
            }
            return 1;
        }

        private static int ClrFuncGetLangValue(IntPtr l, bool isStringType)
        {
            var oldtop = l.gettop();
            if (l.istable(1))
            {
                l.pushnumber(1); // 1
                l.gettable(1); // key
                if (l.IsString(-1))
                {
                    string key = l.GetString(-1);
                    l.pop(1); // X
                    var len = l.getn(1);
                    object[] args = new object[len - 1];
                    for (int i = 2; i <= len; ++i)
                    {
                        l.pushnumber(i);
                        l.gettable(1);
                        args[i - 2] = l.GetLua(-1);
                        l.pop(1);
                    }

                    string val = LanguageConverter.GetLangValue(key, args);

                    if (isStringType)
                    {
                        l.pushstring(val);
                    }
                    else
                    {
                        l.PushLuaObject(val);
                    }
                    return 1;
                }
                else
                {
                    l.settop(oldtop);
                    return 0;
                }
            }
            else
            {
                if (l.IsString(1))
                {
                    string key = l.GetString(1);
                    object[] args = new object[oldtop - 1];
                    for (int i = 2; i <= oldtop; ++i)
                    {
                        args[i - 2] = l.GetLua(i);
                    }

                    string val = LanguageConverter.GetLangValue(key, args);

                    if (isStringType)
                    {
                        l.pushstring(val);
                    }
                    else
                    {
                        l.PushLuaObject(val);
                    }
                    return 1;
                }
                else
                {
                    l.settop(oldtop);
                    return 0;
                }
            }
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int ClrFuncGetLangValueOfUserDataType(IntPtr l)
        {
            return ClrFuncGetLangValue(l, false);
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int ClrFuncGetLangValueOfStringType(IntPtr l)
        {
            return ClrFuncGetLangValue(l, true);
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        public static int UpdateLanguageConverter(IntPtr l)
        {
            if (l.istable(1))
            {
                Dictionary<string, string> updatedMap = new Dictionary<string, string>();
                l.pushnil();
                while (l.next(1))
                {
                    string key, val;
                    l.GetLua(-2, out key);
                    l.GetLua(-1, out val);
                    if (key != null)
                    {
                        updatedMap[key] = val;
                    }
                    l.pop(1);
                }
                LanguageConverter.UpdateDict(updatedMap);
            }
            return 0;
        }
    }

    public class LuaAtPanicException : Exception
    {
        public LuaAtPanicException(string message)
            : base(message)
        {
        }
    }
}