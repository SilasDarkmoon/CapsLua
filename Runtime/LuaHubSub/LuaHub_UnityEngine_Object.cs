#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Object : Capstones.LuaLib.LuaTypeHub.TypeHubCommonPrecompiled, ILuaConvert
        {
            public TypeHubPrecompiled_UnityEngine_Object() : this(typeof(UnityEngine.Object)) { }
            public TypeHubPrecompiled_UnityEngine_Object(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["GetInstanceID"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetInstanceID"]._Method, _Precompiled = ___fm_GetInstanceID };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["name"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["name"]._Method, _Precompiled = ___gf_name };
                _InstanceFieldsNewIndex["name"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["name"]._Method, _Precompiled = ___sf_name };
                _InstanceFieldsIndex["hideFlags"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["hideFlags"]._Method, _Precompiled = ___gf_hideFlags };
                _InstanceFieldsNewIndex["hideFlags"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["hideFlags"]._Method, _Precompiled = ___sf_hideFlags };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
            }
            public override void RegPrecompiledStatic()
            {
                #region REG_I_CTOR
                _Ctor._Precompiled = ___fm_ctor;
                #endregion // REG_I_CTOR
                #region REG_S_FUNC
                _StaticMethods["Destroy"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Destroy"]._Method, _Precompiled = ___sfm_Destroy };
                _StaticMethods["DestroyImmediate"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["DestroyImmediate"]._Method, _Precompiled = ___sfm_DestroyImmediate };
                _StaticMethods["FindObjectsOfType"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["FindObjectsOfType"]._Method, _Precompiled = ___sfm_FindObjectsOfType };
                _StaticMethods["DontDestroyOnLoad"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["DontDestroyOnLoad"]._Method, _Precompiled = ___sfm_DontDestroyOnLoad };
                _StaticMethods["DestroyObject"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["DestroyObject"]._Method, _Precompiled = ___sfm_DestroyObject };
                _StaticMethods["FindSceneObjectsOfType"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["FindSceneObjectsOfType"]._Method, _Precompiled = ___sfm_FindSceneObjectsOfType };
                _StaticMethods["FindObjectsOfTypeIncludingAssets"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["FindObjectsOfTypeIncludingAssets"]._Method, _Precompiled = ___sfm_FindObjectsOfTypeIncludingAssets };
                _StaticMethods["Instantiate"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Instantiate"]._Method, _Precompiled = ___sfm_Instantiate };
                _StaticMethods["FindObjectOfType"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["FindObjectOfType"]._Method, _Precompiled = ___sfm_FindObjectOfType };
                _StaticMethods["op_Equality"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Equality"]._Method, _Precompiled = ___sfm_op_Equality };
                _StaticMethods["op_Inequality"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["op_Inequality"]._Method, _Precompiled = ___sfm_op_Inequality };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                #endregion // REG_S_PROP
                #region REG_G_S_FUNC
                #endregion // REG_G_S_FUNC
                #region REG_S_OP
                #endregion // REG_S_OP
                #region REG_S_CONV
                _ConvertFuncs[typeof(System.Boolean)] = ___convm_System_Boolean;
                #endregion // REG_S_CONV
                #region REG_G_GTYPES
                #endregion // REG_G_GTYPES
            }
            
            #region DEL_I_CTOR
            private static readonly lua.CFunction ___fm_ctor = new lua.CFunction(___mm_ctor);
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            private static readonly lua.CFunction ___fm_GetInstanceID = new lua.CFunction(___mm_GetInstanceID);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_name = new lua.CFunction(___gm_name);
            private static readonly lua.CFunction ___sf_name = new lua.CFunction(___sm_name);
            private static readonly lua.CFunction ___gf_hideFlags = new lua.CFunction(___gm_hideFlags);
            private static readonly lua.CFunction ___sf_hideFlags = new lua.CFunction(___sm_hideFlags);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_Destroy = new lua.CFunction(___smm_Destroy);
            private static readonly lua.CFunction ___sfm_DestroyImmediate = new lua.CFunction(___smm_DestroyImmediate);
            private static readonly lua.CFunction ___sfm_FindObjectsOfType = new lua.CFunction(___smm_FindObjectsOfType);
            private static readonly lua.CFunction ___sfm_DontDestroyOnLoad = new lua.CFunction(___smm_DontDestroyOnLoad);
            private static readonly lua.CFunction ___sfm_DestroyObject = new lua.CFunction(___smm_DestroyObject);
            private static readonly lua.CFunction ___sfm_FindSceneObjectsOfType = new lua.CFunction(___smm_FindSceneObjectsOfType);
            private static readonly lua.CFunction ___sfm_FindObjectsOfTypeIncludingAssets = new lua.CFunction(___smm_FindObjectsOfTypeIncludingAssets);
            private static readonly lua.CFunction ___sfm_Instantiate = new lua.CFunction(___smm_Instantiate);
            private static readonly lua.CFunction ___sfm_FindObjectOfType = new lua.CFunction(___smm_FindObjectOfType);
            private static readonly lua.CFunction ___sfm_op_Equality = new lua.CFunction(___smm_op_Equality);
            private static readonly lua.CFunction ___sfm_op_Inequality = new lua.CFunction(___smm_op_Inequality);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_ctor(IntPtr l)
            {
                try
                {
                    var rv = new UnityEngine.Object();
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
            #endregion // FUNC_I_CTOR
            #region FUNC_I_FUNC
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetInstanceID(IntPtr l)
            {
                try
                {
                    UnityEngine.Object p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetInstanceID();
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
                try
                {
                    UnityEngine.Object tar;
                    l.GetLua(1, out tar);
                    var rv = tar.name;
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
            private static int ___sm_name(IntPtr l)
            {
                try
                {
                    UnityEngine.Object tar;
                    l.GetLua(1, out tar);
                    System.String val;
                    l.GetLua(2, out val);
                    tar.name = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_hideFlags(IntPtr l)
            {
                try
                {
                    UnityEngine.Object tar;
                    l.GetLua(1, out tar);
                    var rv = tar.hideFlags;
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
            private static int ___sm_hideFlags(IntPtr l)
            {
                try
                {
                    UnityEngine.Object tar;
                    l.GetLua(1, out tar);
                    UnityEngine.HideFlags val;
                    l.GetLua(2, out val);
                    tar.hideFlags = val;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Destroy(IntPtr l)
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
                            else if (oldtop >= 2)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Object.Destroy(p0, p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Object.Destroy(p0);
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
            private static int ___smm_DestroyImmediate(IntPtr l)
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
                            else if (oldtop >= 2)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            System.Boolean p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Object.DestroyImmediate(p0, p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Object.DestroyImmediate(p0);
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
            private static int ___smm_FindObjectsOfType(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.Object.FindObjectsOfType(p0);
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
            private static int ___smm_DontDestroyOnLoad(IntPtr l)
            {
                try
                {
                    UnityEngine.Object p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Object.DontDestroyOnLoad(p0);
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
            private static int ___smm_DestroyObject(IntPtr l)
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
                            else if (oldtop >= 2)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Object.DestroyObject(p0, p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Object.DestroyObject(p0);
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
            private static int ___smm_FindSceneObjectsOfType(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.Object.FindSceneObjectsOfType(p0);
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
            private static int ___smm_FindObjectsOfTypeIncludingAssets(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.Object.FindObjectsOfTypeIncludingAssets(p0);
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
            private static int ___smm_Instantiate(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 1)
                            {
                                goto Label_30;
                            }
                            else if (oldtop == 2)
                            {
                                goto Label_40;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_20;
                            }
                            else
                            {
                                {
                                    var ___lt2 = l.type(3);
                                    if (___lt2 == LuaCoreLib.LUA_TBOOLEAN)
                                    {
                                        goto Label_50;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(UnityEngine.Transform) || typeof(UnityEngine.Transform).IsAssignableFrom(___ot1))
                                        {
                                            goto Label_50;
                                        }
                                        goto Label_10;
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Quaternion p2;
                            l.GetLua(3, out p2);
                            var rv = UnityEngine.Object.Instantiate(p0, p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Quaternion p2;
                            l.GetLua(3, out p2);
                            UnityEngine.Transform p3;
                            l.GetLua(4, out p3);
                            var rv = UnityEngine.Object.Instantiate(p0, p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            var rv = UnityEngine.Object.Instantiate(p0);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Transform p1;
                            l.GetLua(2, out p1);
                            var rv = UnityEngine.Object.Instantiate(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            UnityEngine.Object p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Transform p1;
                            l.GetLua(2, out p1);
                            System.Boolean p2;
                            l.GetLua(3, out p2);
                            var rv = UnityEngine.Object.Instantiate(p0, p1, p2);
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
            private static int ___smm_FindObjectOfType(IntPtr l)
            {
                try
                {
                    System.Type p0;
                    l.GetLua(1, out p0);
                    var rv = UnityEngine.Object.FindObjectOfType(p0);
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
            private static int ___smm_op_Equality(IntPtr l)
            {
                try
                {
                    UnityEngine.Object p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Object p1;
                    l.GetLua(2, out p1);
                    var rv = p0 == p1;
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
            private static int ___smm_op_Inequality(IntPtr l)
            {
                try
                {
                    UnityEngine.Object p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Object p1;
                    l.GetLua(2, out p1);
                    var rv = p0 != p1;
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
            #endregion // FUNC_G_I_FUNC
            #region FUNC_I_INDEX
            #endregion // FUNC_I_INDEX
            #region FUNC_G_S_FUNC
            #endregion // FUNC_G_S_FUNC
            #region FUNC_S_OP
            #endregion // FUNC_S_OP
            #region FUNC_S_CONV
            private static int ___convm_System_Boolean(IntPtr l, int index)
            {
                try
                {
                    UnityEngine.Object p0;
                    l.GetLua(index, out p0);
                    l.PushLuaExplicit<System.Boolean>((System.Boolean)p0);
                    return 1;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            #endregion // FUNC_S_CONV
            #region FUNC_G_GTYPES
            #endregion // FUNC_G_GTYPES
            
            #region NESTED_TYPE_HUB
            #endregion // NESTED_TYPE_HUB
        }
        private static TypeHubPrecompiled_UnityEngine_Object ___tp_UnityEngine_Object = new TypeHubPrecompiled_UnityEngine_Object();
        public static void PushLua(this IntPtr l, UnityEngine.Object val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Object val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Object;
        }
    }
}
#endif
