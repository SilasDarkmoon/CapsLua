#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_UI_SpriteState : Capstones.LuaLib.LuaTypeHub.TypeHubValueTypePrecompiled<UnityEngine.UI.SpriteState>
        {
            public TypeHubPrecompiled_UnityEngine_UI_SpriteState()
            {
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_setTypeSpriteState(r);// TODO: fix this.
                }
                #endif
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["pressedSprite"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["pressedSprite"]._Method, _Precompiled = ___gf_pressedSprite };
                _InstanceFieldsNewIndex["pressedSprite"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["pressedSprite"]._Method, _Precompiled = ___sf_pressedSprite };
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
            private static readonly lua.CFunction ___gf_pressedSprite = new lua.CFunction(___gm_pressedSprite);
            private static readonly lua.CFunction ___sf_pressedSprite = new lua.CFunction(___sm_pressedSprite);
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
                    var rv = default(UnityEngine.UI.SpriteState);
                    l.PushLua(rv);
                    return 1;
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
            private static int ___gm_pressedSprite(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.SpriteState tar;
                    tar = GetLuaChecked(l, 1);
                    var rv = tar.pressedSprite;
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
            private static int ___sm_pressedSprite(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.SpriteState tar;
                    tar = GetLuaChecked(l, 1);
                    UnityEngine.Sprite val;
                    l.GetLua(2, out val);
                    tar.pressedSprite = val;
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
                PushLua(l, (UnityEngine.UI.SpriteState)val);
                return IntPtr.Zero;
            }
            public override void SetData(IntPtr l, int index, object val)
            {
                SetDataRaw(l, index, (UnityEngine.UI.SpriteState)val);
            }
            public override object GetLuaObject(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            public static UnityEngine.UI.SpriteState GetLuaChecked(IntPtr l, int index)
            {
                if (l.istable(index))
                {
                    return GetLuaRaw(l, index);
                }
                return default(UnityEngine.UI.SpriteState);
            }
            
            public override IntPtr PushLua(IntPtr l, UnityEngine.UI.SpriteState val)
            {
                return base.PushLua(l, (object)val); // TODO: fix this.
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_pushSpriteState(l, fields);// TODO: fix this.
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
            public override void SetData(IntPtr l, int index, UnityEngine.UI.SpriteState val)
            {
                SetDataRaw(l, index, val);
            }
            public override UnityEngine.UI.SpriteState GetLua(IntPtr l, int index)
            {
                return GetLuaRaw(l, index);
            }
            
            public static void SetDataRaw(IntPtr l, int index, UnityEngine.UI.SpriteState val)
            {
                LuaCommonMeta.LuaTransCommon.Instance.SetData(l, index, val); // TODO: fix this.
                return; // TODO: fix this.
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_setSpriteState(l, index, fields);// TODO: fix this.
                }
                else
                #endif
                {
                    // TODO: fix this.
                }
            }
            public static UnityEngine.UI.SpriteState GetLuaRaw(IntPtr l, int index)
            {
                // TODO: fix this.
                var rawobj = LuaCommonMeta.LuaTransCommon.Instance.GetLua(l, index);
                if (rawobj is UnityEngine.UI.SpriteState)
                return (UnityEngine.UI.SpriteState)rawobj;
                return default(UnityEngine.UI.SpriteState);
                // TODO: fix this.
                UnityEngine.UI.SpriteState rv = new UnityEngine.UI.SpriteState();
                #if !DISABLE_LUA_HUB_C
                if (LuaHub.LuaHubC.Ready)
                {
                    //LuaHub.LuaHubC.capslua_getSpriteState(l, index, out fields);// TODO: fix this.
                }
                else
                #endif
                {
                    // TODO: fix this.
                }
                return rv;
            }
        }
        private static TypeHubPrecompiled_UnityEngine_UI_SpriteState ___tp_UnityEngine_UI_SpriteState = new TypeHubPrecompiled_UnityEngine_UI_SpriteState();
        public static void PushLua(this IntPtr l, UnityEngine.UI.SpriteState val)
        {
            ___tp_UnityEngine_UI_SpriteState.PushLua(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.UI.SpriteState val)
        {
            val = TypeHubPrecompiled_UnityEngine_UI_SpriteState.GetLuaChecked(l, index);
        }
    }
}
#endif
