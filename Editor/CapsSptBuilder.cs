﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Capstones.UnityEngineEx;
using Capstones.LuaLib;

namespace Capstones.UnityEditorEx
{
    public static class CapsSptBuilder
    {
        public enum BuildScriptResult
        {
            Fail = 0,
            Success = 1,
            UpToDate = 2,
        }
        public static BuildScriptResult BuildScript(string file, string dest, int arch)
        {
            var srcFileHash = CapsEditorUtils.GetFileMD5(file) + "-" + CapsEditorUtils.GetFileLength(file);
            var infofile = dest + ".srcinfo";
            if (PlatDependant.IsFileExist(infofile) && PlatDependant.IsFileExist(dest))
            {
                string dstFileHash = "";
                using (var sr = PlatDependant.OpenReadText(infofile))
                {
                    dstFileHash = sr.ReadLine();
                }
                if (!string.IsNullOrEmpty(dstFileHash))
                {
                    if (dstFileHash == srcFileHash + "-" + CapsEditorUtils.GetFileMD5(dest) + "-" + CapsEditorUtils.GetFileLength(dest))
                    {
                        return BuildScriptResult.UpToDate;
                    }
                }
            }

            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(dest));
            System.IO.File.Delete(dest);
            System.IO.File.Delete(infofile);

            bool success = false;
            if (arch == 32)
            {
                success = BuildScriptSub_32(file, dest);
            }
            else
            {
                success = BuildScriptSub_64(file, dest);
            }

            if (success && PlatDependant.IsFileExist(dest))
            {
                using (var sw = PlatDependant.OpenWriteText(infofile))
                {
                    sw.Write(srcFileHash + "-" + CapsEditorUtils.GetFileMD5(dest) + "-" + CapsEditorUtils.GetFileLength(dest));
                }
                return BuildScriptResult.Success;
            }

            BuildScriptSub_RawCopy(file, dest);
            return BuildScriptResult.Fail;
        }
        private static void BuildScriptSub_RawCopy(string src, string dest)
        {
            // make a as-it-is copy.
            System.IO.File.Copy(src, dest, true);
        }
        private static string _ThisMod;
        private static string ThisMod
        {
            get
            {
                if (_ThisMod == null)
                {
                    _ThisMod = CapsEditorUtils.__MOD__;
                }
                return _ThisMod;
            }
        }
        private static string _ToolsDir;
        private static string ToolsDir
        {
            get
            {
                if (_ToolsDir == null)
                {
                    _ToolsDir = System.IO.Path.GetFullPath(CapsModEditor.GetPackageOrModRoot(ThisMod)) + "/~Tools~/";
                }
                return _ToolsDir;
            }
        }

        private static bool BuildScriptSub_64(string src, string dest)
        {
            var filefull = System.IO.Path.GetFullPath(src);
            var destfull = System.IO.Path.GetFullPath(dest);

            string luajitPath = "";
            string workingDirectory = "";
#if UNITY_EDITOR_WIN
            workingDirectory = ToolsDir + "luajit-2.1.0-beta3/x64";
            luajitPath = workingDirectory + "/luajit.exe";
#elif UNITY_EDITOR_OSX
            workingDirectory = ToolsDir + "luajit-2.1.0-beta3/x64";
            luajitPath = workingDirectory + "/luajit";
#endif
            if (!string.IsNullOrEmpty(luajitPath))
            {
                System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo(luajitPath, "-b -s \"" + filefull + "\" \"" + destfull + "\"");
                si.WorkingDirectory = workingDirectory;
                return CapsEditorUtils.ExecuteProcess(si);
            }
            return false;
        }
        private static bool BuildScriptSub_32(string src, string dest)
        {
            var filefull = System.IO.Path.GetFullPath(src);
            var destfull = System.IO.Path.GetFullPath(dest);

            string luajitPath = "";
            string workingDirectory = "";
#if UNITY_EDITOR_WIN
            workingDirectory = ToolsDir + "luajit-2.1.0-beta3/x86";
            luajitPath = workingDirectory + "/luajit.exe";
#elif UNITY_EDITOR_OSX
            workingDirectory = ToolsDir + "luajit-2.1.0-beta3/x86";
            luajitPath = workingDirectory + "/luajit";
#endif
            if (!string.IsNullOrEmpty(luajitPath))
            {
                System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo(luajitPath, "-b -s \"" + filefull + "\" \"" + destfull + "\"");
                si.WorkingDirectory = workingDirectory;
                return CapsEditorUtils.ExecuteProcess(si);
            }
            return false;
        }

        public class CapsSptBuildWork
        {
            public struct CapsSptBuildItem
            {
                public string Norm;
                public string Mod;
                public string ModRoot;
                public string PackageName;
                public string Dist;
                public string Dest; // NOTICE: if you use Dest, the Norm will not be modified by Mod&Dist, Norm will be used as Src.

