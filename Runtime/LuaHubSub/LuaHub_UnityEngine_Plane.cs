#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Plane : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.Plane>
        {
            public TypeHubPrecompiled_UnityEngine_Plane()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    LuaHub.LuaHubC.capslua_setTypePlane(r);
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
            
            public static readonly LuaString LS_NORMAL = new LuaString("normal");
            public static readonly LuaString LS_DISTANCE = new LuaString("distance");
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.Plane)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.Plane)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.Plane GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.Plane);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.Plane val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var normal = val.normal;
                    var distance = val.distance;
                    var normal_x = normal.x;
                    var normal_y = normal.y;
                    var normal_z = normal.z;
                    LuaHub.LuaHubC.capslua_pushPlane(l, distance, normal_x, normal_y, normal_z);
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
            public override void SetData(IntPtr l, int index, UnityEngine.Plane val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.Plane GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.Plane val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var normal = val.normal;
                    var distance = val.distance;
                    var normal_x = normal.x;
                    var normal_y = normal.y;
                    var normal_z = normal.z;
                    LuaHub.LuaHubC.capslua_setPlane(l, index, distance, normal_x, normal_y, normal_z);
                }
                else
                #endif
                {
                    l.checkstack(3);
                    l.pushvalue(index);
                    l.PushString(LS_NORMAL);
                    l.PushLua(val.normal);
                    l.rawset(-3);
                    l.PushString(LS_DISTANCE);
                    l.PushLua(val.distance);
                    l.rawset(-3);
                    l.pop(1);
                }
            }
            public static UnityEngine.Plane GetLuaRaw(IntPtr l, int index)
            {
                UnityEngine.Plane rv = new UnityEngine.Plane();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    UnityEngine.Vector3 normal = default(UnityEngine.Vector3);
                    System.Single distance = default(System.Single);
                    System.Single normal_x = default(System.Single);
                    System.Single normal_y = default(System.Single);
                    System.Single normal_z = default(System.Single);
                    LuaHub.LuaHubC.capslua_getPlane(l, index, out distance, out normal_x, out normal_y, out normal_z);
                    normal.z = normal_z;
                    normal.y = normal_y;
                    normal.x = normal_x;
                    rv.distance = distance;
                    rv.normal = normal;
                }
                else
                #endif
                {
                    UnityEngine.Vector3 normal;
                    System.Single distance;
                    l.checkstack(2);
                    l.pushvalue(index);
                    l.PushString(LS_NORMAL);
                    l.rawget(-2);
                    l.GetLua(-1, out normal);
                    l.pop(1);
                    l.PushString(LS_DISTANCE);
                    l.rawget(-2);
                    l.GetLua(-1, out distance);
                    l.pop(1);
                    l.pop(1);
                    rv.normal = normal;
                    rv.distance = distance;
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_Plane ___tp_UnityEngine_Plane = new TypeHubPrecompiled_UnityEngine_Plane();
        public static void PushLua(this IntPtr l, UnityEngine.Plane val)
        {
            ___tp_UnityEngine_Plane.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Plane val)
        {
            val = TypeHubPrecompiled_UnityEngine_Plane.GetLuaChecked(l, index);
        }
    }
}
#endif
