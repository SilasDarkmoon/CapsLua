using UnityEngine;
using System.Collections;
using Capstones.LuaWrap;
using Capstones.UnityEngineEx;

public interface ICapsUnityLuaBehavEx
{
    CapsUnityLuaBehav Major { set; get; }
}
[RequireComponent(typeof(CapsUnityLuaBehav))]
[DataDictionaryComponentType(DataDictionaryComponentTypeAttribute.DataDictionaryComponentType.Sub)]
public abstract class CapsUnityLuaBehavEx : MonoBehaviour, ICapsUnityLuaBehavEx
{
    public CapsUnityLuaBehav Major { get; set; }
}
public static class CapsUnityLuaBehavExMethods
{
    public static CapsUnityLuaBehav GetMajorBehav<T>(this T self) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = self.Major;
        if (object.ReferenceEquals(major, null))
        {
            major = self.GetComponent<CapsUnityLuaBehav>();
            if (major != null)
            {
                self.Major = major;
            }
        }
        return major;
    }
    public static object[] CallLuaFunc<T>(this T self, string name, params object[] args) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            return major.CallLuaFunc(name, args);
        }
        return null;
    }
    public static void CallLuaFunc<T>(this T self, string name) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            major.CallLuaFunc(name);
        }
    }
    public static void CallLuaFunc<T, P0>(this T self, string name, P0 p0) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            major.CallLuaFunc(name, p0);
        }
    }
    public static void CallLuaFunc<T, P0, P1>(this T self, string name, P0 p0, P1 p1) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            major.CallLuaFunc(name, p0, p1);
        }
    }
    public static void CallLuaFunc<T, P0, P1, P2>(this T self, string name, P0 p0, P1 p1, P2 p2) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            major.CallLuaFunc(name, p0, p1, p2);
        }
    }
    public static void CallLuaFunc<T, P0, P1, P2, P3>(this T self, string name, P0 p0, P1 p1, P2 p2, P3 p3) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            major.CallLuaFunc(name, p0, p1, p2, p3);
        }
    }
    public static void CallLuaFunc<T, P0, P1, P2, P3, P4>(this T self, string name, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            major.CallLuaFunc(name, p0, p1, p2, p3, p4);
        }
    }
    public static void CallLuaFunc<T, P0, P1, P2, P3, P4, P5>(this T self, string name, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            major.CallLuaFunc(name, p0, p1, p2, p3, p4, p5);
        }
    }
    public static bool CallLuaFunc<T, R>(this T self, string name, out R r) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            return major.CallLuaFunc(name, out r);
        }
        r = default(R);
        return false;
    }
    public static bool CallLuaFunc<T, R, P0>(this T self, string name, out R r, P0 p0) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            return major.CallLuaFunc(name, out r, p0);
        }
        r = default(R);
        return false;
    }
    public static bool CallLuaFunc<T, R, P0, P1>(this T self, string name, out R r, P0 p0, P1 p1) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            return major.CallLuaFunc(name, out r, p0, p1);
        }
        r = default(R);
        return false;
    }
    public static bool CallLuaFunc<T, R, P0, P1, P2>(this T self, string name, out R r, P0 p0, P1 p1, P2 p2) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            return major.CallLuaFunc(name, out r, p0, p1, p2);
        }
        r = default(R);
        return false;
    }
    public static bool CallLuaFunc<T, R, P0, P1, P2, P3>(this T self, string name, out R r, P0 p0, P1 p1, P2 p2, P3 p3) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            return major.CallLuaFunc(name, out r, p0, p1, p2, p3);
        }
        r = default(R);
        return false;
    }
    public static bool CallLuaFunc<T, R, P0, P1, P2, P3, P4>(this T self, string name, out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            return major.CallLuaFunc(name, out r, p0, p1, p2, p3, p4);
        }
        r = default(R);
        return false;
    }
    public static bool CallLuaFunc<T, R, P0, P1, P2, P3, P4, P5>(this T self, string name, out R r, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5) where T : Component, ICapsUnityLuaBehavEx
    {
        CapsUnityLuaBehav major = GetMajorBehav(self);
        if (major != null)
        {
            major.BindLua();
            return major.CallLuaFunc(name, out r, p0, p1, p2, p3, p4, p5);
        }
        r = default(R);
        return false;
    }
    public static R CallLuaFunc<T, R>(this T self, string name) where T : Component, ICapsUnityLuaBehavEx
    {
        R r;
        CallLuaFunc(self, name, out r);
        return r;
    }
    public static R CallLuaFunc<T, R, P0>(this T self, string name, P0 p0) where T : Component, ICapsUnityLuaBehavEx
    {
        R r;
        CallLuaFunc(self, name, out r, p0);
        return r;
    }
    public static R CallLuaFunc<T, R, P0, P1>(this T self, string name, P0 p0, P1 p1) where T : Component, ICapsUnityLuaBehavEx
    {
        R r;
        CallLuaFunc(self, name, out r, p0, p1);
        return r;
    }
    public static R CallLuaFunc<T, R, P0, P1, P2>(this T self, string name, P0 p0, P1 p1, P2 p2) where T : Component, ICapsUnityLuaBehavEx
    {
        R r;
        CallLuaFunc(self, name, out r, p0, p1, p2);
        return r;
    }
    public static R CallLuaFunc<T, R, P0, P1, P2, P3>(this T self, string name, P0 p0, P1 p1, P2 p2, P3 p3) where T : Component, ICapsUnityLuaBehavEx
    {
        R r;
        CallLuaFunc(self, name, out r, p0, p1, p2, p3);
        return r;
    }
    public static R CallLuaFunc<T, R, P0, P1, P2, P3, P4>(this T self, string name, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4) where T : Component, ICapsUnityLuaBehavEx
    {
        R r;
        CallLuaFunc(self, name, out r, p0, p1, p2, p3, p4);
        return r;
    }
    public static R CallLuaFunc<T, R, P0, P1, P2, P3, P4, P5>(this T self, string name, P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5) where T : Component, ICapsUnityLuaBehavEx
    {
        R r;
        CallLuaFunc(self, name, out r, p0, p1, p2, p3, p4, p5);
        return r;
    }
}
