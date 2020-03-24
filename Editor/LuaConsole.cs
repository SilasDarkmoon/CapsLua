using System;
using UnityEngine;
using UnityEditor;
using Capstones.UnityEngineEx;
using Capstones.LuaLib;
using Capstones.LuaWrap;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.UnityEditorEx
{
    public class LuaConsole : EditorWindow
    {
        [MenuItem("Lua/Lua Console", priority = 300020)]
        static void Init()
        {
            GetWindow(typeof(LuaConsole)).titleContent = new GUIContent("Lua Console");
        }

        public string Command;
        public string Result;
        //public Vector2 CommandScroll;
        public Vector2 ResultScroll;

        void OnGUI()
        {
            //CommandScroll = EditorGUILayout.BeginScrollView(CommandScroll, GUILayout.MaxHeight(500));
            Command = EditorGUILayout.TextArea(Command, GUILayout.MaxHeight(500));
            //EditorGUILayout.EndScrollView();
            if (GUILayout.Button("Run!"))
            {
                var l = GlobalLua.L.L;
                using (var lr = l.CreateStackRecover())
                {
                    l.dostring(Command);
                    var ntop = l.gettop();
                    if (ntop <= lr.Top)
                    {
                        Result = "<No Result>";
                    }
                    else
                    {
                        var cnt = ntop - lr.Top;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        for (int i = 0; i < cnt; ++i)
                        {
                            if (i > 0)
                            {
                                sb.AppendLine(",");
                            }
                            var index = lr.Top + i + 1;
                            l.GetHierarchicalRaw(lua.LUA_GLOBALSINDEX, "table.concat");
                            l.GetGlobal("vardump");
                            l.pushvalue(index);
                            if (cnt == 1)
                            {
                                l.PushString("result");
                            }
                            else
                            {
                                l.pushnumber(i + 1);
                            }
                            l.pcall(2, 1, 0);
                            l.PushString(Environment.NewLine);
                            l.pcall(2, 1, 0);
                            string tabstr;
                            l.GetLua(-1, out tabstr);
                            sb.Append(tabstr);
                            l.pop(1);
                        }
                        Result = sb.ToString();
                    }
                }
            }
            ResultScroll = EditorGUILayout.BeginScrollView(ResultScroll);
            EditorGUILayout.TextArea(Result);
            EditorGUILayout.EndScrollView();
        }
    }
}