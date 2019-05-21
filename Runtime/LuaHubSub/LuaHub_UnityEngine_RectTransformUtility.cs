#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_RectTransformUtility : Capstones.LuaLib.LuaTypeHub.TypeHubCommonPrecompiled
        {
            public TypeHubPrecompiled_UnityEngine_RectTransformUtility() : this(typeof(UnityEngine.RectTransformUtility)) { }
            public TypeHubPrecompiled_UnityEngine_RectTransformUtility(Type type) : base(type)
            {
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
                _StaticMethods["ScreenPointToWorldPointInRectangle"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["ScreenPointToWorldPointInRectangle"]._Method, _Precompiled = ___sfm_ScreenPointToWorldPointInRectangle };
                _StaticMethods["RectangleContainsScreenPoint"] = new LuaMetaCallWithPrecompiled() { _Method = _StaticMethods["RectangleContainsScreenPoint"]._Method, _Precompiled = ___sfm_RectangleContainsScreenPoint };
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
            private static readonly lua.CFunction ___sfm_ScreenPointToWorldPointInRectangle = new lua.CFunction(___smm_ScreenPointToWorldPointInRectangle);
            private static readonly lua.CFunction ___sfm_RectangleContainsScreenPoint = new lua.CFunction(___smm_RectangleContainsScreenPoint);
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
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_ScreenPointToWorldPointInRectangle(IntPtr l)
            {
                try
                {
                    UnityEngine.RectTransform p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Vector2 p1;
                    l.GetLua(2, out p1);
                    UnityEngine.Camera p2;
                    l.GetLua(3, out p2);
                    UnityEngine.Vector3 p3;
                    l.GetLua(4, out p3);
                    var rv = UnityEngine.RectTransformUtility.ScreenPointToWorldPointInRectangle(p0, p1, p2, out p3);
                    l.PushLua(rv);
                    l.PushLua(p3);
                    return 2;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
                return 0;
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___smm_RectangleContainsScreenPoint(IntPtr l)
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
                            UnityEngine.RectTransform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector2 p1;
                            l.GetLua(2, out p1);
                            var rv = UnityEngine.RectTransformUtility.RectangleContainsScreenPoint(p0, p1);
                            l.PushLua(rv);
                            return 1;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.RectTransform p0;
                            l.GetLua(1, out p0);
                            UnityEngine.Vector2 p1;
                            l.GetLua(2, out p1);
                            UnityEngine.Camera p2;
                            l.GetLua(3, out p2);
                            var rv = UnityEngine.RectTransformUtility.RectangleContainsScreenPoint(p0, p1, p2);
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
        private static TypeHubPrecompiled_UnityEngine_RectTransformUtility ___tp_UnityEngine_RectTransformUtility = new TypeHubPrecompiled_UnityEngine_RectTransformUtility();
        public static void PushLua(this IntPtr l, UnityEngine.RectTransformUtility val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_RectTransformUtility.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.RectTransformUtility val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.RectTransformUtility;
        }
    }
}
#endif
