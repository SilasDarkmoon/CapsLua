using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Capstones.UnityEngineEx;
using Capstones.LuaLib;
using Capstones.LuaWrap;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaWrap
{
    public class LuaState : BaseLua
    {
        public LuaState()
        {
            L = lual.newstate();
            L.openlibs();
            _Closer = new LuaStateCloser() { _L = L };
            _ObjCache = LuaObjCache.GetOrCreateObjCache(L);
        }
        public LuaState(IntPtr l)
        {
            L = l;
            if (L != IntPtr.Zero)
            {
                _ObjCache = LuaObjCache.GetOrCreateObjCache(L);
            }
        }

        public LuaOnStackTable _G
        {
            get
            {
                return new LuaOnStackTable(L, lua.LUA_GLOBALSINDEX);
            }
        }
        public LuaStateRecover CreateStackRecover()
        {
            return new LuaStateRecover(L);
        }
        protected object _ObjCache; // this is for asset holder

        protected internal override object GetFieldImp(object key)
        {
            object rawkey = key;//.UnwrapDynamic();
            if (rawkey is string)
            {
                return _G.GetHierarchical(rawkey as string);
            }
            else
            {
                return _G[key];
            }
        }
        protected internal override bool SetFieldImp(object key, object val)
        {
            object rawkey = key;//.UnwrapDynamic();
            if (rawkey is string)
            {
                return _G.SetHierarchical(rawkey as string, val);
            }
            else
            {
                _G[key] = val;
                return true;
            }
        }

        public static implicit operator IntPtr(LuaState l)
        {
            if (!object.ReferenceEquals(l, null))
                return l.L;
            return IntPtr.Zero;
        }
        public static implicit operator LuaState(IntPtr l)
        {
            return new LuaState(l);
        }

        public override string ToString()
        {
            return "LuaState:" + L.ToString();
        }

        public static bool IgnoreDispose = false;

        protected internal class LuaStateCloser : IDisposable
        {
            [ThreadStatic] protected internal static LinkedList<IntPtr> DelayedCloser;
            protected internal LinkedList<IntPtr> _DelayedCloser;

            protected internal IntPtr _L;
            protected internal bool _Disposed;

            public LuaStateCloser()
            {
                if (DelayedCloser == null)
                    DelayedCloser = new LinkedList<IntPtr>();
                _DelayedCloser = DelayedCloser;
                RawDispose();
            }
            ~LuaStateCloser()
            {
                Dispose(false);
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected internal void Dispose(bool includeManagedRes)
            {
                if (IgnoreDispose)
                {
                    _Disposed = true;
                    return;
                }
                if (!_Disposed)
                {
                    _Disposed = true;
                    if (_L != IntPtr.Zero)
                    {
                        if (_DelayedCloser != null)
                        {
                            lock (_DelayedCloser)
                            {
                                _DelayedCloser.AddLast(_L);
                            }
                        }
                    }
                }
                RawDispose();
            }

            public static void RawDispose()
            {
                if (IgnoreDispose) return;
                if (DelayedCloser != null)
                {
                    int tick = Environment.TickCount;
                    while (DelayedCloser.Count > 0)
                    {
                        IntPtr l = IntPtr.Zero;
                        lock (DelayedCloser)
                        {
                            if (DelayedCloser.Count > 0)
                            {
                                l = DelayedCloser.First.Value;
                                DelayedCloser.RemoveFirst();
                            }
                        }
                        if (l != IntPtr.Zero)
                        {
                            l.close();
                        }
                        var newtick = Environment.TickCount;
                        //if (newtick < tick || newtick - tick > 200)
                        //{
                        //    break;
                        //}
                    }
                }
            }
        }
        protected internal LuaStateCloser _Closer = null;
        public override void Dispose()
        {
            //__UserDataCache = null;
            if (_Closer != null)
            {
                _Closer.Dispose();
            }
        }

        // TODO: more func of lualib import here.
        public int DoFile(string filepath)
        {
            var l = L;
            var oldtop = l.gettop();
            l.pushcfunction(LuaHub.LuaFuncOnError);
            var code = l.dofile(filepath, oldtop + 1);
            l.remove(oldtop + 1);
            return code;
        }
    }

    public class LuaOnStackThread : LuaState
    {
        protected internal bool _IsDone = false;
        public bool IsDone { get { return _IsDone; } }

        public override string ToString()
        {
            return "LuaThreadRaw:" + L.ToString() + ", of ref:" + Refid.ToString();
        }
        public LuaOnStackThread(IntPtr l) : base(IntPtr.Zero)
        {
            L = l;
        }

        protected internal LuaOnStackThread(IntPtr l, int refid) : base(IntPtr.Zero)
        {
            L = l;
            Refid = refid;
        }

        public void Resume()
        {
            DoResume();
            L.settop(0);
        }
        public object[] Resume(params object[] args)
        {
            if (L != IntPtr.Zero)
            {
                if (args != null)
                {
                    for (int i = 0; i < args.Length; ++i)
                    {
                        L.PushLua(args[i]);
                    }
                }
                DoResume();
                object[] rv = ObjectPool.GetReturnValueFromPool(L.gettop());
                for (int i = 0; i < rv.Length; ++i)
                {
                    rv[i] = L.GetLua(i + 1);
                }
                L.settop(0);
                return rv;
            }
            return null;
        }
        public Pack<T1, T2> Resume<T1, T2>()
        {
            Pack<T1, T2> rv = new Pack<T1, T2>();
            if (L != IntPtr.Zero)
            {
                DoResume();
                var rvc = L.gettop();
                if (rvc >= 1)
                {
                    L.GetLua(1, out rv.t1);
                }
                if (rvc >= 2)
                {
                    L.GetLua(2, out rv.t2);
                }
                L.settop(0);
                return rv;
            }
            return rv;
        }

        protected internal virtual void DoResume()
        {
#if ENABLE_PROFILER && ENABLE_PROFILER_LUA_DEEP && !DISABLE_PROFILER_LUA_COROUTINE
            string simpleStack = L.GetSimpleStackInfo(8);
            using (var pcon = new Capstones.UnityFramework.ProfilerContext("LuaCoroutine: " + simpleStack))
#endif
            ResumeRaw(0);
        }
        protected internal void ResumeRaw(int oldtop)
        {
            if (_IsDone)
            {
                L.settop(0);
                return;
            }
            var argc = L.gettop() - oldtop;
            if (argc < 0)
            {
                L.LogWarning("Lua stack is not correct when resume lua coroutine.");
                argc = 0;
            }
            int status = L.resume(argc);
            if (status == lua.LUA_YIELD || status == 0)
            {
                if (status == 0)
                {
                    _IsDone = true;
                }
            }
            else
            {
                L.pushcfunction(LuaHub.LuaFuncOnError);
                L.insert(-2);
                L.pcall(1, 0, 0);
                L.settop(0);
                _IsDone = true;
            }
        }

        public virtual bool IsRunning
        {
            get
            {
                if (L != IntPtr.Zero)
                {
                    return L.status() == lua.LUA_YIELD;
                }
                return false;
            }
        }

        public override void Dispose()
        {
            if (Ref != null)
            {
                Ref.Dispose();
                Ref = null;
            }
        }
    }

    public class LuaThread : LuaOnStackThread
    {
        public override string ToString()
        {
            return "LuaThreadRestartable:" + L.ToString() + ", of ref:" + Refid.ToString();
        }

        protected internal LuaFunc _Func;
        protected internal bool _NeedRestart = true;

        public LuaThread(LuaFunc func) : base(IntPtr.Zero)
        {
            if (!ReferenceEquals(func, null) && func.L != IntPtr.Zero)
            {
                L = func.L.newthread();
                Refid = func.L.refer();
                if (func.Refid != 0)
                {
                    L.getref(func.Refid);
                    _Func = new LuaFunc(L, -1);
                    L.pop(1);
                }
            }
            if (L != IntPtr.Zero)
            {
                _ObjCache = LuaObjCache.GetOrCreateObjCache(L);
            }
        }
        public LuaThread(LuaOnStackFunc func) : base(IntPtr.Zero)
        {
            if (!ReferenceEquals(func, null) && func.L != IntPtr.Zero)
            {
                L = func.L.newthread();
                Refid = func.L.refer();
                func.L.pushvalue(func.StackPos);
                var reffunc = func.L.refer();
                _Func = new LuaFunc();
                _Func.L = L;
                _Func.Refid = reffunc;
            }
            if (L != IntPtr.Zero)
            {
                _ObjCache = LuaObjCache.GetOrCreateObjCache(L);
            }
        }

#if ENABLE_PROFILER && ENABLE_PROFILER_LUA_DEEP && !DISABLE_PROFILER_LUA_COROUTINE
        protected string _ProfilerShownName;
#endif
        protected internal override void DoResume()
        {
            if (!ReferenceEquals(_Func, null) && L != IntPtr.Zero)
            {
                if (_NeedRestart)
                {
                    _NeedRestart = false;
                    _IsDone = false;
                    if (ReferenceEquals(_Func, null))
                    {
                        L.settop(0);
                        return;
                    }
                    L.PushLua(_Func);
                    L.insert(1);
#if ENABLE_PROFILER && ENABLE_PROFILER_LUA_DEEP && !DISABLE_PROFILER_LUA_COROUTINE
                    if (_ProfilerShownName == null)
                    {
                        System.Text.StringBuilder sbName = new System.Text.StringBuilder();
                        sbName.Append("LuaCoroutine in ");
                        string funcName, fileName;
                        int lineStart, lineCur;
                        L.GetFuncInfo(1, out funcName, out fileName, out lineStart, out lineCur);
                        sbName.Append(fileName);
                        sbName.Append(" at ");
                        sbName.Append(lineStart);
                        _ProfilerShownName = sbName.ToString();
                    }
                    using (var pcon = new Capstones.UnityFramework.ProfilerContext(_ProfilerShownName))
                    using (var pconi = new Capstones.UnityFramework.ProfilerContext("at start"))
#endif
                    ResumeRaw(1);
                }
                else if (IsRunning)
                {
#if ENABLE_PROFILER && ENABLE_PROFILER_LUA_DEEP && !DISABLE_PROFILER_LUA_COROUTINE
                    string simpleStack = L.GetSimpleStackInfo(8);
                    using (var pcon = new Capstones.UnityFramework.ProfilerContext(_ProfilerShownName))
                    using (var pconi = new Capstones.UnityFramework.ProfilerContext(simpleStack))
#endif
                    ResumeRaw(0);
                }
            }
        }

        public void Restart()
        {
            _NeedRestart = true;
        }

        public override void Dispose()
        {
            base.Dispose();
            if (!object.ReferenceEquals(_Func, null))
            {
                _Func.Dispose();
            }
        }
    }

    internal class LuaThreadRefMan : ILuaMeta
    {
        internal bool IsClosed = false;
        private List<LuaRef> _RefCache = new List<LuaRef>(8);
        private List<LuaRef> _PendingRecycle = new List<LuaRef>(8);

        internal void ReturnLuaRef(LuaRef lr)
        {
            lr.l = IntPtr.Zero;
            lr.r = 0;
            lr.lr = 0;
            _RefCache.Add(lr);
        }
        public LuaRef GetLuaRef()
        {
            DoPendingRecycle();
            if (_RefCache.Count <= 0)
            {
                var rv = new LuaRef();
                rv.man = this;
                return rv;
            }
            else
            {
                var index = _RefCache.Count - 1;
                var rv = _RefCache[index];
                _RefCache.RemoveAt(index);
                GC.ReRegisterForFinalize(rv);
                return rv;
            }
        }
        internal void DoPendingRecycle()
        {
            if (IsClosed)
            {
                return;
            }
            if (_PendingRecycle.Count <= 0)
            {
                return;
            }
            List<LuaRef> list;
            lock (_PendingRecycle)
            {
                list = new List<LuaRef>(_PendingRecycle);
                _PendingRecycle.Clear();
            }
            for (int i = 0; i < list.Count; ++i)
            {
                var lr = list[i];
                lr.RawDispose();
                ReturnLuaRef(lr);
            }
        }
        internal void RegPendingRecycle(LuaRef lr)
        {
            //GC.SuppressFinalize(lr); // this should be called in finalizer.
            if (IsClosed)
            {
                return;
            }
            lock (_PendingRecycle)
            {
                _PendingRecycle.Add(lr);
            }
        }
        internal void DoImmediateRecycle(LuaRef lr)
        {
            GC.SuppressFinalize(lr);
            if (IsClosed)
            {
                return;
            }
            lr.RawDispose();
            ReturnLuaRef(lr);
        }

        public void Close()
        {
            IsClosed = true;
        }

        public IntPtr r
        {
            get;
            internal set;
        }

        public void gc(IntPtr l, object obj)
        {
            Close();
        }
        public void call(IntPtr l, object tar)
        {
        }


        public void index(IntPtr l, object tar, int kindex)
        {
        }

        public void newindex(IntPtr l, object tar, int kindex, int valindex)
        {
        }
    }

    public class LuaRef : IDisposable
    {
        internal IntPtr l;
        internal int r;
        internal int lr;
        internal LuaThreadRefMan man;

        public void RawDispose()
        {
            if (l != IntPtr.Zero)
            {
                l.unref(lr);
                if (r != 0)
                {
                    l.unref(r);
                }
            }
        }

        public IntPtr L
        {
            get { return l; }
            set
            {
                if (man.IsClosed)
                {
                    return;
                }
                if (l == value)
                {
                    return;
                }
                var old = l;
                l = value;
                if (old != IntPtr.Zero)
                {
                    old.unref(lr);
                }
                if (l != IntPtr.Zero)
                {
                    l.pushthread();
                    lr = l.refer();
                }
                else
                {
                    lr = 0;
                }
            }
        }

        public int Refid
        {
            get { return r; }
            set { r = value; }
        }

        internal LuaRef()
        {
        }
        ~LuaRef()
        {
            man.RegPendingRecycle(this);
        }
        public void Dispose()
        {
            man.DoImmediateRecycle(this);
        }
    }

    internal static class LuaThreadRefHelper
    {
        public static LuaThreadRefMan GetOrCreateRefMan(this IntPtr l)
        {
            l.checkstack(1);
            l.pushlightuserdata(LuaConst.LRKEY_REF_MAN); // #man
            l.gettable(lua.LUA_REGISTRYINDEX); // man
            if (l.isuserdata(-1))
            {
                LuaThreadRefMan man = null;
                try
                {
                    IntPtr pud = l.touserdata(-1);
                    if (pud != IntPtr.Zero)
                    {
                        IntPtr hval = Marshal.ReadIntPtr(pud);
                        GCHandle handle = (GCHandle)hval;
                        man = handle.Target as LuaThreadRefMan;
                    }
                }
                catch { }
                l.pop(1); // X
                return man;
            }
            else
            {
                l.checkstack(5);
                l.pop(1); // X
                l.pushlightuserdata(LuaConst.LRKEY_REF_MAN); // #man
                LuaThreadRefMan man = new LuaThreadRefMan();
                var h = l.PushLuaRawObject(man); // #man man
                l.PushCommonMetaTable(); // #man man meta
                l.setmetatable(-2); // #man man
                l.newtable(); // #man man env
                l.pushlightuserdata(LuaConst.LRKEY_OBJ_META_EX); // #man man env #meta
                l.pushlightuserdata(h); // #man man env #meta meta
                l.settable(-3); // #man man env
                l.setfenv(-2); // #man man
                l.settable(lua.LUA_REGISTRYINDEX); // X
                return man;
            }
        }
    }

    public static class LuaStateHelper
    {
        public static bool GetHierarchicalRaw(this IntPtr l, int index, string key)
        {
            if (string.IsNullOrEmpty(key))
                return false;
            var hkeys = key.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (hkeys == null)
                return false;
            if (l == IntPtr.Zero)
                return false;

            //var oldtop = l.gettop();
            l.pushvalue(index); // table
            l.pushnil(); // table result
            l.insert(-2); // result table
            for (int i = 0; i < hkeys.Length; ++i)
            {
                if (l.istable(-1) || l.IsUserData(-1))
                {
                    l.GetField(-1, hkeys[i]); // result table newresult
                    l.replace(-3); // newresult table
                    l.pop(1); // newresult
                    l.pushvalue(-1); // newresult newtable
                }
                else
                {
                    break;
                }
            }
            l.pop(1); // result
            return true;
        }
        public static object GetHierarchical(this IntPtr l, int index, string key)
        {
            if (GetHierarchicalRaw(l, index, key))
            {
                var rv = l.GetLua(-1);
                l.pop(1);
                return rv;
            }
            return null;
        }
        public static object GetHierarchical(this LuaOnStackTable tab, string key)
        {
            if (ReferenceEquals(tab, null) || tab.L == IntPtr.Zero)
            {
                return null;
            }
            return GetHierarchical(tab.L, tab.StackPos, key);
        }
        public static object GetHierarchical(this LuaTable tab, string key)
        {
            if (ReferenceEquals(tab, null) || tab.L == IntPtr.Zero)
            {
                return null;
            }
            var l = tab.L;
            l.PushLua(tab);
            var rv = GetHierarchical(l, -1, key);
            l.pop(1);
            return rv;
        }
        //public static object GetHierarchical(this LuaOnStackUserData ud, string key)
        //{
        //    if (ReferenceEquals(ud, null) || ud.L == IntPtr.Zero)
        //    {
        //        return null;
        //    }
        //    var l = ud.L;
        //    using (var lr = new LuaStateRecover(l))
        //    {
        //        if (ud.PushToLua())
        //        {
        //            return GetHierarchical(l, -1, key);
        //        }
        //        return null;
        //    }
        //}

        public static bool SetHierarchicalRaw(this IntPtr l, int index, string key, int valindex)
        {
            var val = l.GetLuaOnStack(valindex);
            return SetHierarchical(l, index, key, val);
        }
        public static bool SetHierarchical(this IntPtr l, int index, string key, object val)
        {
            if (string.IsNullOrEmpty(key))
                return false;
            var hkeys = key.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (hkeys == null || hkeys.Length < 1)
                return false;
            if (l == IntPtr.Zero)
                return false;

            l.pushvalue(index); // table
            for (int i = 0; i < hkeys.Length - 1; ++i)
            {
                if (l.istable(-1) || l.IsUserData(-1))
                {
                    l.GetField(-1, hkeys[i]); // table result
                    if (l.isnoneornil(-1))
                    {
                        l.pop(1); // table
                        l.newtable(); // table result
                        l.pushvalue(-1); // table result result
                        l.SetField(-3, hkeys[i]); // table result
                    }
                    l.remove(-2); // result
                }
                else
                {
                    l.pop(1);
                    return false;
                }
            }
            if (l.istable(-1) || l.IsUserData(-1))
            {
                l.PushLua(val); // table val
                l.SetField(-2, hkeys[hkeys.Length - 1]); // table
                l.pop(1);
                return true;
            }
            else
            {
                l.pop(1);
                return false;
            }
        }
        public static bool SetHierarchical(this LuaOnStackTable tab, string key, object val)
        {
            if (ReferenceEquals(tab, null) || tab.L == IntPtr.Zero)
            {
                return false;
            }
            return SetHierarchical(tab.L, tab.StackPos, key, val);
        }
        public static bool SetHierarchical(this LuaTable tab, string key, object val)
        {
            if (ReferenceEquals(tab, null) || tab.L == IntPtr.Zero)
            {
                return false;
            }
            var l = tab.L;
            l.PushLua(tab);
            var rv = SetHierarchical(l, -1, key, val);
            l.pop(1);
            return rv;
        }
        //public static bool SetHierarchical(this LuaOnStackUserData ud, string key, object val)
        //{
        //    if (ReferenceEquals(ud, null) || ud.L == IntPtr.Zero)
        //    {
        //        return false;
        //    }
        //    var l = ud.L;
        //    using (var lr = new LuaStateRecover(l))
        //    {
        //        if (ud.PushToLua())
        //        {
        //            return SetHierarchical(l, -1, key, val);
        //        }
        //        return false;
        //    }
        //}
    }
}

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public static void PushLua(this IntPtr l, LuaWrap.LuaState val)
        {
            val.L.pushthread();
        }
        public static void PushLua(this IntPtr l, LuaWrap.LuaOnStackThread val)
        {
            val.L.pushthread();
        }
        public static void PushLua(this IntPtr l, LuaWrap.LuaThread val)
        {
            val.L.pushthread();
        }

        private class LuaPushNative_LuaState : LuaPushNativeBase<LuaWrap.LuaState>
        {
            public override LuaState GetLua(IntPtr l, int index)
            {
                return new LuaWrap.LuaState(l.tothread(index));
            }
            public override IntPtr PushLua(IntPtr l, LuaWrap.LuaState val)
            {
                val.L.pushthread();
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_LuaState ___tpn_LuaState = new LuaPushNative_LuaState();
        private class LuaPushNative_LuaOnStackThread : LuaPushNativeBase<LuaWrap.LuaOnStackThread>
        {
            public override LuaOnStackThread GetLua(IntPtr l, int index)
            {
                IntPtr lthd = l.tothread(index);
                l.pushvalue(index);
                int refid = l.refer();
                return new Capstones.LuaWrap.LuaOnStackThread(lthd, refid);
            }
            public override IntPtr PushLua(IntPtr l, LuaWrap.LuaOnStackThread val)
            {
                val.L.pushthread();
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_LuaOnStackThread ___tpn_LuaOnStackThread = new LuaPushNative_LuaOnStackThread();
        private class LuaPushNative_LuaThread : LuaPushNativeBase<LuaWrap.LuaThread>
        {
            public override LuaThread GetLua(IntPtr l, int index)
            {
                return new LuaWrap.LuaThread(new LuaFunc(l, index));
            }
            public override IntPtr PushLua(IntPtr l, LuaWrap.LuaThread val)
            {
                val.L.pushthread();
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_LuaThread ___tpn_LuaThread = new LuaPushNative_LuaThread();
    }
}