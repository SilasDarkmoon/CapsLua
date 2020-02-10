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
            if (GetLuaPackType(paramCnt) != null)
            {
                return;
            }

            //string codefolder = "Assets/Mods/" + CapsEditorUtils.__MOD__ + "/LuaHotFix/";
            //string file = codefolder + "LuaPack" + paramCnt + ".cs";
            string file = "EditorOutput/" + "LuaPack" + paramCnt + ".cs";
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
                sw.WriteLine("            get { return _IndexAccessors[index].Getter(this); }");
                sw.WriteLine("            set { _IndexAccessors[index].Setter(ref this, value); }");
                sw.WriteLine("        }");
                sw.Write("        private static LuaPackIndexAccessorList<LuaPack<");
                sw.Write(gargs);
                sw.Write(">> _IndexAccessors = new LuaPackIndexAccessorList<LuaPack<");
                sw.Write(gargs);
                sw.WriteLine(">>");
                sw.WriteLine("        {");
                for (int i = 0; i < paramCnt; ++i)
                {
                    sw.Write("            { thiz => thiz.t");
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
                sw.WriteLine("    }");
                sw.WriteLine("}");
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
        }

        public static Types GetMethodSigTypes(MethodBase method)
        {
            Types types = new Types();
            if (method is ConstructorInfo)
            {
                types.Add(typeof(void));
                types.Add(method.ReflectedType);
            }
            else if (method is MethodInfo)
            {
                var minfo = method as MethodInfo;
                types.Add(minfo.ReturnType);
                if (!minfo.IsStatic)
                {
                    types.Add(method.ReflectedType);
                }
            }
            foreach (var par in method.GetParameters())
            {
                types.Add(par.ParameterType);
            }
            return types;
        }
        private static Dictionary<Types, int> _SigTypesMap = new Dictionary<Types, int>();
        private static AssemblyBuilder _AssemblyBuilder;
        private static ModuleBuilder _ModuleBuilder;
        public static void GenerateStubFuncFor(MethodBase method)
        {
            var asmbuilder = _AssemblyBuilder;
            var codeEmitModule = _ModuleBuilder;
            if (asmbuilder == null)
            {
                var assemblyName = new AssemblyName();
                assemblyName.Name = "LuaHotFixCodeEmit";
                _AssemblyBuilder = asmbuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
                _ModuleBuilder = codeEmitModule = asmbuilder.DefineDynamicModule("LuaHotFixCodeEmit", "LuaHotFixCodeEmit.dll");
            }

            var sigtypes = GetMethodSigTypes(method);
            if (sigtypes.Count < 1)
            {
                return;
            }

            Type rettype = sigtypes[0];
            Type[] argstype = new Type[sigtypes.Count - 1];
            for (int i = 1; i < sigtypes.Count; ++i)
            {
                argstype[i - 1] = sigtypes[i];
            }
            int methodid;
            if (!_SigTypesMap.TryGetValue(sigtypes, out methodid))
            {
                _SigTypesMap[sigtypes] = methodid = _SigTypesMap.Count + 1;
            }

            var typebuilder = codeEmitModule.DefineType("LuaHotFixCodeEmitStub" + methodid, TypeAttributes.Public | TypeAttributes.Class, typeof(object));
            var mbuilder = typebuilder.DefineMethod("StubFunc" + methodid, MethodAttributes.Public | MethodAttributes.Static, rettype, argstype);
            ParameterExpression[] argsexp = new ParameterExpression[argstype.Length];
            for (int i = 0; i< argstype.Length; ++i)
            {
                argsexp[i] = Expression.Parameter(argstype[i], "p" + i);
            }
            LabelTarget returnTarget = Expression.Label(rettype);
            GotoExpression returnExp;
            if (rettype == typeof(void))
            {
                returnExp = Expression.Return(returnTarget);
            }
            else
            {
                returnExp = Expression.Return(returnTarget, Expression.Default(rettype));
            }
            var body = Expression.Block(returnExp, Expression.Label(returnTarget));
            var lambda = Expression.Lambda(body, argsexp);
            lambda.CompileToMethod(mbuilder);

            var createdtype = typebuilder.CreateType();
            asmbuilder.Save("Temp.dll");
        }
    }

    public class LuaHotFixEditor : EditorWindow
    {
        [MenuItem("Lua/HotFix/Test", priority = 200010)]
        public static void Test()
        {
            //var comp = new UnityEditor.Compilation.AssemblyBuilder("EditorOutput/Temp.dll", "EditorOutput/Test1.cs");
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

            for (int i = 11; i < 18; ++i)
            {
                LuaHotFixWriter.GenerateLuaPackFile(i);
            }
        }
    }
}