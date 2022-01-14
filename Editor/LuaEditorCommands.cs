using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Collections.Generic;
using Capstones.UnityEngineEx;
using Capstones.LuaLib;
using Capstones.LuaWrap;
using Capstones.LuaExt;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;
using static Capstones.LuaWrap.LuaPack;

namespace Capstones.UnityEditorEx
{
    public static class LuaEditorCommands
    {
        [MenuItem("GameObject/Push to Lua", priority = 12)]
        public static void PushSelectedToLua()
        {
            var go = Selection.activeGameObject;
            if (go != null && string.IsNullOrEmpty(AssetDatabase.GetAssetPath(go)))
            {
                GlobalLua.L.L.SetGlobal("___EDITOR_TEMP_PUSHED", go);
            }
        }

        [MenuItem("CONTEXT/Component/Push to Lua", priority = 10001)]
        public static void PushSelectedCompToLua(MenuCommand command)
        {
            var comp = command.context as Component;
            if (comp != null && string.IsNullOrEmpty(AssetDatabase.GetAssetPath(comp)))
            {
                GlobalLua.L.L.SetGlobal("___EDITOR_TEMP_PUSHED", comp);
            }
        }

        [MenuItem("Assets/Push to Lua", priority = 2029)]
        public static void PushSelectedAssetToLua()
        {
            var selection = Selection.activeObject;
            if (selection != null && !string.IsNullOrEmpty(AssetDatabase.GetAssetPath(selection)))
            {
                GlobalLua.L.L.SetGlobal("___EDITOR_TEMP_PUSHED", selection);
            }
        }
    }
}