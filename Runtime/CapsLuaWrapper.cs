using System;
using System.Collections;
using System.Collections.Generic;
using Capstones.LuaLib;
using Capstones.LuaWrap;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;
using static Capstones.LuaWrap.LuaPack;

namespace Capstones.LuaWrap
{
    public class BaseLua : ScriptDynamic, IDisposable
    {
        protected internal IntPtr _L;
        protected internal int _R;

        protected internal LuaRef Ref
        {
            get
            {
                return _Binding as LuaRef;
            }
            set
            {
                _Binding = value;
            }
        }
        public IntPtr L
        {
            get { return _L; }
            internal protected set
            {
                var old = _L;
                _L = value;
                if (Ref == null)
                {
                    if (value != IntPtr.Zero && _R != 0)
                    {
                        var man = value.GetOrCreateRefMan();
                        Ref = man.GetLuaRef();
                        Ref.L = value;
                        Ref.Refid = _R;
                    }
                }
                else
                {
                    if (value == IntPtr.Zero)
                    {
                        //_R = 0;
                        Ref.Dispose();
                        Ref = null;
                    }
                    else
                    {
                        if (old != value)
                        {
                            DynamicHelper.LogError("Try to set LuaRef's L to another value.");
                        }
                    }
                }
            }
        }
        public override int Refid
        {
            get { return _R; }
            protected internal set
            {
                var old = _R;
                _R = value;
                if (Ref == null)
                {
                    if (_L != IntPtr.Zero && value != 0)
                    {
                        var man = _L.GetOrCreateRefMan();
                        Ref = man.GetLuaRef();
                        Ref.L = _L;
                        Ref.Refid = value;
                    }
                }
                else
                {
                    if (value == 0)
                    {
                        //_L = IntPtr.Zero;
                        Ref.Dispose();
                        Ref = null;
                    }
                    else
                    {
                        if (old != value)
                        {
                            DynamicHelper.LogError("Try to set LuaRef's Refid to another value.");
                        }
                    }
                }
            }
        }
        public bool IsClosed { get { return object.ReferenceEquals(Ref, null) || Ref.IsClosed; } }

        public override string ToString()
        {
            return "LuaRef:" + Refid.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is BaseLua)
            {
                return Refid == ((BaseLua)obj).Refid && L == ((BaseLua)obj).L;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Refid ^ L.GetHashCode();
        }

        public BaseLua() { }
        public BaseLua(IntPtr l, int refid)
        {
            L = l;
            Refid = refid;
        }
        public virtual void Dispose()
        {
            if (Ref != null)
            {
                Ref.Dispose();
                Ref = null;
            }
        }

        protected internal override object ConvertBinding(Type type)
        {
            if (type.IsSubclassOf(typeof(Delegate)))
            {
                return Capstones.LuaLib.CapsLuaDelegateGenerator.CreateDelegate(type, this);
            }
            else if (type == typeof(bool))
            {
                if (L != IntPtr.Zero && Refid != 0)
                {
                    L.getref(Refid);
                    bool rv = !L.isnoneornil(-1) && !(L.isboolean(-1) && !L.toboolean(-1));
                    L.pop(1);
                    return rv;
                }
                return false;
            }
            else if (typeof(ILuaWrapper).IsAssignableFrom(type))
            {
                try
                {
                    var val = Activator.CreateInstance(type);
                    var wrapper = (ILuaWrapper)val;
                    wrapper.Binding = this;
                    return wrapper;
                }
                catch (Exception e)
                { // we can not create instance of wrapper?
                    DynamicHelper.LogError(e);
                    return null;
                }
            }
            DynamicHelper.LogInfo("__convert(" + type.ToString() + ") meta-method Not Implemented.");
            return null;
        }
        public virtual void PushToLua(IntPtr l)
        {
            l.getref(Refid);
        }

