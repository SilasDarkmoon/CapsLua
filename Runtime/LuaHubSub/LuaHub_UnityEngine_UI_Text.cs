#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_UI_Text : LuaHub.TypeHubPrecompiled_UnityEngine_UI_MaskableGraphic
        {
            public TypeHubPrecompiled_UnityEngine_UI_Text() : this(typeof(UnityEngine.UI.Text)) { }
            public TypeHubPrecompiled_UnityEngine_UI_Text(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["text"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["text"]._Method, _Precompiled = ___gf_text };
                _InstanceFieldsNewIndex["text"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["text"]._Method, _Precompiled = ___sf_text };
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
                _InstanceFieldsIndex["fontSize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["fontSize"]._Method, _Precompiled = ___gf_fontSize };
                _InstanceFieldsNewIndex["fontSize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["fontSize"]._Method, _Precompiled = ___sf_fontSize };
                _InstanceFieldsIndex["color"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["color"]._Method, _Precompiled = ___gf_color };
                _InstanceFieldsNewIndex["color"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["color"]._Method, _Precompiled = ___sf_color };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
                _InstanceMethods_DirectFromBase.Add("SetAllDirty");
                _InstanceMethods_DirectFromBase.Add("SetNativeSize");
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
            private static readonly lua.CFunction ___gf_text = new lua.CFunction(___gm_text);
            private static readonly lua.CFunction ___sf_text = new lua.CFunction(___sm_text);
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
            private static readonly lua.CFunction ___gf_fontSize = new lua.CFunction(___gm_fontSize);
            private static readonly lua.CFunction ___sf_fontSize = new lua.CFunction(___sm_fontSize);
            private static readonly lua.CFunction ___gf_color = new lua.CFunction(___gm_color);
            private static readonly lua.CFunction ___sf_color = new lua.CFunction(___sm_color);
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
            private static int ___gm_text(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Text tar;
                    l.GetLua(1, out tar);
                    var rv = tar.text;
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
            private static int ___sm_text(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Text tar;
                    l.GetLua(1, out tar);
                    System.String val;
                    l.GetLua(2, out val);
                    tar.text = val;
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
                    UnityEngine.UI.Text tar;
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
            private static int ___gm_fontSize(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Text tar;
                    l.GetLua(1, out tar);
                    var rv = tar.fontSize;
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
            private static int ___sm_fontSize(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.Text tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.fontSize = val;
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
                    UnityEngine.UI.Text tar;
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
                    UnityEngine.UI.Text tar;
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
        private static TypeHubPrecompiled_UnityEngine_UI_Text ___tp_UnityEngine_UI_Text = new TypeHubPrecompiled_UnityEngine_UI_Text();
        public static void PushLua(this IntPtr l, UnityEngine.UI.Text val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.UI.Text val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.UI.Text;
        }
    }
}
#endif
