#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_Transform : TypeHubPrecompiled_UnityEngine_Component
        {
            public TypeHubPrecompiled_UnityEngine_Transform() : this(typeof(UnityEngine.Transform)) { }
            public TypeHubPrecompiled_UnityEngine_Transform(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["SetParent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetParent"]._Method, _Precompiled = ___fm_SetParent };
                _InstanceMethods["SetPositionAndRotation"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetPositionAndRotation"]._Method, _Precompiled = ___fm_SetPositionAndRotation };
                _InstanceMethods["Translate"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Translate"]._Method, _Precompiled = ___fm_Translate };
                _InstanceMethods["Rotate"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Rotate"]._Method, _Precompiled = ___fm_Rotate };
                _InstanceMethods["RotateAround"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["RotateAround"]._Method, _Precompiled = ___fm_RotateAround };
                _InstanceMethods["TransformDirection"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["TransformDirection"]._Method, _Precompiled = ___fm_TransformDirection };
                _InstanceMethods["InverseTransformDirection"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["InverseTransformDirection"]._Method, _Precompiled = ___fm_InverseTransformDirection };
                _InstanceMethods["TransformVector"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["TransformVector"]._Method, _Precompiled = ___fm_TransformVector };
                _InstanceMethods["InverseTransformVector"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["InverseTransformVector"]._Method, _Precompiled = ___fm_InverseTransformVector };
                _InstanceMethods["TransformPoint"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["TransformPoint"]._Method, _Precompiled = ___fm_TransformPoint };
                _InstanceMethods["InverseTransformPoint"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["InverseTransformPoint"]._Method, _Precompiled = ___fm_InverseTransformPoint };
                _InstanceMethods["DetachChildren"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["DetachChildren"]._Method, _Precompiled = ___fm_DetachChildren };
                _InstanceMethods["SetAsFirstSibling"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetAsFirstSibling"]._Method, _Precompiled = ___fm_SetAsFirstSibling };
                _InstanceMethods["SetAsLastSibling"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetAsLastSibling"]._Method, _Precompiled = ___fm_SetAsLastSibling };
                _InstanceMethods["SetSiblingIndex"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetSiblingIndex"]._Method, _Precompiled = ___fm_SetSiblingIndex };
                _InstanceMethods["GetSiblingIndex"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetSiblingIndex"]._Method, _Precompiled = ___fm_GetSiblingIndex };
                _InstanceMethods["Find"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Find"]._Method, _Precompiled = ___fm_Find };
                _InstanceMethods["IsChildOf"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["IsChildOf"]._Method, _Precompiled = ___fm_IsChildOf };
                _InstanceMethods["FindChild"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["FindChild"]._Method, _Precompiled = ___fm_FindChild };
                _InstanceMethods["GetEnumerator"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetEnumerator"]._Method, _Precompiled = ___fm_GetEnumerator };
                _InstanceMethods["RotateAroundLocal"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["RotateAroundLocal"]._Method, _Precompiled = ___fm_RotateAroundLocal };
                _InstanceMethods["GetChild"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetChild"]._Method, _Precompiled = ___fm_GetChild };
                _InstanceMethods["GetChildCount"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetChildCount"]._Method, _Precompiled = ___fm_GetChildCount };
                _InstanceMethods["LookAt"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["LookAt"]._Method, _Precompiled = ___fm_LookAt };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["position"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["position"]._Method, _Precompiled = ___gf_position };
                _InstanceFieldsNewIndex["position"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["position"]._Method, _Precompiled = ___sf_position };
                _InstanceFieldsIndex["localPosition"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["localPosition"]._Method, _Precompiled = ___gf_localPosition };
                _InstanceFieldsNewIndex["localPosition"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["localPosition"]._Method, _Precompiled = ___sf_localPosition };
                _InstanceFieldsIndex["eulerAngles"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["eulerAngles"]._Method, _Precompiled = ___gf_eulerAngles };
                _InstanceFieldsNewIndex["eulerAngles"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["eulerAngles"]._Method, _Precompiled = ___sf_eulerAngles };
                _InstanceFieldsIndex["localEulerAngles"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["localEulerAngles"]._Method, _Precompiled = ___gf_localEulerAngles };
                _InstanceFieldsNewIndex["localEulerAngles"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["localEulerAngles"]._Method, _Precompiled = ___sf_localEulerAngles };
                _InstanceFieldsIndex["right"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["right"]._Method, _Precompiled = ___gf_right };
                _InstanceFieldsNewIndex["right"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["right"]._Method, _Precompiled = ___sf_right };
                _InstanceFieldsIndex["up"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["up"]._Method, _Precompiled = ___gf_up };
                _InstanceFieldsNewIndex["up"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["up"]._Method, _Precompiled = ___sf_up };
                _InstanceFieldsIndex["forward"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["forward"]._Method, _Precompiled = ___gf_forward };
                _InstanceFieldsNewIndex["forward"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["forward"]._Method, _Precompiled = ___sf_forward };
                _InstanceFieldsIndex["rotation"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["rotation"]._Method, _Precompiled = ___gf_rotation };
                _InstanceFieldsNewIndex["rotation"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["rotation"]._Method, _Precompiled = ___sf_rotation };
                _InstanceFieldsIndex["localRotation"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["localRotation"]._Method, _Precompiled = ___gf_localRotation };
                _InstanceFieldsNewIndex["localRotation"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["localRotation"]._Method, _Precompiled = ___sf_localRotation };
                _InstanceFieldsIndex["localScale"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["localScale"]._Method, _Precompiled = ___gf_localScale };
                _InstanceFieldsNewIndex["localScale"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["localScale"]._Method, _Precompiled = ___sf_localScale };
                _InstanceFieldsIndex["parent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["parent"]._Method, _Precompiled = ___gf_parent };
                _InstanceFieldsNewIndex["parent"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["parent"]._Method, _Precompiled = ___sf_parent };
                _InstanceFieldsIndex["worldToLocalMatrix"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["worldToLocalMatrix"]._Method, _Precompiled = ___gf_worldToLocalMatrix };
                _InstanceFieldsIndex["localToWorldMatrix"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["localToWorldMatrix"]._Method, _Precompiled = ___gf_localToWorldMatrix };
                _InstanceFieldsIndex["root"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["root"]._Method, _Precompiled = ___gf_root };
                _InstanceFieldsIndex["childCount"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["childCount"]._Method, _Precompiled = ___gf_childCount };
                _InstanceFieldsIndex["lossyScale"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["lossyScale"]._Method, _Precompiled = ___gf_lossyScale };
                _InstanceFieldsIndex["hasChanged"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["hasChanged"]._Method, _Precompiled = ___gf_hasChanged };
                _InstanceFieldsNewIndex["hasChanged"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["hasChanged"]._Method, _Precompiled = ___sf_hasChanged };
                _InstanceFieldsIndex["hierarchyCapacity"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["hierarchyCapacity"]._Method, _Precompiled = ___gf_hierarchyCapacity };
                _InstanceFieldsNewIndex["hierarchyCapacity"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["hierarchyCapacity"]._Method, _Precompiled = ___sf_hierarchyCapacity };
                _InstanceFieldsIndex["hierarchyCount"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["hierarchyCount"]._Method, _Precompiled = ___gf_hierarchyCount };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
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
            private static readonly lua.CFunction ___fm_SetParent = new lua.CFunction(___mm_SetParent);
            private static readonly lua.CFunction ___fm_SetPositionAndRotation = new lua.CFunction(___mm_SetPositionAndRotation);
            private static readonly lua.CFunction ___fm_Translate = new lua.CFunction(___mm_Translate);
            private static readonly lua.CFunction ___fm_Rotate = new lua.CFunction(___mm_Rotate);
            private static readonly lua.CFunction ___fm_RotateAround = new lua.CFunction(___mm_RotateAround);
            private static readonly lua.CFunction ___fm_TransformDirection = new lua.CFunction(___mm_TransformDirection);
            private static readonly lua.CFunction ___fm_InverseTransformDirection = new lua.CFunction(___mm_InverseTransformDirection);
            private static readonly lua.CFunction ___fm_TransformVector = new lua.CFunction(___mm_TransformVector);
            private static readonly lua.CFunction ___fm_InverseTransformVector = new lua.CFunction(___mm_InverseTransformVector);
            private static readonly lua.CFunction ___fm_TransformPoint = new lua.CFunction(___mm_TransformPoint);
            private static readonly lua.CFunction ___fm_InverseTransformPoint = new lua.CFunction(___mm_InverseTransformPoint);
            private static readonly lua.CFunction ___fm_DetachChildren = new lua.CFunction(___mm_DetachChildren);
            private static readonly lua.CFunction ___fm_SetAsFirstSibling = new lua.CFunction(___mm_SetAsFirstSibling);
            private static readonly lua.CFunction ___fm_SetAsLastSibling = new lua.CFunction(___mm_SetAsLastSibling);
            private static readonly lua.CFunction ___fm_SetSiblingIndex = new lua.CFunction(___mm_SetSiblingIndex);
            private static readonly lua.CFunction ___fm_GetSiblingIndex = new lua.CFunction(___mm_GetSiblingIndex);
            private static readonly lua.CFunction ___fm_Find = new lua.CFunction(___mm_Find);
            private static readonly lua.CFunction ___fm_IsChildOf = new lua.CFunction(___mm_IsChildOf);
            private static readonly lua.CFunction ___fm_FindChild = new lua.CFunction(___mm_FindChild);
            private static readonly lua.CFunction ___fm_GetEnumerator = new lua.CFunction(___mm_GetEnumerator);
            private static readonly lua.CFunction ___fm_RotateAroundLocal = new lua.CFunction(___mm_RotateAroundLocal);
            private static readonly lua.CFunction ___fm_GetChild = new lua.CFunction(___mm_GetChild);
            private static readonly lua.CFunction ___fm_GetChildCount = new lua.CFunction(___mm_GetChildCount);
            private static readonly lua.CFunction ___fm_LookAt = new lua.CFunction(___mm_LookAt);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_position = new lua.CFunction(___gm_position);
            private static readonly lua.CFunction ___sf_position = new lua.CFunction(___sm_position);
            private static readonly lua.CFunction ___gf_localPosition = new lua.CFunction(___gm_localPosition);
            private static readonly lua.CFunction ___sf_localPosition = new lua.CFunction(___sm_localPosition);
            private static readonly lua.CFunction ___gf_eulerAngles = new lua.CFunction(___gm_eulerAngles);
            private static readonly lua.CFunction ___sf_eulerAngles = new lua.CFunction(___sm_eulerAngles);
            private static readonly lua.CFunction ___gf_localEulerAngles = new lua.CFunction(___gm_localEulerAngles);
            private static readonly lua.CFunction ___sf_localEulerAngles = new lua.CFunction(___sm_localEulerAngles);
            private static readonly lua.CFunction ___gf_right = new lua.CFunction(___gm_right);
            private static readonly lua.CFunction ___sf_right = new lua.CFunction(___sm_right);
            private static readonly lua.CFunction ___gf_up = new lua.CFunction(___gm_up);
            private static readonly lua.CFunction ___sf_up = new lua.CFunction(___sm_up);
            private static readonly lua.CFunction ___gf_forward = new lua.CFunction(___gm_forward);
            private static readonly lua.CFunction ___sf_forward = new lua.CFunction(___sm_forward);
            private static readonly lua.CFunction ___gf_rotation = new lua.CFunction(___gm_rotation);
            private static readonly lua.CFunction ___sf_rotation = new lua.CFunction(___sm_rotation);
            private static readonly lua.CFunction ___gf_localRotation = new lua.CFunction(___gm_localRotation);
            private static readonly lua.CFunction ___sf_localRotation = new lua.CFunction(___sm_localRotation);
            private static readonly lua.CFunction ___gf_localScale = new lua.CFunction(___gm_localScale);
            private static readonly lua.CFunction ___sf_localScale = new lua.CFunction(___sm_localScale);
            private static readonly lua.CFunction ___gf_parent = new lua.CFunction(___gm_parent);
            private static readonly lua.CFunction ___sf_parent = new lua.CFunction(___sm_parent);
            private static readonly lua.CFunction ___gf_worldToLocalMatrix = new lua.CFunction(___gm_worldToLocalMatrix);
            private static readonly lua.CFunction ___gf_localToWorldMatrix = new lua.CFunction(___gm_localToWorldMatrix);
            private static readonly lua.CFunction ___gf_root = new lua.CFunction(___gm_root);
            private static readonly lua.CFunction ___gf_childCount = new lua.CFunction(___gm_childCount);
            private static readonly lua.CFunction ___gf_lossyScale = new lua.CFunction(___gm_lossyScale);
            private static readonly lua.CFunction ___gf_hasChanged = new lua.CFunction(___gm_hasChanged);
            private static readonly lua.CFunction ___sf_hasChanged = new lua.CFunction(___sm_hasChanged);
            private static readonly lua.CFunction ___gf_hierarchyCapacity = new lua.CFunction(___gm_hierarchyCapacity);
            private static readonly lua.CFunction ___sf_hierarchyCapacity = new lua.CFunction(___sm_hierarchyCapacity);
            private static readonly lua.CFunction ___gf_hierarchyCount = new lua.CFunction(___gm_hierarchyCount);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_SetParent(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 3)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Transform p1;
                            l.GetLua(2, out p1);
                            p0.SetParent(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Transform p1;
                            l.GetLua(2, out p1);
                            System.Boolean p2;
                            l.GetLua(3, out p2);
                            p0.SetParent(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_SetPositionAndRotation(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector3 p1;
                    l.GetLua(2, out p1);
                    UnityEngine.Quaternion p2;
                    l.GetLua(3, out p2);
                    p0.SetPositionAndRotation(p1, p2);
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
            private static int ___mm_Translate(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop == 4)
                            {
                                goto Label_30;
                            }
                            else
                            {
                                {
                                    {
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(UnityEngine.Transform) || typeof(UnityEngine.Transform).IsAssignableFrom(___ot2))
                                        {
                                            goto Label_50;
                                        }
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(UnityEngine.Vector3))
                                        {
                                            goto Label_20;
                                        }
                                        var ___ot4 = l.GetType(5);
                                        if (___ot4 == typeof(UnityEngine.Transform) || typeof(UnityEngine.Transform).IsAssignableFrom(___ot4))
                                        {
                                            goto Label_60;
                                        }
                                        goto Label_40;
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            p0.Translate(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Space p2;
                            l.GetLua(3, out p2);
                            p0.Translate(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            p0.Translate(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            UnityEngine.Space p4;
                            l.GetLua(5, out p4);
                            p0.Translate(p1, p2, p3, p4);
                            return 0;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Transform p2;
                            l.GetLua(3, out p2);
                            p0.Translate(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            UnityEngine.Transform p4;
                            l.GetLua(5, out p4);
                            p0.Translate(p1, p2, p3, p4);
                            return 0;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_Rotate(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 5)
                            {
                                goto Label_40;
                            }
                            else
                            {
                                {
                                    var ___lt1 = l.type(2);
                                    if (___lt1 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_30;
                                    }
                                    var ___lt3 = l.type(4);
                                    if (___lt3 == LuaCoreLib.LUA_TNUMBER)
                                    {
                                        goto Label_30;
                                    }
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(System.Single))
                                        {
                                            goto Label_30;
                                        }
                                        var ___ot2 = l.GetType(3);
                                        if (___ot2 == typeof(UnityEngine.Space))
                                        {
                                            goto Label_20;
                                        }
                                        var ___ot3 = l.GetType(4);
                                        if (___ot3 == typeof(UnityEngine.Space))
                                        {
                                            goto Label_60;
                                        }
                                        goto Label_50;
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            p0.Rotate(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Space p2;
                            l.GetLua(3, out p2);
                            p0.Rotate(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            p0.Rotate(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            UnityEngine.Space p4;
                            l.GetLua(5, out p4);
                            p0.Rotate(p1, p2, p3, p4);
                            return 0;
                        }
                        goto Label_default;
                        Label_50:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            p0.Rotate(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_60:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            UnityEngine.Space p3;
                            l.GetLua(4, out p3);
                            p0.Rotate(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_RotateAround(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 3)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Vector3 p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            p0.RotateAround(p1, p2, p3);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            p0.RotateAround(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_TransformDirection(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            var rv = p0.TransformDirection(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            var rv = p0.TransformDirection(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_InverseTransformDirection(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            var rv = p0.InverseTransformDirection(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            var rv = p0.InverseTransformDirection(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_TransformVector(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            var rv = p0.TransformVector(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            var rv = p0.TransformVector(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_InverseTransformVector(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            var rv = p0.InverseTransformVector(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            var rv = p0.InverseTransformVector(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_TransformPoint(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            var rv = p0.TransformPoint(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            var rv = p0.TransformPoint(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_InverseTransformPoint(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 2)
                            {
                                goto Label_10;
                            }
                            else if (oldtop >= 4)
                            {
                                goto Label_20;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            var rv = p0.InverseTransformPoint(p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            System.Single p1;
                            l.GetLua(2, out p1);
                            System.Single p2;
                            l.GetLua(3, out p2);
                            System.Single p3;
                            l.GetLua(4, out p3);
                            var rv = p0.InverseTransformPoint(p1, p2, p3);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_DetachChildren(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    p0.DetachChildren();
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
            private static int ___mm_SetAsFirstSibling(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    p0.SetAsFirstSibling();
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
            private static int ___mm_SetAsLastSibling(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    p0.SetAsLastSibling();
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
            private static int ___mm_SetSiblingIndex(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    p0.SetSiblingIndex(p1);
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
            private static int ___mm_GetSiblingIndex(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetSiblingIndex();
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_Find(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    var rv = p0.Find(p1);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_IsChildOf(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Transform p1;
                    l.GetLua(2, out p1);
                    var rv = p0.IsChildOf(p1);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_FindChild(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    System.String p1;
                    l.GetLua(2, out p1);
                    var rv = p0.FindChild(p1);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetEnumerator(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetEnumerator();
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_RotateAroundLocal(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector3 p1;
                    l.GetLua(2, out p1);
                    System.Single p2;
                    l.GetLua(3, out p2);
                    p0.RotateAroundLocal(p1, p2);
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
            private static int ___mm_GetChild(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    var rv = p0.GetChild(p1);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_GetChildCount(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform p0;
                    l.GetLua(1, out p0);
                    var rv = p0.GetChildCount();
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___mm_LookAt(IntPtr l)
            {
                try
                {
                    {
                        {
                            {
                                {
                                    {
                                        var ___ot1 = l.GetType(2);
                                        if (___ot1 == typeof(UnityEngine.Vector3))
                                        {
                                            var ___ot2 = l.GetType(3);
                                            if (___ot2 == typeof(UnityEngine.Vector3))
                                            {
                                                goto Label_30;
                                            }
                                            goto Label_40;
                                        }
                                        {
                                            var ___ot2 = l.GetType(3);
                                            if (___ot2 == typeof(UnityEngine.Vector3))
                                            {
                                                goto Label_20;
                                            }
                                            goto Label_10;
                                        }
                                    }
                                }
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Transform p1;
                            l.GetLua(2, out p1);
                            p0.LookAt(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Transform p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Vector3 p2;
                            l.GetLua(3, out p2);
                            p0.LookAt(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_30:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Vector3 p2;
                            l.GetLua(3, out p2);
                            p0.LookAt(p1, p2);
                            return 0;
                        }
                        goto Label_default;
                        Label_40:
                        {
                            UnityEngine.Transform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector3 p1;
                            l.GetLua(2, out p1);
                            p0.LookAt(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_default:
                        {
                        }
                    }
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
            private static int ___gm_position(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.position;
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
            private static int ___sm_position(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.position = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_localPosition(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.localPosition;
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
            private static int ___sm_localPosition(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.localPosition = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_eulerAngles(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.eulerAngles;
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
            private static int ___sm_eulerAngles(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.eulerAngles = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_localEulerAngles(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.localEulerAngles;
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
            private static int ___sm_localEulerAngles(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.localEulerAngles = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_right(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.right;
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
            private static int ___sm_right(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.right = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_up(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.up;
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
            private static int ___sm_up(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.up = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_forward(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.forward;
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
            private static int ___sm_forward(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.forward = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_rotation(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.rotation;
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
            private static int ___sm_rotation(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Quaternion val;
                    l.GetLua(2, out val);
                    tar.rotation = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_localRotation(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.localRotation;
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
            private static int ___sm_localRotation(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Quaternion val;
                    l.GetLua(2, out val);
                    tar.localRotation = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_localScale(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.localScale;
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
            private static int ___sm_localScale(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector3 val;
                    l.GetLua(2, out val);
                    tar.localScale = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_parent(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.parent;
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
            private static int ___sm_parent(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Transform val;
                    l.GetLua(2, out val);
                    tar.parent = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_worldToLocalMatrix(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.worldToLocalMatrix;
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
            private static int ___gm_localToWorldMatrix(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.localToWorldMatrix;
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
            private static int ___gm_root(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.root;
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
            private static int ___gm_childCount(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.childCount;
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
            private static int ___gm_lossyScale(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.lossyScale;
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
            private static int ___gm_hasChanged(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.hasChanged;
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
            private static int ___sm_hasChanged(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.hasChanged = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_hierarchyCapacity(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.hierarchyCapacity;
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
            private static int ___sm_hierarchyCapacity(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.hierarchyCapacity = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_hierarchyCount(IntPtr l)
            {
                try
                {
                    UnityEngine.Transform tar;
                    l.GetLua(1, out tar);
                    var rv = tar.hierarchyCount;
                    l.PushLua(rv);
                    return 1;
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
        private static TypeHubPrecompiled_UnityEngine_Transform ___tp_UnityEngine_Transform = new TypeHubPrecompiled_UnityEngine_Transform();
        public static void PushLua(this IntPtr l, UnityEngine.Transform val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.Transform val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.Transform;
        }
    }
}
#endif
