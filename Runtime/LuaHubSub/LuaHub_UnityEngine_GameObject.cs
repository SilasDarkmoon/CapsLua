#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_GameObject : TypeHubPrecompiled_UnityEngine_Object
        {
            public TypeHubPrecompiled_UnityEngine_GameObject() : this(typeof(UnityEngine.GameObject)) { }
            public TypeHubPrecompiled_UnityEngine_GameObject(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["GetComponent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponent"]._Method, _Precompiled = ___fm_GetComponent };
                _InstanceMethods["GetComponentInChildren"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponentInChildren"]._Method, _Precompiled = ___fm_GetComponentInChildren };
                _InstanceMethods["GetComponentInParent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponentInParent"]._Method, _Precompiled = ___fm_GetComponentInParent };
                _InstanceMethods["GetComponents"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponents"]._Method, _Precompiled = ___fm_GetComponents };
                _InstanceMethods["GetComponentsInChildren"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponentsInChildren"]._Method, _Precompiled = ___fm_GetComponentsInChildren };
                _InstanceMethods["GetComponentsInParent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetComponentsInParent"]._Method, _Precompiled = ___fm_GetComponentsInParent };
                _InstanceMethods["SetActive"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetActive"]._Method, _Precompiled = ___fm_SetActive };
                _InstanceMethods["SetActiveRecursively"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetActiveRecursively"]._Method, _Precompiled = ___fm_SetActiveRecursively };
                _InstanceMethods["CompareTag"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["CompareTag"]._Method, _Precompiled = ___fm_CompareTag };
                _InstanceMethods["SendMessageUpwards"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SendMessageUpwards"]._Method, _Precompiled = ___fm_SendMessageUpwards };
                _InstanceMethods["SendMessage"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SendMessage"]._Method, _Precompiled = ___fm_SendMessage };
                _InstanceMethods["BroadcastMessage"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["BroadcastMessage"]._Method, _Precompiled = ___fm_BroadcastMessage };
                _InstanceMethods["AddComponent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["AddComponent"]._Method, _Precompiled = ___fm_AddComponent };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["name"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["name"]._Method, _Precompiled = ___gf_name };
                _InstanceFieldsNewIndex["name"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["name"]._Method, _Precompiled = ___sf_name };
                _InstanceFieldsIndex["hideFlags"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["hideFlags"]._Method, _Precompiled = ___gf_hideFlags };
                _InstanceFieldsNewIndex["hideFlags"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["hideFlags"]._Method, _Precompiled = ___sf_hideFlags };
                _InstanceFieldsIndex["transform"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["transform"]._Method, _Precompiled = ___gf_transform };
                _InstanceFieldsIndex["layer"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["layer"]._Method, _Precompiled = ___gf_layer };
                _InstanceFieldsNewIndex["layer"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["layer"]._Method, _Precompiled = ___sf_layer };
                _InstanceFieldsIndex["active"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["active"]._Method, _Precompiled = ___gf_active };
                _InstanceFieldsNewIndex["active"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["active"]._Method, _Precompiled = ___sf_active };
                _InstanceFieldsIndex["activeSelf"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["activeSelf"]._Method, _Precompiled = ___gf_activeSelf };
                _InstanceFieldsIndex["activeInHierarchy"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["activeInHierarchy"]._Method, _Precompiled = ___gf_activeInHierarchy };
                _InstanceFieldsIndex["isStatic"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["isStatic"]._Method, _Precompiled = ___gf_isStatic };
                _InstanceFieldsNewIndex["isStatic"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["isStatic"]._Method, _Precompiled = ___sf_isStatic };
                _InstanceFieldsIndex["tag"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["tag"]._Method, _Precompiled = ___gf_tag };
                _InstanceFieldsNewIndex["tag"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["tag"]._Method, _Precompiled = ___sf_tag };
                _InstanceFieldsIndex["scene"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["scene"]._Method, _Precompiled = ___gf_scene };
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                ((GenericMethodMeta)_InstanceMethods["AddComponent"]._Method)._GenericMethodsCache[new Types() { typeof(UnityEngine.SkinnedMeshRenderer) }] = ___fm_AddComponent_UnityEngine_SkinnedMeshRenderer;
                ((GenericMethodMeta)_InstanceMethods["GetComponent"]._Method)._GenericMethodsCache[new Types() { typeof(UnityEngine.SkinnedMeshRenderer) }] = ___fm_GetComponent_UnityEngine_SkinnedMeshRenderer;
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
                _Ctor._Precompiled = ___fm_ctor;
                #endregion // REG_I_CTOR
                #region REG_S_FUNC
                _StaticMethods["CreatePrimitive"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["CreatePrimitive"]._Method, _Precompiled = ___sfm_CreatePrimitive };
                _StaticMethods["FindGameObjectWithTag"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["FindGameObjectWithTag"]._Method, _Precompiled = ___sfm_FindGameObjectWithTag };
                _StaticMethods["FindWithTag"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["FindWithTag"]._Method, _Precompiled = ___sfm_FindWithTag };
                _StaticMethods["FindGameObjectsWithTag"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["FindGameObjectsWithTag"]._Method, _Precompiled = ___sfm_FindGameObjectsWithTag };
                _StaticMethods["Find"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Find"]._Method, _Precompiled = ___sfm_Find };
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
            private static readonly lua.CFunction ___fm_ctor = new lua.CFunction(___mm_ctor);
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            private static readonly lua.CFunction ___fm_GetComponent = new lua.CFunction(___mm_GetComponent);
            private static readonly lua.CFunction ___fm_GetComponentInChildren = new lua.CFunction(___mm_GetComponentInChildren);
            private static readonly lua.CFunction ___fm_GetComponentInParent = new lua.CFunction(___mm_GetComponentInParent);
            private static readonly lua.CFunction ___fm_GetComponents = new lua.CFunction(___mm_GetComponents);
            private static readonly lua.CFunction ___fm_GetComponentsInChildren = new lua.CFunction(___mm_GetComponentsInChildren);
            private static readonly lua.CFunction ___fm_GetComponentsInParent = new lua.CFunction(___mm_GetComponentsInParent);
            private static readonly lua.CFunction ___fm_SetActive = new lua.CFunction(___mm_SetActive);
            private static readonly lua.CFunction ___fm_SetActiveRecursively = new lua.CFunction(___mm_SetActiveRecursively);
            private static readonly lua.CFunction ___fm_CompareTag = new lua.CFunction(___mm_CompareTag);
            private static readonly lua.CFunction ___fm_SendMessageUpwards = new lua.CFunction(___mm_SendMessageUpwards);
            private static readonly lua.CFunction ___fm_SendMessage = new lua.CFunction(___mm_SendMessage);
            private static readonly lua.CFunction ___fm_BroadcastMessage = new lua.CFunction(___mm_BroadcastMessage);
            private static readonly lua.CFunction ___fm_AddComponent = new lua.CFunction(___mm_AddComponent);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_name = new lua.CFunction(___gm_name);
            private static readonly lua.CFunction ___sf_name = new lua.CFunction(___sm_name);
            private static readonly lua.CFunction ___gf_hideFlags = new lua.CFunction(___gm_hideFlags);
            private static readonly lua.CFunction ___sf_hideFlags = new lua.CFunction(___sm_hideFlags);
            private static readonly lua.CFunction ___gf_transform = new lua.CFunction(___gm_transform);
            private static readonly lua.CFunction ___gf_layer = new lua.CFunction(___gm_layer);
            private static readonly lua.CFunction ___sf_layer = new lua.CFunction(___sm_layer);
            private static readonly lua.CFunction ___gf_active = new lua.CFunction(___gm_active);
            private static readonly lua.CFunction ___sf_active = new lua.CFunction(___sm_active);
            private static readonly lua.CFunction ___gf_activeSelf = new lua.CFunction(___gm_activeSelf);
            private static readonly lua.CFunction ___gf_activeInHierarchy = new lua.CFunction(___gm_activeInHierarchy);
            private static readonly lua.CFunction ___gf_isStatic = new lua.CFunction(___gm_isStatic);
            private static readonly lua.CFunction ___sf_isStatic = new lua.CFunction(___sm_isStatic);
            private static readonly lua.CFunction ___gf_tag = new lua.CFunction(___gm_tag);
            private static readonly lua.CFunction ___sf_tag = new lua.CFunction(___sm_tag);
            private static readonly lua.CFunction ___gf_scene = new lua.CFunction(___gm_scene);
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_CreatePrimitive = new lua.CFunction(___smm_CreatePrimitive);
            private static readonly lua.CFunction ___sfm_FindGameObjectWithTag = new lua.CFunction(___smm_FindGameObjectWithTag);
            private static readonly lua.CFunction ___sfm_FindWithTag = new lua.CFunction(___smm_FindWithTag);
            private static readonly lua.CFunction ___sfm_FindGameObjectsWithTag = new lua.CFunction(___smm_FindGameObjectsWithTag);
            private static readonly lua.CFunction ___sfm_Find = new lua.CFunction(___smm_Find);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            #endregion // DEL_S_PROP
            #region DEL_G_I_FUNC
            private static readonly lua.CFunction ___fm_AddComponent_UnityEngine_SkinnedMeshRenderer = new lua.CFunction(___mm_AddComponent_UnityEngine_SkinnedMeshRenderer);
            private static readonly lua.CFunction ___fm_GetComponent_UnityEngine_SkinnedMeshRenderer = new lua.CFunction(___mm_GetComponent_UnityEngine_SkinnedMeshRenderer);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_ctor(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 1)
                            {
                                goto Label_20;
                            }
                            else if (oldtop > 2)
                            {
                                goto Label_32;
                            }
                            else
                            {
                                if (oldtop == 2)
                                {
                                    goto Label_10;
                                }
                                else
                                {
                                    goto Label_30;
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = new UnityEngine.GameObject(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            var rv = new UnityEngine.GameObject();
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            var ltype = l.GetType(3);
                            if (ltype == typeof(System.Type[])) goto Label_31;
                            else goto Label_32;
                        }
                        goto Label_default;
                        Label_31:
                        {
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Type[] p2;
                            l.GetLua(3, out p2);
                            var rv = new UnityEngine.GameObject(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_32:
                        {
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Type[] p2;
                            var paramscnt = l.gettop() - 2;
                            paramscnt = paramscnt < 0 ? 0 : paramscnt;
                            p2 = new System.Type[paramscnt];
                            for (int i = 0; i < paramscnt; ++i)
                            {
                                System.Type paramval;
                                l.GetLua(i + 3, out paramval);
                                p2[i] = paramval;
                            }
                            var rv = new UnityEngine.GameObject(p1, p2);
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
            private static int ___mm_GetComponentInParent(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
            private static int ___mm_SetActive(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject p0;
                    l.GetLua(1, out p0);
                    System.Boolean p1;
                    l.GetLua(2, out p1);
                    p0.SetActive(p1);
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
            private static int ___mm_SetActiveRecursively(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject p0;
                    l.GetLua(1, out p0);
                    System.Boolean p1;
                    l.GetLua(2, out p1);
                    p0.SetActiveRecursively(p1);
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
            private static int ___mm_CompareTag(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            p0.SendMessageUpwards(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            p0.SendMessage(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
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
                            UnityEngine.GameObject p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            p0.BroadcastMessage(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.GameObject p0;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_AddComponent(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject p0;
                    l.GetLua(1, out p0);
                    System.Type p1;
                    l.GetLua(2, out p1);
                    var rv = p0.AddComponent(p1);
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
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_name(IntPtr l)
            {
                UnityEngine.GameObject tar;
                l.GetLua(1, out tar);
                var rv = tar.name;
                l.PushLua(rv);
                return 1;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_name(IntPtr l)
            {
                UnityEngine.GameObject tar;
                l.GetLua(1, out tar);
                System.String val;
                l.GetLua(2, out val);
                tar.name = val;
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_hideFlags(IntPtr l)
            {
                UnityEngine.GameObject tar;
                l.GetLua(1, out tar);
                var rv = tar.hideFlags;
                l.PushLua(rv);
                return 1;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sm_hideFlags(IntPtr l)
            {
                UnityEngine.GameObject tar;
                l.GetLua(1, out tar);
                UnityEngine.HideFlags val;
                l.GetLua(2, out val);
                tar.hideFlags = val;
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_transform(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
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
            private static int ___gm_layer(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
                    l.GetLua(1, out tar);
                    var rv = tar.layer;
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
            private static int ___sm_layer(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.layer = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_active(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
                    l.GetLua(1, out tar);
                    var rv = tar.active;
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
            private static int ___sm_active(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.active = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_activeSelf(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
                    l.GetLua(1, out tar);
                    var rv = tar.activeSelf;
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
            private static int ___gm_activeInHierarchy(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
                    l.GetLua(1, out tar);
                    var rv = tar.activeInHierarchy;
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
            private static int ___gm_isStatic(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
                    l.GetLua(1, out tar);
                    var rv = tar.isStatic;
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
            private static int ___sm_isStatic(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.isStatic = val;
                    return 0;
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
                    UnityEngine.GameObject tar;
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
                    UnityEngine.GameObject tar;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_scene(IntPtr l)
            {
                try
                {
                    UnityEngine.GameObject tar;
                    l.GetLua(1, out tar);
                    var rv = tar.scene;
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
                    UnityEngine.GameObject tar;
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
            #endregion // FUNC_I_PROP
            #region FUNC_S_FUNC
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_CreatePrimitive(IntPtr l)
            {
                try
                {
                    UnityEngine.PrimitiveType p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.GameObject.CreatePrimitive(p0);
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
            private static int ___smm_FindGameObjectWithTag(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.GameObject.FindGameObjectWithTag(p0);
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
            private static int ___smm_FindWithTag(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.GameObject.FindWithTag(p0);
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
            private static int ___smm_FindGameObjectsWithTag(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.GameObject.FindGameObjectsWithTag(p0);
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
            private static int ___smm_Find(IntPtr l)
            {
                try
                {
                    System.String p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.GameObject.Find(p0);
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
            #endregion // FUNC_S_FUNC
            #region FUNC_S_PROP
            #endregion // FUNC_S_PROP
            #region FUNC_G_I_FUNC
            private static int ___mm_g_AddComponent<T>(IntPtr l) where T : UnityEngine.Component
            {
                UnityEngine.GameObject p0;
                l.GetLua(1, out p0);
                var rv = p0.AddComponent<T>();
                l.PushLua(rv);
                return 1;
            }
            private static int ___mm_g_GetComponent<T>(IntPtr l)
            {
                UnityEngine.GameObject p0;
                l.GetLua(1, out p0);
                var rv = p0.GetComponent<T>();
                l.PushLua(rv);
                return 1;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_AddComponent_UnityEngine_SkinnedMeshRenderer(IntPtr l)
            {
                return ___mm_g_AddComponent<UnityEngine.SkinnedMeshRenderer>(l);
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetComponent_UnityEngine_SkinnedMeshRenderer(IntPtr l)
            {
                return ___mm_g_GetComponent<UnityEngine.SkinnedMeshRenderer>(l);
            }
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
        private static TypeHubPrecompiled_UnityEngine_GameObject ___tp_UnityEngine_GameObject = new TypeHubPrecompiled_UnityEngine_GameObject();
        public static void PushLua(this IntPtr l, UnityEngine.GameObject val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_GameObject.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.GameObject val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.GameObject;
        }
    }
}
#endif
