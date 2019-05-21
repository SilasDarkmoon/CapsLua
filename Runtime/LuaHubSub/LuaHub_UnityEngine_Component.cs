#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Component : TypeHubPrecompiled_UnityEngine_Object
        {
            public TypeHubPrecompiled_UnityEngine_Component() : this(typeof(UnityEngine.Component)) { }
            public TypeHubPrecompiled_UnityEngine_Component(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["GetComponent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponent"]._Method, _Precompiled = ___fm_GetComponent };
                _InstanceMethods["GetComponentInChildren"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponentInChildren"]._Method, _Precompiled = ___fm_GetComponentInChildren };
                _InstanceMethods["GetComponentsInChildren"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponentsInChildren"]._Method, _Precompiled = ___fm_GetComponentsInChildren };
                _InstanceMethods["GetComponentInParent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponentInParent"]._Method, _Precompiled = ___fm_GetComponentInParent };
                _InstanceMethods["GetComponentsInParent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponentsInParent"]._Method, _Precompiled = ___fm_GetComponentsInParent };
                _InstanceMethods["GetComponents"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponents"]._Method, _Precompiled = ___fm_GetComponents };
                _InstanceMethods["CompareTag"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["CompareTag"]._Method, _Precompiled = ___fm_CompareTag };
                _InstanceMethods["SendMessageUpwards"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SendMessageUpwards"]._Method, _Precompiled = ___fm_SendMessageUpwards };
                _InstanceMethods["SendMessage"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SendMessage"]._Method, _Precompiled = ___fm_SendMessage };
                _InstanceMethods["BroadcastMessage"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["BroadcastMessage"]._Method, _Precompiled = ___fm_BroadcastMessage };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["transform"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["transform"]._Method, _Precompiled = ___gf_transform };
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
                _InstanceFieldsIndex["tag"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["tag"]._Method, _Precompiled = ___gf_tag };
                _InstanceFieldsNewIndex["tag"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["tag"]._Method, _Precompiled = ___sf_tag };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
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
            private static readonly lua.CFunction ___fm_GetComponent = new lua.CFunction(___mm_GetComponent);
            private static readonly lua.CFunction ___fm_GetComponentInChildren = new lua.CFunction(___mm_GetComponentInChildren);
            private static readonly lua.CFunction ___fm_GetComponentsInChildren = new lua.CFunction(___mm_GetComponentsInChildren);
            private static readonly lua.CFunction ___fm_GetComponentInParent = new lua.CFunction(___mm_GetComponentInParent);
            private static readonly lua.CFunction ___fm_GetComponentsInParent = new lua.CFunction(___mm_GetComponentsInParent);
            private static readonly lua.CFunction ___fm_GetComponents = new lua.CFunction(___mm_GetComponents);
            private static readonly lua.CFunction ___fm_CompareTag = new lua.CFunction(___mm_CompareTag);
            private static readonly lua.CFunction ___fm_SendMessageUpwards = new lua.CFunction(___mm_SendMessageUpwards);
            private static readonly lua.CFunction ___fm_SendMessage = new lua.CFunction(___mm_SendMessage);
            private static readonly lua.CFunction ___fm_BroadcastMessage = new lua.CFunction(___mm_BroadcastMessage);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_transform = new lua.CFunction(___gm_transform);
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
            private static readonly lua.CFunction ___gf_tag = new lua.CFunction(___gm_tag);
            private static readonly lua.CFunction ___sf_tag = new lua.CFunction(___sm_tag);
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
            private static int ___mm_GetComponent(IntPtr l)
            {
                try
                {
                    {
                        {
                            {
                                {
                                    var ___lt1 = l.type(2);
                                    if (___lt1 == LuaCoreLib.LUA_TSTRING)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.String))
                                        {
                                            goto Label_20;
                                        }
                                        goto Label_10;
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetComponent(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetComponent(p1);
                            l.PushLua(rv);
                            return 1;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetComponentInChildren(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 3)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            System.Boolean p2;
                            l.GetLua(3, out p2);
                            var rv = p0.GetComponentInChildren(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetComponentInChildren(p1);
                            l.PushLua(rv);
                            return 1;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetComponentsInChildren(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 3)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetComponentsInChildren(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            System.Boolean p2;
                            l.GetLua(3, out p2);
                            var rv = p0.GetComponentsInChildren(p1, p2);
                            l.PushLua(rv);
                            return 1;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetComponentInParent(IntPtr l)
            {
                try
                {
                    UnityEngine.Component p0;
                    l.GetLua(1, out p0);
                    System.Type p1;
                    l.GetLua(2, out p1);
                    var rv = p0.GetComponentInParent(p1);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetComponentsInParent(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 3)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetComponentsInParent(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            System.Boolean p2;
                            l.GetLua(3, out p2);
                            var rv = p0.GetComponentsInParent(p1, p2);
                            l.PushLua(rv);
                            return 1;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetComponents(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 3)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            var rv = p0.GetComponents(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.Type p1;
                            l.GetLua(2, out p1);
                            System.Collections.Generic.List<UnityEngine.Component> p2;
                            l.GetLua(3, out p2);
                            p0.GetComponents(p1, p2);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_CompareTag(IntPtr l)
            {
                try
                {
                    UnityEngine.Component p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    var rv = p0.CompareTag(p1);
                    l.PushLua(rv);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_SendMessageUpwards(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_30;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_10;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(UnityEngine.SendMessageOptions))
                                        {
                                            goto Label_40;
                                        }
                                        goto Label_20;
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            UnityEngine.SendMessageOptions p3;
                            l.GetLua(4, out p3);
                            p0.SendMessageUpwards(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            p0.SendMessageUpwards(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            p0.SendMessageUpwards(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            UnityEngine.SendMessageOptions p2;
                            l.GetLua(3, out p2);
                            p0.SendMessageUpwards(p1, p2);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_SendMessage(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_30;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_10;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(UnityEngine.SendMessageOptions))
                                        {
                                            goto Label_40;
                                        }
                                        goto Label_20;
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            UnityEngine.SendMessageOptions p3;
                            l.GetLua(4, out p3);
                            p0.SendMessage(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            p0.SendMessage(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            p0.SendMessage(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            UnityEngine.SendMessageOptions p2;
                            l.GetLua(3, out p2);
                            p0.SendMessage(p1, p2);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_BroadcastMessage(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_30;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_10;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(UnityEngine.SendMessageOptions))
                                        {
                                            goto Label_40;
                                        }
                                        goto Label_20;
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            UnityEngine.SendMessageOptions p3;
                            l.GetLua(4, out p3);
                            p0.BroadcastMessage(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Object p2;
                            l.GetLua(3, out p2);
                            p0.BroadcastMessage(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            p0.BroadcastMessage(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.Component p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            UnityEngine.SendMessageOptions p2;
                            l.GetLua(3, out p2);
                            p0.BroadcastMessage(p1, p2);
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
            private static int ___gm_transform(IntPtr l)
            {
                try
                {
                    UnityEngine.Component tar;
                    l.GetLua(1, out tar);
                    var rv = tar.transform;
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
            private static int ___gm_gameObject(IntPtr l)
            {
                try
                {
                    UnityEngine.Component tar;
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
            private static int ___gm_tag(IntPtr l)
            {
                try
                {
                    UnityEngine.Component tar;
                    l.GetLua(1, out tar);
                    var rv = tar.tag;
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
            private static int ___sm_tag(IntPtr l)
            {
                try
                {
                    UnityEngine.Component tar;
                    l.GetLua(1, out tar);
                    System.String val;
                    l.GetLua(2, out val);
                    tar.tag = val;
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
        private static TypeHubPrecompiled_UnityEngine_Component ___tp_UnityEngine_Component = new TypeHubPrecompiled_UnityEngine_Component();
        public static void PushLua(this IntPtr l, UnityEngine.Component val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Component val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Component;
        }
    }
}
#endif
