#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_RectTransform : TypeHubPrecompiled_UnityEngine_Transform
        {
            public TypeHubPrecompiled_UnityEngine_RectTransform() : this(typeof(UnityEngine.RectTransform)) { }
            public TypeHubPrecompiled_UnityEngine_RectTransform(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["GetLocalCorners"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetLocalCorners"]._Method, _Precompiled = ___fm_GetLocalCorners };
                _InstanceMethods["GetWorldCorners"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetWorldCorners"]._Method, _Precompiled = ___fm_GetWorldCorners };
                _InstanceMethods["SetInsetAndSizeFromParentEdge"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetInsetAndSizeFromParentEdge"]._Method, _Precompiled = ___fm_SetInsetAndSizeFromParentEdge };
                _InstanceMethods["SetSizeWithCurrentAnchors"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetSizeWithCurrentAnchors"]._Method, _Precompiled = ___fm_SetSizeWithCurrentAnchors };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["rect"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["rect"]._Method, _Precompiled = ___gf_rect };
                _InstanceFieldsIndex["anchorMin"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["anchorMin"]._Method, _Precompiled = ___gf_anchorMin };
                _InstanceFieldsNewIndex["anchorMin"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["anchorMin"]._Method, _Precompiled = ___sf_anchorMin };
                _InstanceFieldsIndex["anchorMax"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["anchorMax"]._Method, _Precompiled = ___gf_anchorMax };
                _InstanceFieldsNewIndex["anchorMax"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["anchorMax"]._Method, _Precompiled = ___sf_anchorMax };
                _InstanceFieldsIndex["anchoredPosition3D"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["anchoredPosition3D"]._Method, _Precompiled = ___gf_anchoredPosition3D };
                _InstanceFieldsNewIndex["anchoredPosition3D"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["anchoredPosition3D"]._Method, _Precompiled = ___sf_anchoredPosition3D };
                _InstanceFieldsIndex["anchoredPosition"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["anchoredPosition"]._Method, _Precompiled = ___gf_anchoredPosition };
                _InstanceFieldsNewIndex["anchoredPosition"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["anchoredPosition"]._Method, _Precompiled = ___sf_anchoredPosition };
                _InstanceFieldsIndex["sizeDelta"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sizeDelta"]._Method, _Precompiled = ___gf_sizeDelta };
                _InstanceFieldsNewIndex["sizeDelta"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sizeDelta"]._Method, _Precompiled = ___sf_sizeDelta };
                _InstanceFieldsIndex["pivot"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["pivot"]._Method, _Precompiled = ___gf_pivot };
                _InstanceFieldsNewIndex["pivot"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["pivot"]._Method, _Precompiled = ___sf_pivot };
                _InstanceFieldsIndex["offsetMin"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["offsetMin"]._Method, _Precompiled = ___gf_offsetMin };
                _InstanceFieldsNewIndex["offsetMin"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["offsetMin"]._Method, _Precompiled = ___sf_offsetMin };
                _InstanceFieldsIndex["offsetMax"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["offsetMax"]._Method, _Precompiled = ___gf_offsetMax };
                _InstanceFieldsNewIndex["offsetMax"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["offsetMax"]._Method, _Precompiled = ___sf_offsetMax };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
                _InstanceMethods_DirectFromBase.Add("SetParent");
                _InstanceMethods_DirectFromBase.Add("SetPositionAndRotation");
                _InstanceMethods_DirectFromBase.Add("Translate");
                _InstanceMethods_DirectFromBase.Add("Rotate");
                _InstanceMethods_DirectFromBase.Add("RotateAround");
                _InstanceMethods_DirectFromBase.Add("LookAt");
                _InstanceMethods_DirectFromBase.Add("TransformDirection");
                _InstanceMethods_DirectFromBase.Add("InverseTransformDirection");
                _InstanceMethods_DirectFromBase.Add("TransformVector");
                _InstanceMethods_DirectFromBase.Add("InverseTransformVector");
                _InstanceMethods_DirectFromBase.Add("TransformPoint");
                _InstanceMethods_DirectFromBase.Add("InverseTransformPoint");
                _InstanceMethods_DirectFromBase.Add("DetachChildren");
                _InstanceMethods_DirectFromBase.Add("SetAsFirstSibling");
                _InstanceMethods_DirectFromBase.Add("SetAsLastSibling");
                _InstanceMethods_DirectFromBase.Add("SetSiblingIndex");
                _InstanceMethods_DirectFromBase.Add("GetSiblingIndex");
                _InstanceMethods_DirectFromBase.Add("Find");
                _InstanceMethods_DirectFromBase.Add("IsChildOf");
                _InstanceMethods_DirectFromBase.Add("FindChild");
                _InstanceMethods_DirectFromBase.Add("GetEnumerator");
                _InstanceMethods_DirectFromBase.Add("RotateAroundLocal");
                _InstanceMethods_DirectFromBase.Add("GetChild");
                _InstanceMethods_DirectFromBase.Add("GetChildCount");
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
            private static readonly lua.CFunction ___fm_GetLocalCorners = new lua.CFunction(___mm_GetLocalCorners);
            private static readonly lua.CFunction ___fm_GetWorldCorners = new lua.CFunction(___mm_GetWorldCorners);
            private static readonly lua.CFunction ___fm_SetInsetAndSizeFromParentEdge = new lua.CFunction(___mm_SetInsetAndSizeFromParentEdge);
            private static readonly lua.CFunction ___fm_SetSizeWithCurrentAnchors = new lua.CFunction(___mm_SetSizeWithCurrentAnchors);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_rect = new lua.CFunction(___gm_rect);
            private static readonly lua.CFunction ___gf_anchorMin = new lua.CFunction(___gm_anchorMin);
            private static readonly lua.CFunction ___sf_anchorMin = new lua.CFunction(___sm_anchorMin);
            private static readonly lua.CFunction ___gf_anchorMax = new lua.CFunction(___gm_anchorMax);
            private static readonly lua.CFunction ___sf_anchorMax = new lua.CFunction(___sm_anchorMax);
            private static readonly lua.CFunction ___gf_anchoredPosition3D = new lua.CFunction(___gm_anchoredPosition3D);
            private static readonly lua.CFunction ___sf_anchoredPosition3D = new lua.CFunction(___sm_anchoredPosition3D);
            private static readonly lua.CFunction ___gf_anchoredPosition = new lua.CFunction(___gm_anchoredPosition);
            private static readonly lua.CFunction ___sf_anchoredPosition = new lua.CFunction(___sm_anchoredPosition);
            private static readonly lua.CFunction ___gf_sizeDelta = new lua.CFunction(___gm_sizeDelta);
            private static readonly lua.CFunction ___sf_sizeDelta = new lua.CFunction(___sm_sizeDelta);
            private static readonly lua.CFunction ___gf_pivot = new lua.CFunction(___gm_pivot);
            private static readonly lua.CFunction ___sf_pivot = new lua.CFunction(___sm_pivot);
            private static readonly lua.CFunction ___gf_offsetMin = new lua.CFunction(___gm_offsetMin);
            private static readonly lua.CFunction ___sf_offsetMin = new lua.CFunction(___sm_offsetMin);
            private static readonly lua.CFunction ___gf_offsetMax = new lua.CFunction(___gm_offsetMax);
            private static readonly lua.CFunction ___sf_offsetMax = new lua.CFunction(___sm_offsetMax);
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
                    var rv = new UnityEngine.RectTransform();
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetLocalCorners(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector3[] p1;
                    l.GetLua(2, out p1);
                    p0.GetLocalCorners(p1);
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetWorldCorners(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector3[] p1;
                    l.GetLua(2, out p1);
                    p0.GetWorldCorners(p1);
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_SetInsetAndSizeFromParentEdge(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform p0;
                    l.GetLua(1, out p0);
                    UnityEngine.RectTransform.Edge p1;
                    l.GetLua(2, out p1);
                    System.Single p2;
                    l.GetLua(3, out p2);
                    System.Single p3;
                    l.GetLua(4, out p3);
                    p0.SetInsetAndSizeFromParentEdge(p1, p2, p3);
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_SetSizeWithCurrentAnchors(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform p0;
                    l.GetLua(1, out p0);
                    UnityEngine.RectTransform.Axis p1;
                    l.GetLua(2, out p1);
                    System.Single p2;
                    l.GetLua(3, out p2);
                    p0.SetSizeWithCurrentAnchors(p1, p2);
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            #endregion // FUNC_I_FUNC
            #region FUNC_I_PROP
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_rect(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.rect;
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
            private static int ___gm_anchorMin(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.anchorMin;
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
            private static int ___sm_anchorMin(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.anchorMin = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_anchorMax(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.anchorMax;
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
            private static int ___sm_anchorMax(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.anchorMax = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_anchoredPosition3D(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.anchoredPosition3D;
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
            private static int ___sm_anchoredPosition3D(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.anchoredPosition3D = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_anchoredPosition(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.anchoredPosition;
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
            private static int ___sm_anchoredPosition(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.anchoredPosition = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sizeDelta(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sizeDelta;
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
            private static int ___sm_sizeDelta(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.sizeDelta = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_pivot(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.pivot;
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
            private static int ___sm_pivot(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.pivot = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_offsetMin(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.offsetMin;
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
            private static int ___sm_offsetMin(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.offsetMin = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_offsetMax(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.offsetMax;
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
            private static int ___sm_offsetMax(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.offsetMax = val;
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
        private static TypeHubPrecompiled_UnityEngine_RectTransform ___tp_UnityEngine_RectTransform = new TypeHubPrecompiled_UnityEngine_RectTransform();
        public static void PushLua(this IntPtr l, UnityEngine.RectTransform val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_RectTransform.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.RectTransform val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.RectTransform;
        }
    }
}
#endif
