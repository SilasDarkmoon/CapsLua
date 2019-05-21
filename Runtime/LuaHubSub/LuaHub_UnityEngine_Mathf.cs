#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Mathf : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.Mathf>
        {
            public TypeHubPrecompiled_UnityEngine_Mathf()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_setTypeMathf(r);// TODO: fix this.
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
                _StaticFieldsIndex["Deg2Rad"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticFieldsIndex["Deg2Rad"]._Method, _Precompiled = ___sgf_Deg2Rad };
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
            private static readonly lua.CFunction ___sgf_Deg2Rad = new lua.CFunction(___sgm_Deg2Rad);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___sgm_Deg2Rad(IntPtr l)
            {
                try
                {
                    var rv = UnityEngine.Mathf.Deg2Rad;
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
            
            public override IntPtr PushLua(IntPtr l, object val)
            {
                PushLua(l, (UnityEngine.Mathf)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.Mathf)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.Mathf GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.Mathf);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.Mathf val)
            {
                return base.PushLua(l, (object)val); // TODO: fix this.
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_pushMathf(l, fields);// TODO: fix this.
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
            public override void SetData(IntPtr l, int index, UnityEngine.Mathf val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.Mathf GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.Mathf val)
            {
                LuaCommonMeta.LuaTransCommon.Instance.SetData(l, index, val); // TODO: fix this.
                return; // TODO: fix this.
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_setMathf(l, index, fields);// TODO: fix this.
                }
                else
                #endif
                {
                    // TODO: fix this.
                }
            }
            public static UnityEngine.Mathf GetLuaRaw(IntPtr l, int index)
            {
                // TODO: fix this.
                var rawobj = LuaCommonMeta.LuaTransCommon.Instance.GetLua(l, index);
                if (rawobj is UnityEngine.Mathf)
                return (UnityEngine.Mathf)rawobj;
                return default(UnityEngine.Mathf);
                // TODO: fix this.
                UnityEngine.Mathf rv = new UnityEngine.Mathf();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_getMathf(l, index, out fields);// TODO: fix this.
                }
                else
                #endif
                {
                    // TODO: fix this.
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_Mathf ___tp_UnityEngine_Mathf = new TypeHubPrecompiled_UnityEngine_Mathf();
        public static void PushLua(this IntPtr l, UnityEngine.Mathf val)
        {
            ___tp_UnityEngine_Mathf.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Mathf val)
        {
            val = TypeHubPrecompiled_UnityEngine_Mathf.GetLuaChecked(l, index);
        }
    }
}
#endif
