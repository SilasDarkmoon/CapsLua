#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_AudioSource : LuaHub.TypeHubPrecompiled_UnityEngine_Behaviour
        {
            public TypeHubPrecompiled_UnityEngine_AudioSource() : this(typeof(UnityEngine.AudioSource)) { }
            public TypeHubPrecompiled_UnityEngine_AudioSource(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["Stop"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Stop"]._Method, _Precompiled = ___fm_Stop };
                _InstanceMethods["Play"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["Play"]._Method, _Precompiled = ___fm_Play };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["volume"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["volume"]._Method, _Precompiled = ___gf_volume };
                _InstanceFieldsNewIndex["volume"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["volume"]._Method, _Precompiled = ___sf_volume };
                _InstanceFieldsIndex["isPlaying"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["isPlaying"]._Method, _Precompiled = ___gf_isPlaying };
                _InstanceFieldsIndex["clip"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["clip"]._Method, _Precompiled = ___gf_clip };
                _InstanceFieldsNewIndex["clip"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["clip"]._Method, _Precompiled = ___sf_clip };
                _InstanceFieldsIndex["loop"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["loop"]._Method, _Precompiled = ___gf_loop };
                _InstanceFieldsNewIndex["loop"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["loop"]._Method, _Precompiled = ___sf_loop };
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
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
            private static readonly lua.CFunction ___fm_Stop = new lua.CFunction(___mm_Stop);
            private static readonly lua.CFunction ___fm_Play = new lua.CFunction(___mm_Play);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_volume = new lua.CFunction(___gm_volume);
            private static readonly lua.CFunction ___sf_volume = new lua.CFunction(___sm_volume);
            private static readonly lua.CFunction ___gf_isPlaying = new lua.CFunction(___gm_isPlaying);
            private static readonly lua.CFunction ___gf_clip = new lua.CFunction(___gm_clip);
            private static readonly lua.CFunction ___sf_clip = new lua.CFunction(___sm_clip);
            private static readonly lua.CFunction ___gf_loop = new lua.CFunction(___gm_loop);
            private static readonly lua.CFunction ___sf_loop = new lua.CFunction(___sm_loop);
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
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
            private static int ___mm_Stop(IntPtr l)
            {
                try
                {
                    UnityEngine.AudioSource p0;
                    l.GetLua(1, out p0);
                    p0.Stop();
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
            private static int ___mm_Play(IntPtr l)
            {
                try
                {
                    {
                        {
                            var oldtop = l.gettop();
                            if (oldtop == 1)
                            {
                                goto Label_20;
                            }
                            else if (oldtop >= 2)
                            {
                                goto Label_10;
                            }
                        }
                        goto Label_default;
                        Label_10:
                        {
                            UnityEngine.AudioSource p0;
                            l.GetLua(1, out p0);
                            System.UInt64 p1;
                            l.GetLua(2, out p1);
                            p0.Play(p1);
                            return 0;
                        }
                        goto Label_default;
                        Label_20:
                        {
                            UnityEngine.AudioSource p0;
                            l.GetLua(1, out p0);
                            p0.Play();
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
            private static int ___gm_volume(IntPtr l)
            {
                try
                {
                    UnityEngine.AudioSource tar;
                    l.GetLua(1, out tar);
                    var rv = tar.volume;
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
            private static int ___sm_volume(IntPtr l)
            {
                try
                {
                    UnityEngine.AudioSource tar;
                    l.GetLua(1, out tar);
                    System.Single val;
                    l.GetLua(2, out val);
                    tar.volume = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_isPlaying(IntPtr l)
            {
                try
                {
                    UnityEngine.AudioSource tar;
                    l.GetLua(1, out tar);
                    var rv = tar.isPlaying;
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
            private static int ___gm_clip(IntPtr l)
            {
                try
                {
                    UnityEngine.AudioSource tar;
                    l.GetLua(1, out tar);
                    var rv = tar.clip;
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
            private static int ___sm_clip(IntPtr l)
            {
                try
                {
                    UnityEngine.AudioSource tar;
                    l.GetLua(1, out tar);
                    UnityEngine.AudioClip val;
                    l.GetLua(2, out val);
                    tar.clip = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_loop(IntPtr l)
            {
                try
                {
                    UnityEngine.AudioSource tar;
                    l.GetLua(1, out tar);
                    var rv = tar.loop;
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
            private static int ___sm_loop(IntPtr l)
            {
                try
                {
                    UnityEngine.AudioSource tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.loop = val;
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
                    UnityEngine.AudioSource tar;
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
        private static TypeHubPrecompiled_UnityEngine_AudioSource ___tp_UnityEngine_AudioSource = new TypeHubPrecompiled_UnityEngine_AudioSource();
        public static void PushLua(this IntPtr l, UnityEngine.AudioSource val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            ___tp_UnityEngine_AudioSource.PushLuaObject(l, val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.AudioSource val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.AudioSource;
        }
    }
}
#endif
