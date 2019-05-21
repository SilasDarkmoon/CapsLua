#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_RenderTexture : LuaHub.TypeHubPrecompiled_UnityEngine_Texture
        {
            public TypeHubPrecompiled_UnityEngine_RenderTexture() : this(typeof(UnityEngine.RenderTexture)) { }
            public TypeHubPrecompiled_UnityEngine_RenderTexture(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["name"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["name"]._Method, _Precompiled = ___gf_name };
                _InstanceFieldsNewIndex["name"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["name"]._Method, _Precompiled = ___sf_name };
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
                _StaticMethods["GetTemporary"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["GetTemporary"]._Method, _Precompiled = ___sfm_GetTemporary };
                _StaticMethods["ReleaseTemporary"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["ReleaseTemporary"]._Method, _Precompiled = ___sfm_ReleaseTemporary };
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                _StaticFieldsIndex["active"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["active"]._Method, _Precompiled = ___sgf_active };
                _StaticFieldsNewIndex["active"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsNewIndex["active"]._Method, _Precompiled = ___ssf_active };
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
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_name = new lua.CFunction(___gm_name);
            private static readonly lua.CFunction ___sf_name = new lua.CFunction(___sm_name);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_GetTemporary = new lua.CFunction(___smm_GetTemporary);
            private static readonly lua.CFunction ___sfm_ReleaseTemporary = new lua.CFunction(___smm_ReleaseTemporary);
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_active = new lua.CFunction(___sgm_active);
            private static readonly lua.CFunction ___ssf_active = new lua.CFunction(___ssm_active);
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
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_name(IntPtr l)
            {
                try
                {
                    UnityEngine.RenderTexture tar;
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
                    UnityEngine.RenderTexture tar;
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
            #endregion // FUNC_I_PROP
            #region FUNC_S_FUNC
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_GetTemporary(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_60;
                            }
                            else if (oldtop == 3)
                            {
                                goto Label_50;
                            }
                            else if (oldtop == 4)
                            {
                                goto Label_40;
                            }
                            else if (oldtop == 5)
                            {
                                goto Label_30;
                            }
                            else if (oldtop >= 6)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Int32 p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            UnityEngine.RenderTextureFormat p3;
                            l.GetLua(4, out p3);
                            UnityEngine.RenderTextureReadWrite p4;
                            l.GetLua(5, out p4);
                            System.Int32 p5;
                            l.GetLua(6, out p5);
                            var rv = UnityEngine.RenderTexture.GetTemporary(p0, p1, p2, p3, p4, p5);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.Int32 p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            UnityEngine.RenderTextureFormat p3;
                            l.GetLua(4, out p3);
                            UnityEngine.RenderTextureReadWrite p4;
                            l.GetLua(5, out p4);
                            var rv = UnityEngine.RenderTexture.GetTemporary(p0, p1, p2, p3, p4);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            System.Int32 p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            UnityEngine.RenderTextureFormat p3;
                            l.GetLua(4, out p3);
                            var rv = UnityEngine.RenderTexture.GetTemporary(p0, p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            System.Int32 p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = UnityEngine.RenderTexture.GetTemporary(p0, p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            System.Int32 p0;
                            l.GetLua(1, out p0);
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            var rv = UnityEngine.RenderTexture.GetTemporary(p0, p1);
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
            private static int ___smm_ReleaseTemporary(IntPtr l)
            {
                try
                {
                    UnityEngine.RenderTexture p0;
                    l.GetLua(1, out p0);
                    UnityEngine.RenderTexture.ReleaseTemporary(p0);
                    return 0;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_active(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.RenderTexture.active;
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
            private static int ___ssm_active(IntPtr l)
            {
                try
                {
                    UnityEngine.RenderTexture val;
                    l.GetLua(1, out val);
                    UnityEngine.RenderTexture.active = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
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
        private static TypeHubPrecompiled_UnityEngine_RenderTexture ___tp_UnityEngine_RenderTexture = new TypeHubPrecompiled_UnityEngine_RenderTexture();
        public static void PushLua(this IntPtr l, UnityEngine.RenderTexture val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.RenderTexture val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.RenderTexture;
        }
    }
}
#endif
