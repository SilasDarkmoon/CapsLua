﻿#if UNITY_INCLUDE_TESTS
#region TESTS
using Capstones.LuaLib;
using Capstones.UnityEngineEx;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Capstones.LuaWrap.HotFixTest
{
    public class TestClass
    {
        public int Value;

        [LuaHotFix]
        public TestClass(int val)
        {
            Value = val;
        }
    }

    public class TestGenericClass<T>
    {
        public void TestVoidFunc()
        {
            HashSet<string> recordedMembers = new HashSet<string>();
            HashSet<string> compiledMembers = new HashSet<string>();

            var cachedPath = "Assets/Mods/CapsLua/LuaPrecompile/MemberList.txt";
            //var cachedPath = "EditorOutput/LuaPrecompile/CachedCommands.txt";
            if (PlatDependant.IsFileExist(cachedPath))
            {
                try
                {
                    using (var sr = PlatDependant.OpenReadText(cachedPath))
                    {
                        while (true)
                        {
                            var line = sr.ReadLine();
                            if (line == null)
                                break;

                            if (!string.IsNullOrEmpty(line))
                            {
                                recordedMembers.Add(line);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    PlatDependant.LogError(e);
                }
            }
        }
        public void TestParamFunc(string filePath, int times)
        {
            for (int i = 0; i < times; ++i)
            {
                HashSet<string> recordedMembers = new HashSet<string>();
                HashSet<string> compiledMembers = new HashSet<string>();

                var cachedPath = filePath + i;
                //var cachedPath = "EditorOutput/LuaPrecompile/CachedCommands.txt";
                if (PlatDependant.IsFileExist(cachedPath))
                {
                    try
                    {
                        using (var sr = PlatDependant.OpenReadText(cachedPath))
                        {
                            while (true)
                            {
                                var line = sr.ReadLine();
                                if (line == null)
                                    break;

                                if (!string.IsNullOrEmpty(line))
                                {
                                    recordedMembers.Add(line);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        PlatDependant.LogError(e);
                    }
                }
            }
        }
        public string TestReturnFunc(string filePath, int times)
        {
            string last = null;
            for (int i = 0; i < times; ++i)
            {
                if (i == 3)
                {
                    return i.ToString();
                }
                HashSet<string> recordedMembers = new HashSet<string>();
                HashSet<string> compiledMembers = new HashSet<string>();

                var cachedPath = filePath + i;
                //var cachedPath = "EditorOutput/LuaPrecompile/CachedCommands.txt";
                if (PlatDependant.IsFileExist(cachedPath))
                {
                    try
                    {
                        using (var sr = PlatDependant.OpenReadText(cachedPath))
                        {
                            while (true)
                            {
                                var line = sr.ReadLine();
                                if (line == null)
                                    break;
                                last = line;
                                if (!string.IsNullOrEmpty(line))
                                {
                                    recordedMembers.Add(line);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        PlatDependant.LogError(e);
                        return e.Message;
                    }
                }
            }
            return last;
        }
        public void TestOutFunc(string filePath, int times, out string rv)
        {
            string last = null;
            for (int i = 0; i < times; ++i)
            {
                if (i == 3)
                {
                    rv = i.ToString();
                    return;
                }
                HashSet<string> recordedMembers = new HashSet<string>();
                HashSet<string> compiledMembers = new HashSet<string>();

                var cachedPath = filePath + i;
                //var cachedPath = "EditorOutput/LuaPrecompile/CachedCommands.txt";
                if (PlatDependant.IsFileExist(cachedPath))
                {
                    try
                    {
                        using (var sr = PlatDependant.OpenReadText(cachedPath))
                        {
                            while (true)
                            {
                                var line = sr.ReadLine();
                                if (line == null)
                                    break;
                                last = line;
                                if (!string.IsNullOrEmpty(line))
                                {
                                    recordedMembers.Add(line);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        PlatDependant.LogError(e);
                        rv = e.Message;
                        return;
                    }
                }
            }
            rv = last;
            return;
        }

        public int TestReturnOutFunc(string filePath, int times, out string rv)
        {
            string last = null;
            for (int i = 0; i < times; ++i)
            {
                if (i == 3)
                {
                    rv = i.ToString();
                    return i;
                }
                HashSet<string> recordedMembers = new HashSet<string>();
                HashSet<string> compiledMembers = new HashSet<string>();

                var cachedPath = filePath + i;
                //var cachedPath = "EditorOutput/LuaPrecompile/CachedCommands.txt";
                if (PlatDependant.IsFileExist(cachedPath))
                {
                    try
                    {
                        using (var sr = PlatDependant.OpenReadText(cachedPath))
                        {
                            while (true)
                            {
                                var line = sr.ReadLine();
                                if (line == null)
                                    break;
                                last = line;
                                if (!string.IsNullOrEmpty(line))
                                {
                                    recordedMembers.Add(line);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        PlatDependant.LogError(e);
                        rv = e.Message;
                        return i;
                    }
                }
            }
            rv = last;
            return last?.Length ?? 0;
        }

        [LuaHotFix]
        public T TestReturnOutGenericFunc(string filePath, int times, T input, out T rv)
        {
            if (typeof(T) == typeof(string))
            {
                rv = (T)(object)(filePath + " " + times + " " + input);
                return rv;
            }
            else
            {
                rv = input;
                return rv;
            }
        }
    }

    public struct TestStruct
    {
        public static int GetValue(TestStruct val)
        {
            return val.Value;
        }
        public int Value;

        [LuaHotFix]
        public TestStruct(int val)
        {
            Value = val;
        }
    }

    public struct TestGenericStruct<T>
    {

    }
}
#endregion
#endif