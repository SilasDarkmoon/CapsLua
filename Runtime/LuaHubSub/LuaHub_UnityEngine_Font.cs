#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Font : LuaHub.TypeHubPrecompiled_UnityEngine_Object
        {
            public TypeHubPrecompiled_UnityEngine_Font() : this(typeof(UnityEngine.Font)) { }
            public TypeHubPrecompiled_UnityEngine_Font(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["RequestCharactersInTexture"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["RequestCharactersInTexture"]._Method, _Precompiled = ___fm_RequestCharactersInTexture };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["material"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["material"]._Method, _Precompiled = ___gf_material };
                _InstanceFieldsNewIndex["material"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["material"]._Method, _Precompiled = ___sf_material };
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
            private static readonly lua.CFunction ___fm_RequestCharactersInTexture = new lua.CFunction(___mm_RequestCharactersInTexture);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_material = new lua.CFunction(___gm_material);
            private static readonly lua.CFunction ___sf_material = new lua.CFunction(___sm_material);
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
            private static int ___mm_RequestCharactersInTexture(IntPtr l)
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
                            else if (oldtop == 3)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Font p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            UnityEngine.FontStyle p3;
                            l.GetLua(4, out p3);
                            p0.RequestCharactersInTexture(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Font p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            System.Int32 p2;
                            l.GetLua(3, out p2);
                            p0.RequestCharactersInTexture(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Font p0;
                            l.GetLua(1, out p0);
                            System.String p1;
                            l.GetLua(2, out p1);
                            p0.RequestCharactersInTexture(p1);
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
            private static int ___gm_material(IntPtr l)
            {
                try
                {
                    UnityEngine.Font tar;
                    l.GetLua(1, out tar);
                    var rv = tar.material;
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
            private static int ___sm_material(IntPtr l)
            {
                try
                {
                    UnityEngine.Font tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Material val;
                    l.GetLua(2, out val);
                    tar.material = val;
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
        private static TypeHubPrecompiled_UnityEngine_Font ___tp_UnityEngine_Font = new TypeHubPrecompiled_UnityEngine_Font();
        public static void PushLua(this IntPtr l, UnityEngine.Font val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_Font.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Font val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Font;
        }
    }
}
#endif
