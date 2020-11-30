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
            if (type == typeof(bool))
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
            DynamicHelper.LogInfo("__convert(" + type.ToString() + ") meta-method Not Implemented.");
            return null;
        }

        public void Call()
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l);
        }
        public void Call<P0>(P0 p0)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0);
        }
        public void Call<P0, P1>(P0 p0, P1 p1)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1);
        }
        public void Call<P0, P1, P2>(P0 p0, P1 p1, P2 p2)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2);
        }
        public void Call<P0, P1, P2, P3>(P0 p0, P1 p1, P2 p2, P3 p3)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3);
        }
        public void Call<P0, P1, P2, P3, P4>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4);
        }
        public void Call<P0, P1, P2, P3, P4, P5>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5);
        }
        public void Call<P0, P1, P2, P3, P4, P5, P6>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6);
        }
        public void Call<P0, P1, P2, P3, P4, P5, P6, P7>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6, p7);
        }
        public void Call<P0, P1, P2, P3, P4, P5, P6, P7, P8>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6, p7, p8);
        }
        public void Call<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            var l = L;
            l.getref(Refid);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
        }
        public bool Call<R>(out R r)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r);
        }
        public bool Call<R, P0>(out R r, P0 p0)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0);
        }
        public bool Call<R, P0, P1>(out R r, P0 p0, P1 p1)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1);
        }
        public bool Call<R, P0, P1, P2>(out R r, P0 p0, P1 p1, P2 p2)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2);
        }
        public bool Call<R, P0, P1, P2, P3>(out R r, P0 p0, P1 p1, P2 p2, P3 p3)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3);
        }
        public bool Call<R, P0, P1, P2, P3, P4>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5, P6>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5, P6, P7>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6, p7);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            var l = L;
            l.getref(Refid);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6, p7, p8);
        }
        public bool Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            var l = L;
            l.getref(Refid);
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
            DynamicHelper.LogInfo("__convert(" + type.ToString() + ") meta-method Not Implemented.");
            return null;
        }

        public new void Call()
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l);
        }
        public new void Call<P0>(P0 p0)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0);
        }
        public new void Call<P0, P1>(P0 p0, P1 p1)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1);
        }
        public new void Call<P0, P1, P2>(P0 p0, P1 p1, P2 p2)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2);
        }
        public new void Call<P0, P1, P2, P3>(P0 p0, P1 p1, P2 p2, P3 p3)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3);
        }
        public new void Call<P0, P1, P2, P3, P4>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4);
        }
        public new void Call<P0, P1, P2, P3, P4, P5>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5);
        }
        public new void Call<P0, P1, P2, P3, P4, P5, P6>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6);
        }
        public new void Call<P0, P1, P2, P3, P4, P5, P6, P7>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6, p7);
        }
        public new void Call<P0, P1, P2, P3, P4, P5, P6, P7, P8>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6, p7, p8);
        }
        public new void Call<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            var l = L;
            l.pushvalue(StackPos);
            LuaFuncHelper.PushArgsAndCall(l, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
        }
        public new bool Call<R>(out R r)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r);
        }
        public new bool Call<R, P0>(out R r, P0 p0)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0);
        }
        public new bool Call<R, P0, P1>(out R r, P0 p0, P1 p1)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1);
        }
        public new bool Call<R, P0, P1, P2>(out R r, P0 p0, P1 p1, P2 p2)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2);
        }
        public new bool Call<R, P0, P1, P2, P3>(out R r, P0 p0, P1 p1, P2 p2, P3 p3)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3);
        }
        public new bool Call<R, P0, P1, P2, P3, P4>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4);
        }
        public new bool Call<R, P0, P1, P2, P3, P4, P5>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5);
        }
        public new bool Call<R, P0, P1, P2, P3, P4, P5, P6>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6);
        }
        public new bool Call<R, P0, P1, P2, P3, P4, P5, P6, P7>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6, p7);
        }
        public new bool Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6, p7, p8);
        }
        public new bool Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            var l = L;
            l.pushvalue(StackPos);
            return LuaFuncHelper.PushArgsAndCall(l, out r, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
        }
        public new R Call<R>()
        {
            R r;
            Call(out r);
            return r;
        }
        public new R Call<R, P0>(P0 p0)
        {
            R r;
            Call(out r, p0);
            return r;
        }
        public new R Call<R, P0, P1>(P0 p0, P1 p1)
        {
            R r;
            Call(out r, p0, p1);
            return r;
        }
        public new R Call<R, P0, P1, P2>(P0 p0, P1 p1, P2 p2)
        {
            R r;
            Call(out r, p0, p1, p2);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3>(P0 p0, P1 p1, P2 p2, P3 p3)
        {
            R r;
            Call(out r, p0, p1, p2, p3);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5, P6>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5, P6, P7>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7, p8);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
            return r;
        }
    }
}

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public static void PushLua(this IntPtr l, LuaWrap.BaseLuaOnStack val)
        {
            l.pushvalue(val.StackPos);
        }
        public static void PushLua(this IntPtr l, LuaWrap.BaseLua val)
        {
            l.getref(val.Refid);
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
    }
}

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class BaseLuaWrapperHub<T> : LuaTypeHub.TypeHubValueType, ILuaTrans<T>, ILuaPush<T>
            where T : ILuaWrapper, new()
        {
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
                var current = (l.GetLuaRawObject(-1) as WeakReference).GetWeakReference<T>();
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
                    l.pushlightuserdata(LuaConst.LRKEY_TARGET); // ud meta #tar
                    l.PushLuaRawObject(new WeakReference(val)); // ud meta #tar tar
                    l.rawset(-3); // ud meta
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
                    var current = (l.GetLuaRawObject(-1) as WeakReference).GetWeakReference<T>();
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
                            l.pushlightuserdata(LuaConst.LRKEY_TARGET); // ud meta #tar
                            l.PushLuaRawObject(new WeakReference(val)); // ud meta #tar tar
                            l.rawset(-3); // ud meta
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
    //public class LuaList<T> : BaseLuaWrapper, ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
    //{
    //    private static LuaHub.BaseLuaWrapperHub<LuaList<T>> LuaHubSub = new LuaHub.BaseLuaWrapperHub<LuaList<T>>();

    //    public bool IsSynchronized { get { return false; } }

    //    public object SyncRoot { get { return null; } }

    //    public void CopyTo(Array array, int index)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public T this[int index] { get; set; }

    //    public int Count
    //    {
    //        get
    //        {
    //            var l = Binding.L;
    //            l.refer(Binding.Refid);
    //            var cnt = l.getn(-1);
    //            l.pop(1);
    //            return cnt;
    //        }
    //    }

    //    public int Capacity { get { return int.MaxValue; } }

    //    public bool IsReadOnly => throw new NotImplementedException();

    //    public bool IsFixedSize => throw new NotImplementedException();

    //    object IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public void Add(T item);
    //    public void AddRange(IEnumerable<T> collection);
    //    public ReadOnlyCollection<T> AsReadOnly();
    //    public int BinarySearch(T item);
    //    public int BinarySearch(T item, IComparer<T> comparer);
    //    public int BinarySearch(int index, int count, T item, IComparer<T> comparer);
    //    public void Clear();
    //    public bool Contains(T item);
    //    public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter);
    //    public void CopyTo(int index, T[] array, int arrayIndex, int count);
    //    public void CopyTo(T[] array, int arrayIndex);
    //    public void CopyTo(T[] array);
    //    public bool Exists(Predicate<T> match);
    //    public T Find(Predicate<T> match);
    //    public List<T> FindAll(Predicate<T> match);
    //    public int FindIndex(int startIndex, int count, Predicate<T> match);
    //    public int FindIndex(int startIndex, Predicate<T> match);
    //    public int FindIndex(Predicate<T> match);
    //    public T FindLast(Predicate<T> match);
    //    public int FindLastIndex(int startIndex, int count, Predicate<T> match);
    //    public int FindLastIndex(int startIndex, Predicate<T> match);
    //    public int FindLastIndex(Predicate<T> match);
    //    public void ForEach(Action<T> action);
    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public List<T> GetRange(int index, int count);
    //    public int IndexOf(T item, int index, int count);
    //    public int IndexOf(T item, int index);
    //    public int IndexOf(T item);
    //    public void Insert(int index, T item);
    //    public void InsertRange(int index, IEnumerable<T> collection);
    //    public int LastIndexOf(T item);
    //    public int LastIndexOf(T item, int index);
    //    public int LastIndexOf(T item, int index, int count);
    //    public bool Remove(T item);
    //    public int RemoveAll(Predicate<T> match);
    //    public void RemoveAt(int index);
    //    public void RemoveRange(int index, int count);
    //    public void Reverse(int index, int count);
    //    public void Reverse();
    //    public void Sort(Comparison<T> comparison);
    //    public void Sort(int index, int count, IComparer<T> comparer);
    //    public void Sort();
    //    public void Sort(IComparer<T> comparer);
    //    public T[] ToArray();
    //    public void TrimExcess();
    //    public bool TrueForAll(Predicate<T> match);

    //    public int Add(object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Contains(object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int IndexOf(object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Insert(int index, object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Remove(object value)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class LuaQueue<T> : LuaList<T>
    //{
    //    private static LuaHub.BaseLuaWrapperHub<LuaQueue<T>> LuaHubSub = new LuaHub.BaseLuaWrapperHub<LuaQueue<T>>();



    //    public T Dequeue()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public void Enqueue(T item)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public T Peek()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}