        public void Call()
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l);
        }
        public void Call<P0>(P0 p0)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0);
        }
        public void Call<P0, P1>(P0 p0, P1 p1)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1);
        }
        public void Call<P0, P1, P2>(P0 p0, P1 p1, P2 p2)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2);
        }
        public void Call<P0, P1, P2, P3>(P0 p0, P1 p1, P2 p2, P3 p3)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3);
        }
        public void Call<P0, P1, P2, P3, P4>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4);
        }
        public void Call<P0, P1, P2, P3, P4, P5>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5);
        }
        public void Call<P0, P1, P2, P3, P4, P5, P6>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6);
        }
        public void Call<P0, P1, P2, P3, P4, P5, P6, P7>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6, p7);
        }
        public void Call<P0, P1, P2, P3, P4, P5, P6, P7, P8>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6, p7, p8);
        }
        public void Call<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            var l = L;
            PushToLua(l);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
        }
        public bool Call<R>(out R r)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r);
        }
        public bool Call<R, P0>(out R r, P0 p0)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0);
        }
        public bool Call<R, P0, P1>(out R r, P0 p0, P1 p1)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1);
        }
        public bool Call<R, P0, P1, P2>(out R r, P0 p0, P1 p1, P2 p2)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2);
        }
        public bool Call<R, P0, P1, P2, P3>(out R r, P0 p0, P1 p1, P2 p2, P3 p3)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3);
        }
        public bool Call<R, P0, P1, P2, P3, P4>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5, P6>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5, P6, P7>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6, p7);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6, p7, p8);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            var l = L;
            PushToLua(l);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
        }
        public R Call<R>()
        {
            R r;
            Call(out r);
            return r;
        }
        public R Call<R, P0>(P0 p0)
        {
            R r;
            Call(out r, p0);
            return r;
        }
        public R Call<R, P0, P1>(P0 p0, P1 p1)
        {
            R r;
            Call(out r, p0, p1);
            return r;
        }
        public R Call<R, P0, P1, P2>(P0 p0, P1 p1, P2 p2)
        {
            R r;
            Call(out r, p0, p1, p2);
            return r;
        }
        public R Call<R, P0, P1, P2, P3>(P0 p0, P1 p1, P2 p2, P3 p3)
        {
            R r;
            Call(out r, p0, p1, p2, p3);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5, P6>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5, P6, P7>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7, p8);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
            return r;
        }
    }

    public class BaseLuaOnStack : BaseLua
    {
        public override string ToString()
        {
            return "LuaOnStack:" + StackPos.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is BaseLuaOnStack)
            {
                return StackPos == ((BaseLuaOnStack)obj).StackPos && L == ((BaseLuaOnStack)obj).L;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return StackPos ^ L.GetHashCode();
        }
        public override int Refid
        {
            get
            {
                return 0;
            }
            protected internal set
            {
            }
        }

        public virtual int StackPos
        {
            //get
            //{
            //    if (_Binding == null)
            //        return 0;
            //    if (_Binding is int)
            //        return (int)_Binding;
            //    return 0;
            //}
            //protected internal set
            //{
            //    _Binding = value;
            //}
            get; set;
        }

        protected internal override object ConvertBinding(Type type)
        {
            if (type == typeof(bool))
            {
                if (L != IntPtr.Zero && StackPos != 0)
                {
                    bool rv = !L.isnoneornil(StackPos) && !(L.isboolean(StackPos) && !L.toboolean(StackPos));
                    return rv;
                }
                return false;
            }
            else if (typeof(ILuaWrapper).IsAssignableFrom(type))
            {
                try
                {
                    var val = Activator.CreateInstance(type);
                    var wrapper = (ILuaWrapper)val;
                    wrapper.Binding = this;
                    return wrapper;
                }
                catch (Exception e)
                { // we can not create instance of wrapper?
                    DynamicHelper.LogError(e);
                    return null;
                }
            }
            DynamicHelper.LogInfo("__convert(" + type.ToString() + ") meta-method Not Implemented.");
            return null;
        }
        public override void PushToLua(IntPtr l)
        {
            l.pushvalue(StackPos);
        }
    }
}

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public static void PushLua(this IntPtr l, BaseLuaOnStack val)
        {
            l.pushvalue(val.StackPos);
        }
        public static void PushLua(this IntPtr l, BaseLua val)
        {
            if (val is BaseLuaOnStack)
            {
                l.pushvalue(((BaseLuaOnStack)val).StackPos);
            }
            else
            {
                l.getref(val.Refid);
            }
        }

        private class LuaPushNative_BaseLuaOnStack : LuaPushNativeBase<LuaWrap.BaseLuaOnStack>
        {
            public override BaseLuaOnStack GetLua(IntPtr l, int index)
            {
                return new BaseLuaOnStack() { L = l, StackPos = index };
            }
            public override IntPtr PushLua(IntPtr l, LuaWrap.BaseLuaOnStack val)
            {
                l.pushvalue(val.StackPos);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_BaseLuaOnStack ___tpn_BaseLuaOnStack = new LuaPushNative_BaseLuaOnStack();
        private class LuaPushNative_BaseLua : LuaPushNativeBase<LuaWrap.BaseLua>
        {
            public override BaseLua GetLua(IntPtr l, int index)
            {
                l.pushvalue(index);
                int refid = l.refer();
                return new BaseLua(l, refid);
            }
            public override IntPtr PushLua(IntPtr l, LuaWrap.BaseLua val)
            {
                l.getref(val.Refid);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_BaseLua ___tpn_BaseLua = new LuaPushNative_BaseLua();
    }
}

// Lua Wrapper. Its data and functions are in lua but we can use it in C# by this wrapper.
// When we push this wrapper to lua, we actually push its binding LuaTable
namespace Capstones.LuaWrap
{
    public interface ILuaWrapper
    {
        BaseLua Binding { get; set; }
        string LuaFile { get; }
    }
    public class BaseLuaWrapper : ILuaWrapper
    {
        public BaseLua Binding { get; set; }
        public virtual string LuaFile { get; protected set; }
        public IntPtr L { get { return ReferenceEquals(Binding, null) ? IntPtr.Zero : Binding.L; } }
        protected virtual bool ShouldCheckLuaHubSub { get { return true; } }

        public BaseLuaWrapper()
        {
            if (ShouldCheckLuaHubSub)
            {
                CheckLuaHubSub(this);
            }
        }
        public BaseLuaWrapper(IntPtr l) : this()
        {
            this.BindLua(l);
        }
        protected static LuaTypeHub.TypeHubValueType CheckLuaHubSub(object thiz)
        {
            var type = thiz.GetType();
            LuaTypeHub.TypeHubValueType hub;
            if (!LuaHubSubs.TryGetValue(type, out hub))
            {
                hub = (LuaTypeHub.TypeHubValueType)Activator.CreateInstance(typeof(LuaHub.BaseLuaWrapperHub<>).MakeGenericType(type));
                //LuaHubSubs[type] = hub;
            }
            return hub;
        }
        protected internal static readonly Dictionary<Type, LuaTypeHub.TypeHubValueType> LuaHubSubs = new Dictionary<Type, LuaTypeHub.TypeHubValueType>();
        private static LuaHub.BaseLuaWrapperHub<BaseLuaWrapper> LuaHubSub = new LuaHub.BaseLuaWrapperHub<BaseLuaWrapper>();

        public T Get<T>(string field)
        {
            var l = Binding.L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                T val;
                l.GetTable(out val, -1, field);
                return val;
            }
        }
        public void Set<T>(string field, T val)
        {
            var l = Binding.L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                l.SetTable(-1, Pack(val), field);
            }
        }
    }
    public class BaseLuaWrapper<T> : BaseLuaWrapper where T : BaseLuaWrapper, new()
    {
        protected override bool ShouldCheckLuaHubSub { get { return false; } }
        public BaseLuaWrapper() : base() { }
        public BaseLuaWrapper(IntPtr l) : base(l) { }

        protected static LuaHub.BaseLuaWrapperHub<T> LuaHubSub = new LuaHub.BaseLuaWrapperHub<T>();
    }

    public static class LuaWrapperExtensions
    {
        public static bool BindLua<TIn>(this ILuaWrapper thiz, IntPtr l, TIn args)
            where TIn : struct, ILuaPack
        {
            if (thiz == null)
            {
                return false;
            }
            if (ReferenceEquals(thiz.Binding, null))
            {
                if (string.IsNullOrEmpty(thiz.LuaFile))
                {
                    l.newtable();
                }
                else if (!l.NewTable(thiz.LuaFile, args)) // ud
                {
                    l.pop(1);
                    return false;
                }
                if (!l.getmetatable(-1)) // ud meta
                { // ud
                    l.newtable(); // ud meta
                    l.pushvalue(-1); // ud meta meta
                    l.SetField(-2, LuaConst.LS_META_KEY_INDEX); // ud meta
                    l.pushvalue(-1); // ud meta meta
                    l.setmetatable(-3); // ud meta
                }
                else
                { // we have already made metatable. that means we attached to lua class. this metatable is shared. so we'd better not record data to the metatable.
                    l.pop(1);
                    l.pushvalue(-1); // ud ud
                }
                l.pushlightuserdata(LuaConst.LRKEY_TYPE_TRANS); // ud meta #trans
                l.pushlightuserdata(LuaTypeHub.GetTypeHub(thiz.GetType()).r); // ud meta #trans trans
                l.rawset(-3); // ud meta
                l.pushlightuserdata(LuaConst.LRKEY_TARGET);
                l.PushLuaRawObject(new WeakReference(thiz));
                l.rawset(-3); // ud meta
                thiz.Binding = new LuaTable(l, -2);
                l.pop(2); // X
                return true;
            }
            else
            {
                return true;
            }
        }

        public static bool BindLua(this ILuaWrapper thiz, IntPtr l)
        {
            return thiz.BindLua(l, Pack());
        }

        public static T GetWrapper<T>(this ILuaWrapper thiz) where T : ILuaWrapper, new()
        {
            if (thiz == null)
            {
                return default(T);
            }
            else
            {
                var copy = new T();
                copy.Binding = thiz.Binding;
                return copy;
            }
        }
        public static void GetWrapper<T>(this ILuaWrapper thiz, out T copy) where T : ILuaWrapper, new()
        {
            copy = thiz.GetWrapper<T>();
        }

        public static T GetWrapper<T>(this BaseLua lua) where T : ILuaWrapper, new()
        {
            if (ReferenceEquals(lua, null))
            {
                return default(T);
            }
            else
            {
                var result = new T();
                result.Binding = lua;
                return result;
            }
        }
        public static void GetWrapper<T>(this BaseLua lua, out T result) where T : ILuaWrapper, new()
        {
            result = lua.GetWrapper<T>();
        }

        public static T GetWrapper<T>(this object o) where T : ILuaWrapper, new()
        {
            if (o is T)
            {
                return (T)o;
            }
            else if (o is BaseLua)
            {
                var result = new T();
                result.Binding = (BaseLua)o;
                return result;
            }
            else if (o is ILuaWrapper)
            {
                var result = new T();
                result.Binding = ((ILuaWrapper)o).Binding;
                return result;
            }
            return default(T);
        }
        public static void GetWrapper<T>(this object o, out T result) where T : ILuaWrapper, new()
        {
            result = o.GetWrapper<T>();
        }
    }
}

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class BaseLuaWrapperHub<T> : LuaTypeHub.TypeHubValueType, ILuaTrans<T>, ILuaPush<T>
            where T : ILuaWrapper, new()
        {
            public override bool Nonexclusive { get { return true; } }
            public static void SetDataRaw(IntPtr l, int index, T val)
            {
                if (ReferenceEquals(val.Binding, null))
                {
                    if (!val.BindLua(l))
                    {
                        return;
                    }
                }
                l.checkstack(3);
                l.PushLua(val.Binding); // ud
                l.pushlightuserdata(LuaConst.LRKEY_TARGET); // ud #tar
                l.gettable(-2); // ud tar
                var current = l.isuserdata(-1) ? (l.GetLuaRawObject(-1) as WeakReference).GetWeakReference<T>() : default(T);
                if (ReferenceEquals(current, val))
                {
                    l.pop(2); // X
                }
                else
                {
                    l.pop(1); // ud
                    if (!l.getmetatable(-1)) // ud meta
                    { // ud
                        l.newtable(); // ud meta
                        l.pushvalue(-1); // ud meta meta
                        l.SetField(-2, LuaConst.LS_META_KEY_INDEX); // ud meta
                        l.pushvalue(-1); // ud meta meta
                        l.setmetatable(-3); // ud meta
                    }
                    else
                    {
                        l.pushlightuserdata(LuaConst.LRKEY_TARGET); // ud meta #tar
                        l.rawget(-2); // ud meta tar
                        if (l.isnoneornil(-1))
                        { // the tar is not stored in metatable
                            l.pop(2); // ud
                            l.pushvalue(-1); // ud ud
                        }
                        else
                        {
                            l.pop(1); // ud meta
                        }
                    }
                    l.pushlightuserdata(LuaConst.LRKEY_TARGET); // ud meta #tar
                    l.PushLuaRawObject(new WeakReference(val)); // ud meta #tar tar
                    l.rawset(-3); // ud meta
                    if (!(val.Binding is BaseLuaOnStack))
                    {
                        l.pushlightuserdata(LuaConst.LRKEY_TYPE_TRANS);
                        l.pushlightuserdata(LuaTypeHub.GetTypeHub(typeof(T)).r);
                        l.rawset(-3);
                    }
                    l.pop(2); // X
                }
            }
            public static T GetLuaRaw(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    l.checkstack(3);
                    l.pushvalue(index); // ud
                    l.pushlightuserdata(LuaConst.LRKEY_TARGET); // ud #tar
                    l.gettable(-2); // ud tar
                    var current = l.isuserdata(-1) ? (l.GetLuaRawObject(-1) as WeakReference).GetWeakReference<T>() : default(T);
                    l.pop(2); // X
                    if (current != null)
                    {
                        return current;
                    }
                    else
                    {
                        var val = new T();
                        if (val != null)
                        {
                            l.pushvalue(index); // ud
                            val.Binding = new BaseLua(l, l.refer()); // X
                            l.pushvalue(index); // ud
                            if (!l.getmetatable(-1)) // ud meta
                            { // ud
                                l.newtable(); // ud meta
                                l.pushvalue(-1); // ud meta meta
                                l.SetField(-2, LuaConst.LS_META_KEY_INDEX); // ud meta
                                l.pushvalue(-1); // ud meta meta
                                l.setmetatable(-3); // ud meta
                            }
                            else
                            {
                                l.pushlightuserdata(LuaConst.LRKEY_TARGET); // ud meta #tar
                                l.rawget(-2); // ud meta tar
                                if (l.isnoneornil(-1))
                                { // the tar is not stored in metatable
                                    l.pop(2); // ud
                                    l.pushvalue(-1); // ud ud
                                }
                                else
                                {
                                    l.pop(1); // ud meta
                                }
                            }
                            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // ud meta #tar
                            l.PushLuaRawObject(new WeakReference(val)); // ud meta #tar tar
                            l.rawset(-3); // ud meta
                            l.pushlightuserdata(LuaConst.LRKEY_TYPE_TRANS);
                            l.pushlightuserdata(LuaTypeHub.GetTypeHub(typeof(T)).r);
                            l.rawset(-3);
                            l.pop(2); // X
                            return val;
                        }
                    }
                }
                return default(T);
            }
            public static void PushLuaRaw(IntPtr l, T val)
            {
                if (ReferenceEquals(val.Binding, null))
                {
                    if (!val.BindLua(l))
                    {
                        l.pushnil();
                        return;
                    }
                }
                l.PushLua(val.Binding);
            }

            public class LuaWrapperNative : LuaPushNativeBase<T>
            {
                public override T GetLua(IntPtr l, int index)
                {
                    return GetLuaRaw(l, index);
                }
                public override IntPtr PushLua(IntPtr l, T val)
                {
                    PushLuaRaw(l, val);
                    return IntPtr.Zero;
                }
            }
            public static readonly LuaWrapperNative LuaHubNative = new LuaWrapperNative();

            public BaseLuaWrapperHub() : base(null)
            {
                t = typeof(T);
                PutIntoCache();
                BaseLuaWrapper.LuaHubSubs[t] = this;
            }
            protected override bool UpdateDataAfterCall
            {
                get { return true; }
            }

            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLuaRaw(l, (T)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (T)val);
            }
            public override object GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public IntPtr PushLua(IntPtr l, T val)
            {
                PushLuaRaw(l, val);
                return IntPtr.Zero;
            }
            public void SetData(IntPtr l, int index, T val)
            {
                SetDataRaw(l, index, val);
            }
            T ILuaTrans<T>.GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
        }
    }
}

