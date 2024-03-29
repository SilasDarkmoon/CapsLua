﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Capstones.UnityEngineEx;

namespace Capstones.UnityEditorEx
{
    [InitializeOnLoad]
    public static class CapsLuaEntry
    {
        static CapsLuaEntry()
        {
            SafeInitializerUtils.DoDelayedInitialize();
            CapsEditorInitializer.ShouldAlreadyInit();

            CapsPackageEditor.OnPackagesChanged += ReinitGlobalLua;
            CapsDistributeEditor.OnDistributeFlagsChanged += ReinitGlobalLua;
        }
        private static void ReinitGlobalLua()
        {
            GlobalLua.Reinit();
        }

        [MenuItem("Res/Build Scripts (No Update, Raw Copy)", priority = 200120)]
        public static void BuildSptCommand()
        {
            CapsResBuilder.BuildingParams = CapsResBuilder.ResBuilderParams.Create();
            CapsResBuilder.BuildingParams.makezip = false;
            var work = CapsSptBuilder.BuildSptAsync(null, null, new[] { new CapsSptBuilder.SptBuilderEx_RawCopy() });
            while (work.MoveNext()) ;
            CapsResBuilder.BuildingParams = null;
        }

        [MenuItem("Lua/Reinit Global Lua", priority = 300010)]
        public static void ReinitGlobalLuaInEditor()
        {
            if (!Application.isPlaying)
            {
                ReinitGlobalLua();
            }
            else
            {
                PlatDependant.LogError("Cannot reinit global lua while playing.");
            }
        }
    }
}