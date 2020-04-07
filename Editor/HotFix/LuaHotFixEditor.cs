using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using Capstones.UnityEngineEx;
using Capstones.LuaLib;
using Capstones.LuaExt;
using Capstones.LuaWrap;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

using Object = UnityEngine.Object;
using Types = Capstones.LuaLib.Types;

namespace Capstones.UnityEditorEx
{
    [InitializeOnLoad]
    public static class LuaHotFixWriter
    {
        public static Type GetLuaPackType(int paramCnt)
        {
            if (paramCnt <= 0)
            {
                return null;
            }
            var searchTypeName = "Capstones.LuaWrap.LuaPack`" + paramCnt;
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                var existing = asm.GetType(searchTypeName);
                if (existing != null)
                {
                    return existing;
                }
            }
            return null;
        }
        public static void GenerateLuaPackFile(int paramCnt)
        {
            if (paramCnt <= 0)
            {
                return;
            }
            //if (GetLuaPackType(paramCnt) != null)
            //{
            //    return;
            //}

            //string codefolder = "Assets/Mods/" + CapsEditorUtils.__MOD__ + "/LuaHotFix/";
            //string file = codefolder + "LuaPack" + paramCnt + ".cs";
            string file = "EditorOutput/LuaHotFix/LuaPack/" + "LuaPack" + paramCnt + ".cs";
            var sb = new System.Text.StringBuilder();
            sb.Clear();
            for (int i = 0; i < paramCnt; ++i)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append("T");
                sb.Append(i);
            }
            string gargs = sb.ToString();
            sb.Clear();
            for (int i = 0; i < paramCnt; ++i)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append("T");
                sb.Append(i);
                sb.Append(" p");
                sb.Append(i);
            }
            string pargs = sb.ToString();

            using (var sw = PlatDependant.OpenWriteText(file))
            {
                sw.WriteLine("using System;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using Capstones.LuaLib;");
                sw.WriteLine();
                sw.WriteLine("namespace Capstones.LuaWrap");
                sw.WriteLine("{");
                sw.Write("    public struct LuaPack<");
                sw.Write(gargs);
                sw.WriteLine("> : ILuaPack");
                sw.WriteLine("    {");
                for (int i = 0; i < paramCnt; ++i)
                {
                    sw.Write("        public T");
                    sw.Write(i);
                    sw.Write(" t");
                    sw.Write(i);
                    sw.WriteLine(";");
                }
                sw.Write("        public LuaPack(");
                sw.Write(pargs);
                sw.WriteLine(")");
                sw.WriteLine("        {");
                for (int i = 0; i < paramCnt; ++i)
                {
                    sw.Write("            t");
                    sw.Write(i);
                    sw.Write(" = p");
                    sw.Write(i);
                    sw.WriteLine(";");
                }
                sw.WriteLine("        }");
                sw.WriteLine();
                sw.Write("        public int ElementCount { get { return ");
                sw.Write(paramCnt);
                sw.WriteLine("; } }");
                sw.WriteLine("        public void GetFromLua(IntPtr l)");
                sw.WriteLine("        {");
                for (int i = 0; i < paramCnt; ++i)
                {
                    sw.Write("            l.GetLua(-");
                    sw.Write(i + 1);
                    sw.Write(", out t");
                    sw.Write(paramCnt - i - 1);
                    sw.WriteLine(");");
                }
                sw.WriteLine("        }");
                sw.WriteLine("        public void PushToLua(IntPtr l)");
                sw.WriteLine("        {");
                for (int i = 0; i < paramCnt; ++i)
                {
                    sw.Write("            l.PushLua(t");
                    sw.Write(i);
                    sw.WriteLine(");");
                }
                sw.WriteLine("        }");
                sw.WriteLine("        public object this[int index]");
                sw.WriteLine("        {");
                sw.WriteLine("            get { return _IndexAccessors.GetItem(ref this, index); }");
                sw.WriteLine("            set { _IndexAccessors.SetItem(ref this, index, value); }");
                sw.WriteLine("        }");
                sw.Write("        private static LuaPackIndexAccessorList<LuaPack<");
                sw.Write(gargs);
                sw.Write(">> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<");
                sw.Write(gargs);
                sw.WriteLine(">>");
                sw.WriteLine("        {");
                for (int i = 0; i < paramCnt; ++i)
                {
                    sw.Write("            { (ref LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> thiz) => thiz.t");
                    sw.Write(i);
                    sw.Write(", (ref LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> thiz, object val) => thiz.t");
                    sw.Write(i);
                    sw.Write(" = (T");
                    sw.Write(i);
                    sw.WriteLine(")val },");
                }
                sw.WriteLine("        };");
                sw.Write("        public void Deconstruct(");
                for (int i = 0; i < paramCnt; ++i)
                {
                    if (i > 0)
                    {
                        sw.Write(", ");
                    }
                    sw.Write("out T");
                    sw.Write(i);
                    sw.Write(" o");
                    sw.Write(i);
                }
                sw.WriteLine(")");
                sw.WriteLine("        {");
                for (int i = 0; i < paramCnt; ++i)
                {
                    sw.Write("            o");
                    sw.Write(i);
                    sw.Write(" = t");
                    sw.Write(i);
                    sw.WriteLine(";");
                }
                sw.WriteLine("        }");
                sw.WriteLine();
                sw.WriteLine("#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0");
                sw.Write("        public static implicit operator LuaPack<");
                sw.Write(gargs);
                sw.Write(">(");
                if (paramCnt >= 8)
                {
                    sw.Write("(");
                    sw.Write(gargs);
                    sw.Write(")");
                }
                else
                {
                    sw.Write("ValueTuple<");
                    sw.Write(gargs);
                    sw.Write(">");
                }
                sw.WriteLine(" t)");
                sw.WriteLine("        {");
                sw.Write("            return new LuaPack<");
                sw.Write(gargs);
                sw.Write(">(");
                for (int i = 0; i < paramCnt; ++i)
                {
                    if (i > 0)
                    {
                        sw.Write(", ");
                    }
                    sw.Write("t.Item");
                    sw.Write(i + 1);
                }
                sw.WriteLine(");");
                sw.WriteLine("        }");
                sw.Write("        public static implicit operator ");
                if (paramCnt >= 8)
                {
                    sw.Write("(");
                    sw.Write(gargs);
                    sw.Write(")");
                }
                else
                {
                    sw.Write("ValueTuple<");
                    sw.Write(gargs);
                    sw.Write(">");
                }
                sw.Write("(LuaPack<");
                sw.Write(gargs);
                sw.WriteLine("> p)");
                sw.WriteLine("        {");
                sw.Write("            return ");
                if (paramCnt < 8)
                {
                    sw.Write("new ValueTuple<");
                    sw.Write(gargs);
                    sw.Write(">");
                }
                sw.Write("(");
                for (int i = 0; i < paramCnt; ++i)
                {
                    if (i > 0)
                    {
                        sw.Write(", ");
                    }
                    sw.Write("p.t");
                    sw.Write(i);
                }
                sw.WriteLine(");");
                sw.WriteLine("        }");
                sw.WriteLine("#endif");
                sw.WriteLine("    }");
                sw.WriteLine("}");

                if (paramCnt > 0)
                {
                    sb.Clear();
                    for (int i = 0; i < paramCnt; ++i)
                    {
                        sb.Append(", ");
                        sb.Append("out T");
                        sb.Append(i);
                        sb.Append(" rv");
                        sb.Append(i);
                    }
                    var outpars = sb.ToString();

                    sb.Clear();
                    for (int i = 0; i < paramCnt; ++i)
                    {
                        if (i > 0)
                        {
                            sb.Append(", ");
                        }
                        sb.Append("out rv");
                        sb.Append(i);
                    }
                    var outset = sb.ToString();

                    sw.WriteLine("namespace Capstones.LuaWrap");
                    sw.WriteLine("{");
                    sw.WriteLine("    public static partial class LuaFuncExHelper");
                    sw.WriteLine("    {");

                    sw.Write("        public static void PushArgsAndCall<TIn, ");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", TIn args)");
                    sw.WriteLine();
                    sw.WriteLine("            where TIn : struct, ILuaPack");
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            PushArgsAndCall(l, args, out pack);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void CallGlobal<TIn, ");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", string name, TIn args)");
                    sw.WriteLine();
                    sw.WriteLine("            where TIn : struct, ILuaPack");
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            CallGlobal(l, name, args, out pack);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void CallGlobalHierarchical<TIn, ");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", string name, TIn args)");
                    sw.WriteLine();
                    sw.WriteLine("            where TIn : struct, ILuaPack");
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            CallGlobalHierarchical(l, name, args, out pack);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void DoString<");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", string chunk)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            DoString(l, chunk, out pack);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void DoFile<");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", string path)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            DoFile(l, path, out pack);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void GetTable<");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", int index, params string[] fields)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            GetTable(l, index, out pack, fields);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void GetSubTable<");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", int index, string fieldname, params string[] fields)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            GetTable(l, index, fieldname, out pack, fields);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void GetTableHierarchical<");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", int index, string fieldname, params string[] fields)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            GetTableHierarchical(l, index, fieldname, out pack, fields);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void GetGlobalTable<");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", string name, params string[] fields)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            GetGlobalTable(l, name, out pack, fields);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void GetGlobalTableHierarchical<");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", string name, params string[] fields)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            GetGlobalTableHierarchical(l, name, out pack, fields);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.Write("        public static void Require<");
                    sw.Write(gargs);
                    sw.Write(">(this IntPtr l");
                    sw.Write(outpars);
                    sw.Write(", string name, params string[] fields)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.Write("            LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> pack;");
                    sw.WriteLine();
                    sw.WriteLine("            Require(l, name, out pack, fields);");
                    sw.Write("            pack.Deconstruct(");
                    sw.Write(outset);
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");

                    sw.WriteLine("    }");
                    sw.WriteLine("}");
                }

                if (paramCnt > 1)
                {
                    sw.WriteLine("#if !UNITY_ENGINE && !UNITY_5_3_OR_NEWER || NET_4_6 || NET_STANDARD_2_0");
                    sw.WriteLine("namespace Capstones.LuaWrap");
                    sw.WriteLine("{");
                    sw.WriteLine("    public partial struct LuaPack");
                    sw.WriteLine("    {");
                    sw.Write("        public static LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> Pack<");
                    sw.Write(gargs);
                    sw.Write(">(");
                    sw.Write(pargs);
                    sw.Write(")");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.Write("            return new LuaPack<");
                    sw.Write(gargs);
                    sw.Write(">(");
                    for (int i = 0; i < paramCnt; ++i)
                    {
                        if (i > 0)
                        {
                            sw.Write(", ");
                        }
                        sw.Write("p");
                        sw.Write(i);
                    }
                    sw.Write(");");
                    sw.WriteLine();
                    sw.WriteLine("        }");
                    sw.Write("        public static LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> Pack<");
                    sw.Write(gargs);
                    sw.Write(">((");
                    sw.Write(gargs);
                    sw.Write(") t)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.WriteLine("            return t;");
                    sw.WriteLine("        }");
                    sw.Write("        public static (");
                    sw.Write(gargs);
                    sw.Write(") Unpack<");
                    sw.Write(gargs);
                    sw.Write(">(LuaPack<");
                    sw.Write(gargs);
                    sw.Write("> p)");
                    sw.WriteLine();
                    sw.WriteLine("        {");
                    sw.WriteLine("            return p;");
                    sw.WriteLine("        }");
                    sw.WriteLine("    }");
                    sw.WriteLine("}");
                    sw.WriteLine("#endif");
                }
            }
            //AssetDatabase.Refresh();

            //var comp = new UnityEditor.Compilation.AssemblyBuilder("EditorOutput/Temp.dll", file);
            //comp.additionalReferences = new[] { "Library/ScriptAssemblies/CapsLua.dll" };
            //comp.buildStarted += assemblyPath =>
            //{
            //    Debug.LogFormat("Assembly build started for {0}", assemblyPath);
            //};

            //// Called on main thread
            //comp.buildFinished += (assemblyPath, compilerMessages) =>
            //{
            //    foreach (var message in compilerMessages)
            //    {
            //        if (message.type == UnityEditor.Compilation.CompilerMessageType.Error)
            //        {
            //            Debug.LogError(message.message);
            //        }
            //        else if (message.type == UnityEditor.Compilation.CompilerMessageType.Warning)
            //        {
            //            Debug.LogWarning(message.message);
            //        }
            //    }

            //    var errorCount = compilerMessages.Count(m => m.type == UnityEditor.Compilation.CompilerMessageType.Error);
            //    var warningCount = compilerMessages.Count(m => m.type == UnityEditor.Compilation.CompilerMessageType.Warning);

            //    Debug.LogFormat("Assembly build finished for {0}", assemblyPath);
            //    Debug.LogFormat("Warnings: {0} - Errors: {0}", errorCount, warningCount);

            //    if (errorCount == 0)
            //    {
            //    }
            //};
            //comp.Build();

            //new Microsoft.CSharp.CSharpCodeProvider().CompileAssemblyFromFile()
        }

        public static List<string> ParseHotFixList()
        {
            List<string> list = new List<string>();
            var prelists = CapsModEditor.FindAssetsInMods("LuaHotFix/MemberList.txt");
            foreach (var listfile in prelists)
            {
                using (var sr = PlatDependant.OpenReadText(listfile))
                {
                    while (true)
                    {
                        var line = sr.ReadLine();
                        if (line == null)
                            break;
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (line.StartsWith("--"))
                            {
                            }
                            else
                            {
                                list.Add(line);
                            }
                        }
                    }
                }
            }
            return list;
        }

        private class LuaHotFixBuildProcessor : UnityEditor.Build.IPreprocessBuildWithReport
        {
            public int callbackOrder { get { return 0; } }
            public void OnPreprocessBuild(UnityEditor.Build.Reporting.BuildReport report)
            {
                IsBuildingPlayer = true;
            }
        }
        private static bool IsBuildingPlayer = false;
        static LuaHotFixWriter()
        {
#if !DISABLE_LUA_HOTFIX
            UnityEditor.Compilation.CompilationPipeline.assemblyCompilationFinished += (file, messages) =>
            {
                if (!IsBuildingPlayer)
                {
#if UNITY_EDITOR && !DEBUG_LUA_HOTFIX_IN_EDITOR
                    return;
#endif
                }
                LuaHotFixCodeInjector.AssembliesDirectory = System.IO.Path.GetDirectoryName(file);
                LuaHotFixCodeInjector.TryLoadAssembly(file);
            };

            UnityEditor.Compilation.CompilationPipeline.compilationFinished += state =>
            {
                if (!IsBuildingPlayer)
                {
#if UNITY_EDITOR && !DEBUG_LUA_HOTFIX_IN_EDITOR
                    return;
#endif
                }
                IsBuildingPlayer = false;
                LuaHotFixCodeInjector.Inject(ParseHotFixList(), true);
                LuaHotFixCodeInjector.UnloadAssemblies();
            };
#endif
        }
    }

    public class LuaHotFixEditor : EditorWindow
    {
        [MenuItem("Lua/HotFix/Generate LuaPack File", priority = 200010)]
        static void Init()
        {
            GetWindow(typeof(LuaHotFixEditor)).titleContent = new GUIContent("GenerateLuaPack");
        }

        int luaPackParamCnt = 18;
        void OnGUI()
        {
            luaPackParamCnt = EditorGUILayout.IntField(luaPackParamCnt);
            if (GUILayout.Button("Go!"))
            {
                if (luaPackParamCnt > 0)
                {
                    //var existing = LuaHotFixWriter.GetLuaPackType(luaPackParamCnt);
                    //if (existing == null)
                    {
                        LuaHotFixWriter.GenerateLuaPackFile(luaPackParamCnt);
                        EditorUtility.OpenWithDefaultApp("EditorOutput/LuaHotFix/LuaPack/" + "LuaPack" + luaPackParamCnt + ".cs");
                    }
                }
            }
        }

        [MenuItem("Lua/HotFix/Generate ByRefUtils.dll", priority = 200020)]
        public static void GenerateByRefUtils()
        {
            LuaHotFixCodeInjector.GenerateByRefUtils();
        }

#if UNITY_INCLUDE_TESTS
        #region TESTS
        public static void TestPack<TLuaPack>()
            where TLuaPack : struct, ILuaPack
        {
            var l = GlobalLua.L.L;
            TLuaPack pin = default;
            TLuaPack pout = default;
            l.CallGlobal("TestPack", pin, out pout);
            for (int i = 0; i < pout.ElementCount; ++i)
            {
                PlatDependant.LogError(pout[i]);
            }
        }

        [MenuItem("Lua/HotFix/Test HotFix", priority = 290010)]
        public static void TestHotFix()
        {
            var test1 = new Capstones.LuaWrap.HotFixTest.TestGenericClass<int>();
            int a, b;
            a = test1.TestReturnOutGenericFunc("this", 2, 3, out b);
            Debug.LogError(a);
            Debug.LogError(b);

            var test2 = new Capstones.LuaWrap.HotFixTest.TestGenericClass<string>();
            string c, d;
            c = test2.TestReturnOutGenericFunc("me", 5, "???", out d);
            Debug.LogError(c);
            Debug.LogError(d);

            var test3 = new Capstones.LuaWrap.HotFixTest.TestStruct(5);
            Debug.LogError(test3.Value);

            var test4 = new Capstones.LuaWrap.HotFixTest.TestClass(5);
            Debug.LogError(test4.Value);

            var test5 = new Capstones.LuaWrap.HotFixTest.TestGenericClass<int>();
            test5.TestVoidFunc();
        }

        [MenuItem("Lua/HotFix/Test LuaPack", priority = 290020)]
        public static void TestLuaPack()
        {
            Type[] genargs = new Type[18];
            for (int i = 0; i < genargs.Length; ++i)
            {
                genargs[i] = typeof(int);
            }
            var packtype = typeof(LuaPack).Assembly.GetTypes().Where(type => type.Name == "LuaPack`18").FirstOrDefault().MakeGenericType(genargs);
            typeof(LuaHotFixEditor).GetMethod("TestPack").MakeGenericMethod(packtype).Invoke(null, new object[0]);
        }
        #endregion
#endif
    }
}