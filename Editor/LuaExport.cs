using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Collections.Generic;
using Capstones.UnityEngineEx;

namespace Capstones.UnityEditorEx
{
    public static class LuaExport
    {
        [MenuItem("Lua/Lua Export", priority = 300015)]
        public static void Export()
        {
            var window = EditorWindow.GetWindow(typeof(LuaExportWindow)) as LuaExportWindow;
        }
    }

    public struct LuaDescript
    {
        public string path;
        public string uri;
        public string mod;
        public string distribute;
    }


    public class LuaExportWindow : EditorWindow
    {
        private string ExportPath = string.Empty;
        private string IncludeRoots = string.Empty;

        private HashSet<string> Includes;

        void OnGUI()
        {
            EditorGUILayout.TextArea("根据distribute导出lua端所需的资源。\n若指定了包含根路径的话,则只会导出指定路径的内容。否则完整导出");
            ExportPath = EditorGUILayout.TextField("导出路径:", ExportPath);
            if (GUILayout.Button("导出路径选择"))
            {
                var path = EditorUtility.OpenFolderPanel("Select log output folder", ExportPath, "");
                if (!string.IsNullOrEmpty(path))
                {
                    ExportPath = path;
                }
            }
            IncludeRoots = EditorGUILayout.TextField("包含根路径(分号分隔):", IncludeRoots);

            if (GUILayout.Button("导出"))
            {
                if (!string.IsNullOrEmpty(IncludeRoots))
                {
                    Includes = new HashSet<string>(IncludeRoots.Split(';'));
                }
                else
                {
                    Includes = new HashSet<string>();
                }
                var exportPath = string.Empty;
                if (!ExportPath.EndsWith("/") && !ExportPath.EndsWith("\\"))
                {
                    exportPath = ExportPath + Path.DirectorySeparatorChar;
                }
                DoExport(exportPath);
            }
        }

        private void DoExport(string exportPath)
        {
            if (CreateRootDirectory(exportPath) == null)
            {
                return;
            }
            var assets = AssetDatabase.GetAllAssetPaths();
            var distributes = ResManager.PreRuntimeDFlags;
            var distributeSorter = new Dictionary<string, int>();
            for (var i = 0; i < distributes.Count; i++)
            {
                distributeSorter[distributes[i]] = i;
            }
            var loaded = new Dictionary<string, LuaDescript>();
            foreach (var asset in assets)
            {
                if (!asset.EndsWith("lua"))
                {
                    continue;
                }
                if (Directory.Exists(asset))
                {
                    continue;
                }
                var uri = ResManager.GetAssetNormPath(asset, out var type, out var mod, out var distribute);
                if (!string.IsNullOrEmpty(distribute) && !distributeSorter.ContainsKey(distribute))
                {
                    continue;
                }
                if (uri.IndexOf("/") > 0)
                {
                    if (Includes.Count > 0 && !Includes.Contains(GetPathFirstDirectory(uri)))
                    {
                        continue;
                    }
                }
                else
                {
                    if (Includes.Count > 0)
                    {
                        continue;
                    }
                }

                var result = new LuaDescript()
                {
                    uri = uri,
                    path = asset,
                    mod = mod,
                    distribute = distribute
                };
                if (loaded.TryGetValue(uri, out var descript) && CompareTo(descript, result, distributeSorter) >= 0)
                {
                    continue;
                }
                loaded[uri] = result;
            }
            foreach (var item in loaded)
            {
                var newPath = exportPath + item.Value.uri;
                var newFile = new FileInfo(newPath);
                if (!newFile.Directory.Exists)
                {
                    newFile.Directory.Create();
                }
                File.Copy(item.Value.path, newPath);
            }
            System.Diagnostics.Process.Start(exportPath);
        }

        private string GetPathFirstDirectory(string path)
        {
            return path.Substring(0, path.IndexOf("/"));
        }

        private int CompareTo(LuaDescript d1, LuaDescript d2, Dictionary<string, int> distributeSorter)
        {
            if (string.IsNullOrEmpty(d1.distribute) && string.IsNullOrEmpty(d2.distribute))
            {
                return CompareMods(d1.mod, d2.mod, distributeSorter);
            }
            if (string.IsNullOrEmpty(d1.distribute) || string.IsNullOrEmpty(d2.distribute))
            {
                return string.IsNullOrEmpty(d1.distribute) ? -1 : 1;
            }
            if (distributeSorter[d1.distribute] != distributeSorter[d2.distribute])
            {
                return distributeSorter[d1.distribute].CompareTo(distributeSorter[d2.distribute]);
            }
            return CompareMods(d1.mod, d2.mod, distributeSorter);

        }

        private int CompareMods(string mod1, string mod2, Dictionary<string, int> distributeSorter)
        {
            mod1 = CapsModEditor.IsModOptional(mod1) ? mod1 : string.Empty;
            mod2 = CapsModEditor.IsModOptional(mod2) ? mod2 : string.Empty;
            if (mod1 == mod2)
            {
                return 0;
            }
            if (string.IsNullOrEmpty(mod1) || string.IsNullOrEmpty(mod2))
            {
                return string.IsNullOrEmpty(mod1) ? -1 : 1;
            }
            return distributeSorter[mod1].CompareTo(distributeSorter[mod2]);
        }

        private object CreateRootDirectory(string exportPath)
        {
            if (string.IsNullOrEmpty(exportPath))
            {
                return null;
            }
            var root = new DirectoryInfo(exportPath);
            if (root.Exists)
            {
                root.Delete(true);
            }
            root.Create();
            return root;
        }
    }
}