// Some lua collections
namespace Capstones.LuaWrap
{
    public class LuaList<T> : BaseLuaWrapper<LuaList<T>>, ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
    {
        public LuaList() : base() { }
        public LuaList(IntPtr l) : base(l) { }

        protected IEqualityComparer<T> _Comparer = EqualityComparer<T>.Default;
        protected bool Equals(T v1, T v2)
        {
            return _Comparer.Equals(v1, v2);
        }

        public bool IsSynchronized { get { return false; } }
        public object SyncRoot { get { return LuaHubSub; } }

        public void CopyTo(Array array, int index)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    array.SetValue(val, index + i);
                    l.pop(1);
                }
            }
        }

        public T this[int index]
        {
            get
            {
                var l = L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    l.pushnumber(index + 1);
                    l.rawget(-2);
                    return l.GetLua<T>(-1);
                }
            }
            set
            {
                var l = L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    l.pushnumber(index + 1);
                    l.PushLua(value);
                    l.rawset(-3);
                }
            }
        }

        public int Count
        {
            get
            {
                var l = L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    return l.getn(-1);
                }
            }
        }

        public int Capacity { get { return int.MaxValue; } }
        public bool IsReadOnly { get { return false; } }
        public bool IsFixedSize { get { return false; } }

        object IList.this[int index]
        {
            get { return this[index]; }
            set { this[index] = (T)value; }
        }

        public void Add(T item)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                l.pushnumber(cnt + 1);
                l.PushLua(item);
                l.rawset(-3);
            }
        }
        public void AddRange(IEnumerable<T> collection)
        {
            var index = 0;
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                foreach (var item in collection)
                {
                    l.pushnumber(cnt + (++index));
                    l.PushLua(item);
                    l.rawset(-3);
                }
            }
        }
        public void Clear()
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.pushnil();
                    l.rawset(-3);
                }
            }
        }
        public bool Contains(T item)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (Equals(val, item))
                    {
                        return true;
                    }
                    l.pop(1);
                }
            }
            return false;
        }
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(index + i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    array[arrayIndex + i] = val;
                    l.pop(1);
                }
            }
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    array[arrayIndex + i] = val;
                    l.pop(1);
                }
            }
        }
        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        public bool Exists(Predicate<T> match)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        return true;
                    }
                    l.pop(1);
                }
            }
            return false;
        }
        public T Find(Predicate<T> match)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        return val;
                    }
                    l.pop(1);
                }
            }
            return default(T);
        }
        public List<T> FindAll(Predicate<T> match)
        {
            List<T> results = new List<T>();
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        results.Add(val);
                    }
                    l.pop(1);
                }
            }
            return results;
        }
        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(startIndex + i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        return startIndex + i;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public int FindIndex(int startIndex, Predicate<T> match)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var count = l.getn(-1) - startIndex;
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(startIndex + i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        return startIndex + i;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public int FindIndex(Predicate<T> match)
        {
            return FindIndex(0, match);
        }
        public T FindLast(Predicate<T> match)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = cnt; i > 0; --i)
                {
                    l.pushnumber(i);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        return val;
                    }
                    l.pop(1);
                }
            }
            return default(T);
        }
        public int FindLastIndex(int startIndex, int count, Predicate<T> match)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(startIndex + 1 - i);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        return startIndex - i;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public int FindLastIndex(int startIndex, Predicate<T> match)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var count = l.getn(-1);
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(startIndex + 1 - i);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        return startIndex - i;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public int FindLastIndex(Predicate<T> match)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = cnt; i > 0; --i)
                {
                    l.pushnumber(i);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        return i - 1;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public void ForEach(Action<T> action)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    l.pop(1);
                    action(val);
                }
            }
        }

        public struct Enumerator : IEnumerator<T>
        {
            private BaseLua Binding;
            private int Index;

            public T Current
            {
                get
                {
                    var l = Binding.L;
                    using (var lr = l.CreateStackRecover())
                    {
                        l.PushLua(Binding);
                        l.pushnumber(Index);
                        l.rawget(-2);
                        return l.GetLua<T>(-1);
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Enumerator(LuaList<T> list)
            {
                Index = 0;
                Binding = list.Binding;
            }

            public void Dispose()
            {
                Index = 0;
                Binding = null;
            }

            public bool MoveNext()
            {
                var index = ++Index;
                if (ReferenceEquals(Binding, null))
                {
                    return false;
                }
                var l = Binding.L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    var cnt = l.getn(-1);
                    return index <= cnt;
                }
            }

            public void Reset()
            {
                Index = 0;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<T> GetRange(int index, int count)
        {
            List<T> results = new List<T>();
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(index + i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    results.Add(val);
                    l.pop(1);
                }
            }
            return results;
        }
        public int IndexOf(T item, int index, int count)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(index + i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (Equals(val, item))
                    {
                        return index + i;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public int IndexOf(T item, int index)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var count = l.getn(-1) - index;
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(index + i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (Equals(val, item))
                    {
                        return index + i;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public int IndexOf(T item)
        {
            return IndexOf(item, 0);
        }
        public void Insert(int index, T item)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = cnt - 1; i >= 0; --i)
                {
                    if (i > index)
                    {
                        l.pushnumber(i + 2);
                        l.pushnumber(i + 1);
                        l.rawget(-3);
                        l.rawset(-3);
                    }
                    else if (i == index)
                    {
                        l.pushnumber(i + 1);
                        l.PushLua(item);
                        l.rawset(-3);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            var list = new List<T>();
            foreach (var item in collection)
            {
                list.Add(item);
            }
            var rangecnt = list.Count;
            if (rangecnt > 0)
            {
                var l = L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    var cnt = l.getn(-1);
                    for (int i = cnt - 1; i >= 0; --i)
                    {
                        if (i > index)
                        {
                            l.pushnumber(i + 1 + rangecnt);
                            l.pushnumber(i + 1);
                            l.rawget(-3);
                            l.rawset(-3);
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = 0; i < rangecnt; ++i)
                    {
                        l.pushnumber(index + 1 + i);
                        l.PushLua(list[i]);
                        l.rawset(-3);
                    }
                }
            }
        }
        public int LastIndexOf(T item)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = cnt; i > 0; --i)
                {
                    l.pushnumber(i);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (Equals(val, item))
                    {
                        return i - 1;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public int LastIndexOf(T item, int index)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var count = l.getn(-1);
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(index + 1 - i);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (Equals(val, item))
                    {
                        return index - i;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public int LastIndexOf(T item, int index, int count)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                for (int i = 0; i < count; ++i)
                {
                    l.pushnumber(index + 1 - i);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (Equals(val, item))
                    {
                        return index - i;
                    }
                    l.pop(1);
                }
            }
            return -1;
        }
        public bool Remove(T item)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    l.pop(1);
                    if (Equals(val, item))
                    {
                        for (i = i + 1; i < cnt; ++i)
                        {
                            l.pushnumber(i);
                            l.pushnumber(i + 1);
                            l.rawget(-3);
                            l.rawset(-3);
                        }
                        l.pushnumber(cnt);
                        l.pushnil();
                        l.rawset(-3);
                        return true;
                    }
                }
            }
            return false;
        }
        public int RemoveAll(Predicate<T> match)
        {
            int removed = 0;
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    if (match(val))
                    {
                        ++removed;
                        l.pop(1);
                    }
                    else if (removed > 0)
                    {
                        l.pushnumber(i + 1 - removed);
                        l.insert(-2);
                        l.rawset(-3);
                        l.pushnumber(i + 1);
                        l.pushnil();
                        l.rawset(-3);
                    }
                    else
                    {
                        l.pop(1);
                    }
                }
            }
            return removed;
        }
        public void RemoveAt(int index)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                if (index < cnt)
                {
                    for (int i = index + 1; i < cnt; ++i)
                    {
                        l.pushnumber(i);
                        l.pushnumber(i + 1);
                        l.rawget(-3);
                        l.rawset(-3);
                    }
                    l.pushnumber(cnt);
                    l.pushnil();
                    l.rawset(-3);
                }
            }
        }
        public void RemoveRange(int index, int count)
        {
            if (count > 0)
            {
                var l = L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    var cnt = l.getn(-1);
                    for (int i = index; i < cnt; ++i)
                    {
                        l.pushnumber(i + 1);
                        l.pushnumber(i + count + 1);
                        l.rawget(-3);
                        l.rawset(-3);
                    }
                }
            }
        }
        public T[] ToArray()
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                T[] result = new T[cnt];
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    result[i] = val;
                    l.pop(1);
                }
                return result;
            }
        }
        public void TrimExcess()
        {
        }
        public bool TrueForAll(Predicate<T> match)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                for (int i = 0; i < cnt; ++i)
                {
                    l.pushnumber(i + 1);
                    l.rawget(-2);
                    var val = l.GetLua<T>(-1);
                    l.pop(1);
                    if (!match(val))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        int IList.Add(object value)
        {
            Add((T)value);
            return Count - 1;
        }
        bool IList.Contains(object value)
        {
            if (value is T)
            {
                return Contains((T)value);
            }
            if (value == null && !typeof(T).IsValueType)
            {
                return Contains((T)value);
            }
            return false;
        }
        int IList.IndexOf(object value)
        {
            if (value is T)
            {
                return IndexOf((T)value);
            }
            if (value == null && !typeof(T).IsValueType)
            {
                return IndexOf((T)value);
            }
            return -1;
        }
        void IList.Insert(int index, object value)
        {
            Insert(index, (T)value);
        }
        void IList.Remove(object value)
        {
            if (value is T)
            {
                Remove((T)value);
            }
            if (value == null && !typeof(T).IsValueType)
            {
                Remove((T)value);
            }
        }
    }

    public class LuaQueue<T> : LuaList<T>
    {
        private static new LuaHub.BaseLuaWrapperHub<LuaQueue<T>> LuaHubSub = new LuaHub.BaseLuaWrapperHub<LuaQueue<T>>();

        public LuaQueue() : base() { }
        public LuaQueue(IntPtr l) : base(l) { }

        public T Dequeue()
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                T item;
                l.pushnumber(1);
                l.rawget(-2);
                l.GetLua(-1, out item);
                l.pop(1);
                var cnt = l.getn(-1);
                for (int i = 1; i < cnt; ++i)
                {
                    l.pushnumber(i);
                    l.pushnumber(i + 1);
                    l.rawget(-3);
                    l.rawset(-3);
                }
                l.pushnumber(cnt);
                l.pushnil();
                l.rawset(-3);
                return item;
            }
        }
        public void Enqueue(T item)
        {
            Add(item);
        }
        public T Peek()
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                T item;
                l.pushnumber(1);
                l.rawget(-2);
                l.GetLua(-1, out item);
                return item;
            }
        }
    }

    public class LuaStack<T> : LuaList<T>
    {
        private static new LuaHub.BaseLuaWrapperHub<LuaStack<T>> LuaHubSub = new LuaHub.BaseLuaWrapperHub<LuaStack<T>>();

        public LuaStack() : base() { }
        public LuaStack(IntPtr l) : base(l) { }

        public T Peek()
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                if (cnt > 0)
                {
                    l.pushnumber(cnt);
                    l.rawget(-2);
                    return l.GetLua<T>(-1);
                }
                else
                {
                    return default(T);
                }
            }
        }
        public T Pop()
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                var cnt = l.getn(-1);
                if (cnt > 0)
                {
                    l.pushnumber(cnt);
                    l.rawget(-2);
                    var item = l.GetLua<T>(-1);
                    l.pop(1);
                    l.pushnumber(cnt);
                    l.pushnil();
                    l.rawset(-3);
                    return item;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public void Push(T item)
        {
            Add(item);
        }
    }

    public class LuaDictionary<TK, TV> : BaseLuaWrapper<LuaDictionary<TK, TV>>, ICollection<KeyValuePair<TK, TV>>, IEnumerable<KeyValuePair<TK, TV>>, IEnumerable, IDictionary<TK, TV>, IReadOnlyCollection<KeyValuePair<TK, TV>>, IReadOnlyDictionary<TK, TV>, ICollection, IDictionary,
        UnityEngineEx.IConvertibleDictionary
    {
        public LuaDictionary() : base() { }
        public LuaDictionary(IntPtr l) : base(l) { }
        public virtual bool IsRaw { get; set; }

        protected static IEqualityComparer<TK> _KeyComparer = EqualityComparer<TK>.Default;
        protected static bool Equals(TK v1, TK v2)
        {
            return _KeyComparer.Equals(v1, v2);
        }
        protected static IEqualityComparer<TV> _ValueComparer = EqualityComparer<TV>.Default;
        protected static bool EqualsValue(TV v1, TV v2)
        {
            return _ValueComparer.Equals(v1, v2);
        }

        protected void GetTable(IntPtr l, int index)
        {
            if (IsRaw)
            {
                l.rawget(index);
            }
            else
            {
                l.gettable(index);
            }
        }
        protected void SetTable(IntPtr l, int index)
        {
            if (IsRaw)
            {
                l.rawset(index);
            }
            else
            {
                l.settable(index);
            }
        }
        protected void GetTable(int index)
        {
            GetTable(L, index);
        }
        protected void SetTable(int index)
        {
            SetTable(L, index);
        }

        public TV this[TK key]
        {
            get
            {
                var l = L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    TV item;
                    l.PushLua(key);
                    GetTable(l, -2);
                    l.GetLua(-1, out item);
                    return item;
                }
            }
            set
            {
                var l = L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    l.PushLua(key);
                    l.PushLua(value);
                    SetTable(l, -3);
                }
            }
        }
        public int Count
        {
            get
            {
                int count = 0;
                var l = L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    l.pushnil();
                    while (l.next(-2))
                    {
                        ++count;
                        l.pop(1);
                    }
                }
                return count;
            }
        }
        public void Add(TK key, TV value)
        {
            this[key] = value;
        }
        public void Clear()
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                l.pushnil();
                while (l.next(-2))
                {
                    l.pop(1);
                    l.pushvalue(-1);
                    l.pushnil();
                    l.rawset(-4);
                }
            }
        }
        public bool ContainsKey(TK key)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                l.PushLua(key);
                GetTable(l, -2);
                return !l.isnoneornil(-1);
            }
        }
        public bool Remove(TK key)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                l.PushLua(key);
                l.pushvalue(-1);
                GetTable(l, -3);
                var exist = !l.isnoneornil(-1);
                l.pop(1);
                l.pushnil();
                SetTable(l, -3);
                return exist;
            }
        }
        public bool TryGetValue(TK key, out TV value)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                l.PushLua(key);
                GetTable(l, -2);
                var exist = !l.isnoneornil(-1);
                if (exist)
                {
                    l.GetLua(-1, out value);
                }
                else
                {
                    value = default(TV);
                }
                return exist;
            }
        }
        public bool ContainsValue(TV value)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                l.pushnil();
                while (l.next(-2))
                {
                    var item = l.GetLua<TV>(-1);
                    if (EqualsValue(item, value))
                    {
                        return true;
                    }
                    l.pop(1);
                }
            }
            return false;
        }

        public void CopyTo(Array array, int arrayIndex)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                int count = 0;
                l.PushLua(Binding);
                l.pushnil();
                while (l.next(-2))
                {
                    var val = l.GetLua<TV>(-1);
                    l.pushvalue(-2);
                    var key = l.GetLua<TK>(-1);
                    array.SetValue(new KeyValuePair<TK, TV>(key, val), arrayIndex + count);
                    l.pop(2);
                    ++count;
                }
            }
        }
        public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                int count = 0;
                l.PushLua(Binding);
                l.pushnil();
                while (l.next(-2))
                {
                    var val = l.GetLua<TV>(-1);
                    l.pushvalue(-2);
                    var key = l.GetLua<TK>(-1);
                    array[arrayIndex + count] = new KeyValuePair<TK, TV>(key, val);
                    l.pop(2);
                    ++count;
                }
            }
        }
        public void Add(KeyValuePair<TK, TV> item)
        {
            Add(item.Key, item.Value);
        }
        public bool Contains(KeyValuePair<TK, TV> item)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                l.PushLua(item.Key);
                GetTable(l, -2);
                var existing = l.GetLua<TV>(-1);
                if (EqualsValue(existing, item.Value))
                {
                    return true;
                }
                return false;
            }
        }
        public bool Remove(KeyValuePair<TK, TV> item)
        {
            var l = L;
            using (var lr = l.CreateStackRecover())
            {
                l.PushLua(Binding);
                l.PushLua(item.Key);
                l.pushvalue(-1);
                GetTable(l, -3);
                var existing = l.GetLua<TV>(-1);
                if (EqualsValue(existing, item.Value))
                {
                    l.pop(1);
                    l.pushnil();
                    SetTable(l, -3);
                    return true;
                }
                return false;
            }
        }

        public struct Enumerator : IEnumerator<KeyValuePair<TK, TV>>, IEnumerator, IDisposable, IDictionaryEnumerator
        {
            private BaseLua Binding;
            private object CurrentKey;

            public Enumerator(LuaDictionary<TK, TV> thiz)
            {
                CurrentKey = null;
                Binding = thiz.Binding;
            }

            public KeyValuePair<TK, TV> Current { get; private set; }

            object IEnumerator.Current { get { return Current; } }

            DictionaryEntry IDictionaryEnumerator.Entry { get { return new DictionaryEntry(Current.Key, Current.Value); } }

            object IDictionaryEnumerator.Key { get { return Current.Key; } }

            object IDictionaryEnumerator.Value { get { return Current.Value; } }

            public void Dispose()
            {
                Current = default(KeyValuePair<TK, TV>);
                CurrentKey = null;
                Binding = null;
            }
            public bool MoveNext()
            {
                var l = Binding.L;
                using (var lr = l.CreateStackRecover())
                {
                    l.PushLua(Binding);
                    l.PushLua(CurrentKey);
                    var success = l.next(-2);
                    if (success)
                    {
                        var val = l.GetLua<TV>(-1);
                        l.pushvalue(-2);
                        var key = l.GetLua<TK>(-1);
                        Current = new KeyValuePair<TK, TV>(key, val);
                        CurrentKey = l.GetLua(-3);
                    }
                    else
                    {
                        Current = default(KeyValuePair<TK, TV>);
                        //CurrentKey = null;
                    }
                    return success;
                }
            }
            public void Reset()
            {
                Current = default(KeyValuePair<TK, TV>);
                CurrentKey = null;
            }
        }
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        IEnumerator<KeyValuePair<TK, TV>> IEnumerable<KeyValuePair<TK, TV>>.GetEnumerator()
        {
            return GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return GetEnumerator();
        }

        public KeyCollection Keys { get { return new KeyCollection(this); } }
        public ValueCollection Values { get { return new ValueCollection(this); } }
        ICollection<TK> IDictionary<TK, TV>.Keys { get { return Keys; } }
        ICollection<TV> IDictionary<TK, TV>.Values { get { return Values; } }
        IEnumerable<TK> IReadOnlyDictionary<TK, TV>.Keys { get { return Keys; } }
        IEnumerable<TV> IReadOnlyDictionary<TK, TV>.Values { get { return Values; } }
        ICollection IDictionary.Keys { get { return Keys; } }
        ICollection IDictionary.Values { get { return Values; } }
        public struct KeyCollection : ICollection<TK>, IEnumerable<TK>, IEnumerable, IReadOnlyCollection<TK>, ICollection
        {
            private LuaDictionary<TK, TV> Parent;
            public KeyCollection(LuaDictionary<TK, TV> thiz)
            {
                Parent = thiz;
            }
            public int Count { get { return Parent.Count; } }
            public void CopyTo(TK[] array, int index)
            {
                var l = Parent.L;
                using (var lr = l.CreateStackRecover())
                {
                    int count = 0;
                    l.PushLua(Parent.Binding);
                    l.pushnil();
                    while (l.next(-2))
                    {
                        l.pushvalue(-2);
                        var key = l.GetLua<TK>(-1);
                        array[index + count] = key;
                        l.pop(2);
                        ++count;
                    }
                }
            }
            public bool Contains(TK key)
            {
                return Parent.ContainsKey(key);
            }
            public bool IsReadOnly { get { return true; } }

            public Enumerator GetEnumerator()
            {
                return new Enumerator(Parent.GetEnumerator());
            }
            IEnumerator<TK> IEnumerable<TK>.GetEnumerator()
            {
                return GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public struct Enumerator : IEnumerator<TK>, IEnumerator, IDisposable
            {
                private LuaDictionary<TK, TV>.Enumerator Parent;
                public Enumerator(LuaDictionary<TK, TV>.Enumerator parent)
                {
                    Parent = parent;
                }
                public TK Current { get { return Parent.Current.Key; } }
                object IEnumerator.Current { get { return Current; } }

                public void Dispose()
                {
                    Parent.Dispose();
                }
                public bool MoveNext()
                {
                    return Parent.MoveNext();
                }
                public void Reset()
                {
                    Parent.Reset();
                }
            }

            void ICollection<TK>.Add(TK item)
            {
                throw new NotSupportedException();
            }
            void ICollection<TK>.Clear()
            {
                throw new NotSupportedException();
            }
            bool ICollection<TK>.Remove(TK item)
            {
                throw new NotSupportedException();
            }
            public bool IsSynchronized { get { return false; } }
            public object SyncRoot { get { return LuaHubSub; } }
            public void CopyTo(Array array, int index)
            {
                var l = Parent.L;
                using (var lr = l.CreateStackRecover())
                {
                    int count = 0;
                    l.PushLua(Parent.Binding);
                    l.pushnil();
                    while (l.next(-2))
                    {
                        l.pushvalue(-2);
                        var key = l.GetLua<TK>(-1);
                        array.SetValue(key, index + count);
                        l.pop(2);
                        ++count;
                    }
                }
            }
        }
        public sealed class ValueCollection : ICollection<TV>, IEnumerable<TV>, IEnumerable, IReadOnlyCollection<TV>, ICollection
        {
            private LuaDictionary<TK, TV> Parent;
            public ValueCollection(LuaDictionary<TK, TV> thiz)
            {
                Parent = thiz;
            }
            public int Count { get { return Parent.Count; } }
            public void CopyTo(TV[] array, int index)
            {
                var l = Parent.L;
                using (var lr = l.CreateStackRecover())
                {
                    int count = 0;
                    l.PushLua(Parent.Binding);
                    l.pushnil();
                    while (l.next(-2))
                    {
                        var val = l.GetLua<TV>(-1);
                        array[index + count] = val;
                        l.pop(1);
                        ++count;
                    }
                }
            }
            public bool Contains(TV val)
            {
                return Parent.ContainsValue(val);
            }
            public bool IsReadOnly { get { return true; } }

            public Enumerator GetEnumerator()
            {
                return new Enumerator(Parent.GetEnumerator());
            }
            IEnumerator<TV> IEnumerable<TV>.GetEnumerator()
            {
                return GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public struct Enumerator : IEnumerator<TV>, IEnumerator, IDisposable
            {
                private LuaDictionary<TK, TV>.Enumerator Parent;
                public Enumerator(LuaDictionary<TK, TV>.Enumerator parent)
                {
                    Parent = parent;
                }
                public TV Current { get { return Parent.Current.Value; } }
                object IEnumerator.Current { get { return Current; } }

                public void Dispose()
                {
                    Parent.Dispose();
                }
                public bool MoveNext()
                {
                    return Parent.MoveNext();
                }
                public void Reset()
                {
                    Parent.Reset();
                }
            }

            void ICollection<TV>.Add(TV item)
            {
                throw new NotSupportedException();
            }
            void ICollection<TV>.Clear()
            {
                throw new NotSupportedException();
            }
            bool ICollection<TV>.Remove(TV item)
            {
                throw new NotSupportedException();
            }
            public bool IsSynchronized { get { return false; } }
            public object SyncRoot { get { return LuaHubSub; } }
            public void CopyTo(Array array, int index)
            {
                var l = Parent.L;
                using (var lr = l.CreateStackRecover())
                {
                    int count = 0;
                    l.PushLua(Parent.Binding);
                    l.pushnil();
                    while (l.next(-2))
                    {
                        var val = l.GetLua<TV>(-1);
                        array.SetValue(val, index + count);
                        l.pop(1);
                        ++count;
                    }
                }
            }
        }

        public bool IsSynchronized { get { return false; } }
        public object SyncRoot { get { return LuaHubSub; } }
        public bool IsReadOnly { get { return false; } }
        public bool IsFixedSize { get { return false; } }

        void IDictionary.Add(object key, object value)
        {
            Add((TK)key, (TV)value);
        }
        bool IDictionary.Contains(object key)
        {
            if (key is TK)
            {
                return ContainsKey((TK)key);
            }
            if (key == null && !typeof(TK).IsValueType)
            {
                return ContainsKey((TK)key);
            }
            return false;
        }
        void IDictionary.Remove(object key)
        {
            if (key is TK)
            {
                Remove((TK)key);
            }
        }
        object IDictionary.this[object key]
        {
            get { return this[(TK)key]; }
            set { this[(TK)key] = (TV)value; }
        }
    }
}

