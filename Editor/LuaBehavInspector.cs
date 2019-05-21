﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Capstones.UnityEngineEx;

using Object = UnityEngine.Object;

namespace Capstones.UnityEditorEx
{
    [CustomEditor(typeof(CapsUnityLuaBehav))]
    [CanEditMultipleObjects]
    public class CapsUnityLuaBehavInspector : InspectorBase<CapsUnityLuaBehav>
    {
        #region SerializedObject and Property
        private SerializedObject soTarget = null;
        private SerializedProperty spLua;
        private SerializedProperty spEx;
        #endregion

        void OnEnable()
        {
            if (targets != null && targets.Length == 1)
            {
                soTarget = new SerializedObject(target);
                spLua = soTarget.FindProperty("InitLuaPath");
                spEx = soTarget.FindProperty("ExFields");
            }
            else
            {
                soTarget = new SerializedObject(targets);
                spLua = soTarget.FindProperty("InitLuaPath");
            }
        }

        public static string GetLuaPath(string luastr)
        {
            if (luastr != null)
            {
                var path = luastr.Replace('.', '/');
                path = "CapsSpt/" + path + ".lua";
                var real = ResManager.EditorResLoader.CheckDistributePath(path);
                return real;
            }
            return null;
        }

        private string GetLuaLibStr(string path)
        {
            if (path != null)
            {
                return CapsResInfoEditor.GetAssetNormPath(path);
            }
            return null;
        }

        //private void GenerateSelectLuaButton()
        //{
        //    GUIContent btntxt = new GUIContent("*");
        //    var size = GUI.skin.button.CalcSize(btntxt);
        //    if (GUILayout.Button(btntxt, new[] { GUILayout.Width(size.x) }))
        //    {
        //        var p = GetLuaPath(spLua.stringValue);
        //        if (p != null)
        //        {
        //            try
        //            {
        //                var asset = AssetDatabase.LoadMainAssetAtPath(p);
        //                if (asset != null)
        //                {
        //                    EditorGUIUtility.PingObject(asset);
        //                }
        //                Debug.Log(p);
        //            }
        //            catch (Exception e)
        //            {
        //                Debug.LogException(e);
        //            }
        //        }
        //        else
        //        {
        //            Debug.Log("Lua file \"" + spLua.stringValue + "\" does not exist");
        //        }
        //    }
        //}

        public override void OnInspectorGUI()
        {
            if (targets != null && targets.Length == 1)
            {
                soTarget.Update();
                //EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(spLua, new GUIContent("Lua:"));
                //GenerateSelectLuaButton();
                //EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                Object luaObj = null;
                var path = GetLuaPath(spLua.stringValue);
                if (path != null)
                {
                    luaObj = AssetDatabase.LoadMainAssetAtPath(path);
                }
                var newLuaObj = EditorGUILayout.ObjectField("Lua Object:", luaObj, typeof(DefaultAsset), false);
                if (newLuaObj != luaObj)
                {
                    var newPath = AssetDatabase.GetAssetPath(newLuaObj);
                    var newlibstr = GetLuaLibStr(newPath);
                    if (newLuaObj == null)
                    {
                        newlibstr = "";
                    }
                    if (newlibstr != null)
                    {
                        spLua.stringValue = newlibstr;
                    }
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.PropertyField(spEx);
                soTarget.ApplyModifiedProperties();
            }
            else
            {
                soTarget.Update();
                //EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(spLua, new GUIContent("Lua:"));
                //GenerateSelectLuaButton();
                //EditorGUILayout.EndHorizontal();
                //EditorGUILayout.BeginHorizontal();
                //EditorGUILayout.PropertyField(spOrder, new GUIContent("Order:"));
                //EditorGUILayout.EndHorizontal();
                soTarget.ApplyModifiedProperties();
            }
        }
    }

    public static class LuaBehaviourUtils
    {
        [MenuItem("CONTEXT/CapsUnityLuaBehav/Copy Extra as Lua", priority = 10002)]
        public static void CopyLuaBehavExtra(MenuCommand command)
        {
            var behav = command.context as CapsUnityLuaBehav;
            if (behav != null)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (var key in behav.ExFields.Keys)
                {
                    if (sb.Length != 0)
                    {
                        sb.AppendLine();
                    }
                    sb.AppendFormat("    self.{0} = self.___ex.{0}", key);
                }

                EditorGUIUtility.systemCopyBuffer = sb.ToString();
            }
            else
            {
                EditorGUIUtility.systemCopyBuffer = string.Empty;
            }
        }
    }
}