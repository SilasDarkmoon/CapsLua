using System;
using System.Collections.Generic;
using Capstones.UnityEngineEx;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public interface ILuaHandle
    {
        IntPtr r { get; }
    }
    public interface ILuaTypeRef : ILuaHandle
    {
        Type t { get; }
    }

    public interface ILuaTrans
    {
        void SetData(IntPtr l, int index, object val);
        object GetLua(IntPtr l, int index);
        Type GetType(IntPtr l, int index);
        bool Nonexclusive { get; } // for GetLua<T>. Can the lua-table be converted to C# objects of different types?
    }
    public interface ILuaTrans<T>
    {
        void SetData(IntPtr l, int index, T val);
        T GetLua(IntPtr l, int index);
    }
    public interface ILuaTransMulti
    {
        void SetData<T>(IntPtr l, int index, T val);
        T GetLua<T>(IntPtr l, int index);
    }
    public interface ILuaPush
    {
        IntPtr PushLua(IntPtr l, object val);
        bool ShouldCache { get; }
        bool PushFromCache(IntPtr l, object val);
    }
    public interface ILuaPush<T>
    {
        IntPtr PushLua(IntPtr l, T val);
    }
    public interface ILuaTypeHub : ILuaHandle, ILuaTypeRef, ILuaTrans, ILuaPush
    {
        void PushLuaTypeRaw(IntPtr l);
    }

    public interface ILuaMetaCall : ILuaHandle
    {
        void call(IntPtr l, object tar);
    }
    public interface ILuaMetaGC : ILuaHandle
    {
        void gc(IntPtr l, object obj);
    }
    public interface ILuaMetaIndex : ILuaHandle
    {
        void index(IntPtr l, object tar, int kindex);
    }
    public interface ILuaMetaNewIndex : ILuaHandle
    {
        void newindex(IntPtr l, object tar, int kindex, int valindex);
    }
    public interface ILuaMeta : ILuaMetaCall, ILuaMetaGC, ILuaMetaIndex, ILuaMetaNewIndex
    {
    }

    public delegate int LuaConvertFunc(IntPtr l, int index);
    public interface ILuaConvert
    {
        LuaConvertFunc GetConverter(Type totype);
    }

    public abstract class SelfHandled : ILuaHandle
    {
        protected IntPtr _r;
        public IntPtr r
        {
            get { return _r; }
        }

        protected internal SelfHandled()
        {
            _r = (IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(this);
        }
    }

    public struct LuaStateRecover : IDisposable
    {
        private IntPtr _l;
        private int _top;

        public int Top
        {
            get { return _top; }
        }

        public LuaStateRecover(IntPtr l)
        {
            _l = l;
            _top = l.gettop(); // this is dangerous, but the user should call it with available "l".
        }

        public void Dispose()
        {
            int top = _l.gettop();
            if (top < _top)
            {
                _l.LogWarning("lua stack top is lower than the prev top, there may be some mistake!");
            }
            else
            {
                _l.settop(_top);
            }
        }
    }

    public static partial class LuaHub
    {
        private static HashSet<Type> NumericTypes = new HashSet<Type>()
        {
            typeof(bool),
            typeof(byte),
            typeof(decimal),
            typeof(double),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(sbyte),
            typeof(float),
            typeof(ushort),
            typeof(uint),
            typeof(ulong),
        };
        private static HashSet<Type> ConvertibleTypes = new HashSet<Type>()
        {
            typeof(bool),
            typeof(byte),
            typeof(decimal),
            typeof(double),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(sbyte),
            typeof(float),
            typeof(ushort),
            typeof(uint),
            typeof(ulong),

            typeof(char),
            typeof(string),
            typeof(IntPtr),
        };

        public static bool IsNumeric(Type t)
        {
            return NumericTypes.Contains(t);
        }
        public static bool IsNumeric(object val)
        {
            return val != null && IsNumeric(val.GetType());
        }
        public static bool IsConvertible(Type t)
        {
            return ConvertibleTypes.Contains(t) || t.IsEnum();
        }
        public static bool IsConvertible(object val)
        {
            return val != null && IsConvertible(val.GetType());
        }
        public static bool CanConvertRaw(Type curtype, Type totype)
        {
            if (totype == null)
            {
                if (curtype == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (curtype == null)
            {
                if (totype.IsValueType())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            if (totype.IsAssignableFrom(curtype))
            {
                return true;
            }
            if (IsConvertible(curtype) && IsConvertible(totype))
            {
                return true;
            }
            if (curtype.IsSubclassOf(typeof(BaseDynamic)) && totype.IsSubclassOf(typeof(Delegate)))
            {
                return true;
            }
            return false;
        }
        public static object ConvertTypeRaw(this object obj, Type type)
        {
            if (type == null)
                return null;
            if (obj == null)
                return null;
            if (obj is LuaWrap.BaseLua && type.IsSubclassOf(typeof(Delegate)))
            {
                return Capstones.LuaLib.CapsLuaDelegateGenerator.CreateDelegate(type, obj as LuaWrap.BaseLua);
            }
            if (type.IsAssignableFrom(obj.GetType()))
                return obj;
            if (type.IsEnum())
            {
                if (obj is string)
                {
                    return Enum.Parse(type, obj as string);
                }
                else if (IsNumeric(obj))
                {
                    return Enum.ToObject(type, (object)Convert.ToUInt64(obj));
                }
                else
                {
                    return Enum.ToObject(type, 0UL);
                }
            }
            else if (obj is Enum)
            {
                if (type == typeof(string))
                {
                    return obj.ToString();
                }
                else if (IsNumeric(type))
                {
                    return Convert.ChangeType(Convert.ToUInt64(obj), type);
                }
                else
                {
                    return Convert.ChangeType(0, type);
                }
            }
            else if (IsNumeric(type) && IsNumeric(obj))
            {
                try
                {
                    return Convert.ChangeType(obj, type);
                }
                catch
                {
                    return null;
                }
            }
            else if (type == typeof(IntPtr) && IsNumeric(obj))
            {
                try
                {
                    long l = Convert.ToInt64(obj);
                    IntPtr p = (IntPtr)l;
                    return p;
                }
                catch
                {
                    return null;
                }
            }
            else if (obj is IntPtr && IsNumeric(type))
            {
                IntPtr p = (IntPtr)obj;
                long l = (long)p;
                try
                {
                    return Convert.ChangeType(l, type);
                }
                catch
                {
                    return null;
                }
            }
            else if (IsConvertible(type) && IsConvertible(obj))
            {
                try
                {
                    return Convert.ChangeType(obj, type);
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
        public static int GetTypeWeight(Type type)
        {
            if (type == null)
            {
                return 0;
            }
            if (type.IsEnum())
            {
                return 11;
            }
            switch (type.GetTypeCode())
            {
                case TypeCode.Boolean:
                    return 0;
                case TypeCode.Byte:
                    return 1;
                case TypeCode.Char:
                    return 1;
                case TypeCode.DateTime:
                    return 9;
                case TypeCode.Decimal:
                    return 16;
                case TypeCode.Double:
                    return 10;
                case TypeCode.Int16:
                    return 2;
                case TypeCode.Int32:
                    return 4;
                case TypeCode.Int64:
                    return 8;
                case TypeCode.SByte:
                    return 1;
                case TypeCode.Single:
                    return 5;
                case TypeCode.UInt16:
                    return 2;
                case TypeCode.UInt32:
                    return 4;
                case TypeCode.UInt64:
                    return 8;
            }
            return 17;
        }
        public static int GetParamsCode(IList<Type> types)
        {
            int code = 0;
            if (types != null)
            {
                for (int i = 0; i < types.Count; ++i)
                {
                    int codepart = 0;
                    if (types[i] != null && types[i].IsValueType())
                    {
                        codepart = 1 << i;
                    }
                    code += codepart;
                }
            }
            return code;
        }

        public static int NormalizeIndex(this IntPtr l, int index)
        {
            if (index < 0)
            {
                var top = l.gettop();
                if (-index <= top)
                {
                    index = top + 1 + index;
                }
            }
            return index;
        }
        public static LuaStateRecover CreateStackRecover(this IntPtr l)
        {
            return new LuaStateRecover(l);
        }
        public static IntPtr Indicator(this IntPtr l)
        {
            return l.topointer(lua.LUA_REGISTRYINDEX);
        }

        internal static void PushLuaStackTrace(this IntPtr l)
        {
            l.checkstack(4);
            l.GetGlobal(LuaConst.LS_LIB_DEBUG); // debug
            l.GetField(-1, LuaConst.LS_LIB_TRACEBACK); // debug traceback
            l.PushString(LuaConst.LS_COMMON_EMPTY); // debug tb ""
            l.pushnumber(2); // debug tb "" 2
            l.pcall(2, 1, 0); // debug "stack"
            l.remove(-2); // "stack"
        }
        public static void LogInfo(this IntPtr l, object message)
        {
            PushLuaStackTrace(l);
            var lstack = l.tostring(-1);
            l.pop(1);
            var m = (message ?? "nullptr").ToString() + "\n" + lstack;
            ForbidLuaStackTrace = true;
            PlatDependant.LogInfo(m);
            ForbidLuaStackTrace = false;
        }
        public static void LogWarning(this IntPtr l, object message)
        {
            PushLuaStackTrace(l);
            var lstack = l.tostring(-1);
            l.pop(1);
            var m = (message ?? "nullptr").ToString() + "\n" + lstack;
            ForbidLuaStackTrace = true;
            PlatDependant.LogWarning(m);
            ForbidLuaStackTrace = false;
        }
        public static void LogError(this IntPtr l, object message)
        {
            PushLuaStackTrace(l);
            var lstack = l.tostring(-1);
            l.pop(1);
            var m = (message ?? "nullptr").ToString() + "\n" + lstack;
            ForbidLuaStackTrace = true;
            PlatDependant.LogError(m);
            ForbidLuaStackTrace = false;
        }
        [ThreadStatic] internal static bool ForbidLuaStackTrace;

        public static readonly lua.CFunction LuaFuncOnInfo = new lua.CFunction(LuaOnInfo);
        public static readonly lua.CFunction LuaFuncOnWarning = new lua.CFunction(LuaOnWarning);
        public static readonly lua.CFunction LuaFuncOnError = new lua.CFunction(LuaOnError);
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaOnInfo(IntPtr l)
        {
            l.checkstack(1);
            l.pushvalue(1);
            var message = l.GetLua(-1);
            LogInfo(l, message);
            return 1;
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaOnWarning(IntPtr l)
        {
            l.checkstack(1);
            l.pushvalue(1);
            var message = l.GetLua(-1);
            LogWarning(l, message);
            return 1;
        }
        [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
        private static int LuaOnError(IntPtr l)
        {
            l.checkstack(1);
            l.pushvalue(1);
            var message = l.GetLua(-1);
            LogError(l, message);
            return 1;
        }
    }
}