using System;
using System.Collections;
using System.Collections.Generic;
using Capstones.LuaLib;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;
using Capstones.LuaWrap;

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
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r);
            return r;
        }
        public R Call<R, P0>(P0 p0)
        {
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r, p0);
            return r;
        }
        public R Call<R, P0, P1>(P0 p0, P1 p1)
        {
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r, p0, p1);
            return r;
        }
        public R Call<R, P0, P1, P2>(P0 p0, P1 p1, P2 p2)
        {
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r, p0, p1, p2);
            return r;
        }
        public R Call<R, P0, P1, P2, P3>(P0 p0, P1 p1, P2 p2, P3 p3)
        {
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r, p0, p1, p2, p3);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r, p0, p1, p2, p3, p4);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5, P6>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5, P6, P7>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            var l = L;
            l.getref(Refid);
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7, p8);
            return r;
        }
        public R Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            var l = L;
            l.getref(Refid);
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
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r);
            return r;
        }
        public new R Call<R, P0>(P0 p0)
        {
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r, p0);
            return r;
        }
        public new R Call<R, P0, P1>(P0 p0, P1 p1)
        {
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r, p0, p1);
            return r;
        }
        public new R Call<R, P0, P1, P2>(P0 p0, P1 p1, P2 p2)
        {
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r, p0, p1, p2);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3>(P0 p0, P1 p1, P2 p2, P3 p3)
        {
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r, p0, p1, p2, p3);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r, p0, p1, p2, p3, p4);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5, P6>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5, P6, P7>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            var l = L;
            l.pushvalue(StackPos);
            R r;
            Call(out r, p0, p1, p2, p3, p4, p5, p6, p7, p8);
            return r;
        }
        public new R Call<R, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            var l = L;
            l.pushvalue(StackPos);
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