using System;

using Capstones.LuaExt;
using Capstones.LuaLib;
using Capstones.LuaWrap;
using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public struct LuaStackPos
    {
        //private IntPtr _L;
        //public IntPtr L
        //{
        //    get { return _L; }
        //    internal set { _L = value; }
        //}
        private int _Pos;
        public int Pos
        {
            get { return _Pos; }
            internal set { _Pos = value; }
        }
    }

    public static partial class LuaHub
    {
        public static LuaStackPos OnStack(this IntPtr l, int pos)
        {
            return new LuaStackPos() { Pos = l.NormalizeIndex(pos) };
        }

        public static void PushLua(this IntPtr l, LuaStackPos val)
        {
            l.pushvalue(val.Pos);
        }
        public static void GetLua(this IntPtr l, int pos, out LuaStackPos val)
        {
            val = l.OnStack(pos);
        }

        private class LuaPushNative_LuaStackPos : LuaPushNativeBase<LuaStackPos>
        {
            public override LuaStackPos GetLua(IntPtr l, int index)
            {
                return l.OnStack(index);
            }
            public override IntPtr PushLua(IntPtr l, LuaStackPos val)
            {
                l.pushvalue(val.Pos);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_LuaStackPos ___tpn_LuaStackPos = new LuaPushNative_LuaStackPos();
    }
}