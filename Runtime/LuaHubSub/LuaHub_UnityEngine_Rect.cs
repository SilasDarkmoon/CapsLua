#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Rect : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.Rect>
        {
            public TypeHubPrecompiled_UnityEngine_Rect()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    LuaHub.LuaHubC.capslua_setTypeRect(r);
                }
                #endif
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["width"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["width"]._Method, _Precompiled = ___gf_width };
                _InstanceFieldsNewIndex["width"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["width"]._Method, _Precompiled = ___sf_width };
                _InstanceFieldsIndex["height"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["height"]._Method, _Precompiled = ___gf_height };
                _InstanceFieldsNewIndex["height"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["height"]._Method, _Precompiled = ___sf_height };
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
            private static readonly lua.CFunction ___gf_width = new lua.CFunction(___gm_width);
            private static readonly lua.CFunction ___sf_width = new lua.CFunction(___sm_width);
            private static readonly lua.CFunction ___gf_height = new lua.CFunction(___gm_height);
            private static readonly lua.CFunction ___sf_height = new lua.CFunction(___sm_height);
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
                            if (oldtop == 1)
                            {
                                goto Label_40;
                            }
                            else if (oldtop == 2)
                            {
                                goto Label_30;
                            }
                            else if (oldtop == 3)
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
                            var rv = new UnityEngine.Rect(p1, p2, p3, p4);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Vector2 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Vector2 p2;
                            l.GetLua(3, out p2);
                            var rv = new UnityEngine.Rect(p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Rect p1;
                            l.GetLua(2, out p1);
                            var rv = new UnityEngine.Rect(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            var rv = default(UnityEngine.Rect);
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
            private static int ___gm_width(IntPtr l)
            {
                try
                {
                    UnityEngine.Rect tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.width;
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
            private static int ___sm_width(IntPtr l)
            {
                try
                {
                    UnityEngine.Rect tar;
                    tar = GetLuaChecked(l, 1);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.width = val;
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
            private static int ___gm_height(IntPtr l)
            {
                try
                {
                    UnityEngine.Rect tar;
                    tar = GetLuaChecked(l, 1);
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
                    UnityEngine.Rect tar;
                    tar = GetLuaChecked(l, 1);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.height = val;
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
            
            public static readonly LuaString LS_XMIN = new LuaString("xMin");
            public static readonly LuaString LS_YMIN = new LuaString("yMin");
            public static readonly LuaString LS_WIDTH = new LuaString("width");
            public static readonly LuaString LS_HEIGHT = new LuaString("height");
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.Rect)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.Rect)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.Rect GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.Rect);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.Rect val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var xMin = val.xMin;
                    var yMin = val.yMin;
                    var width = val.width;
                    var height = val.height;
                    LuaHub.LuaHubC.capslua_pushRect(l, xMin, yMin, width, height);
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
            public override void SetData(IntPtr l, int index, UnityEngine.Rect val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.Rect GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.Rect val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var xMin = val.xMin;
                    var yMin = val.yMin;
                    var width = val.width;
                    var height = val.height;
                    LuaHub.LuaHubC.capslua_setRect(l, index, xMin, yMin, width, height);
                }
                else
                #endif
                {
                    l.checkstack(3);
                    l.pushvalue(index);
                    l.PushString(LS_XMIN);
                    l.PushLua(val.xMin);
                    l.rawset(-3);
                    l.PushString(LS_YMIN);
                    l.PushLua(val.yMin);
                    l.rawset(-3);
                    l.PushString(LS_WIDTH);
                    l.PushLua(val.width);
                    l.rawset(-3);
                    l.PushString(LS_HEIGHT);
                    l.PushLua(val.height);
                    l.rawset(-3);
                    l.pop(1);
                }
            }
            public static UnityEngine.Rect GetLuaRaw(IntPtr l, int index)
            {
                UnityEngine.Rect rv = new UnityEngine.Rect();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    System.Single xMin = default(System.Single);
                    System.Single yMin = default(System.Single);
                    System.Single width = default(System.Single);
                    System.Single height = default(System.Single);
                    LuaHub.LuaHubC.capslua_getRect(l, index, out xMin, out yMin, out width, out height);
                    rv.height = height;
                    rv.width = width;
                    rv.yMin = yMin;
                    rv.xMin = xMin;
                }
                else
                #endif
                {
                    System.Single xMin;
                    System.Single yMin;
                    System.Single width;
                    System.Single height;
                    l.checkstack(2);
                    l.pushvalue(index);
                    l.PushString(LS_XMIN);
                    l.rawget(-2);
                    l.GetLua(-1, out xMin);
                    l.pop(1);
                    l.PushString(LS_YMIN);
                    l.rawget(-2);
                    l.GetLua(-1, out yMin);
                    l.pop(1);
                    l.PushString(LS_WIDTH);
                    l.rawget(-2);
                    l.GetLua(-1, out width);
                    l.pop(1);
                    l.PushString(LS_HEIGHT);
                    l.rawget(-2);
                    l.GetLua(-1, out height);
                    l.pop(1);
                    l.pop(1);
                    rv.xMin = xMin;
                    rv.yMin = yMin;
                    rv.width = width;
                    rv.height = height;
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_Rect ___tp_UnityEngine_Rect = new TypeHubPrecompiled_UnityEngine_Rect();
        public static void PushLua(this IntPtr l, UnityEngine.Rect val)
        {
            ___tp_UnityEngine_Rect.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Rect val)
        {
            val = TypeHubPrecompiled_UnityEngine_Rect.GetLuaChecked(l, index);
        }
    }
}
#endif
