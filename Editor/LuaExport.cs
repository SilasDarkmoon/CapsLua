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
        public bool successFlag;
        public string path;
        public string uri;
        public int prior;
    }


    public class LuaExportWindow : EditorWindow
    {
        private string ExportPath = string.Empty;
        private string IncludeRoots = string.Empty;

        private HashSet<string> Includes;

        private static Func<string, HashSet<string>, HashSet<string>, Dictionary<string, LuaDescript>, LuaDescript>[] GetDescriptFunctions =
        {
            NormalLuaDescript,
            ModLuaDescript,
            DistLuaDescript,
            ModDistLuaDescript
        };

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
            var root = CreateRootDirectory(ExportPath);
            if (root == null)
            {
                return;
            }
            var distributes = new HashSet<string>(ResManager.PreRuntimeDFlags);
            var assets = AssetDatabase.GetAllAssetPaths();
            var loaded = new Dictionary<string, LuaDescript>();
            foreach (var path in assets)
            {
                //只处理lua
                if (!path.EndsWith("lua"))
                {
                    continue;
                }
                foreach (var func in GetDescriptFunctions)
                {
                    var descript = func(path, distributes, Includes, loaded);
                    if (descript.successFlag)
                    {
                        loaded[descript.uri] = descript;
                        break;
                    }
                }
            }
            foreach (var item in loaded)
            {
                var newPath = exportPath + item.Value.uri;
                var newFile = new FileInfo(newPath);
                if (!newFile.Directory.Exists)
                {
                    newFile.Directory.Create();
                }
                File.Copy(item.Value.path, newPath, true);
            }
            UnityEngine.Debug.LogFormat("Finish");
        }

        private static LuaDescript NormalLuaDescript(string path, HashSet<string> distributes, HashSet<string> includes, Dictionary<string, LuaDescript> loaded)
        {
            var empty = default(LuaDescript);
            if (path.StartsWith("Assets/CapsSpt/dist"))
            {
                return empty;
            }
            if (!path.StartsWith("Assets/CapsSpt"))
            {
                return empty;
            }
            var uri = path.Substring("Assets/CapsSpt/".Length);
            var layers = uri.Split('/');
            if (layers.Length < 1 || (includes.Count > 0 && !includes.Contains(layers[0])))
            {
                return empty;
            }
            var result = new LuaDescript()
            {
                uri = uri,
                path = path,
                prior = 0,
                successFlag = true
            };
            if (loaded.ContainsKey(result.uri))
            {
                return empty;
            }
            return result;
        }

        private static LuaDescript ModLuaDescript(string path, HashSet<string> distributes, HashSet<string> includes, Dictionary<string, LuaDescript> loaded)
        {
            var empty = default(LuaDescript);
            if (!path.StartsWith("Assets/Mods"))
            {
                return empty;
            }
            var relativePath = path.Substring("Assets/Mods/".Length);
            var layers = relativePath.Split('/');
            if (layers.Length < 2)
            {
                return empty;
            }
            if (layers[1] != "CapsSpt")
            {
                return empty;
            }
            if (layers.Length < 3 || (includes.Count > 0 && !includes.Contains(layers[2])))
            {
                return empty;
            }
            var result = new LuaDescript()
            {
                path = path,
                uri = relativePath.Substring(layers[0].Length + layers[1].Length + 2),
                prior = 1,
                successFlag = true,
            };
            if (loaded.TryGetValue(result.uri, out var loadedLua) && loadedLua.prior > result.prior)
            {
                return empty;
            }
            return result;
        }

        private static LuaDescript DistLuaDescript(string path, HashSet<string> distributes, HashSet<string> includes, Dictionary<string, LuaDescript> loaded)
        {
            var empty = default(LuaDescript);
            if (!path.StartsWith("Assets/CapsSpt/dist/"))
            {
                return empty;
            }
            var relativePath = path.Substring("Assets/CapsSpt/dist/".Length);
            var layers = relativePath.Split('/');
            if (layers.Length == 0)
            {
                return empty;
            }
            var distribute = layers[0];
            if (!distributes.Contains(distribute))
            {
                return empty;
            }
            if (layers.Length < 2 || (includes.Count > 0 && !includes.Contains(layers[1])))
            {
                return empty;
            }
            var result = new LuaDescript()
            {
                uri = relativePath.Substring(distribute.Length + 1),
                path = path,
                prior = 2,
                successFlag = true,
            };
            if (loaded.TryGetValue(result.uri, out var loadedLua) && loadedLua.prior > result.prior)
            {
                return empty;
            }
            return result;
        }



        private static LuaDescript ModDistLuaDescript(string path, HashSet<string> distributes, HashSet<string> includes, Dictionary<string, LuaDescript> loaded)
        {
            var empty = default(LuaDescript);
            if (!path.StartsWith("Assets/Mods"))
            {
                return empty;
            }
            var relativePath = path.Substring("Assets/Mods/".Length);
            var layers = relativePath.Split('/');
            if (layers.Length < 3)
            {
                return empty;
            }
            if (layers[1] != "CapsSpt")
            {
                return empty;
            }
            var distribute = layers[2];
            if (!distributes.Contains(distribute))
            {
                return empty;
            }
            if (layers.Length < 4 || (includes.Count > 0 && !includes.Contains(layers[3])))
            {
                return empty;
            }
            var result = new LuaDescript()
            {
                path = path,
                uri = relativePath.Substring(layers[0].Length + layers[1].Length + layers[2].Length + 3),
                prior = 4,
                successFlag = true,
            };
            if (loaded.TryGetValue(result.uri, out var loadedLua) && loadedLua.prior > result.prior)
            {
                return empty;
            }
            return result;
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