#if !DISABLE_LUA_PRECOMPILE
using System;

using lua = Capstones.LuaLib.LuaCoreLib;
using lual = Capstones.LuaLib.LuaAuxLib;
using luae = Capstones.LuaLib.LuaLibEx;

namespace Capstones.LuaLib
{
    public static partial class LuaHub
    {
        public class TypeHubPrecompiled_UnityEngine_SkinnedMeshRenderer : TypeHubPrecompiled_UnityEngine_Renderer
        {
            public TypeHubPrecompiled_UnityEngine_SkinnedMeshRenderer() : this(typeof(UnityEngine.SkinnedMeshRenderer)) { }
            public TypeHubPrecompiled_UnityEngine_SkinnedMeshRenderer(Type type) : base(type)
            {
                #region REG_I_FUNC
                _InstanceMethods["BakeMesh"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["BakeMesh"]._Method, _Precompiled = ___fm_BakeMesh };
                _InstanceMethods["GetBlendShapeWeight"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["GetBlendShapeWeight"]._Method, _Precompiled = ___fm_GetBlendShapeWeight };
                _InstanceMethods["SetBlendShapeWeight"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceMethods["SetBlendShapeWeight"]._Method, _Precompiled = ___fm_SetBlendShapeWeight };
                #endregion // REG_I_FUNC
                #region REG_I_PROP
                _InstanceFieldsIndex["bones"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["bones"]._Method, _Precompiled = ___gf_bones };
                _InstanceFieldsNewIndex["bones"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["bones"]._Method, _Precompiled = ___sf_bones };
                _InstanceFieldsIndex["rootBone"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["rootBone"]._Method, _Precompiled = ___gf_rootBone };
                _InstanceFieldsNewIndex["rootBone"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["rootBone"]._Method, _Precompiled = ___sf_rootBone };
                _InstanceFieldsIndex["quality"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["quality"]._Method, _Precompiled = ___gf_quality };
                _InstanceFieldsNewIndex["quality"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["quality"]._Method, _Precompiled = ___sf_quality };
                _InstanceFieldsIndex["sharedMesh"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sharedMesh"]._Method, _Precompiled = ___gf_sharedMesh };
                _InstanceFieldsNewIndex["sharedMesh"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sharedMesh"]._Method, _Precompiled = ___sf_sharedMesh };
                _InstanceFieldsIndex["updateWhenOffscreen"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["updateWhenOffscreen"]._Method, _Precompiled = ___gf_updateWhenOffscreen };
                _InstanceFieldsNewIndex["updateWhenOffscreen"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["updateWhenOffscreen"]._Method, _Precompiled = ___sf_updateWhenOffscreen };
                _InstanceFieldsIndex["skinnedMotionVectors"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["skinnedMotionVectors"]._Method, _Precompiled = ___gf_skinnedMotionVectors };
                _InstanceFieldsNewIndex["skinnedMotionVectors"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["skinnedMotionVectors"]._Method, _Precompiled = ___sf_skinnedMotionVectors };
                _InstanceFieldsIndex["localBounds"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["localBounds"]._Method, _Precompiled = ___gf_localBounds };
                _InstanceFieldsNewIndex["localBounds"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["localBounds"]._Method, _Precompiled = ___sf_localBounds };
                _InstanceFieldsIndex["isPartOfStaticBatch"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["isPartOfStaticBatch"]._Method, _Precompiled = ___gf_isPartOfStaticBatch };
                _InstanceFieldsIndex["worldToLocalMatrix"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["worldToLocalMatrix"]._Method, _Precompiled = ___gf_worldToLocalMatrix };
                _InstanceFieldsIndex["localToWorldMatrix"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["localToWorldMatrix"]._Method, _Precompiled = ___gf_localToWorldMatrix };
                _InstanceFieldsIndex["enabled"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["enabled"]._Method, _Precompiled = ___gf_enabled };
                _InstanceFieldsNewIndex["enabled"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["enabled"]._Method, _Precompiled = ___sf_enabled };
                _InstanceFieldsIndex["shadowCastingMode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["shadowCastingMode"]._Method, _Precompiled = ___gf_shadowCastingMode };
                _InstanceFieldsNewIndex["shadowCastingMode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["shadowCastingMode"]._Method, _Precompiled = ___sf_shadowCastingMode };
                _InstanceFieldsIndex["receiveShadows"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["receiveShadows"]._Method, _Precompiled = ___gf_receiveShadows };
                _InstanceFieldsNewIndex["receiveShadows"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["receiveShadows"]._Method, _Precompiled = ___sf_receiveShadows };
                _InstanceFieldsIndex["material"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["material"]._Method, _Precompiled = ___gf_material };
                _InstanceFieldsNewIndex["material"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["material"]._Method, _Precompiled = ___sf_material };
                _InstanceFieldsIndex["sharedMaterial"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sharedMaterial"]._Method, _Precompiled = ___gf_sharedMaterial };
                _InstanceFieldsNewIndex["sharedMaterial"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sharedMaterial"]._Method, _Precompiled = ___sf_sharedMaterial };
                _InstanceFieldsIndex["materials"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["materials"]._Method, _Precompiled = ___gf_materials };
                _InstanceFieldsNewIndex["materials"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["materials"]._Method, _Precompiled = ___sf_materials };
                _InstanceFieldsIndex["sharedMaterials"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sharedMaterials"]._Method, _Precompiled = ___gf_sharedMaterials };
                _InstanceFieldsNewIndex["sharedMaterials"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sharedMaterials"]._Method, _Precompiled = ___sf_sharedMaterials };
                _InstanceFieldsIndex["bounds"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["bounds"]._Method, _Precompiled = ___gf_bounds };
                _InstanceFieldsIndex["lightmapIndex"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["lightmapIndex"]._Method, _Precompiled = ___gf_lightmapIndex };
                _InstanceFieldsNewIndex["lightmapIndex"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["lightmapIndex"]._Method, _Precompiled = ___sf_lightmapIndex };
                _InstanceFieldsIndex["realtimeLightmapIndex"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["realtimeLightmapIndex"]._Method, _Precompiled = ___gf_realtimeLightmapIndex };
                _InstanceFieldsNewIndex["realtimeLightmapIndex"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["realtimeLightmapIndex"]._Method, _Precompiled = ___sf_realtimeLightmapIndex };
                _InstanceFieldsIndex["lightmapScaleOffset"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["lightmapScaleOffset"]._Method, _Precompiled = ___gf_lightmapScaleOffset };
                _InstanceFieldsNewIndex["lightmapScaleOffset"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["lightmapScaleOffset"]._Method, _Precompiled = ___sf_lightmapScaleOffset };
                _InstanceFieldsIndex["motionVectorGenerationMode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["motionVectorGenerationMode"]._Method, _Precompiled = ___gf_motionVectorGenerationMode };
                _InstanceFieldsNewIndex["motionVectorGenerationMode"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["motionVectorGenerationMode"]._Method, _Precompiled = ___sf_motionVectorGenerationMode };
                _InstanceFieldsIndex["realtimeLightmapScaleOffset"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["realtimeLightmapScaleOffset"]._Method, _Precompiled = ___gf_realtimeLightmapScaleOffset };
                _InstanceFieldsNewIndex["realtimeLightmapScaleOffset"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["realtimeLightmapScaleOffset"]._Method, _Precompiled = ___sf_realtimeLightmapScaleOffset };
                _InstanceFieldsIndex["isVisible"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["isVisible"]._Method, _Precompiled = ___gf_isVisible };
                _InstanceFieldsIndex["lightProbeUsage"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["lightProbeUsage"]._Method, _Precompiled = ___gf_lightProbeUsage };
                _InstanceFieldsNewIndex["lightProbeUsage"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["lightProbeUsage"]._Method, _Precompiled = ___sf_lightProbeUsage };
                _InstanceFieldsIndex["lightProbeProxyVolumeOverride"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["lightProbeProxyVolumeOverride"]._Method, _Precompiled = ___gf_lightProbeProxyVolumeOverride };
                _InstanceFieldsNewIndex["lightProbeProxyVolumeOverride"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["lightProbeProxyVolumeOverride"]._Method, _Precompiled = ___sf_lightProbeProxyVolumeOverride };
                _InstanceFieldsIndex["probeAnchor"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["probeAnchor"]._Method, _Precompiled = ___gf_probeAnchor };
                _InstanceFieldsNewIndex["probeAnchor"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["probeAnchor"]._Method, _Precompiled = ___sf_probeAnchor };
                _InstanceFieldsIndex["reflectionProbeUsage"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["reflectionProbeUsage"]._Method, _Precompiled = ___gf_reflectionProbeUsage };
                _InstanceFieldsNewIndex["reflectionProbeUsage"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["reflectionProbeUsage"]._Method, _Precompiled = ___sf_reflectionProbeUsage };
                _InstanceFieldsIndex["sortingLayerName"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sortingLayerName"]._Method, _Precompiled = ___gf_sortingLayerName };
                _InstanceFieldsNewIndex["sortingLayerName"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sortingLayerName"]._Method, _Precompiled = ___sf_sortingLayerName };
                _InstanceFieldsIndex["sortingLayerID"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sortingLayerID"]._Method, _Precompiled = ___gf_sortingLayerID };
                _InstanceFieldsNewIndex["sortingLayerID"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sortingLayerID"]._Method, _Precompiled = ___sf_sortingLayerID };
                _InstanceFieldsIndex["sortingOrder"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["sortingOrder"]._Method, _Precompiled = ___gf_sortingOrder };
                _InstanceFieldsNewIndex["sortingOrder"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["sortingOrder"]._Method, _Precompiled = ___sf_sortingOrder };
                _InstanceFieldsIndex["castShadows"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["castShadows"]._Method, _Precompiled = ___gf_castShadows };
                _InstanceFieldsNewIndex["castShadows"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["castShadows"]._Method, _Precompiled = ___sf_castShadows };
                _InstanceFieldsIndex["motionVectors"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["motionVectors"]._Method, _Precompiled = ___gf_motionVectors };
                _InstanceFieldsNewIndex["motionVectors"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["motionVectors"]._Method, _Precompiled = ___sf_motionVectors };
                _InstanceFieldsIndex["useLightProbes"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["useLightProbes"]._Method, _Precompiled = ___gf_useLightProbes };
                _InstanceFieldsNewIndex["useLightProbes"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["useLightProbes"]._Method, _Precompiled = ___sf_useLightProbes };
                _InstanceFieldsIndex["transform"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["transform"]._Method, _Precompiled = ___gf_transform };
                _InstanceFieldsIndex["gameObject"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["gameObject"]._Method, _Precompiled = ___gf_gameObject };
                _InstanceFieldsIndex["tag"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["tag"]._Method, _Precompiled = ___gf_tag };
                _InstanceFieldsNewIndex["tag"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["tag"]._Method, _Precompiled = ___sf_tag };
                _InstanceFieldsIndex["name"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["name"]._Method, _Precompiled = ___gf_name };
                _InstanceFieldsNewIndex["name"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["name"]._Method, _Precompiled = ___sf_name };
                _InstanceFieldsIndex["hideFlags"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsIndex["hideFlags"]._Method, _Precompiled = ___gf_hideFlags };
                _InstanceFieldsNewIndex["hideFlags"] = new LuaMetaCallWithPrecompiled() { _Method = _InstanceFieldsNewIndex["hideFlags"]._Method, _Precompiled = ___sf_hideFlags };
                #endregion // REG_I_PROP
                #region REG_G_I_FUNC
                #endregion // REG_G_I_FUNC
                #region REG_I_INDEX
                #endregion // REG_I_INDEX
                #if UNITY_EDITOR
                _InstanceMethods_DirectFromBase.Add("SetPropertyBlock");
                _InstanceMethods_DirectFromBase.Add("GetPropertyBlock");
                _InstanceMethods_DirectFromBase.Add("GetClosestReflectionProbes");
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
            private static readonly lua.CFunction ___fm_BakeMesh = new lua.CFunction(___mm_BakeMesh);
            private static readonly lua.CFunction ___fm_GetBlendShapeWeight = new lua.CFunction(___mm_GetBlendShapeWeight);
            private static readonly lua.CFunction ___fm_SetBlendShapeWeight = new lua.CFunction(___mm_SetBlendShapeWeight);
            #endregion // DEL_I_FUNC
            #region DEL_I_PROP
            private static readonly lua.CFunction ___gf_bones = new lua.CFunction(___gm_bones);
            private static readonly lua.CFunction ___sf_bones = new lua.CFunction(___sm_bones);
            private static readonly lua.CFunction ___gf_rootBone = new lua.CFunction(___gm_rootBone);
            private static readonly lua.CFunction ___sf_rootBone = new lua.CFunction(___sm_rootBone);
            private static readonly lua.CFunction ___gf_quality = new lua.CFunction(___gm_quality);
            private static readonly lua.CFunction ___sf_quality = new lua.CFunction(___sm_quality);
            private static readonly lua.CFunction ___gf_sharedMesh = new lua.CFunction(___gm_sharedMesh);
            private static readonly lua.CFunction ___sf_sharedMesh = new lua.CFunction(___sm_sharedMesh);
            private static readonly lua.CFunction ___gf_updateWhenOffscreen = new lua.CFunction(___gm_updateWhenOffscreen);
            private static readonly lua.CFunction ___sf_updateWhenOffscreen = new lua.CFunction(___sm_updateWhenOffscreen);
            private static readonly lua.CFunction ___gf_skinnedMotionVectors = new lua.CFunction(___gm_skinnedMotionVectors);
            private static readonly lua.CFunction ___sf_skinnedMotionVectors = new lua.CFunction(___sm_skinnedMotionVectors);
            private static readonly lua.CFunction ___gf_localBounds = new lua.CFunction(___gm_localBounds);
            private static readonly lua.CFunction ___sf_localBounds = new lua.CFunction(___sm_localBounds);
            private static readonly lua.CFunction ___gf_isPartOfStaticBatch = new lua.CFunction(___gm_isPartOfStaticBatch);
            private static readonly lua.CFunction ___gf_worldToLocalMatrix = new lua.CFunction(___gm_worldToLocalMatrix);
            private static readonly lua.CFunction ___gf_localToWorldMatrix = new lua.CFunction(___gm_localToWorldMatrix);
            private static readonly lua.CFunction ___gf_enabled = new lua.CFunction(___gm_enabled);
            private static readonly lua.CFunction ___sf_enabled = new lua.CFunction(___sm_enabled);
            private static readonly lua.CFunction ___gf_shadowCastingMode = new lua.CFunction(___gm_shadowCastingMode);
            private static readonly lua.CFunction ___sf_shadowCastingMode = new lua.CFunction(___sm_shadowCastingMode);
            private static readonly lua.CFunction ___gf_receiveShadows = new lua.CFunction(___gm_receiveShadows);
            private static readonly lua.CFunction ___sf_receiveShadows = new lua.CFunction(___sm_receiveShadows);
            private static readonly lua.CFunction ___gf_material = new lua.CFunction(___gm_material);
            private static readonly lua.CFunction ___sf_material = new lua.CFunction(___sm_material);
            private static readonly lua.CFunction ___gf_sharedMaterial = new lua.CFunction(___gm_sharedMaterial);
            private static readonly lua.CFunction ___sf_sharedMaterial = new lua.CFunction(___sm_sharedMaterial);
            private static readonly lua.CFunction ___gf_materials = new lua.CFunction(___gm_materials);
            private static readonly lua.CFunction ___sf_materials = new lua.CFunction(___sm_materials);
            private static readonly lua.CFunction ___gf_sharedMaterials = new lua.CFunction(___gm_sharedMaterials);
            private static readonly lua.CFunction ___sf_sharedMaterials = new lua.CFunction(___sm_sharedMaterials);
            private static readonly lua.CFunction ___gf_bounds = new lua.CFunction(___gm_bounds);
            private static readonly lua.CFunction ___gf_lightmapIndex = new lua.CFunction(___gm_lightmapIndex);
            private static readonly lua.CFunction ___sf_lightmapIndex = new lua.CFunction(___sm_lightmapIndex);
            private static readonly lua.CFunction ___gf_realtimeLightmapIndex = new lua.CFunction(___gm_realtimeLightmapIndex);
            private static readonly lua.CFunction ___sf_realtimeLightmapIndex = new lua.CFunction(___sm_realtimeLightmapIndex);
            private static readonly lua.CFunction ___gf_lightmapScaleOffset = new lua.CFunction(___gm_lightmapScaleOffset);
            private static readonly lua.CFunction ___sf_lightmapScaleOffset = new lua.CFunction(___sm_lightmapScaleOffset);
            private static readonly lua.CFunction ___gf_motionVectorGenerationMode = new lua.CFunction(___gm_motionVectorGenerationMode);
            private static readonly lua.CFunction ___sf_motionVectorGenerationMode = new lua.CFunction(___sm_motionVectorGenerationMode);
            private static readonly lua.CFunction ___gf_realtimeLightmapScaleOffset = new lua.CFunction(___gm_realtimeLightmapScaleOffset);
            private static readonly lua.CFunction ___sf_realtimeLightmapScaleOffset = new lua.CFunction(___sm_realtimeLightmapScaleOffset);
            private static readonly lua.CFunction ___gf_isVisible = new lua.CFunction(___gm_isVisible);
            private static readonly lua.CFunction ___gf_lightProbeUsage = new lua.CFunction(___gm_lightProbeUsage);
            private static readonly lua.CFunction ___sf_lightProbeUsage = new lua.CFunction(___sm_lightProbeUsage);
            private static readonly lua.CFunction ___gf_lightProbeProxyVolumeOverride = new lua.CFunction(___gm_lightProbeProxyVolumeOverride);
            private static readonly lua.CFunction ___sf_lightProbeProxyVolumeOverride = new lua.CFunction(___sm_lightProbeProxyVolumeOverride);
            private static readonly lua.CFunction ___gf_probeAnchor = new lua.CFunction(___gm_probeAnchor);
            private static readonly lua.CFunction ___sf_probeAnchor = new lua.CFunction(___sm_probeAnchor);
            private static readonly lua.CFunction ___gf_reflectionProbeUsage = new lua.CFunction(___gm_reflectionProbeUsage);
            private static readonly lua.CFunction ___sf_reflectionProbeUsage = new lua.CFunction(___sm_reflectionProbeUsage);
            private static readonly lua.CFunction ___gf_sortingLayerName = new lua.CFunction(___gm_sortingLayerName);
            private static readonly lua.CFunction ___sf_sortingLayerName = new lua.CFunction(___sm_sortingLayerName);
            private static readonly lua.CFunction ___gf_sortingLayerID = new lua.CFunction(___gm_sortingLayerID);
            private static readonly lua.CFunction ___sf_sortingLayerID = new lua.CFunction(___sm_sortingLayerID);
            private static readonly lua.CFunction ___gf_sortingOrder = new lua.CFunction(___gm_sortingOrder);
            private static readonly lua.CFunction ___sf_sortingOrder = new lua.CFunction(___sm_sortingOrder);
            private static readonly lua.CFunction ___gf_castShadows = new lua.CFunction(___gm_castShadows);
            private static readonly lua.CFunction ___sf_castShadows = new lua.CFunction(___sm_castShadows);
            private static readonly lua.CFunction ___gf_motionVectors = new lua.CFunction(___gm_motionVectors);
            private static readonly lua.CFunction ___sf_motionVectors = new lua.CFunction(___sm_motionVectors);
            private static readonly lua.CFunction ___gf_useLightProbes = new lua.CFunction(___gm_useLightProbes);
            private static readonly lua.CFunction ___sf_useLightProbes = new lua.CFunction(___sm_useLightProbes);
            private static readonly lua.CFunction ___gf_transform = new lua.CFunction(___gm_transform);
            private static readonly lua.CFunction ___gf_gameObject = new lua.CFunction(___gm_gameObject);
            private static readonly lua.CFunction ___gf_tag = new lua.CFunction(___gm_tag);
            private static readonly lua.CFunction ___sf_tag = new lua.CFunction(___sm_tag);
            private static readonly lua.CFunction ___gf_name = new lua.CFunction(___gm_name);
            private static readonly lua.CFunction ___sf_name = new lua.CFunction(___sm_name);
            private static readonly lua.CFunction ___gf_hideFlags = new lua.CFunction(___gm_hideFlags);
            private static readonly lua.CFunction ___sf_hideFlags = new lua.CFunction(___sm_hideFlags);
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
                    var rv = new UnityEngine.SkinnedMeshRenderer();
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
            private static int ___mm_BakeMesh(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer p0;
                    l.GetLua(1, out p0);
                    UnityEngine.Mesh p1;
                    l.GetLua(2, out p1);
                    p0.BakeMesh(p1);
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
            private static int ___mm_GetBlendShapeWeight(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer p0;
                    l.GetLua(1, out p0);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    var rv = p0.GetBlendShapeWeight(p1);
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
            private static int ___mm_SetBlendShapeWeight(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer p0;
                    l.GetLua(1, out p0);
                    System.Int32 p1;
                    l.GetLua(2, out p1);
                    System.Single p2;
                    l.GetLua(3, out p2);
                    p0.SetBlendShapeWeight(p1, p2);
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
            private static int ___gm_bones(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.bones;
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
            private static int ___sm_bones(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Transform[] val;
                    l.GetLua(2, out val);
                    tar.bones = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_rootBone(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.rootBone;
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
            private static int ___sm_rootBone(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Transform val;
                    l.GetLua(2, out val);
                    tar.rootBone = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_quality(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.quality;
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
            private static int ___sm_quality(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.SkinQuality val;
                    l.GetLua(2, out val);
                    tar.quality = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sharedMesh(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sharedMesh;
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
            private static int ___sm_sharedMesh(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Mesh val;
                    l.GetLua(2, out val);
                    tar.sharedMesh = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_updateWhenOffscreen(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.updateWhenOffscreen;
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
            private static int ___sm_updateWhenOffscreen(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.updateWhenOffscreen = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_skinnedMotionVectors(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.skinnedMotionVectors;
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
            private static int ___sm_skinnedMotionVectors(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.skinnedMotionVectors = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_localBounds(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.localBounds;
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
            private static int ___sm_localBounds(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Bounds val;
                    l.GetLua(2, out val);
                    tar.localBounds = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_isPartOfStaticBatch(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.isPartOfStaticBatch;
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
            private static int ___gm_worldToLocalMatrix(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
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
                    UnityEngine.SkinnedMeshRenderer tar;
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
            private static int ___gm_enabled(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
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
                    UnityEngine.SkinnedMeshRenderer tar;
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
            private static int ___gm_shadowCastingMode(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.shadowCastingMode;
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
            private static int ___sm_shadowCastingMode(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Rendering.ShadowCastingMode val;
                    l.GetLua(2, out val);
                    tar.shadowCastingMode = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_receiveShadows(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.receiveShadows;
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
            private static int ___sm_receiveShadows(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.receiveShadows = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_material(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.material;
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
            private static int ___sm_material(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Material val;
                    l.GetLua(2, out val);
                    tar.material = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sharedMaterial(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sharedMaterial;
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
            private static int ___sm_sharedMaterial(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Material val;
                    l.GetLua(2, out val);
                    tar.sharedMaterial = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_materials(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.materials;
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
            private static int ___sm_materials(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Material[] val;
                    l.GetLua(2, out val);
                    tar.materials = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sharedMaterials(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sharedMaterials;
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
            private static int ___sm_sharedMaterials(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Material[] val;
                    l.GetLua(2, out val);
                    tar.sharedMaterials = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_bounds(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.bounds;
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
            private static int ___gm_lightmapIndex(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.lightmapIndex;
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
            private static int ___sm_lightmapIndex(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.lightmapIndex = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_realtimeLightmapIndex(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.realtimeLightmapIndex;
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
            private static int ___sm_realtimeLightmapIndex(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.realtimeLightmapIndex = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_lightmapScaleOffset(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.lightmapScaleOffset;
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
            private static int ___sm_lightmapScaleOffset(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector4 val;
                    l.GetLua(2, out val);
                    tar.lightmapScaleOffset = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_motionVectorGenerationMode(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.motionVectorGenerationMode;
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
            private static int ___sm_motionVectorGenerationMode(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.MotionVectorGenerationMode val;
                    l.GetLua(2, out val);
                    tar.motionVectorGenerationMode = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_realtimeLightmapScaleOffset(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.realtimeLightmapScaleOffset;
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
            private static int ___sm_realtimeLightmapScaleOffset(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Vector4 val;
                    l.GetLua(2, out val);
                    tar.realtimeLightmapScaleOffset = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_isVisible(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.isVisible;
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
            private static int ___gm_lightProbeUsage(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.lightProbeUsage;
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
            private static int ___sm_lightProbeUsage(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Rendering.LightProbeUsage val;
                    l.GetLua(2, out val);
                    tar.lightProbeUsage = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_lightProbeProxyVolumeOverride(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.lightProbeProxyVolumeOverride;
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
            private static int ___sm_lightProbeProxyVolumeOverride(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.GameObject val;
                    l.GetLua(2, out val);
                    tar.lightProbeProxyVolumeOverride = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_probeAnchor(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.probeAnchor;
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
            private static int ___sm_probeAnchor(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Transform val;
                    l.GetLua(2, out val);
                    tar.probeAnchor = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_reflectionProbeUsage(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.reflectionProbeUsage;
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
            private static int ___sm_reflectionProbeUsage(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.Rendering.ReflectionProbeUsage val;
                    l.GetLua(2, out val);
                    tar.reflectionProbeUsage = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sortingLayerName(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sortingLayerName;
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
            private static int ___sm_sortingLayerName(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.String val;
                    l.GetLua(2, out val);
                    tar.sortingLayerName = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sortingLayerID(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sortingLayerID;
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
            private static int ___sm_sortingLayerID(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.sortingLayerID = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_sortingOrder(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.sortingOrder;
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
            private static int ___sm_sortingOrder(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Int32 val;
                    l.GetLua(2, out val);
                    tar.sortingOrder = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_castShadows(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.castShadows;
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
            private static int ___sm_castShadows(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.castShadows = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_motionVectors(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.motionVectors;
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
            private static int ___sm_motionVectors(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.motionVectors = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_useLightProbes(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.useLightProbes;
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
            private static int ___sm_useLightProbes(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.Boolean val;
                    l.GetLua(2, out val);
                    tar.useLightProbes = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_transform(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
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
            private static int ___gm_gameObject(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
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
            private static int ___gm_tag(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.tag;
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
            private static int ___sm_tag(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.String val;
                    l.GetLua(2, out val);
                    tar.tag = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_name(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.name;
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
            private static int ___sm_name(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    System.String val;
                    l.GetLua(2, out val);
                    tar.name = val;
                    return 0;
                }
                catch (Exception exception)
                {
                    l.LogError(exception);
                    return 0;
                }
            }
            [AOT.MonoPInvokeCallback(typeof(lua.CFunction))]
            private static int ___gm_hideFlags(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    var rv = tar.hideFlags;
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
            private static int ___sm_hideFlags(IntPtr l)
            {
                try
                {
                    UnityEngine.SkinnedMeshRenderer tar;
                    l.GetLua(1, out tar);
                    UnityEngine.HideFlags val;
                    l.GetLua(2, out val);
                    tar.hideFlags = val;
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
        private static TypeHubPrecompiled_UnityEngine_SkinnedMeshRenderer ___tp_UnityEngine_SkinnedMeshRenderer = new TypeHubPrecompiled_UnityEngine_SkinnedMeshRenderer();
        public static void PushLua(this IntPtr l, UnityEngine.SkinnedMeshRenderer val)
        {
            if (object.ReferenceEquals(val, null))
            l.pushnil();
            else
            l.PushLuaObject(val);
        }
        public static void GetLua(this IntPtr l, int index, out UnityEngine.SkinnedMeshRenderer val)
        {
            val = LuaHub.GetLuaTableObjectChecked(l, index) as UnityEngine.SkinnedMeshRenderer;
        }
    }
}
#endif
