using System;
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
            CapsEditorInitializer.ShouldAlreadyInit();

            CapsPackageEditor.OnPackagesChanged += ReinitGlobalLua;
            CapsDistributeEditor.OnDistributeFlagsChanged += ReinitGlobalLua;
        }

        private static void ReinitGlobalLua()
        {
            GlobalLua.Reinit();
        }

        [MenuItem("Test/Build Scripts")]
        public static void BuildSptCommand()
        {
            //var work = CapsSptBuilder.BuildSptAsync(null, null, new[] { new CapsSptBuilder.SptBuilderEx_RawCopy() });
            var work = CapsSptBuilder.BuildSptAsync(null, null);
            while (work.MoveNext()) ;
        }
    }
}