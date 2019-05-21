#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Material : LuaHub.TypeHubPrecompiled_UnityEngine_Object
        {
            public TypeHubPrecompiled_UnityEngine_Material() : this(typeof(UnityEngine.Material)) { }
            public TypeHubPrecompiled_UnityEngine_Material(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["SetVector"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetVector"]._Method, _Precompiled = ___fm_SetVector };
                _InstanceMethods["SetFloat"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetFloat"]._Method, _Precompiled = ___fm_SetFloat };
                _InstanceMethods["SetTexture"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetTexture"]._Method, _Precompiled = ___fm_SetTexture };
                _InstanceMethods["SetColor"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetColor"]._Method, _Precompiled = ___fm_SetColor };
                _InstanceMethods["SetInt"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetInt"]._Method, _Precompiled = ___fm_SetInt };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["mainTexture"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["mainTexture"]._Method, _Precompiled = ___gf_mainTexture };
                _InstanceFieldsNewIndex["mainTexture"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["mainTexture"]._Method, _Precompiled = ___sf_mainTexture };
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
                _Ctor._Precompiled = ___fm_ctor;
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
            private static readonly lua.CFunction ___fm_ctor = new lua.CFunction(___mm_ctor);
            #endregion // DEL_I_CTOR
            #region DEL_I_FUNC
            private static readonly lua.CFunction ___fm_SetVector = new lua.CFunction(___mm_SetVector);
            private static readonly lua.CFunction ___fm_SetFloat = new lua.CFunction(___mm_SetFloat);
            private static readonly lua.CFunction ___fm_SetTexture = new lua.CFunction(___mm_SetTexture);
            private static readonly lua.CFunction ___fm_SetColor = new lua.CFunction(___mm_SetColor);
            private static readonly lua.CFunction ___fm_SetInt = new lua.CFunction(___mm_SetInt);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_mainTexture = new lua.CFunction(___gm_mainTexture);
            private static readonly lua.CFunction ___sf_mainTexture = new lua.CFunction(___sm_mainTexture);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_ctor(IntPtr l)
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
                                        goto Label_10;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(UnityEngine.Material) || typeof(UnityEngine.Material).IsAssignableFrom(___ot1))
                                        {
                                            goto Label_30;
                                        }
                                        if (___ot1 == typeof(UnityEngine.Shader))
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
                            System.String p1;
                            l.GetLua(2, out p1);
                            var rv = new UnityEngine.Material(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Shader p1;
                            l.GetLua(2, out p1);
                            var rv = new UnityEngine.Material(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Material p1;
                            l.GetLua(2, out p1);
                            var rv = new UnityEngine.Material(p1);
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
            private static int ___mm_SetVector(IntPtr l)
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
                                        goto Label_10;
                                    }
                                    else if (___lt1 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Int32))
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
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Vector4 p2;
                            l.GetLua(3, out p2);
                            p0.SetVector(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Vector4 p2;
                            l.GetLua(3, out p2);
                            p0.SetVector(p1, p2);
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
            private static int ___mm_SetFloat(IntPtr l)
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
                                        goto Label_10;
                                    }
                                    else if (___lt1 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Int32))
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
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            p0.SetFloat(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            p0.SetFloat(p1, p2);
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
            private static int ___mm_SetTexture(IntPtr l)
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
                                        goto Label_10;
                                    }
                                    else if (___lt1 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Int32))
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
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Texture p2;
                            l.GetLua(3, out p2);
                            p0.SetTexture(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Texture p2;
                            l.GetLua(3, out p2);
                            p0.SetTexture(p1, p2);
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
            private static int ___mm_SetColor(IntPtr l)
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
                                        goto Label_10;
                                    }
                                    else if (___lt1 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Int32))
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
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Color p2;
                            l.GetLua(3, out p2);
                            p0.SetColor(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Color p2;
                            l.GetLua(3, out p2);
                            p0.SetColor(p1, p2);
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
            private static int ___mm_SetInt(IntPtr l)
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
                                        goto Label_10;
                                    }
                                    else if (___lt1 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_20;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Int32))
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
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            p0.SetInt(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Material p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            p0.SetInt(p1, p2);
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
            private static int ___gm_mainTexture(IntPtr l)
            {
                try
                {
                    UnityEngine.Material tar;
                    l.GetLua(1, out tar);
                    var rv = tar.mainTexture;
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
            private static int ___sm_mainTexture(IntPtr l)
            {
                try
                {
                    UnityEngine.Material tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Texture val;
                    l.GetLua(2, out val);
                    tar.mainTexture = val;
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
        private static TypeHubPrecompiled_UnityEngine_Material ___tp_UnityEngine_Material = new TypeHubPrecompiled_UnityEngine_Material();
        public static void PushLua(this IntPtr l, UnityEngine.Material val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Material val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Material;
        }
    }
}
#endif
