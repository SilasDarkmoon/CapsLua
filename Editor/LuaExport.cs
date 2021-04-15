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
        [MenuItem("Lua/Export Lua Scripts", priority = 300018)]
        public static void Export()
        {
            var window = EditorWindow.GetWindow<LuaExportWindow>();
            window.titleContent = new GUIContent("Export Lua Scripts");
        }

        [MenuItem("Lua/Export Lua Lib", priority = 300019)]
        public static void ExportLuaLib()
        {
            var window = EditorWindow.GetWindow<LuaLibExportWindow>();
            window.titleContent = new GUIContent("Export Lua Lib");
        }
    }

    public struct LuaDesc
    {
        public string path;
        public string norm;
        public string mod;
        public string dist;
    }

    public class LuaExportWindow : EditorWindow
    {
        private string ExportPath = string.Empty;
        private string IncludeRoots = string.Empty;

        private HashSet<string> Includes;

        void OnGUI()
        {
            GUI.enabled = false;
            EditorGUILayout.TextArea("根据distribute导出lua端所需的资源。\n若指定了包含根路径的话,则只会导出指定路径的内容。否则完整导出");
            GUI.enabled = true;
            ExportPath = EditorGUILayout.TextField("导出路径:", ExportPath);
            if (GUILayout.Button("导出路径选择"))
            {
                var path = EditorUtility.OpenFolderPanel("Select export folder", ExportPath, "");
                if (!string.IsNullOrEmpty(path))
                {
                    ExportPath = path;
                }
            }
            IncludeRoots = EditorGUILayout.TextField("包含根路径(分号分隔):", IncludeRoots);

            GUI.enabled = !string.IsNullOrEmpty(ExportPath);
            if (GUILayout.Button("导出"))
            {
                Includes = new HashSet<string>();
                if (!string.IsNullOrEmpty(IncludeRoots))
                {
                    var items = IncludeRoots.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < items.Length; ++i)
                    {
                        var item = items[i].Trim().TrimEnd('/', '\\');
                        Includes.Add(item);
                    }
                }
                var exportPath = string.Empty;
                if (!ExportPath.EndsWith("/") && !ExportPath.EndsWith("\\"))
                {
                    exportPath = ExportPath + Path.DirectorySeparatorChar;
                }
                DoExport(exportPath, Includes);
            }
            GUI.enabled = true;
        }

        private static string CheckExportPath(string exportPath)
        {
            if (exportPath == null)
            {
                return null;
            }
            while (exportPath.EndsWith("\\") || exportPath.EndsWith("/"))
            {
                exportPath = exportPath.Substring(0, exportPath.Length - 1);
            }
            var last = System.IO.Path.GetFileName(exportPath);
            if (last.Equals("~lua~", StringComparison.InvariantCultureIgnoreCase))
            {
                exportPath = System.IO.Path.GetDirectoryName(exportPath);
            }
            if (System.IO.File.Exists(exportPath + "/.luaexport"))
            {
                return exportPath + "/";
            }
            if (string.IsNullOrEmpty(exportPath))
            {
                return "~lua~/";
            }
            else
            {
                return exportPath + "/~lua~/";
            }
        }
        private static bool IsFileIncluded(string file, IEnumerable<string> roots)
        {
            if (string.IsNullOrEmpty(file))
            {
                return false;
            }
            if (roots == null)
            {
                return true;
            }
            bool? result = null;
            foreach (var root in roots)
            {
                string rroot = root.TrimEnd('\\', '/');
                if (file.StartsWith(rroot, StringComparison.InvariantCultureIgnoreCase)
                    && file.Length > rroot.Length
                    && (file[rroot.Length] == '\\' || file[rroot.Length] == '/')
                    )
                {
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }
            }
            return result ?? true;
        }
        public static void DoExport(string exportPath, IEnumerable<string> roots)
        {
            exportPath = CheckExportPath(exportPath);
            if (exportPath == null)
            {
                return;
            }
            if (System.IO.Directory.Exists(exportPath))
            {
                try
                {
                    System.IO.Directory.Delete(exportPath, true);
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
            }
            System.IO.Directory.CreateDirectory(exportPath);

            var assets = AssetDatabase.GetAllAssetPaths();
            var distributes = ResManager.PreRuntimeDFlags;
            var distributeSorter = new Dictionary<string, int>();
            for (var i = 0; i < distributes.Count; i++)
            {
                distributeSorter[distributes[i]] = i;
            }
            var loaded = new Dictionary<string, LuaDesc>();
            foreach (var asset in assets)
            {
                if (!asset.EndsWith(".lua", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }
                if (!File.Exists(asset))
                {
                    continue;
                }
                string norm, type, mod, dist;
                norm = ResManager.GetAssetNormPath(asset, out type, out mod, out dist);
                if (type != "spt")
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(dist) && !distributeSorter.ContainsKey(dist))
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(mod) && CapsModEditor.IsModOptional(mod) && !distributeSorter.ContainsKey(dist))
                {
                    continue;
                }
                if (!IsFileIncluded(norm, roots))
                {
                    continue;
                }

                var desc = new LuaDesc()
                {
                    norm = norm,
                    path = asset,
                    mod = mod,
                    dist = dist
                };
                LuaDesc olddesc;
                if (loaded.TryGetValue(norm, out olddesc) && CompareTo(olddesc, desc, distributeSorter) >= 0)
                {
                    continue;
                }
                loaded[norm] = desc;
            }
            foreach (var item in loaded)
            {
                var newPath = exportPath + item.Value.norm;
                var newFile = new FileInfo(newPath);
                if (!newFile.Directory.Exists)
                {
                    newFile.Directory.Create();
                }
                File.Copy(item.Value.path, newPath);
            }
            EditorUtility.RevealInFinder(exportPath);
        }

        private static int CompareTo(LuaDesc d1, LuaDesc d2, Dictionary<string, int> distributeSorter)
        {
            if (string.IsNullOrEmpty(d1.dist) && string.IsNullOrEmpty(d2.dist))
            {
                return CompareMods(d1.mod, d2.mod, distributeSorter);
            }
            if (string.IsNullOrEmpty(d1.dist) || string.IsNullOrEmpty(d2.dist))
            {
                return string.IsNullOrEmpty(d1.dist) ? -1 : 1;
            }
            if (distributeSorter[d1.dist] != distributeSorter[d2.dist])
            {
                return distributeSorter[d1.dist].CompareTo(distributeSorter[d2.dist]);
            }
            return CompareMods(d1.mod, d2.mod, distributeSorter);

        }

        private static int CompareMods(string mod1, string mod2, Dictionary<string, int> distributeSorter)
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
    }

    public class LuaLibExportWindow : EditorWindow
    {
        public static readonly Dictionary<string, string> LuaLibFileMap = new Dictionary<string, string>()
        {
            { "Packages/cn.capstones.async/Runtime/SignalAwaiter.cs",                                       "Common/SignalAwaiter.cs" },
            { "Packages/cn.capstones.modsentry/Runtime/EventExtensions.cs",                                 "Common/EventExtensions.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/LanguageConverter/CapsLanguageConverter.cs",        "Common/CapsLanguageConverter.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/CapsResManager_ConfigLoader.cs",                    "Common/CapsResManager_ConfigLoader.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/CapsResManager_DistributeFlags.cs",                 "Common/CapsResManager_DistributeFlags.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/Libs/Framework/CommonStructs/CommonStructs.cs",     "Common/CommonStructs.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/Libs/Framework/PlatDependant/IsolatedPrefs.cs",     "Common/IsolatedPrefs.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/Libs/JSON/JSONObject.cs",                           "Common/JSONObject.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/Libs/Framework/PlatDependant/PlatDependant.cs",     "Common/PlatDependant.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/Libs/Framework/PlatDependant/ThreadSafeValues.cs",  "Common/ThreadSafeValues.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/Libs/Framework/WeakRefExt/WeakRefExtensions.cs",    "Common/WeakRefExtensions.cs" },
            { "Packages/cn.capstones.resmanager/Runtime/Libs/Framework/UnityManagers/PluginManager.cs",     "Common/PluginManager.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsDynamic.cs",                                           "Lua/CapsDynamic.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaCommonMeta.cs",                                     "Lua/CapsLuaCommonMeta.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaConst.cs",                                          "Lua/CapsLuaConst.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaDelegate.cs",                                       "Lua/CapsLuaDelegate.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaExtend.cs",                                         "Lua/CapsLuaExtend.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaFunc.cs",                                           "Lua/CapsLuaFunc.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaFuncEx.cs",                                         "Lua/CapsLuaFuncEx.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaHub.cs",                                            "Lua/CapsLuaHub.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaHubC.cs",                                           "Lua/CapsLuaHubC.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaHubEssential.cs",                                   "Lua/CapsLuaHubEssential.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaLib.cs",                                            "Lua/CapsLuaLib.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaMethodMeta.cs",                                     "Lua/CapsLuaMethodMeta.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaObjCache.cs",                                       "Lua/CapsLuaObjCache.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaOnStack.cs",                                        "Lua/CapsLuaOnStack.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaPropertyMeta.cs",                                   "Lua/CapsLuaPropertyMeta.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaState.cs",                                          "Lua/CapsLuaState.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaString.cs",                                         "Lua/CapsLuaString.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaTable.cs",                                          "Lua/CapsLuaTable.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaTypeHub.cs",                                        "Lua/CapsLuaTypeHub.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaTypeNonPublicReflector.cs",                         "Lua/CapsLuaTypeNonPublicReflector.cs" },
            { "Packages/cn.capstones.lua/Runtime/CapsLuaWrapper.cs",                                        "Lua/CapsLuaWrapper.cs" },
            { "Packages/cn.capstones.lua/Runtime/Framework/CapsGlobalLua.cs",                               "Lua/Framework/CapsGlobalLua.cs" },
            { "Packages/cn.capstones.lua/Runtime/Framework/CapsLuaFileManager.cs",                          "Lua/Framework/CapsLuaFileManager.cs" },
            { "Packages/cn.capstones.lua/Runtime/LuaExt/CapsLuaExtAssembly.cs",                             "Lua/LuaExt/CapsLuaExtAssembly.cs" },
            { "Packages/cn.capstones.lua/Runtime/LuaExt/CapsLuaExtFramework.cs",                            "Lua/LuaExt/CapsLuaExtFramework.cs" },
            { "Packages/cn.capstones.lua/Runtime/LuaExt/CapsLuaExtJson.cs",                                 "Lua/LuaExt/CapsLuaExtJson.cs" },
            { "Packages/cn.capstones.lua/Runtime/Precompile/LuaHub_LuaNative.cs",                           "Lua/LuaHubSub/LuaHub_LuaNative.cs" },
            { "Packages/cn.capstones.lua/Runtime/Precompile/LuaPrecompileAttribute.cs",                     "Lua/LuaHubSub/LuaPrecompileAttribute.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaPrecompileLoaderEx.cs",                                     "Lua/LuaHubSub/LuaPrecompileLoaderEx.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_Capstones_LuaLib_LuaHub.cs",                            "Lua/LuaHubSub/LuaHub_Capstones_LuaLib_LuaHub.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_Capstones_LuaLib_LuaHub_LuaHubC.cs",                    "Lua/LuaHubSub/LuaHub_Capstones_LuaLib_LuaHub_LuaHubC.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Boolean.cs",                                     "Lua/LuaHubSub/LuaHub_System_Boolean.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Byte.cs",                                        "Lua/LuaHubSub/LuaHub_System_Byte.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Char.cs",                                        "Lua/LuaHubSub/LuaHub_System_Char.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Convert.cs",                                     "Lua/LuaHubSub/LuaHub_System_Convert.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Decimal.cs",                                     "Lua/LuaHubSub/LuaHub_System_Decimal.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Double.cs",                                      "Lua/LuaHubSub/LuaHub_System_Double.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_GC.cs",                                          "Lua/LuaHubSub/LuaHub_System_GC.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Int16.cs",                                       "Lua/LuaHubSub/LuaHub_System_Int16.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Int32.cs",                                       "Lua/LuaHubSub/LuaHub_System_Int32.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Int64.cs",                                       "Lua/LuaHubSub/LuaHub_System_Int64.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_IntPtr.cs",                                      "Lua/LuaHubSub/LuaHub_System_IntPtr.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Reflection_MemberInfo.cs",                       "Lua/LuaHubSub/LuaHub_System_Reflection_MemberInfo.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_SByte.cs",                                       "Lua/LuaHubSub/LuaHub_System_SByte.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Single.cs",                                      "Lua/LuaHubSub/LuaHub_System_Single.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_String.cs",                                      "Lua/LuaHubSub/LuaHub_System_String.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_Type.cs",                                        "Lua/LuaHubSub/LuaHub_System_Type.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_UInt16.cs",                                      "Lua/LuaHubSub/LuaHub_System_UInt16.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_UInt32.cs",                                      "Lua/LuaHubSub/LuaHub_System_UInt32.cs" },
            { "Assets/Mods/CapsLua/LuaHubSub/LuaHub_System_UInt64.cs",                                      "Lua/LuaHubSub/LuaHub_System_UInt64.cs" },
        };


        private string ExportPath = string.Empty;

        void OnGUI()
        {
            ExportPath = EditorGUILayout.TextField("导出路径:", ExportPath);
            if (GUILayout.Button("导出路径选择"))
            {
                var path = EditorUtility.OpenFolderPanel("Select export folder", ExportPath, "");
                if (!string.IsNullOrEmpty(path))
                {
                    ExportPath = path;
                }
            }

            GUI.enabled = !string.IsNullOrEmpty(ExportPath);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("导出"))
            {
                DoExport(ExportPath);
            }
            if (GUILayout.Button("导入"))
            {
                DoImport(ExportPath);
            }
            GUILayout.EndHorizontal();
            GUI.enabled = true;
        }

        private static string CheckExportPath(string exportPath)
        {
            if (exportPath == null)
            {
                return null;
            }
            while (exportPath.EndsWith("\\") || exportPath.EndsWith("/"))
            {
                exportPath = exportPath.Substring(0, exportPath.Length - 1);
            }
            var last = System.IO.Path.GetFileName(exportPath);
            if (last.Equals("~lualib~", StringComparison.InvariantCultureIgnoreCase))
            {
                exportPath = System.IO.Path.GetDirectoryName(exportPath);
            }
            if (System.IO.File.Exists(exportPath + "/.lualibexport"))
            {
                return exportPath + "/";
            }
            if (string.IsNullOrEmpty(exportPath))
            {
                return "~lualib~/";
            }
            else
            {
                return exportPath + "/~lualib~/";
            }
        }
        public static void DoExport(string exportPath)
        {
            exportPath = CheckExportPath(exportPath);
            if (exportPath == null)
            {
                return;
            }
            if (System.IO.Directory.Exists(exportPath))
            {
                try
                {
                    System.IO.Directory.Delete(exportPath, true);
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
            }
            System.IO.Directory.CreateDirectory(exportPath);

            foreach (var kvp in LuaLibFileMap)
            {
                var dest = exportPath + kvp.Value;
                PlatDependant.CopyFile(kvp.Key, dest);
            }
            EditorUtility.RevealInFinder(exportPath);
        }
        private static string CheckImportPath(string importPath)
        {
            if (importPath == null)
            {
                return null;
            }
            while (importPath.EndsWith("\\") || importPath.EndsWith("/"))
            {
                importPath = importPath.Substring(0, importPath.Length - 1);
            }
            var last = System.IO.Path.GetFileName(importPath);
            if (last.Equals("~lualib~", StringComparison.InvariantCultureIgnoreCase))
            {
                return importPath + "/";
            }
            if (System.IO.Directory.Exists(importPath + "/~lualib~"))
            {
                return importPath + "/~lualib~/";
            }
            else
            {
                return importPath + "/";
            }
        }
        public static void DoImport(string importPath)
        {
            importPath = CheckImportPath(importPath);
            if (importPath == null)
            {
                return;
            }
            if (!System.IO.Directory.Exists(importPath))
            {
                return;
            }

            foreach (var kvp in LuaLibFileMap)
            {
                var ex = importPath + kvp.Value;
                if (System.IO.File.Exists(ex))
                {
                    PlatDependant.CopyFile(ex, kvp.Key);
                }
            }
        }
    }
}