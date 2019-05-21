#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_UI_GridLayoutGroup : LuaHub.TypeHubPrecompiled_UnityEngine_UI_LayoutGroup
        {
            public TypeHubPrecompiled_UnityEngine_UI_GridLayoutGroup() : this(typeof(UnityEngine.UI.GridLayoutGroup)) { }
            public TypeHubPrecompiled_UnityEngine_UI_GridLayoutGroup(Type type) : base(type)
            {
                #region REG_I_FUNC
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["spacing"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["spacing"]._Method, _Precompiled = ___gf_spacing };
                _InstanceFieldsNewIndex["spacing"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["spacing"]._Method, _Precompiled = ___sf_spacing };
                _InstanceFieldsIndex["cellSize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["cellSize"]._Method, _Precompiled = ___gf_cellSize };
                _InstanceFieldsNewIndex["cellSize"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["cellSize"]._Method, _Precompiled = ___sf_cellSize };
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
            private static readonly lua.CFunction ___gf_spacing = new lua.CFunction(___gm_spacing);
            private static readonly lua.CFunction ___sf_spacing = new lua.CFunction(___sm_spacing);
            private static readonly lua.CFunction ___gf_cellSize = new lua.CFunction(___gm_cellSize);
            private static readonly lua.CFunction ___sf_cellSize = new lua.CFunction(___sm_cellSize);
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
            private static int ___gm_spacing(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.GridLayoutGroup tar;
                    l.GetLua(1, out tar);
                    var rv = tar.spacing;
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
            private static int ___sm_spacing(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.GridLayoutGroup tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.spacing = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_cellSize(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.GridLayoutGroup tar;
                    l.GetLua(1, out tar);
                    var rv = tar.cellSize;
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
            private static int ___sm_cellSize(IntPtr l)
            {
                try
                {
                    UnityEngine.UI.GridLayoutGroup tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector2 val;
                    l.GetLua(2, out val);
                    tar.cellSize = val;
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
        private static TypeHubPrecompiled_UnityEngine_UI_GridLayoutGroup ___tp_UnityEngine_UI_GridLayoutGroup = new TypeHubPrecompiled_UnityEngine_UI_GridLayoutGroup();
        public static void PushLua(this IntPtr l, UnityEngine.UI.GridLayoutGroup val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.UI.GridLayoutGroup val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.UI.GridLayoutGroup;
        }
    }
}
#endif
