#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_RaycastHit : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.RaycastHit>
        {
            public TypeHubPrecompiled_UnityEngine_RaycastHit()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_setTypeRaycastHit(r);// TODO: fix this.
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
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.RaycastHit)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.RaycastHit)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.RaycastHit GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.RaycastHit);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.RaycastHit val)
            {
                return base.PushLua(l, (object)val); // TODO: fix this.
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_pushRaycastHit(l, fields);// TODO: fix this.
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
            public override void SetData(IntPtr l, int index, UnityEngine.RaycastHit val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.RaycastHit GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.RaycastHit val)
            {
                LuaCommonMeta.LuaTransCommon.Instance.SetData(l, index, val); // TODO: fix this.
                return; // TODO: fix this.
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_setRaycastHit(l, index, fields);// TODO: fix this.
                }
                else
                #endif
                {
                    // TODO: fix this.
                }
            }
            public static UnityEngine.RaycastHit GetLuaRaw(IntPtr l, int index)
            {
                // TODO: fix this.
                var rawobj = LuaCommonMeta.LuaTransCommon.Instance.GetLua(l, index);
                if (rawobj is UnityEngine.RaycastHit)
                return (UnityEngine.RaycastHit)rawobj;
                return default(UnityEngine.RaycastHit);
                // TODO: fix this.
                UnityEngine.RaycastHit rv = new UnityEngine.RaycastHit();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_getRaycastHit(l, index, out fields);// TODO: fix this.
                }
                else
                #endif
                {
                    // TODO: fix this.
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_RaycastHit ___tp_UnityEngine_RaycastHit = new TypeHubPrecompiled_UnityEngine_RaycastHit();
        public static void PushLua(this IntPtr l, UnityEngine.RaycastHit val)
        {
            ___tp_UnityEngine_RaycastHit.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.RaycastHit val)
        {
            val = TypeHubPrecompiled_UnityEngine_RaycastHit.GetLuaChecked(l, index);
        }
    }
}
#endif
