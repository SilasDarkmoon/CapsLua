#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Bounds : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.Bounds>
        {
            public TypeHubPrecompiled_UnityEngine_Bounds()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHubC.Ready)
                {
                    LuaHubC.capslua_setTypeBounds(r);
                }
                #endif
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
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
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
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
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
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
            
            public static readonly LuaString LS_CENTER = new LuaString("center");
            public static readonly LuaString LS_EXTENTS = new LuaString("extents");
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.Bounds)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.Bounds)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.Bounds GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.Bounds);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.Bounds val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHubC.Ready)
                {
                    var center = val.center;
                    var extents = val.extents;
                    var center_x = center.x;
                    var center_y = center.y;
                    var center_z = center.z;
                    var extents_x = extents.x;
                    var extents_y = extents.y;
                    var extents_z = extents.z;
                    LuaHubC.capslua_pushBounds(l, center_x, center_y, center_z, extents_x, extents_y, extents_z);
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
            public override void SetData(IntPtr l, int index, UnityEngine.Bounds val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.Bounds GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.Bounds val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHubC.Ready)
                {
                    var center = val.center;
                    var extents = val.extents;
                    var center_x = center.x;
                    var center_y = center.y;
                    var center_z = center.z;
                    var extents_x = extents.x;
                    var extents_y = extents.y;
                    var extents_z = extents.z;
                    LuaHubC.capslua_setBounds(l, index, center_x, center_y, center_z, extents_x, extents_y, extents_z);
                }
                else
                #endif
                {
                    l.checkstack(3);
                    l.pushvalue(index);
                    l.PushString(LS_CENTER);
                    l.PushLua(val.center);
                    l.rawset(-3);
                    l.PushString(LS_EXTENTS);
                    l.PushLua(val.extents);
                    l.rawset(-3);
                    l.pop(1);
                }
            }
            public static UnityEngine.Bounds GetLuaRaw(IntPtr l, int index)
            {
                UnityEngine.Bounds rv = new UnityEngine.Bounds();
                #if !DISABLE_LUA_HUB_C
                if (LuaHubC.Ready)
                {
                    UnityEngine.Vector3 center = default(UnityEngine.Vector3);
                    UnityEngine.Vector3 extents = default(UnityEngine.Vector3);
                    System.Single center_x = default(System.Single);
                    System.Single center_y = default(System.Single);
                    System.Single center_z = default(System.Single);
                    System.Single extents_x = default(System.Single);
                    System.Single extents_y = default(System.Single);
                    System.Single extents_z = default(System.Single);
                    LuaHubC.capslua_getBounds(l, index, out center_x, out center_y, out center_z, out extents_x, out extents_y, out extents_z);
                    extents.z = extents_z;
                    extents.y = extents_y;
                    extents.x = extents_x;
                    center.z = center_z;
                    center.y = center_y;
                    center.x = center_x;
                    rv.extents = extents;
                    rv.center = center;
                }
                else
                #endif
                {
                    UnityEngine.Vector3 center;
                    UnityEngine.Vector3 extents;
                    l.checkstack(2);
                    l.pushvalue(index);
                    l.PushString(LS_CENTER);
                    l.rawget(-2);
                    l.GetLua(-1, out center);
                    l.pop(1);
                    l.PushString(LS_EXTENTS);
                    l.rawget(-2);
                    l.GetLua(-1, out extents);
                    l.pop(1);
                    l.pop(1);
                    rv.center = center;
                    rv.extents = extents;
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_Bounds ___tp_UnityEngine_Bounds = new TypeHubPrecompiled_UnityEngine_Bounds();
        public static void PushLua(this IntPtr l, UnityEngine.Bounds val)
        {
            ___tp_UnityEngine_Bounds.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Bounds val)
        {
            val = TypeHubPrecompiled_UnityEngine_Bounds.GetLuaChecked(l, index);
        }
    }
}
#endif
