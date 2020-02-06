using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Capstones.LuaLib
{
    /// <summary>
    /// if some code is with this attribute, it is supposed to be precompiled.
    /// if some code is with this attribute and ignore is true, it is forbidden to be precompiled.
    /// if some code is not with this attribute, we must precompile it with - 1. Manually, 2. Write a white list, 3. Precompile while running.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class LuaPrecompileAttribute : Attribute
    {
        public bool Ignore { get; set; }
    }

    //public class ReflectAnalyzerTestClass
    //{
    //    public class TestGenericClass<T>
    //    {
    //        public class TestNestedGenericClass<U>
    //        {

    //        }

    //        public static void TestFuncGenericFunc<Y>(ref Y y) { }
    //    }

    //    public class TestNormalClass
    //    {
    //        [LuaPrecompile]
    //        public void TestFunc() { }
    //        [LuaPrecompile(Ignore = true)]
    //        public void TestIgnoreFunc() { }
    //    }
    //}
}
