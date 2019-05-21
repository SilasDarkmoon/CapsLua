#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Texture2D : LuaHub.TypeHubPrecompiled_UnityEngine_Texture
        {
            public TypeHubPrecompiled_UnityEngine_Texture2D() : this(typeof(UnityEngine.Texture2D)) { }
            public TypeHubPrecompiled_UnityEngine_Texture2D(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["ReadPixels"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["ReadPixels"]._Method, _Precompiled = ___fm_ReadPixels };
                _InstanceMethods["Apply"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Apply"]._Method, _Precompiled = ___fm_Apply };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["height"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["height"]._Method, _Precompiled = ___gf_height };
                _InstanceFieldsNewIndex["height"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["height"]._Method, _Precompiled = ___sf_height };
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
            private static readonly lua.CFunction ___fm_ReadPixels = new lua.CFunction(___mm_ReadPixels);
            private static readonly lua.CFunction ___fm_Apply = new lua.CFunction(___mm_Apply);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_height = new lua.CFunction(___gm_height);
            private static readonly lua.CFunction ___sf_height = new lua.CFunction(___sm_height);
            private static readonly lua.CFunction ___gf_name = new lua.CFunction(___gm_name);
            private static readonly lua.CFunction ___sf_name = new lua.CFunction(___sm_name);
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
                            var oldtop = l.gettop();
                            if (oldtop == 3)
                            {
                                goto Label_10;
                            }
                            else if (oldtop == 5)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 6)
                            {
                                goto Label_30;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            var rv = new UnityEngine.Texture2D(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            UnityEngine.TextureFormat p3;
                            l.GetLua(4, out p3);
                            System.Boolean p4;
                            l.GetLua(5, out p4);
                            var rv = new UnityEngine.Texture2D(p1, p2, p3, p4);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            System.Int32 p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            UnityEngine.TextureFormat p3;
                            l.GetLua(4, out p3);
                            System.Boolean p4;
                            l.GetLua(5, out p4);
                            System.Boolean p5;
                            l.GetLua(6, out p5);
                            var rv = new UnityEngine.Texture2D(p1, p2, p3, p4, p5);
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
            private static int ___mm_ReadPixels(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 4)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 5)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Texture2D p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Rect p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            System.Boolean p4;
                            l.GetLua(5, out p4);
                            p0.ReadPixels(p1, p2, p3, p4);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Texture2D p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Rect p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            System.Int32 p3;
                            l.GetLua(4, out p3);
                            p0.ReadPixels(p1, p2, p3);
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
            private static int ___mm_Apply(IntPtr l)
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
                            UnityEngine.Texture2D p0;
                            l.GetLua(1, out p0);
                            System.Boolean p1;
                            l.GetLua(2, out p1);
                            System.Boolean p2;
                            l.GetLua(3, out p2);
                            p0.Apply(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Texture2D p0;
                            l.GetLua(1, out p0);
                            System.Boolean p1;
                            l.GetLua(2, out p1);
                            p0.Apply(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Texture2D p0;
                            l.GetLua(1, out p0);
                            p0.Apply();
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
            private static int ___gm_height(IntPtr l)
            {
                try
                {
                    UnityEngine.Texture2D tar;
                    l.GetLua(1, out tar);
                    var rv = tar.height;
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
            private static int ___sm_height(IntPtr l)
            {
                try
                {
                    UnityEngine.Texture2D tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.height = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_name(IntPtr l)
            {
                try
                {
                    UnityEngine.Texture2D tar;
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
                    UnityEngine.Texture2D tar;
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
        private static TypeHubPrecompiled_UnityEngine_Texture2D ___tp_UnityEngine_Texture2D = new TypeHubPrecompiled_UnityEngine_Texture2D();
        public static void PushLua(this IntPtr l, UnityEngine.Texture2D val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_Texture2D.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Texture2D val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Texture2D;
        }
    }
}
#endif
