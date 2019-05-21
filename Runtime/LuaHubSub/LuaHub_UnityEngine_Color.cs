#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Color : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.Color>
        {
            public TypeHubPrecompiled_UnityEngine_Color()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    LuaHub.LuaHubC.capslua_setTypeColor(r);
                }
                #endif
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["r"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["r"]._Method, _Precompiled = ___gf_r };
                _InstanceFieldsNewIndex["r"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["r"]._Method, _Precompiled = ___sf_r };
                _InstanceFieldsIndex["g"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["g"]._Method, _Precompiled = ___gf_g };
                _InstanceFieldsNewIndex["g"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["g"]._Method, _Precompiled = ___sf_g };
                _InstanceFieldsIndex["b"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["b"]._Method, _Precompiled = ___gf_b };
                _InstanceFieldsNewIndex["b"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["b"]._Method, _Precompiled = ___sf_b };
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
                #endregion // REG_S_FUNC
                #region REG_S_PROP
                _StaticFieldsIndex["white"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["white"]._Method, _Precompiled = ___sgf_white };
                _StaticFieldsIndex["black"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["black"]._Method, _Precompiled = ___sgf_black };
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
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_r = new lua.CFunction(___gm_r);
            private static readonly lua.CFunction ___sf_r = new lua.CFunction(___sm_r);
            private static readonly lua.CFunction ___gf_g = new lua.CFunction(___gm_g);
            private static readonly lua.CFunction ___sf_g = new lua.CFunction(___sm_g);
            private static readonly lua.CFunction ___gf_b = new lua.CFunction(___gm_b);
            private static readonly lua.CFunction ___sf_b = new lua.CFunction(___sm_b);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_white = new lua.CFunction(___sgm_white);
            private static readonly lua.CFunction ___sgf_black = new lua.CFunction(___sgm_black);
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
                            if (oldtop == 1)
                            {
                                goto Label_30;
                            }
                            else if (oldtop == 4)
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
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            System.Single p4;
                            l.GetLua(5, out p4);
                            var rv = new UnityEngine.Color(p1, p2, p3, p4);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            var rv = new UnityEngine.Color(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            var rv = default(UnityEngine.Color);
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
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_r(IntPtr l)
            {
                try
                {
                    UnityEngine.Color tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.r;
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
            private static int ___sm_r(IntPtr l)
            {
                try
                {
                    UnityEngine.Color tar;
                    tar = GetLuaChecked(l, 1);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.r = val;
                    SetDataRaw(l, 1, tar);
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_g(IntPtr l)
            {
                try
                {
                    UnityEngine.Color tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.g;
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
            private static int ___sm_g(IntPtr l)
            {
                try
                {
                    UnityEngine.Color tar;
                    tar = GetLuaChecked(l, 1);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.g = val;
                    SetDataRaw(l, 1, tar);
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_b(IntPtr l)
            {
                try
                {
                    UnityEngine.Color tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.b;
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
            private static int ___sm_b(IntPtr l)
            {
                try
                {
                    UnityEngine.Color tar;
                    tar = GetLuaChecked(l, 1);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.b = val;
                    SetDataRaw(l, 1, tar);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_white(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Color.white;
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
            private static int ___sgm_black(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Color.black;
                    l.PushLua(rv);
                    return 1;
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
            
            public static readonly LuaString LS_R = new LuaString("r");
            public static readonly LuaString LS_G = new LuaString("g");
            public static readonly LuaString LS_B = new LuaString("b");
            public static readonly LuaString LS_A = new LuaString("a");
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.Color)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.Color)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.Color GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.Color);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.Color val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var r = val.r;
                    var g = val.g;
                    var b = val.b;
                    var a = val.a;
                    LuaHub.LuaHubC.capslua_pushColor(l, r, g, b, a);
                }
                else
                #endif
                {
                    l.checkstack(3);
                    l.newtable(); // ud
                    SetDataRaw(l, -1, val);
                    PushToLuaCached(l); // ud type
                    l.pushlightuserdata(LuaConst.LRKEY_OBJ_META); // ud type #meta
                    l.rawget(-2); // ud type meta
                    l.setmetatable(-3); // ud type
                    l.pop(1); // ud
                }
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, UnityEngine.Color val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.Color GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.Color val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var r = val.r;
                    var g = val.g;
                    var b = val.b;
                    var a = val.a;
                    LuaHub.LuaHubC.capslua_setColor(l, index, r, g, b, a);
                }
                else
                #endif
                {
                    l.checkstack(3);
                    l.pushvalue(index);
                    l.PushString(LS_R);
                    l.PushLua(val.r);
                    l.rawset(-3);
                    l.PushString(LS_G);
                    l.PushLua(val.g);
                    l.rawset(-3);
                    l.PushString(LS_B);
                    l.PushLua(val.b);
                    l.rawset(-3);
                    l.PushString(LS_A);
                    l.PushLua(val.a);
                    l.rawset(-3);
                    l.pop(1);
                }
            }
            public static UnityEngine.Color GetLuaRaw(IntPtr l, int index)
            {
                UnityEngine.Color rv = new UnityEngine.Color();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    System.Single r = default(System.Single);
                    System.Single g = default(System.Single);
                    System.Single b = default(System.Single);
                    System.Single a = default(System.Single);
                    LuaHub.LuaHubC.capslua_getColor(l, index, out r, out g, out b, out a);
                    rv.a = a;
                    rv.b = b;
                    rv.g = g;
                    rv.r = r;
                }
                else
                #endif
                {
                    System.Single r;
                    System.Single g;
                    System.Single b;
                    System.Single a;
                    l.checkstack(2);
                    l.pushvalue(index);
                    l.PushString(LS_R);
                    l.rawget(-2);
                    l.GetLua(-1, out r);
                    l.pop(1);
                    l.PushString(LS_G);
                    l.rawget(-2);
                    l.GetLua(-1, out g);
                    l.pop(1);
                    l.PushString(LS_B);
                    l.rawget(-2);
                    l.GetLua(-1, out b);
                    l.pop(1);
                    l.PushString(LS_A);
                    l.rawget(-2);
                    l.GetLua(-1, out a);
                    l.pop(1);
                    l.pop(1);
                    rv.r = r;
                    rv.g = g;
                    rv.b = b;
                    rv.a = a;
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_Color ___tp_UnityEngine_Color = new TypeHubPrecompiled_UnityEngine_Color();
        public static void PushLua(this IntPtr l, UnityEngine.Color val)
        {
            ___tp_UnityEngine_Color.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Color val)
        {
            val = TypeHubPrecompiled_UnityEngine_Color.GetLuaChecked(l, index);
        }
    }
}
#endif
