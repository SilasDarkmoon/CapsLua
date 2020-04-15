﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Capstones.UnityEngineEx;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
#if UNITY_INCLUDE_TESTS
    #region TESTS
    public static class CapsLuaEventMetaTest
    {
        public static event Action OnCommand = () => { };

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Test/Lua/Test Event", priority = 300020)]
        public static void TestEvent()
        {
            OnCommand();
        }
#endif
    }
    #endregion
#endif
}