#if UNITY_EDITOR
#if UNITY_INCLUDE_TESTS
#region TESTS
namespace Capstones.Test
{
    using Capstones.UnityEngineEx;

    public static class TestLuaCollections
    {
        [UnityEditor.MenuItem("Test/Lua/Test Collections", priority = 300030)]
        public static void Test()
        {
            var l = GlobalLua.L.L;
            using (var lr = l.CreateStackRecover())
            {
                var ll = new LuaList<int>(l);
                for (int i = 0; i < 10; ++i)
                {
                    ll.Add(i);
                }

                ll.RemoveRange(3, 2);
                l.CallGlobal("dumpraw", Pack(ll));

                l.newtable();
                LuaQueue<int> lq;
                l.GetLua(-1, out lq);
                for (int i = 0; i < 10; ++i)
                {
                    lq.Enqueue(i);
                }
                PlatDependant.LogInfo(lq.Dequeue());
                PlatDependant.LogInfo(lq.Dequeue());
                l.CallGlobal("dumpraw", Pack(lq));
                l.pop(1);

                l.newtable();
                LuaStack<int> ls = l.GetLuaOnStack(-1).GetWrapper<LuaStack<int>>();
                for (int i = 0; i < 10; ++i)
                {
                    ls.Push(i);
                }
                PlatDependant.LogInfo(ls.Pop());
                PlatDependant.LogInfo(ls.Pop());
                l.CallGlobal("dumpraw", Pack(ls));
                l.pop(1);

                var ld = new LuaDictionary<string, int>(l);
                for (int i = 0; i < 10; ++i)
                {
                    ld["s" + i] = i;
                }
                PlatDependant.LogInfo(ld["s3"]);
                PlatDependant.LogInfo(ld.Remove("s3"));
                int s4;
                PlatDependant.LogInfo(ld.TryGetValue("s4", out s4));
                PlatDependant.LogInfo(s4);

                PlatDependant.LogInfo(ld.Get<GCCollectionMode>("s0"));
                l.CallGlobal("dumpraw", Pack(ld));
            }
        }
    }
}
#endregion
#endif
#endif
