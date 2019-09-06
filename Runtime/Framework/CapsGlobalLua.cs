using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Capstones.LuaLib;
using Capstones.LuaWrap;
using Capstones.LuaExt;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaExt
{
    public static partial class LuaExLibs
    {
        public delegate void LuaInitFunc(IntPtr L);
        public class LuaExLibItem
        {
            public LuaInitFunc InitFunc;
            public int Order;

            protected LuaExLibItem()
            {
                InitFuncs.Add(this);
            }
            public LuaExLibItem(LuaInitFunc initFunc, int order) : this()
            {
                InitFunc = initFunc;
                Order = order;
            }
        }

        private static List<LuaExLibItem> _InitFuncs;
        public static List<LuaExLibItem> InitFuncs
        {
            get
            {
                if (_InitFuncs == null)
                {
                    _InitFuncs = new List<LuaExLibItem>();
                }
                return _InitFuncs;
            }
        }
    }
}

namespace Capstones.UnityEngineEx
{
    public static class GlobalLua
    {
        public static LuaState L;

        static GlobalLua()
        {
            LuaExLibs.InitFuncs.Sort((a, b) => a.Order - b.Order);
            LuaExLibs.InitFuncs.TrimExcess();
#if UNITY_EDITOR
            Init();
#endif
        }

        public static void Init()
        {
            if (object.ReferenceEquals(L, null))
            {
                L = new LuaState();
                for (int i = 0; i < LuaExLibs.InitFuncs.Count; ++i)
                {
                    var func = LuaExLibs.InitFuncs[i].InitFunc;
                    if (func != null)
                    {
                        try
                        {
                            func(L);
                        }
                        catch (Exception e)
                        {
                            PlatDependant.LogError(e);
                        }
                    }
                }
            }
        }
        public static void Reinit()
        {
            if (!object.ReferenceEquals(L, null))
            {
                L.Dispose();
                L = null;
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }
            Init();
        }

#if UNITY_EDITOR
        private static bool IsEditorRunning = false;
        public static void EditorCheckRunningState()
        {
            if (!IsEditorRunning && Application.isPlaying)
            {
                IsEditorRunning = true;

                Action onPlayModeChanged = null;
                onPlayModeChanged = () =>
                {
                    if (!Application.isPlaying)
                    {
                        Reinit();

                        EditorBridge.OnPlayModeChanged -= onPlayModeChanged;
                        IsEditorRunning = false;
                    }
                };
                EditorBridge.OnPlayModeChanged += onPlayModeChanged;
            }
        }
#endif

        public static Coroutine StartLuaCoroutine(LuaFunc lfunc)
        {
            return StartLuaCoroutineForBehav(null, lfunc);
        }
        public static Coroutine StartLuaCoroutineForBehav(this MonoBehaviour behav, LuaFunc lfunc)
        {
            if (behav != null)
            {
                var work = EnumLuaCoroutine(lfunc);
                if (work is IDisposable)
                {
                    var info = new CoroutineRunner.CoroutineInfo() { behav = behav, work = work };
                    return behav.StartCoroutine(CoroutineRunner.SafeEnumerator(work, info));
                }
                else
                {
                    return behav.StartCoroutine(EnumLuaCoroutine(lfunc));
                }
            }
            else
            {
                return CoroutineRunner.StartCoroutine(EnumLuaCoroutine(lfunc));
            }
        }
        public static IEnumerator EnumLuaCoroutine(LuaFunc lfunc)
        {
            if (lfunc != null)
            {
                LuaThread lthd = new LuaThread(lfunc);
                lfunc.Dispose();
                return EnumLuaCoroutine(lthd);
            }
            else
            {
                return CoroutineRunner.GetEmptyEnumerator();
            }
        }

        public static Coroutine StartLuaCoroutine(LuaOnStackFunc lfunc)
        {
            return StartLuaCoroutineForBehav(null, lfunc);
        }
        public static Coroutine StartLuaCoroutineForBehav(this MonoBehaviour behav, LuaOnStackFunc lfunc)
        {
            if (behav != null)
            {
                var work = EnumLuaCoroutine(lfunc);
                if (work is IDisposable)
                {
                    var info = new CoroutineRunner.CoroutineInfo() { behav = behav, work = work };
                    return behav.StartCoroutine(CoroutineRunner.SafeEnumerator(work, info));
                }
                else
                {
                    return behav.StartCoroutine(EnumLuaCoroutine(lfunc));
                }
            }
            else
            {
                return CoroutineRunner.StartCoroutine(EnumLuaCoroutine(lfunc));
            }
        }
        public static IEnumerator EnumLuaCoroutine(LuaOnStackFunc lfunc)
        {
            if (lfunc != null)
            {
                LuaThread lthd = new LuaThread(lfunc);
                return EnumLuaCoroutine(lthd);
            }
            else
            {
                return CoroutineRunner.GetEmptyEnumerator();
            }
        }

        public static IEnumerator EnumLuaCoroutine(LuaOnStackThread lthd)
        {
            if (lthd != null)
            {
                using (lthd)
                {
                    while (true)
                    {
                        lthd.DoResume();
                        var l = lthd.L;
                        var rvc = l.gettop();
                        if (lthd.IsDone)
                        {
                            l.settop(0);
                            yield break;
                        }
                        else if (rvc > 0)
                        {
                            var result = l.GetLua(1);
                            if (rvc >= 2 && l.toboolean(2))
                            {
                                l.settop(0);
                                if (result is IEnumerator)
                                {
                                    var etor = result as IEnumerator;
                                    while (etor.MoveNext())
                                    {
                                        yield return etor.Current;
                                    }
                                }
                                else if (result is IEnumerable)
                                {
                                    var enumerable = result as IEnumerable;
                                    foreach (var obj in enumerable)
                                    {
                                        yield return obj;
                                    }
                                }
                                else
                                {
                                    yield return result;
                                }
                            }
                            else
                            {
                                l.settop(0);
                                yield return result;
                            }
                        }
                        else
                        {
                            yield return null;
                        }
                    }
                }
            }
        }

        public static IEnumerator DeepGC()
        {
            for (int i = 0; i < 3; ++i)
            {
                if (!object.ReferenceEquals(L, null))
                {
                    L.L.gc(2, 0);
                    yield return null;
                }
            }
        }
        public static void DeepGCStep()
        {
            if (!object.ReferenceEquals(L, null))
            {
                L.L.gc(2, 0);
            }
        }
    }

    public static class GlobalLuaEntry
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnUnityStart()
        {
            ResManager.GarbageCollector.GarbageCollectorEvents[0].Insert(0, GlobalLua.DeepGCStep);
#if UNITY_EDITOR
            ResManager.AddInitItem(ResManager.LifetimeOrders.Zero, GlobalLuaEditorCheck);
#endif
        }
#if UNITY_EDITOR
        private static void GlobalLuaEditorCheck()
        {
            GlobalLua.EditorCheckRunningState();
        }
#endif
    }
}
