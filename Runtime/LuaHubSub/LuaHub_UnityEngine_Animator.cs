#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Animator : LuaHub.TypeHubPrecompiled_UnityEngine_Behaviour
        {
            public TypeHubPrecompiled_UnityEngine_Animator() : this(typeof(UnityEngine.Animator)) { }
            public TypeHubPrecompiled_UnityEngine_Animator(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["Update"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Update"]._Method, _Precompiled = ___fm_Update };
                _InstanceMethods["Play"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Play"]._Method, _Precompiled = ___fm_Play };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
                _InstanceFieldsIndex["enabled"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["enabled"]._Method, _Precompiled = ___gf_enabled };
                _InstanceFieldsNewIndex["enabled"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["enabled"]._Method, _Precompiled = ___sf_enabled };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
                _InstanceMethods_DirectFromBase.Add("GetComponent");
                _InstanceMethods_DirectFromBase.Add("GetComponentInChildren");
                _InstanceMethods_DirectFromBase.Add("GetComponentsInChildren");
                _InstanceMethods_DirectFromBase.Add("GetComponentInParent");
                _InstanceMethods_DirectFromBase.Add("GetComponentsInParent");
                _InstanceMethods_DirectFromBase.Add("GetComponents");
                _InstanceMethods_DirectFromBase.Add("CompareTag");
                _InstanceMethods_DirectFromBase.Add("SendMessageUpwards");
                _InstanceMethods_DirectFromBase.Add("SendMessage");
                _InstanceMethods_DirectFromBase.Add("BroadcastMessage");
                _InstanceMethods_DirectFromBase.Add("GetInstanceID");
                #endif
            }
            public override void RegPrecompiledStatic()
            {
                #region REG_I_CTOR
                #endregion // REG_I_CTOR
                #region REG_S_FUNC
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                #endregion // REG_S_PROP
                #region REG_G_S_FUNC
                #endregion // REG_G_S_FUNC
                #region REG_S_OP
                #endregion // REG_S_OP
                #region REG_S_CONV
                #endregion // REG_S_CONV
                #region REG_G_GTYPES
                #endregion // REG_G_GTYPES
            }
            
            #region DEL_I_CTOR
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            private static readonly lua.CFunction ___fm_Update = new lua.CFunction(___mm_Update);
            private static readonly lua.CFunction ___fm_Play = new lua.CFunction(___mm_Play);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
            private static readonly lua.CFunction ___gf_enabled = new lua.CFunction(___gm_enabled);
            private static readonly lua.CFunction ___sf_enabled = new lua.CFunction(___sm_enabled);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            #endregion // DEL_S_PROP
            #region DEL_G_I_FUNC
            #endregion // DEL_G_I_FUNC
            #region DEL_I_INDEX
            #endregion // DEL_I_INDEX
            #region DEL_G_S_FUNC
            #endregion // DEL_G_S_FUNC
            #region DEL_S_OP
            #endregion // DEL_S_OP
            #region DEL_S_CONV
            #endregion // DEL_S_CONV
            #region DEL_G_GTYPES
            #endregion // DEL_G_GTYPES
            
            #region FUNC_I_CTOR
            #endregion // FUNC_I_CTOR
            #region FUNC_I_FUNC
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_Update(IntPtr l)
            {
                try
                {
                    UnityEngine.Animator p0;
                    l.GetLua(1, out p0);
                    System.Single p1;
                    l.GetLua(2, out p1);
                    p0.Update(p1);
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_Play(IntPtr l)
            {
                try
                {
                    {
                        {
                            {
                                {
                                    {
                                        var ___ot3 = l.GetType(4);
                                        if (___ot3 == typeof(System.Double) || ___ot3 == typeof(System.Single))
                                        {
                                            var ___ot1 = l.GetType(2);
                                            if (___ot1 == typeof(System.Double) || ___ot1 == typeof(System.Int32))
                                            {
                                                goto Label_40;
                                            }
                                            goto Label_30;
                                        }
                                        {
                                            var ___ot1 = l.GetType(2);
                                            if (___ot1 == typeof(System.Double) || ___ot1 == typeof(System.Int32))
                                            {
                                                var ___ot2 = l.GetType(3);
                                                if (___ot2 == typeof(System.Double) || ___ot2 == typeof(System.Int32))
                                                {
                                                    goto Label_50;
                                                }
                                                goto Label_60;
                                            }
                                            {
                                                var ___ot2 = l.GetType(3);
                                                if (___ot2 == typeof(System.Double) || ___ot2 == typeof(System.Int32))
                                                {
                                                    goto Label_10;
                                                }
                                                goto Label_20;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Animator p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            p0.Play(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Animator p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            p0.Play(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Animator p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            p0.Play(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.Animator p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            p0.Play(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            UnityEngine.Animator p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            p0.Play(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            UnityEngine.Animator p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            p0.Play(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_gameObject(IntPtr l)
            {
                try
                {
                    UnityEngine.Animator tar;
                    l.GetLua(1, out tar);
                    var rv = tar.gameObject;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_enabled(IntPtr l)
            {
                try
                {
                    UnityEngine.Animator tar;
                    l.GetLua(1, out tar);
                    var rv = tar.enabled;
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_enabled(IntPtr l)
            {
                try
                {
                    UnityEngine.Animator tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.enabled = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            #endregion // FUNC_I_PROP
            #region FUNC_S_FUNC
            #endregion // FUNC_S_FUNC
            #region FUNC_S_PROP
            #endregion // FUNC_S_PROP
            #region FUNC_G_I_FUNC
            #endregion // FUNC_G_I_FUNC
            #region FUNC_I_INDEX
            #endregion // FUNC_I_INDEX
            #region FUNC_G_S_FUNC
            #endregion // FUNC_G_S_FUNC
            #region FUNC_S_OP
            #endregion // FUNC_S_OP
            #region FUNC_S_CONV
            #endregion // FUNC_S_CONV
            #region FUNC_G_GTYPES
            #endregion // FUNC_G_GTYPES
            
            #region NESTED_TYPE_HUB
            #endregion // NESTED_TYPE_HUB
        }
        private static TypeHubPrecompiled_UnityEngine_Animator ___tp_UnityEngine_Animator = new TypeHubPrecompiled_UnityEngine_Animator();
        public static void PushLua(this IntPtr l, UnityEngine.Animator val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_Animator.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Animator val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Animator;
        }
    }
}
#endif