                public string GetSource()
                {
                    if (string.IsNullOrEmpty(Dest))
                    {
                        var name = Norm ?? "";
                        if (!string.IsNullOrEmpty(Dist))
                        {
                            name = "dist/" + Dist + "/" + name;
                        }
                        if (string.IsNullOrEmpty(Mod))
                        {
                            return "Assets/CapsSpt/" + name;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(ModRoot))
                            {
                                return ModRoot + "/CapsSpt/" + name;
                            }
                            else
                            {
                                return "Assets/Mods/" + Mod + "/CapsSpt/" + name;
                            }
                        }
                    }
                    else
                    {
                        return Norm;
                    }
                }
                public string GetSourceAsset()
                {
                    if (string.IsNullOrEmpty(Dest))
                    {
                        var name = Norm ?? "";
                        if (!string.IsNullOrEmpty(Dist))
                        {
                            name = "dist/" + Dist + "/" + name;
                        }
                        if (string.IsNullOrEmpty(Mod))
                        {
                            return "Assets/CapsSpt/" + name;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(PackageName))
                            {
                                return "Packages/" + PackageName + "/CapsSpt/" + name;
                            }
                            else
                            {
                                return "Assets/Mods/" + Mod + "/CapsSpt/" + name;
                            }
                        }
                    }
                    else
                    {
                        return Norm;
                    }
                }
                public string GetDest()
                {
                    if (string.IsNullOrEmpty(Dest))
                    {
                        var name = Norm ?? "";
                        if (!string.IsNullOrEmpty(Dist))
                        {
                            name = "dist/" + Dist + "/" + name;
                        }
                        if (string.IsNullOrEmpty(Mod))
                        {
                            return name;
                        }
                        else
                        {
                            return "mod/" + Mod + "/" + name;
                        }
                    }
                    else
                    {
                        return Dest;
                    }
                }
                public string GetDest(int arch)
                {
                    if (string.IsNullOrEmpty(Dest))
                    {
                        var name = Norm ?? "";
                        if (!string.IsNullOrEmpty(Dist))
                        {
                            name = "dist/" + Dist + "/" + name;
                        }
                        if (string.IsNullOrEmpty(Mod))
                        {
                            return "@" + arch + "/" + name;
                        }
                        else
                        {
                            return "@" + arch + "/" + "mod/" + Mod + "/" + name;
                        }
                    }
                    else
                    {
                        return Dest;
                    }
                }
            }

            public readonly List<CapsSptBuildItem> Files = new List<CapsSptBuildItem>();
            public string OutputDir;
            public string OutputExt = ".lua";
            public bool RawCopy = false;

            public Action OnDone = null;

            private int NextFileIndex = 0;
            private volatile int DoneCount = 0;
            private BuildScriptResult?[] Results;
            private System.Threading.AutoResetEvent BuildDone = new System.Threading.AutoResetEvent(false);

            public bool IsMultiArchBuild
            {
                get
                {
#if UNITY_ANDROID
                    return true;
#else
                    return false;
#endif
                }
            }
#if UNITY_ANDROID
            private static readonly int[] _MultiBuildArchs = new[] { 32, 64 };
#else
            private static readonly int[] _MultiBuildArchs = new int[0];
