#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_EventSystems_RaycastResult : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.EventSystems.RaycastResult>
        {
            public TypeHubPrecompiled_UnityEngine_EventSystems_RaycastResult()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_setTypeRaycastResult(r);// TODO: fix this.
                }
                #endif
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
                _InstanceFieldsNewIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["gameObject"]._Method, _Precompiled = ___sf_gameObject };
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
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
            private static readonly lua.CFunction ___sf_gameObject = new lua.CFunction(___sm_gameObject);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_gameObject(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.RaycastResult tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.gameObject;
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
            private static int ___sm_gameObject(IntPtr l)
            {
                try
                {
                    UnityEngine.EventSystems.RaycastResult tar;
                    tar = GetLuaChecked(l, 1);
                    UnityEngine.GameObject val;
                    l.GetLua(2, out val);
                    tar.gameObject = val;
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
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.EventSystems.RaycastResult)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.EventSystems.RaycastResult)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.EventSystems.RaycastResult GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.EventSystems.RaycastResult);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.EventSystems.RaycastResult val)
            {
                return base.PushLua(l, (object)val); // TODO: fix this.
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_pushRaycastResult(l, fields);// TODO: fix this.
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
            public override void SetData(IntPtr l, int index, UnityEngine.EventSystems.RaycastResult val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.EventSystems.RaycastResult GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.EventSystems.RaycastResult val)
            {
                LuaCommonMeta.LuaTransCommon.Instance.SetData(l, index, val); // TODO: fix this.
                return; // TODO: fix this.
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_setRaycastResult(l, index, fields);// TODO: fix this.
                }
                else
                #endif
                {
                    // TODO: fix this.
                }
            }
            public static UnityEngine.EventSystems.RaycastResult GetLuaRaw(IntPtr l, int index)
            {
                // TODO: fix this.
                var rawobj = LuaCommonMeta.LuaTransCommon.Instance.GetLua(l, index);
                if (rawobj is UnityEngine.EventSystems.RaycastResult)
                return (UnityEngine.EventSystems.RaycastResult)rawobj;
                return default(UnityEngine.EventSystems.RaycastResult);
                // TODO: fix this.
                UnityEngine.EventSystems.RaycastResult rv = new UnityEngine.EventSystems.RaycastResult();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_getRaycastResult(l, index, out fields);// TODO: fix this.
                }
                else
                #endif
                {
                    // TODO: fix this.
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_EventSystems_RaycastResult ___tp_UnityEngine_EventSystems_RaycastResult = new TypeHubPrecompiled_UnityEngine_EventSystems_RaycastResult();
        public static void PushLua(this IntPtr l, UnityEngine.EventSystems.RaycastResult val)
        {
            ___tp_UnityEngine_EventSystems_RaycastResult.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.EventSystems.RaycastResult val)
        {
            val = TypeHubPrecompiled_UnityEngine_EventSystems_RaycastResult.GetLuaChecked(l, index);
        }
    }
}
#endif
