#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Vector2 : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.Vector2>
        {
            public TypeHubPrecompiled_UnityEngine_Vector2()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    LuaHub.LuaHubC.capslua_setTypeVector2(r);
                }
                #endif
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["y"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["y"]._Method, _Precompiled = ___gf_y };
                _InstanceFieldsNewIndex["y"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["y"]._Method, _Precompiled = ___sf_y };
                _InstanceFieldsIndex["x"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["x"]._Method, _Precompiled = ___gf_x };
                _InstanceFieldsNewIndex["x"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["x"]._Method, _Precompiled = ___sf_x };
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
                _StaticFieldsIndex["zero"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["zero"]._Method, _Precompiled = ___sgf_zero };
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
            private static readonly lua.CFunction ___gf_y = new lua.CFunction(___gm_y);
            private static readonly lua.CFunction ___sf_y = new lua.CFunction(___sm_y);
            private static readonly lua.CFunction ___gf_x = new lua.CFunction(___gm_x);
            private static readonly lua.CFunction ___sf_x = new lua.CFunction(___sm_x);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            #endregion // DEL_S_FUNC
            #region DEL_S_PROP
            private static readonly lua.CFunction ___sgf_zero = new lua.CFunction(___sgm_zero);
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
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            var rv = new UnityEngine.Vector2(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            var rv = default(UnityEngine.Vector2);
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
            private static int ___gm_y(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector2 tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.y;
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
            private static int ___sm_y(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector2 tar;
                    tar = GetLuaChecked(l, 1);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.y = val;
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
            private static int ___gm_x(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector2 tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.x;
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
            private static int ___sm_x(IntPtr l)
            {
                try
                {
                    UnityEngine.Vector2 tar;
                    tar = GetLuaChecked(l, 1);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.x = val;
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
            private static int ___sgm_zero(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Vector2.zero;
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
            
            public static readonly LuaString LS_X = new LuaString("x");
            public static readonly LuaString LS_Y = new LuaString("y");
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.Vector2)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.Vector2)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.Vector2 GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.Vector2);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.Vector2 val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var x = val.x;
                    var y = val.y;
                    LuaHub.LuaHubC.capslua_pushVector2(l, x, y);
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
            public override void SetData(IntPtr l, int index, UnityEngine.Vector2 val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.Vector2 GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.Vector2 val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var x = val.x;
                    var y = val.y;
                    LuaHub.LuaHubC.capslua_setVector2(l, index, x, y);
                }
                else
                #endif
                {
                    l.checkstack(3);
                    l.pushvalue(index);
                    l.PushString(LS_X);
                    l.PushLua(val.x);
                    l.rawset(-3);
                    l.PushString(LS_Y);
                    l.PushLua(val.y);
                    l.rawset(-3);
                    l.pop(1);
                }
            }
            public static UnityEngine.Vector2 GetLuaRaw(IntPtr l, int index)
            {
                UnityEngine.Vector2 rv = new UnityEngine.Vector2();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    System.Single x = default(System.Single);
                    System.Single y = default(System.Single);
                    LuaHub.LuaHubC.capslua_getVector2(l, index, out x, out y);
                    rv.y = y;
                    rv.x = x;
                }
                else
                #endif
                {
                    System.Single x;
                    System.Single y;
                    l.checkstack(2);
                    l.pushvalue(index);
                    l.PushString(LS_X);
                    l.rawget(-2);
                    l.GetLua(-1, out x);
                    l.pop(1);
                    l.PushString(LS_Y);
                    l.rawget(-2);
                    l.GetLua(-1, out y);
                    l.pop(1);
                    l.pop(1);
                    rv.x = x;
                    rv.y = y;
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_Vector2 ___tp_UnityEngine_Vector2 = new TypeHubPrecompiled_UnityEngine_Vector2();
        public static void PushLua(this IntPtr l, UnityEngine.Vector2 val)
        {
            ___tp_UnityEngine_Vector2.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Vector2 val)
        {
            val = TypeHubPrecompiled_UnityEngine_Vector2.GetLuaChecked(l, index);
        }
    }
}
#endif
