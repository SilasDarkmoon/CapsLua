#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Cloth : LuaHub.TypeHubPrecompiled_UnityEngine_Component
        {
            public TypeHubPrecompiled_UnityEngine_Cloth() : this(typeof(UnityEngine.Cloth)) { }
            public TypeHubPrecompiled_UnityEngine_Cloth(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["SetEnabledFading"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetEnabledFading"]._Method, _Precompiled = ___fm_SetEnabledFading };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["randomAcceleration"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["randomAcceleration"]._Method, _Precompiled = ___gf_randomAcceleration };
                _InstanceFieldsNewIndex["randomAcceleration"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["randomAcceleration"]._Method, _Precompiled = ___sf_randomAcceleration };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
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
            private static readonly lua.CFunction ___fm_SetEnabledFading = new lua.CFunction(___mm_SetEnabledFading);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_randomAcceleration = new lua.CFunction(___gm_randomAcceleration);
            private static readonly lua.CFunction ___sf_randomAcceleration = new lua.CFunction(___sm_randomAcceleration);
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
            private static int ___mm_SetEnabledFading(IntPtr l)
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
                            UnityEngine.Cloth p0;
                            l.GetLua(1, out p0);
                            System.Boolean p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            p0.SetEnabledFading(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Cloth p0;
                            l.GetLua(1, out p0);
                            System.Boolean p1;
                            l.GetLua(2, out p1);
                            p0.SetEnabledFading(p1);
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
            private static int ___gm_randomAcceleration(IntPtr l)
            {
                try
                {
                    UnityEngine.Cloth tar;
                    l.GetLua(1, out tar);
                    var rv = tar.randomAcceleration;
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
            private static int ___sm_randomAcceleration(IntPtr l)
            {
                try
                {
                    UnityEngine.Cloth tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.randomAcceleration = val;
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
        private static TypeHubPrecompiled_UnityEngine_Cloth ___tp_UnityEngine_Cloth = new TypeHubPrecompiled_UnityEngine_Cloth();
        public static void PushLua(this IntPtr l, UnityEngine.Cloth val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_Cloth.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Cloth val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Cloth;
        }
    }
}
#endif
