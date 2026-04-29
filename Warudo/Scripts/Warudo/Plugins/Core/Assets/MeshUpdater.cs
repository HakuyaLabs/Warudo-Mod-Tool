using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets
{
    public class MeshUpdater
    {
        public Dictionary<string, MeshRenderer> MeshRenderers => throw new NotImplementedException();
        public Dictionary<string, SkinnedMeshRenderer> SkinnedMeshRenderers => throw new NotImplementedException();
        public Dictionary<string, List<Material>> Materials => throw new NotImplementedException();
        public Dictionary<string, CharacterAsset.VRMBlendShapeClipData> VrmBlendShapeClips => throw new NotImplementedException();
        public MeshUpdater(Func<Dictionary<string, MeshRenderer>> meshRenderersGetter, Func<Dictionary<string, SkinnedMeshRenderer>> skinnedMeshRenderersGetter, Func<Dictionary<string, List<Material>>> materialsGetter, Func<Dictionary<string, CharacterAsset.VRMBlendShapeClipData>> vrmBlendShapeClipsGetter)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public object GetInitialMaterialPropertyValue(string materialName, string propertyName, MaterialPropertyType propertyType)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlendShapes(Dictionary<string, SkinnedMeshRenderer> skinnedMeshRenderers, Dictionary<string, Dictionary<string, float>> blendShapes)
        {
            throw new NotImplementedException();
        }

        public void ApplyBlendShapeEntry(Dictionary<string, SkinnedMeshRenderer> skinnedMeshRenderers, Dictionary<string, CharacterAsset.VRMBlendShapeClipData> vrmBlendShapeClips, IBlendShapeEntry bs)
        {
            throw new NotImplementedException();
        }

        public void UpdateMaterialProperties(Dictionary<string, Dictionary<string, object>> materialProperties)
        {
            throw new NotImplementedException();
        }

        public void ApplyMaterialPropertyEntry(Dictionary<string, CharacterAsset.VRMBlendShapeClipData> vrmBlendShapeClips, IMaterialPropertyEntry mp)
        {
            throw new NotImplementedException();
        }

        public void Update(IBlendShapeEntry[] defaultBlendShapes, IMaterialPropertyEntry[] defaultMaterialProperties, Dictionary<string, Dictionary<string, float>> blendShapes, Dictionary<string, Dictionary<string, object>> materialProperties, List<IBlendShapeEntryProvider> overrideBlendShapeEntryProviders = null, List<IMaterialPropertyEntryProvider> overrideMaterialPropertyEntryProviders = null)
        {
            throw new NotImplementedException();
        }

        public void ResetBlendShapes(string smrName)
        {
            throw new NotImplementedException();
        }

        public void ResetBlendShapes()
        {
            throw new NotImplementedException();
        }

        public void ResetBlendShapesNextFrame()
        {
            throw new NotImplementedException();
        }

        public void ResetMaterialProperties(string materialName)
        {
            throw new NotImplementedException();
        }

        public void ResetMaterialProperties()
        {
            throw new NotImplementedException();
        }

        public void ResetMaterialPropertiesNextFrame()
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, List<Material>> GetMaterials(IEnumerable<Renderer> renderers)
        {
            throw new NotImplementedException();
        }
    }
}