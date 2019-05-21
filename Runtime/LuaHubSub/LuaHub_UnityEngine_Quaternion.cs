#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Quaternion : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.Quaternion>
        {
            public TypeHubPrecompiled_UnityEngine_Quaternion()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    LuaHub.LuaHubC.capslua_setTypeQuaternion(r);
                }
                #endif
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["eulerAngles"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["eulerAngles"]._Method, _Precompiled = ___gf_eulerAngles };
                _InstanceFieldsNewIndex["eulerAngles"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["eulerAngles"]._Method, _Precompiled = ___sf_eulerAngles };
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
                _StaticMethods["Euler"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["Euler"]._Method, _Precompiled = ___sfm_Euler };
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
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_eulerAngles = new lua.CFunction(___gm_eulerAngles);
            private static readonly lua.CFunction ___sf_eulerAngles = new lua.CFunction(___sm_eulerAngles);
            #endregion // DEL_I_PROP
            #region DEL_S_FUNC
            private static readonly lua.CFunction ___sfm_Euler = new lua.CFunction(___smm_Euler);
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
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_eulerAngles(IntPtr l)
            {
                try
                {
                    UnityEngine.Quaternion tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.eulerAngles;
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
            private static int ___sm_eulerAngles(IntPtr l)
            {
                try
                {
                    UnityEngine.Quaternion tar;
                    tar = GetLuaChecked(l, 1);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.eulerAngles = val;
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_Euler(IntPtr l)
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
                            System.Single p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            var rv = UnityEngine.Quaternion.Euler(p0, p1, p2);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Vector3 p0;
                            l.GetLua(1, out p0);
                            var rv = UnityEngine.Quaternion.Euler(p0);
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
            
            public static readonly LuaString LS_X = new LuaString("x");
            public static readonly LuaString LS_Y = new LuaString("y");
            public static readonly LuaString LS_Z = new LuaString("z");
            public static readonly LuaString LS_W = new LuaString("w");
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.Quaternion)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.Quaternion)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.Quaternion GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.Quaternion);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.Quaternion val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var x = val.x;
                    var y = val.y;
                    var z = val.z;
                    var w = val.w;
                    LuaHub.LuaHubC.capslua_pushQuaternion(l, x, y, z, w);
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
            public override void SetData(IntPtr l, int index, UnityEngine.Quaternion val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.Quaternion GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.Quaternion val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var x = val.x;
                    var y = val.y;
                    var z = val.z;
                    var w = val.w;
                    LuaHub.LuaHubC.capslua_setQuaternion(l, index, x, y, z, w);
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
                    l.PushString(LS_Z);
                    l.PushLua(val.z);
                    l.rawset(-3);
                    l.PushString(LS_W);
                    l.PushLua(val.w);
                    l.rawset(-3);
                    l.pop(1);
                }
            }
            public static UnityEngine.Quaternion GetLuaRaw(IntPtr l, int index)
            {
                UnityEngine.Quaternion rv = new UnityEngine.Quaternion();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    System.Single x = default(System.Single);
                    System.Single y = default(System.Single);
                    System.Single z = default(System.Single);
                    System.Single w = default(System.Single);
                    LuaHub.LuaHubC.capslua_getQuaternion(l, index, out x, out y, out z, out w);
                    rv.w = w;
                    rv.z = z;
                    rv.y = y;
                    rv.x = x;
                }
                else
                #endif
                {
                    System.Single x;
                    System.Single y;
                    System.Single z;
                    System.Single w;
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
                    l.PushString(LS_Z);
                    l.rawget(-2);
                    l.GetLua(-1, out z);
                    l.pop(1);
                    l.PushString(LS_W);
                    l.rawget(-2);
                    l.GetLua(-1, out w);
                    l.pop(1);
                    l.pop(1);
                    rv.x = x;
                    rv.y = y;
                    rv.z = z;
                    rv.w = w;
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_Quaternion ___tp_UnityEngine_Quaternion = new TypeHubPrecompiled_UnityEngine_Quaternion();
        public static void PushLua(this IntPtr l, UnityEngine.Quaternion val)
        {
            ___tp_UnityEngine_Quaternion.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Quaternion val)
        {
            val = TypeHubPrecompiled_UnityEngine_Quaternion.GetLuaChecked(l, index);
        }
    }
}
#endif
