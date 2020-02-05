using System;
using System.Collections.Generic;
using System.Reflection;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public interface ILuaNative
    {
        void Wrap(IntPtr l, int index);
        void Unwrap(IntPtr l, int index);
    }

    public static partial class LuaHub
    {
        private abstract class LuaPushNative
        {
            public static Dictionary<Type, object> _NativePushLuaFuncs = new Dictionary<Type, object>();
        }
        private abstract class LuaPushNativeBase<T> : LuaPushNative, ILuaPush<T>, ILuaTrans<T>
        {
            public LuaPushNativeBase()
            {
                _NativePushLuaFuncs[typeof(T)] = this;
            }

            public void SetData(IntPtr l, int index, T val)
            {
                // no meaning.
            }
            public abstract T GetLua(IntPtr l, int index);
            public abstract IntPtr PushLua(IntPtr l, T val);

        }
        private class LuaPushNative_bool : LuaPushNativeBase<bool>
        {
            public override bool GetLua(IntPtr l, int index)
            {
                return l.toboolean(index);
            }
            public override IntPtr PushLua(IntPtr l, bool val)
            {
                l.pushboolean(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_bool ___tpn_bool = new LuaPushNative_bool();
        private class LuaPushNative_byte : LuaPushNativeBase<byte>
        {
            public override byte GetLua(IntPtr l, int index)
            {
                return (byte)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, byte val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_byte ___tpn_byte = new LuaPushNative_byte();
        private class LuaPushNative_bytes : LuaPushNativeBase<byte[]>
        {
            public override byte[] GetLua(IntPtr l, int index)
            {
                return l.tolstring(index);
            }
            public override IntPtr PushLua(IntPtr l, byte[] val)
            {
                //if (val == null)
                //    l.pushnil();
                //else
                    l.pushbuffer(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_bytes ___tpn_bytes = new LuaPushNative_bytes();
        private class LuaPushNative_char : LuaPushNativeBase<char>
        {
            public override char GetLua(IntPtr l, int index)
            {
                return (char)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, char val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_char ___tpn_char = new LuaPushNative_char();
        private class LuaPushNative_decimal : LuaPushNativeBase<decimal>
        {
            public override decimal GetLua(IntPtr l, int index)
            {
                return (decimal)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, decimal val)
            {
                l.pushnumber((double)val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_decimal ___tpn_decimal = new LuaPushNative_decimal();
        private class LuaPushNative_double : LuaPushNativeBase<double>
        {
            public override double GetLua(IntPtr l, int index)
            {
                return l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, double val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_double ___tpn_double = new LuaPushNative_double();
        private class LuaPushNative_float : LuaPushNativeBase<float>
        {
            public override float GetLua(IntPtr l, int index)
            {
                return (float)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, float val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_float ___tpn_float = new LuaPushNative_float();
        private class LuaPushNative_int : LuaPushNativeBase<int>
        {
            public override int GetLua(IntPtr l, int index)
            {
                return (int)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, int val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_int ___tpn_int = new LuaPushNative_int();
        private class LuaPushNative_IntPtr : LuaPushNativeBase<IntPtr>
        {
            public override IntPtr GetLua(IntPtr l, int index)
            {
                return l.touserdata(index);
            }
            public override IntPtr PushLua(IntPtr l, IntPtr val)
            {
                l.pushlightuserdata(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_IntPtr ___tpn_IntPtr = new LuaPushNative_IntPtr();
        private class LuaPushNative_long : LuaPushNativeBase<long>
        {
            public override long GetLua(IntPtr l, int index)
            {
                return (long)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, long val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_long ___tpn_long = new LuaPushNative_long();
        private class LuaPushNative_sbyte : LuaPushNativeBase<sbyte>
        {
            public override sbyte GetLua(IntPtr l, int index)
            {
                return (sbyte)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, sbyte val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_sbyte ___tpn_sbyte = new LuaPushNative_sbyte();
        private class LuaPushNative_short : LuaPushNativeBase<short>
        {
            public override short GetLua(IntPtr l, int index)
            {
                return (short)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, short val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_short ___tpn_short = new LuaPushNative_short();
        private class LuaPushNative_string : LuaPushNativeBase<string>
        {
            public override string GetLua(IntPtr l, int index)
            {
                return l.GetString(index);
            }
            public override IntPtr PushLua(IntPtr l, string val)
            {
                //if (val == null)
                //    l.pushnil();
                //else
                    l.PushString(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_string ___tpn_string = new LuaPushNative_string();
        private class LuaPushNative_uint : LuaPushNativeBase<uint>
        {
            public override uint GetLua(IntPtr l, int index)
            {
                return (uint)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, uint val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_uint ___tpn_uint = new LuaPushNative_uint();
        private class LuaPushNative_ulong : LuaPushNativeBase<ulong>
        {
            public override ulong GetLua(IntPtr l, int index)
            {
                return (ulong)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, ulong val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_ulong ___tpn_ulong = new LuaPushNative_ulong();
        private class LuaPushNative_ushort : LuaPushNativeBase<ushort>
        {
            public override ushort GetLua(IntPtr l, int index)
            {
                return (ushort)l.tonumber(index);
            }
            public override IntPtr PushLua(IntPtr l, ushort val)
            {
                l.pushnumber(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_ushort ___tpn_ushort = new LuaPushNative_ushort();
        private class LuaPushNative_Type : LuaPushNativeBase<Type>
        {
            public override Type GetLua(IntPtr l, int index)
            {
                return l.GetLua(index) as Type;
            }
            public override IntPtr PushLua(IntPtr l, Type val)
            {
                //if (val == null)
                //    l.pushnil();
                //else
                    l.PushLuaType(val);
                return IntPtr.Zero;
            }
        }
        private static LuaPushNative_Type ___tpn_Type = new LuaPushNative_Type();
    }
}