#endif
            public int[] MultiBuildArchs
            {
                get { return _MultiBuildArchs; }
            }

            public void StartWork()
            {
                PlatDependant.LogInfo("Start Build Work");
                Results = new BuildScriptResult?[Files.Count];
                int cpucnt = System.Environment.ProcessorCount;
                for (int i = 0; i < cpucnt; ++i)
                {
                    PlatDependant.RunBackground(BuildWork);
                }
            }
            public IEnumerator WaitForWorkDone(IEditorWorkProgressShower win)
            {
                if (win == null)
                {
                    int doneindex = 0;
                    int donecnt = 0;
                    while (doneindex < Results.Length)
                    {
                        if (donecnt < DoneCount || BuildDone.WaitOne())
                        {
                            while (doneindex < Results.Length && Results[doneindex] != null)
                            {
                                var result = Results[doneindex] ?? BuildScriptResult.Fail;
                                var file = Files[doneindex];
                                var mess = file.GetDest() + " : " + result.ToString();
                                if (result == BuildScriptResult.Fail)
                                {
                                    Debug.LogError(mess);
                                }
                                else
                                {
                                    Debug.Log(mess);
                                }
                                ++doneindex;
                            }
                            donecnt = doneindex;
                            for (int i = doneindex + 1; i < Results.Length; ++i)
                            {
                                if (Results[i] != null)
                                {
                                    ++donecnt;
                                }
                            }
                        }
                    }
                }
                else
                {
                    int doneindex = 0;
                    int donecnt = 0;
                    while (doneindex < Results.Length)
                    {
                        if (donecnt < DoneCount || BuildDone.WaitOne(0))
                        {
                            while (doneindex < Results.Length && Results[doneindex] != null)
                            {
                                var result = Results[doneindex] ?? BuildScriptResult.Fail;
                                var file = Files[doneindex];
                                var mess = file.GetDest() + " : " + result.ToString();
                                if (result == BuildScriptResult.Fail)
                                {
                                    win.Message = mess;
                                    Debug.LogError(mess);
                                }
                                else
                                {
                                    win.Message = mess;
                                    Debug.Log(mess);
                                }
                                ++doneindex;
                                if (AsyncWorkTimer.Check()) yield return null;
                            }
                            donecnt = doneindex;
                            for (int i = doneindex + 1; i < Results.Length; ++i)
                            {
                                if (Results[i] != null)
                                {
                                    ++donecnt;
                                }
                            }
                            if (AsyncWorkTimer.Check()) yield return null;
                        }
                        else
                        {
                            yield return null;
                        }
                    }
                }
            }

            private void BuildWork(TaskProgress prog)
            {
                while (true)
                {
                    var index = System.Threading.Interlocked.Increment(ref NextFileIndex) - 1;
                    if (index >= Files.Count)
                    {
                        return;
                    }
                    var item = Files[index];
                    BuildScriptResult result = BuildScriptResult.Fail;
                    try
                    {
                        if (string.IsNullOrEmpty(item.Norm))
                        {
                            result = BuildScriptResult.UpToDate;
                        }
                        else
                        {
                            var src = item.GetSource();
                            if (System.IO.File.Exists(src))
                            {
                                var dst = item.GetDest() ?? "";
                                if (dst.EndsWith(".lua"))
                                {
                                    dst = dst.Substring(0, dst.Length - ".lua".Length);
                                }
                                dst += OutputExt;
                                if (!string.IsNullOrEmpty(OutputDir))
                                {
                                    dst = OutputDir + dst;
                                }
                                else if (string.IsNullOrEmpty(item.Dest))
                                {
                                    dst = "Assets/StreamingAssets/spt/" + dst;
                                }

                                if (RawCopy)
                                {
                                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(dst));
                                    System.IO.File.Delete(dst);
                                    System.IO.File.Delete(dst + ".srcinfo");
                                    BuildScriptSub_RawCopy(src, dst);
                                    result = BuildScriptResult.Success;
                                }
                                else
                                {
                                    if (IsMultiArchBuild)
                                    {
                                        var archs = MultiBuildArchs;
                                        int mresult = int.MaxValue;
                                        for (int i = 0; i < archs.Length; ++i)
                                        {
                                            var arch = archs[i];
                                            dst = item.GetDest(arch) ?? "";
                                            if (dst.EndsWith(".lua"))
                                            {
                                                dst = dst.Substring(0, dst.Length - ".lua".Length);
                                            }
                                            dst += OutputExt;
                                            if (!string.IsNullOrEmpty(OutputDir))
                                            {
                                                dst = OutputDir + dst;
                                            }
                                            else if (string.IsNullOrEmpty(item.Dest))
                                            {
                                                dst = "Assets/StreamingAssets/spt/" + dst;
                                            }

                                            var presult = (int)BuildScript(src, dst, arch);
                                            mresult = Math.Min(mresult, presult);
                                        }
                                        result = (BuildScriptResult)mresult;
                                    }
                                    else
                                    {
                                        result = BuildScript(src, dst, 64);
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        Results[index] = result;
                        ++DoneCount;
                        BuildDone.Set();
                    }
                }
            }

            public void DeleteNonBuildOldFiles()
            {
                HashSet<string> buildFiles = new HashSet<string>();
                for (int i = 0; i < Files.Count; ++i)
                {
                    var item = Files[i];
                    var dst = item.GetDest() ?? "";
                    if (dst.EndsWith(".lua"))
                    {
                        dst = dst.Substring(0, dst.Length - ".lua".Length);
                    }
                    dst += OutputExt;
                    if (!string.IsNullOrEmpty(OutputDir))
                    {
                        dst = OutputDir + dst;
                    }
                    else if (string.IsNullOrEmpty(item.Dest))
                    {
                        dst = "Assets/StreamingAssets/spt/" + dst;
                    }

                    if (RawCopy || !IsMultiArchBuild)
                    {
                        buildFiles.Add(dst.Replace('\\', '/'));
                    }
                    else
                    {
                        var archs = MultiBuildArchs;
                        int mresult = int.MaxValue;
                        for (int j = 0; j < archs.Length; ++j)
                        {
                            var arch = archs[j];
                            dst = item.GetDest(arch) ?? "";
                            if (dst.EndsWith(".lua"))
                            {
                                dst = dst.Substring(0, dst.Length - ".lua".Length);
                            }
                            dst += OutputExt;
                            if (!string.IsNullOrEmpty(OutputDir))
                            {
                                dst = OutputDir + dst;
                            }
                            else if (string.IsNullOrEmpty(item.Dest))
                            {
                                dst = "Assets/StreamingAssets/spt/" + dst;
                            }

                            buildFiles.Add(dst.Replace('\\', '/'));
                        }
                    }
                }

                string outputdir = OutputDir;
                if (string.IsNullOrEmpty(outputdir))
                {
                    outputdir = "Assets/StreamingAssets/spt/";
                }
                if (System.IO.Directory.Exists(outputdir))
                {
                    var files = PlatDependant.GetAllFiles(outputdir);
                    for (int i = 0; i < files.Length; ++i)
                    {
                        var file = files[i].Replace('\\', '/');
                        if (file.EndsWith(OutputExt) && !buildFiles.Contains(file))
                        {
                            PlatDependant.DeleteFile(file);
                            PlatDependant.DeleteFile(file + ".srcinfo");
                        }
                    }
                }
            }

            public CapsResManifest[] GenerateManifests()
            {
                Dictionary<string, Dictionary<string, CapsResManifest>> mod2mani = new Dictionary<string, Dictionary<string, CapsResManifest>>();
                for (int i = 0; i < Files.Count; ++i)
                {
                    var item = Files[i];
                    if (!string.IsNullOrEmpty(item.Norm))
                    {
                        var mod = item.Mod ?? "";
                        var dist = item.Dist ?? "";

                        Dictionary<string, CapsResManifest> manis;
                        if (!mod2mani.TryGetValue(mod, out manis))
                        {
                            manis = new Dictionary<string, CapsResManifest>();
                            mod2mani[mod] = manis;
                        }
                        CapsResManifest mani;
                        if (!manis.TryGetValue(dist, out mani))
                        {
                            mani = new CapsResManifest();
                            mani.MFlag = mod;
                            mani.DFlag = dist;
                            manis[dist] = mani;
                        }
                        mani.AddOrGetItem(item.GetSourceAsset());
                    }
                }
                List<CapsResManifest> result = new List<CapsResManifest>();
                foreach (var mmani in mod2mani)
                {
                    result.AddRange(mmani.Value.Values);
                }
                return result.ToArray();
            }
        }
        public interface ISptBuilderEx
        {
            void PreGenerateBuildWork(CapsSptBuildWork buildwork);
            void ModifyBuildWork(CapsSptBuildWork buildwork);
        }
        public static readonly List<ISptBuilderEx> SptBuilderEx = new List<ISptBuilderEx>();
        public class SptBuilderEx_RawCopy : ISptBuilderEx
        {
            public void PreGenerateBuildWork(CapsSptBuildWork buildwork)
            {
                buildwork.RawCopy = true;
            }
            public void ModifyBuildWork(CapsSptBuildWork buildwork)
            {
            }
        }

        public static IEnumerator GenerateBuildWorkAsync(CapsSptBuildWork result, IList<string> scripts, IEditorWorkProgressShower winprog)
        {
            return GenerateBuildWorkAsync(result, scripts, winprog, null);
        }
        public static IEnumerator GenerateBuildWorkAsync(CapsSptBuildWork result, IList<string> scripts, IEditorWorkProgressShower winprog, IList<ISptBuilderEx> runOnceBuilderEx)
        {
            List<ISptBuilderEx> allBuilderEx = new List<ISptBuilderEx>(SptBuilderEx);
            if (runOnceBuilderEx != null)
            {
                allBuilderEx.AddRange(runOnceBuilderEx);
            }

            var logger = new EditorWorkProgressLogger() { Shower = winprog };
            logger.Log("(Start) Generate Spt Build Work.");
            if (winprog != null && AsyncWorkTimer.Check()) yield return null;

            if (result == null)
            {
                logger.Log("(Error) You have to provide container to retrive the result.");
                yield break;
            }

            for (int j = 0; j < allBuilderEx.Count; ++j)
            {
                allBuilderEx[j].PreGenerateBuildWork(result);
            }

            result.Files.Clear();

            if (scripts == null)
            {
                logger.Log("(Option) Get All Scripts.");
                scripts = AssetDatabase.GetAllAssetPaths();
                if (winprog != null && AsyncWorkTimer.Check()) yield return null;
            }

            if (scripts != null)
            {
                Dictionary<string, CapsSptBuildWork.CapsSptBuildItem> workitems = new Dictionary<string, CapsSptBuildWork.CapsSptBuildItem>();
                for (int i = 0; i < scripts.Count; ++i)
                {
                    if (winprog != null && AsyncWorkTimer.Check()) yield return null;
                    var script = scripts[i];
                    if (!script.EndsWith(".lua"))
                    {
                        continue;
                    }
                    logger.Log(script);

                    if (!System.IO.File.Exists(script))
                    {
                        logger.Log("Not Exist.");
                        continue;
                    }

                    string mod = null;
                    string dist = null;
                    string norm = script;
                    string package = null;
                    if (script.StartsWith("Assets/Mods/"))
                    {
                        var sub = script.Substring("Assets/Mods/".Length);
                        var index = sub.IndexOf('/');
                        if (index < 0)
                        {
                            logger.Log("Cannot Parse Module.");
                            continue;
                        }
                        mod = sub.Substring(0, index);
                        if (string.IsNullOrEmpty(mod))
                        {
                            logger.Log("Empty Module.");
                            continue;
                        }
                        sub = sub.Substring(index + 1);
                        if (!sub.StartsWith("CapsSpt/"))
                        {
                            logger.Log("Should Ignore This Script.");
                            continue;
                        }

                        sub = sub.Substring("CapsSpt/".Length);
                        norm = sub;
                        if (sub.StartsWith("dist/"))
                        {
                            sub = sub.Substring("dist/".Length);
                            index = sub.IndexOf('/');
                            if (index > 0)
                            {
                                dist = sub.Substring(0, index);
                                norm = sub.Substring(index + 1);
                            }
                        }
                    }
                    else if (script.StartsWith("Packages/"))
                    {
                        var sub = script.Substring("Packages/".Length);
                        var index = sub.IndexOf('/');
                        if (index < 0)
                        {
                            logger.Log("Cannot Parse Package.");
                            continue;
                        }
                        package = sub.Substring(0, index);
                        if (string.IsNullOrEmpty(package))
                        {
                            logger.Log("Empty Package Name.");
                            continue;
                        }
                        sub = sub.Substring(index + 1);
                        if (!sub.StartsWith("CapsSpt/"))
                        {
                            logger.Log("Should Ignore This Script.");
                            continue;
                        }

                        sub = sub.Substring("CapsSpt/".Length);
                        norm = sub;
                        if (sub.StartsWith("dist/"))
                        {
                            sub = sub.Substring("dist/".Length);
                            index = sub.IndexOf('/');
                            if (index > 0)
                            {
                                dist = sub.Substring(0, index);
                                norm = sub.Substring(index + 1);
                            }
                        }
                    }
                    else
                    {
                        if (script.StartsWith("Assets/CapsSpt/"))
                        {
                            mod = "";
                            var sub = script.Substring("Assets/CapsSpt/".Length);
                            norm = sub;
                            if (sub.StartsWith("dist/"))
                            {
                                sub = sub.Substring("dist/".Length);
                                var index = sub.IndexOf('/');
                                if (index > 0)
                                {
                                    dist = sub.Substring(0, index);
                                    norm = sub.Substring(index + 1);
                                }
                            }
                        }
                        else
                        {
                            logger.Log("Should Ignore This Script.");
                            continue;
                        }
                    }

                    if (string.IsNullOrEmpty(norm))
                    {
                        logger.Log("Normallized Path Empty.");
                        continue;
                    }
                    mod = mod ?? "";
                    dist = dist ?? "";
                    if (package == null)
                    {
                        logger.Log("Mod " + mod + "; Dist " + dist + "; Norm " + norm);
                    }
                    else
                    {
                        mod = CapsModEditor.GetPackageModName(package) ?? "";
                        logger.Log("Package " + package + "; Mod " + mod + "; Dist " + dist + "; Norm " + norm);
                    }

                    CapsSptBuildWork.CapsSptBuildItem item = new CapsSptBuildWork.CapsSptBuildItem()
                    {
                        Norm = norm,
                        Mod = mod,
                        Dist = dist,
                    };
                    if (package != null)
                    {
                        item.PackageName = package;
                        item.ModRoot = CapsModEditor.GetPackageRoot(package);
                    }

                    var dst = item.GetDest();
                    if (!workitems.ContainsKey(dst) || !string.IsNullOrEmpty(item.Mod) && string.IsNullOrEmpty(workitems[dst].PackageName))
                    {
                        workitems[dst] = item;
                    }
                }

                result.Files.AddRange(workitems.Values);
            }

            for (int j = 0; j < allBuilderEx.Count; ++j)
            {
                allBuilderEx[j].ModifyBuildWork(result);
            }
            logger.Log("(Done) Generate Spt Build Work.");
        }

        public static IEnumerator BuildSptAsync(IList<string> scripts, IEditorWorkProgressShower winprog)
        {
            return BuildSptAsync(scripts, winprog, null);
        }
        public static IEnumerator BuildSptAsync(IList<string> scripts, IEditorWorkProgressShower winprog, IList<ISptBuilderEx> runOnceBuilderEx)
        {
            bool isDefaultBuild = scripts == null;
            var logger = new EditorWorkProgressLogger() { Shower = winprog };
            bool shouldCreateBuildingParams = CapsResBuilder.BuildingParams == null;
            CapsResBuilder.BuildingParams = CapsResBuilder.BuildingParams ?? CapsResBuilder.ResBuilderParams.Create();
            var timetoken = CapsResBuilder.BuildingParams.timetoken;
            var makezip = CapsResBuilder.BuildingParams.makezip;
            string outputDir = "Latest";
            if (!isDefaultBuild)
            {
                outputDir = timetoken + "/build";
            }
            outputDir = "EditorOutput/Build/" + outputDir;

            System.IO.StreamWriter swlog = null;
            try
            {
                System.IO.Directory.CreateDirectory(outputDir + "/log/");
                swlog = new System.IO.StreamWriter(outputDir + "/log/SptBuildLog.txt", false, System.Text.Encoding.UTF8);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

            Application.LogCallback LogToFile = (message, stack, logtype) =>
            {
                swlog.WriteLine(message);
                swlog.Flush();
            };
            if (swlog != null)
            {
                Application.logMessageReceived += LogToFile;
            }
            bool cleanupDone = false;
            Action BuilderCleanup = () =>
            {
                if (!cleanupDone)
                {
                    logger.Log("(Phase) Build Spt Cleaup.");
                    cleanupDone = true;
                    logger.Log("(Done) Build Spt Cleaup.");
                    if (swlog != null)
                    {
                        Application.logMessageReceived -= LogToFile;
                        swlog.Flush();
                        swlog.Dispose();

                        if (isDefaultBuild)
                        {
                            var logdir = "EditorOutput/Build/" + timetoken + "/log/";
                            System.IO.Directory.CreateDirectory(logdir);
                            System.IO.File.Copy(outputDir + "/log/SptBuildLog.txt", logdir + "SptBuildLog.txt", true);
                        }
                    }
                    if (shouldCreateBuildingParams)
                    {
                        CapsResBuilder.BuildingParams = null;
                    }
                }
            };
            if (winprog != null) winprog.OnQuit += BuilderCleanup;

            try
            {
                logger.Log("(Start) Build Spt.");
                if (winprog != null && AsyncWorkTimer.Check()) yield return null;

                // Generate Build Work
                CapsSptBuildWork buildwork = new CapsSptBuildWork();
                buildwork.OutputDir = outputDir + "/spt/";
                var work = GenerateBuildWorkAsync(buildwork, scripts, winprog, runOnceBuilderEx);
                while (work.MoveNext())
                {
                    if (winprog != null)
                    {
                        yield return work.Current;
                    }
                }
                // Fire Build Work
                logger.Log("(Start) Run Build Spt (On ThreadPool)!");
                buildwork.StartWork();

                //// Maybe we donot need the manifest, we can build one on first startup.
                //// We can save the runtime manifest in json file, but we should test the speed of loading the manifest from json file.
                //// If it is too slow to load the manifest from json file, maybe we need this again.
                //// Or we should find the file at runtime (as we do before).
                //logger.Log("(Phase) Write Spt Manifest.");
                //var managermod = CapsEditorUtils.__MOD__;
                //var manidir = "Assets/Mods/" + managermod + "/Build/";
                //System.IO.Directory.CreateDirectory(manidir);
                //List<AssetBundleBuild> listManiBuilds = new List<AssetBundleBuild>();
                //HashSet<string> maniFileNames = new HashSet<string>();
                //foreach (var kvp in works)
                //{
                //    var mod = kvp.Key;
                //    foreach (var mani in kvp.Value.Manifests)
                //    {
                //        var dist = mani.DFlag;
                //        if (winprog != null && AsyncWorkTimer.Check()) yield return null;
                //        logger.Log("Mod " + mod + "; Dist " + dist);

                //        var dmani = CapsResManifest.Save(mani);
                //        var filename = "m-" + mod + "-d-" + dist;
                //        var manipath = manidir + filename + ".m.asset";
                //        AssetDatabase.CreateAsset(dmani, manipath);

                //        maniFileNames.Add(filename.ToLower());
                //        listManiBuilds.Add(new AssetBundleBuild() { assetBundleName = filename + ".m.ab", assetNames = new[] { manipath } });
                //    }
                //}

                //logger.Log("(Phase) Build Manifest.");
                //if (winprog != null && AsyncWorkTimer.Check()) yield return null;
                //var buildopt = BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression;
                //BuildTarget buildtar = EditorUserBuildSettings.activeBuildTarget;
                //var outmanidir = outputDir + "/res/mani";
                //System.IO.Directory.CreateDirectory(outmanidir);
                //BuildPipeline.BuildAssetBundles(outmanidir, listManiBuilds.ToArray(), buildopt, buildtar);

                //logger.Log("(Phase) Delete Unused Manifest.");
                //if (winprog != null && AsyncWorkTimer.Check()) yield return null;
                //var manifiles = PlatDependant.GetAllFiles(outmanidir);
                //for (int i = 0; i < manifiles.Length; ++i)
                //{
                //    var file = manifiles[i];
                //    if (file.EndsWith(".m.ab"))
                //    {
                //        var filename = file.Substring(outmanidir.Length + 1, file.Length - outmanidir.Length - 1 - ".m.ab".Length);
                //        if (!maniFileNames.Contains(filename))
                //        {
                //            PlatDependant.DeleteFile(file);
                //            PlatDependant.DeleteFile(file + ".manifest");
                //        }
                //    }
                //}

                logger.Log("(Phase) Delete Old Build Whose Source File Has Been Deleted.");
                buildwork.DeleteNonBuildOldFiles();

                logger.Log("(Phase) Delete Mod Folder Not Built.");
                var builtMods = new HashSet<string>();
                for (int i = 0; i < buildwork.Files.Count; ++i)
                {
                    var mod = buildwork.Files[i].Mod;
                    builtMods.Add(mod ?? "");
                }
                List<string> dstsptRoots = new List<string>();
                if (buildwork.RawCopy || !buildwork.IsMultiArchBuild)
                {
                    dstsptRoots.Add("/spt/");
                    if (System.IO.Directory.Exists(outputDir + "/spt/"))
                    {
                        var subsptfolders = System.IO.Directory.GetDirectories(outputDir + "/spt/");
                        if (subsptfolders != null)
                        {
                            for (int i = 0; i < subsptfolders.Length; ++i)
                            {
                                var subfolder = subsptfolders[i];
                                if (subfolder.StartsWith(outputDir + "/spt/@", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    var sub = subfolder.Substring(outputDir.Length + "/spt/@".Length);
                                    var index = sub.IndexOfAny(new[] { '/', '\\' });
                                    if (index > 0)
                                    {
                                        sub = sub.Substring(0, index);
                                    }
                                    int arch;
                                    if (int.TryParse(sub, out arch))
                                    {
                                        System.IO.Directory.Delete(subfolder, true);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    var archs = buildwork.MultiBuildArchs;
                    for (int i = 0; i < archs.Length; ++i)
                    {
                        var arch = archs[i];
                        dstsptRoots.Add("/spt/@" + arch + "/");
                    }
                    if (System.IO.Directory.Exists(outputDir + "/spt/mod/"))
                    {
                        System.IO.Directory.Delete(outputDir + "/spt/mod/", true);
                    }
                }
                for (int j = 0; j < dstsptRoots.Count; ++j)
                {
                    var outmoddir = outputDir + dstsptRoots[j] + "mod/";
                    if (System.IO.Directory.Exists(outmoddir))
                    {
                        if (builtMods.Count == 0 || builtMods.Count == 1 && builtMods.Contains(""))
                        {
                            System.IO.Directory.Delete(outmoddir, true);
                        }
                        else
                        {
                            var allModFolders = System.IO.Directory.GetDirectories(outmoddir);
                            for (int i = 0; i < allModFolders.Length; ++i)
                            {
                                if (winprog != null && AsyncWorkTimer.Check()) yield return null;
                                var modfolder = allModFolders[i];
                                logger.Log(modfolder);
                                var mod = modfolder.Substring(outmoddir.Length);
                                if (!builtMods.Contains(mod))
                                {
                                    System.IO.Directory.Delete(modfolder, true);
                                }
                            }
                        }
                    }

                    //var samoddir = "Assets/StreamingAssets" + dstsptRoots[j] + "mod/";
                    //if (System.IO.Directory.Exists(samoddir))
                    //{
                    //    logger.Log("(Phase) Delete StreamingAssets Mod Folder Not Built.");
                    //    if (builtMods.Count == 0 || builtMods.Count == 1 && builtMods.Contains(""))
                    //    {
                    //        System.IO.Directory.Delete(samoddir, true);
                    //    }
                    //    else
                    //    {
                    //        var allModFolders = System.IO.Directory.GetDirectories(samoddir);
                    //        for (int i = 0; i < allModFolders.Length; ++i)
                    //        {
                    //            if (winprog != null && AsyncWorkTimer.Check()) yield return null;
                    //            var modfolder = allModFolders[i];
                    //            logger.Log(modfolder);
                    //            var mod = modfolder.Substring(samoddir.Length);
                    //            if (!builtMods.Contains(mod))
                    //            {
                    //                System.IO.Directory.Delete(modfolder, true);
                    //            }
                    //        }
                    //    }
                    //}
                }

                if (isDefaultBuild)
                {
                    logger.Log("(Phase) Write Version.");
                    int version = CapsResBuilder.GetResVersion();

                    int lastBuildVersion = 0;
                    int streamingVersion = 0;
                    var outverdir = "EditorOutput/Build/Latest/spt/version.txt";

                    if (System.IO.File.Exists("Assets/StreamingAssets/spt/version.txt"))
                    {
                        var lines = System.IO.File.ReadAllLines("Assets/StreamingAssets/spt/version.txt");
                        if (lines != null && lines.Length > 0)
                        {
                            int.TryParse(lines[0], out streamingVersion);
                        }
                    }
                    if (System.IO.File.Exists(outverdir))
                    {
                        var lines = System.IO.File.ReadAllLines(outverdir);
                        if (lines != null && lines.Length > 0)
                        {
                            int.TryParse(lines[0], out lastBuildVersion);
                        }
                    }
                    if (streamingVersion > 0 || lastBuildVersion <= 0)
                    {
                        int maxver = Math.Max(lastBuildVersion, streamingVersion);
                        if (maxver >= version)
                        {
                            version = maxver + 10;
                        }
                    }
                    else
                    {
                        version = lastBuildVersion;
                    }
                    if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(outverdir)))
                    {
                        System.IO.File.WriteAllText(outverdir, version.ToString());
                    }
                }

                logger.Log("(Phase) Delete old scripts in Streaming Assets.");
                if (System.IO.Directory.Exists("Assets/StreamingAssets/spt/"))
                {
                    System.IO.Directory.Move("Assets/StreamingAssets/spt", "Assets/StreamingAssets/spt_temp");
                    System.IO.Directory.Delete("Assets/StreamingAssets/spt_temp/", true);
                    PlatDependant.CreateFolder("Assets/StreamingAssets/spt/");
                }

                logger.Log("(Phase) Wait For Build.");
                work = buildwork.WaitForWorkDone(winprog);
                while (work.MoveNext())
                {
                    if (winprog != null)
                    {
                        yield return work.Current;
                    }
                }


                logger.Log("(Phase) Copy.");
                var outsptdir = outputDir + "/spt/";
                if (System.IO.Directory.Exists(outsptdir))
                {
                    var allbuildfiles = PlatDependant.GetAllFiles(outsptdir);
                    for (int i = 0; i < allbuildfiles.Length; ++i)
                    {
                        if (winprog != null && AsyncWorkTimer.Check()) yield return null;
                        var srcfile = allbuildfiles[i];
                        if (srcfile.EndsWith(".srcinfo"))
                        {
                            continue;
                        }
                        var part = srcfile.Substring(outsptdir.Length);
                        logger.Log(part);
                        var destfile = "Assets/StreamingAssets/spt/" + part;
                        PlatDependant.CreateFolder(System.IO.Path.GetDirectoryName(destfile));
                        System.IO.File.Copy(srcfile, destfile);
                    }
                }

                if (isDefaultBuild && makezip)
                {
                    logger.Log("(Phase) Zip.");
                    List<Pack<string, string, IList<string>>> zips = new List<Pack<string, string, IList<string>>>();
                    var outzipdir = "EditorOutput/Build/" + timetoken + "/whole/spt/";
                    System.IO.Directory.CreateDirectory(outzipdir);
                    Dictionary<string, HashSet<string>> builtModsAndDists = new Dictionary<string, HashSet<string>>();
                    for (int i = 0; i < buildwork.Files.Count; ++i)
                    {
                        var mod = buildwork.Files[i].Mod ?? "";
                        var dist = buildwork.Files[i].Dist ?? "";

                        HashSet<string> dists;
                        if (!builtModsAndDists.TryGetValue(mod, out dists))
                        {
                            dists = new HashSet<string>();
                            builtModsAndDists[mod] = dists;
                        }
                        dists.Add(dist);
                    }
                    HashSet<string> InMainNonOptMods = new HashSet<string>();
                    foreach (var kvpModsAndDists in builtModsAndDists)
                    {
                        var mod = kvpModsAndDists.Key;
                        if (mod != "")
                        {
                            var moddesc = ResManager.GetDistributeDesc(mod);
                            if (moddesc == null || (moddesc.InMain && !moddesc.IsOptional))
                            {
                                InMainNonOptMods.Add(mod);
                            }
                        }
                    }
                    if (InMainNonOptMods.Count > 0)
                    {
                        if (!builtModsAndDists.ContainsKey(""))
                        {
                            builtModsAndDists[""] = new HashSet<string>();
                        }
                    }

                    foreach (var kvpModsAndDists in builtModsAndDists)
                    {
                        var mod = kvpModsAndDists.Key;
                        var dists = kvpModsAndDists.Value;
                        if (InMainNonOptMods.Contains(mod))
                        {
                            continue;
                        }
                        List<Pack<string, string>> lstModAndDist = new List<Pack<string, string>>();
                        foreach (var dist in dists)
                        {
                            lstModAndDist.Add(new Pack<string, string>(mod, dist));
                        }
                        if (mod == "")
                        {
                            foreach (var exmod in InMainNonOptMods)
                            {
                                foreach (var exdist in builtModsAndDists[exmod])
                                {
                                    lstModAndDist.Add(new Pack<string, string>(exmod, exdist));
                                }
                            }
                        }
                        for (int i = 0; i < lstModAndDist.Count; ++i)
                        {
                            var exmod = lstModAndDist[i].t1;
                            var dist = lstModAndDist[i].t2;

                            for (int j = 0; j < dstsptRoots.Count; ++j)
                            {
                                var sptFolder = outputDir + dstsptRoots[j];
                                if (exmod != "")
                                {
                                    sptFolder += "mod/";
                                    sptFolder += exmod;
                                    sptFolder += "/";
                                }
                                if (dist != "")
                                {
                                    sptFolder += "dist/";
                                    sptFolder += dist;
                                    sptFolder += "/";
                                }

                                List<string> entries = new List<string>();
                                if (System.IO.Directory.Exists(sptFolder))
                                {
                                    try
                                    {
                                        var files = PlatDependant.GetAllFiles(sptFolder);
                                        for (int k = 0; k < files.Length; ++k)
                                        {
                                            var file = files[k];
                                            if (file.EndsWith(".lua"))
                                            {
                                                var raw = file.Substring(sptFolder.Length).Replace('\\', '/');
                                                if (!(exmod == "" && raw.StartsWith("/mod/") || dist == "" && raw.StartsWith("/dist/")))
                                                {
                                                    var entry = file.Substring(outputDir.Length + 1);
                                                    entries.Add(entry);
                                                    entries.Add(entry + ".srcinfo");
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        logger.Log("(Error)(Not Critical)");
                                        logger.Log(e.ToString());
                                    }
                                }
                                if (entries.Count > 0)
                                {
                                    //// mani
                                    //var mani = "m-" + mod.ToLower() + "-d-" + dist.ToLower() + ".m.ab";
                                    //mani = "res/mani/" + mani;
                                    //entries.Add(mani);
                                    //entries.Add(mani + ".manifest");
                                    //entries.Add("res/mani/mani");
                                    //entries.Add("res/mani/mani.manifest");
                                    // version
                                    entries.Add("spt/version.txt");

                                    string zipfile;
                                    if (dstsptRoots[j] == "/spt/")
                                    {
                                        zipfile = outzipdir + "m-" + mod + "-d-" + dist + ".zip";
                                    }
                                    else
                                    {
                                        var sub = dstsptRoots[j].Substring("/spt/".Length, dstsptRoots[j].Length - "/spt/".Length - 1);
                                        zipfile = outzipdir + "m-" + mod + "-d-" + dist + "." + sub + ".zip";
                                    }
                                    zips.Add(new Pack<string, string, IList<string>>(zipfile, outputDir, entries));
                                    //var workz = CapsResBuilder.MakeZipAsync(zipfile, outputDir, entries, winprog);
                                    //while (workz.MoveNext())
                                    //{
                                    //    if (winprog != null)
                                    //    {
                                    //        yield return workz.Current;
                                    //    }
                                    //}
                                }
                            }
                        }
                    }
                    if (zips.Count > 0)
                    {
                        var workz = CapsResBuilder.MakeZipsBackground(zips, winprog);
                        while (workz.MoveNext())
                        {
                            if (winprog != null)
                            {
                                yield return workz.Current;
                            }
                        }
                    }
                }
            }
            finally
            {
                BuilderCleanup();
                logger.Log("(Done) Build Spt.");
            }
        }

        private class CapsSptBuilderPreExport : UnityEditor.Build.IPreprocessBuild
        {
            public int callbackOrder { get { return 0; } }
            private static HashSet<string> NonSptFiles = new HashSet<string>()
            {
                "manifest.m.txt",
                "index.txt",
                "version.txt",
                "ver.txt",
            };

            public void OnPreprocessBuild(BuildTarget target, string path)
            {
                CapsResManifest sptmani = new CapsResManifest();
                HashSet<string> keys = new HashSet<string>();
                HashSet<int> archs = new HashSet<int>();
                using (var sw = PlatDependant.OpenWriteText("Assets/StreamingAssets/spt/index.txt"))
                {
                    var files = PlatDependant.GetAllFiles("Assets/StreamingAssets/spt/");
                    if (files != null)
                    {
                        for (int i = 0; i < files.Length; ++i)
                        {
                            var file = files[i];
                            if (file.EndsWith(".meta"))
                            {
                                continue;
                            }
                            var part = file.Substring("Assets/StreamingAssets/spt/".Length);
                            if (NonSptFiles.Contains(part))
                            {
                                continue;
                            }
                            sptmani.AddOrGetItem(part);
                            if (part.StartsWith("@"))
                            {
                                var index = part.IndexOfAny(new[] { '/', '\\' });
                                if (index > 0)
                                {
                                    var dir0 = part.Substring(1, index - 1);
                                    int arch;
                                    if (int.TryParse(dir0, out arch))
                                    {
                                        archs.Add(arch);
                                        part = part.Substring(index + 1);
                                    }
                                }
                            }
                            string mod = "";
                            string dist = "";
                            if (part.StartsWith("mod/"))
                            {
                                var iend = part.IndexOf('/', "mod/".Length);
                                if (iend > 0)
                                {
                                    mod = part.Substring("mod/".Length, iend - "mod/".Length);
                                    part = part.Substring(iend + 1);
                                }
                            }
                            if (part.StartsWith("dist/"))
                            {
                                var iend = part.IndexOf('/', "dist/".Length);
                                if (iend > 0)
                                {
                                    dist = part.Substring("dist/".Length, iend - "dist/".Length);
                                }
                            }

                            if (mod != "")
                            {
                                var moddesc = ResManager.GetDistributeDesc(mod);
                                if (moddesc == null || (moddesc.InMain && !moddesc.IsOptional))
                                {
                                    mod = "";
                                }
                            }

                            var key = "m-" + (mod ?? "").ToLower() + "-d-" + (dist ?? "").ToLower();
                            if (keys.Add(key))
                            {
                                sw.WriteLine(key);
                            }
                        }
                    }
                }
                if (archs.Count > 0)
                {
                    foreach (var arch in archs)
                    {
                        sptmani.AddOrGetItem("@arch/@" + arch);
                    }
                }
                CapsLuaFileManager.SaveManifest(sptmani, "Assets/StreamingAssets/spt/manifest.m.txt");
            }
        }
    }
}