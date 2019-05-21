#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Ray : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.Ray>
        {
            public TypeHubPrecompiled_UnityEngine_Ray()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    LuaHub.LuaHubC.capslua_setTypeRay(r);
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
            
            public static readonly LuaString LS_ORIGIN = new LuaString("origin");
            public static readonly LuaString LS_DIRECTION = new LuaString("direction");
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.Ray)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.Ray)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.Ray GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.Ray);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.Ray val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var origin = val.origin;
                    var direction = val.direction;
                    var origin_x = origin.x;
                    var origin_y = origin.y;
                    var origin_z = origin.z;
                    var direction_x = direction.x;
                    var direction_y = direction.y;
                    var direction_z = direction.z;
                    LuaHub.LuaHubC.capslua_pushRay(l, origin_x, origin_y, origin_z, direction_x, direction_y, direction_z);
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
            public override void SetData(IntPtr l, int index, UnityEngine.Ray val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.Ray GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.Ray val)
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    var origin = val.origin;
                    var direction = val.direction;
                    var origin_x = origin.x;
                    var origin_y = origin.y;
                    var origin_z = origin.z;
                    var direction_x = direction.x;
                    var direction_y = direction.y;
                    var direction_z = direction.z;
                    LuaHub.LuaHubC.capslua_setRay(l, index, origin_x, origin_y, origin_z, direction_x, direction_y, direction_z);
                }
                else
                #endif
                {
                    l.checkstack(3);
                    l.pushvalue(index);
                    l.PushString(LS_ORIGIN);
                    l.PushLua(val.origin);
                    l.rawset(-3);
                    l.PushString(LS_DIRECTION);
                    l.PushLua(val.direction);
                    l.rawset(-3);
                    l.pop(1);
                }
            }
            public static UnityEngine.Ray GetLuaRaw(IntPtr l, int index)
            {
                UnityEngine.Ray rv = new UnityEngine.Ray();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    UnityEngine.Vector3 origin = default(UnityEngine.Vector3);
                    UnityEngine.Vector3 direction = default(UnityEngine.Vector3);
                    System.Single origin_x = default(System.Single);
                    System.Single origin_y = default(System.Single);
                    System.Single origin_z = default(System.Single);
                    System.Single direction_x = default(System.Single);
                    System.Single direction_y = default(System.Single);
                    System.Single direction_z = default(System.Single);
                    LuaHub.LuaHubC.capslua_getRay(l, index, out origin_x, out origin_y, out origin_z, out direction_x, out direction_y, out direction_z);
                    direction.z = direction_z;
                    direction.y = direction_y;
                    direction.x = direction_x;
                    origin.z = origin_z;
                    origin.y = origin_y;
                    origin.x = origin_x;
                    rv.direction = direction;
                    rv.origin = origin;
                }
                else
                #endif
                {
                    UnityEngine.Vector3 origin;
                    UnityEngine.Vector3 direction;
                    l.checkstack(2);
                    l.pushvalue(index);
                    l.PushString(LS_ORIGIN);
                    l.rawget(-2);
                    l.GetLua(-1, out origin);
                    l.pop(1);
                    l.PushString(LS_DIRECTION);
                    l.rawget(-2);
                    l.GetLua(-1, out direction);
                    l.pop(1);
                    l.pop(1);
                    rv.origin = origin;
                    rv.direction = direction;
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_Ray ___tp_UnityEngine_Ray = new TypeHubPrecompiled_UnityEngine_Ray();
        public static void PushLua(this IntPtr l, UnityEngine.Ray val)
        {
            ___tp_UnityEngine_Ray.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Ray val)
        {
            val = TypeHubPrecompiled_UnityEngine_Ray.GetLuaChecked(l, index);
        }
    }
}
#endif
