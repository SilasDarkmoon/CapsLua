#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_UI_Image : LuaHub.TypeHubPrecompiled_UnityEngine_UI_MaskableGraphic
        {
            public TypeHubPrecompiled_UnityEngine_UI_Image() : this(typeof(UnityEngine.UI.Image)) { }
            public TypeHubPrecompiled_UnityEngine_UI_Image(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["transform"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["transform"]._Method, _Precompiled = ___gf_transform };
                _InstanceFieldsIndex["enabled"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["enabled"]._Method, _Precompiled = ___gf_enabled };
                _InstanceFieldsNewIndex["enabled"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["enabled"]._Method, _Precompiled = ___sf_enabled };
                _InstanceFieldsIndex["overrideSprite"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["overrideSprite"]._Method, _Precompiled = ___gf_overrideSprite };
                _InstanceFieldsNewIndex["overrideSprite"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["overrideSprite"]._Method, _Precompiled = ___sf_overrideSprite };
                _InstanceFieldsIndex["color"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["color"]._Method, _Precompiled = ___gf_color };
                _InstanceFieldsNewIndex["color"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["color"]._Method, _Precompiled = ___sf_color };
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
                _InstanceFieldsIndex["sprite"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sprite"]._Method, _Precompiled = ___gf_sprite };
                _InstanceFieldsNewIndex["sprite"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sprite"]._Method, _Precompiled = ___sf_sprite };
                _InstanceFieldsIndex["fillAmount"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["fillAmount"]._Method, _Precompiled = ___gf_fillAmount };
                _InstanceFieldsNewIndex["fillAmount"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["fillAmount"]._Method, _Precompiled = ___sf_fillAmount };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
                _InstanceMethods_DirectFromBase.Add("SetNativeSize");
                _InstanceMethods_DirectFromBase.Add("SetAllDirty");
                _InstanceMethods_DirectFromBase.Add("GetComponent");
                _InstanceMethods_DirectFromBase.Add("GetComponentInChildren");
                _InstanceMethods_DirectFromBase.Add("GetComponentsInChildren");
                _InstanceMethods_DirectFromBase.Add("GetComponentInParent");
                _InstanceMethods_DirectFromBase.Add("GetComponentsInParent");
                _InstanceMethods_DirectFromBase.Add("GetComponents");
                _InstanceMethods_DirectFromBase.Add("CompareTag");
                _InstanceMethods_DirectFromBase.Add("SendMessageUpwards");
                _InstanceMethods_DirectFromBase.Add("SendMessage");
                _InstanceMethods_DirectFromBase.Add("BroadcastMessage");
                _InstanceMethods_DirectFromBase.Add("GetInstanceID");
                #endif
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
            private static readonly lua.CFunction ___gf_transform = new lua.CFunction(___gm_transform);
            private static readonly lua.CFunction ___gf_enabled = new lua.CFunction(___gm_enabled);
            private static readonly lua.CFunction ___sf_enabled = new lua.CFunction(___sm_enabled);
            private static readonly lua.CFunction ___gf_overrideSprite = new lua.CFunction(___gm_overrideSprite);
            private static readonly lua.CFunction ___sf_overrideSprite = new lua.CFunction(___sm_overrideSprite);
            private static readonly lua.CFunction ___gf_color = new lua.CFunction(___gm_color);
            private static readonly lua.CFunction ___sf_color = new lua.CFunction(___sm_color);
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
            private static readonly lua.CFunction ___gf_sprite = new lua.CFunction(___gm_sprite);
            private static readonly lua.CFunction ___sf_sprite = new lua.CFunction(___sm_sprite);
            private static readonly lua.CFunction ___gf_fillAmount = new lua.CFunction(___gm_fillAmount);
            private static readonly lua.CFunction ___sf_fillAmount = new lua.CFunction(___sm_fillAmount);
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
            private static int ___gm_transform(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    var rv = tar.transform;
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
            private static int ___gm_enabled(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    var rv = tar.enabled;
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
            private static int ___sm_enabled(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.enabled = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_overrideSprite(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    var rv = tar.overrideSprite;
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
            private static int ___sm_overrideSprite(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Sprite val;
                    l.GetLua(2, out val);
                    tar.overrideSprite = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_color(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    var rv = tar.color;
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
            private static int ___sm_color(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Color val;
                    l.GetLua(2, out val);
                    tar.color = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_gameObject(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
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
            private static int ___gm_sprite(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sprite;
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
            private static int ___sm_sprite(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Sprite val;
                    l.GetLua(2, out val);
                    tar.sprite = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_fillAmount(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    var rv = tar.fillAmount;
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
            private static int ___sm_fillAmount(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Image tar;
                    l.GetLua(1, out tar);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.fillAmount = val;
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
        }
        private static TypeHubPrecompiled_UnityEngine_UI_Image ___tp_UnityEngine_UI_Image = new TypeHubPrecompiled_UnityEngine_UI_Image();
        public static void PushLua(this IntPtr l, UnityEngine.UI.Image val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.UI.Image val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.UI.Image;
        }
    }
}
#endif
