using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Resource;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Mixins;
using Warudo.Plugins.Core.Events;
using Warudo.Plugins.Core.Utils;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Assets.Prop
{
    public class PropAsset : FromSourceGameObjectAsset, IMeshDataParent
    {
        protected override bool UsePreviewGallery => throw new NotImplementedException();
        public Attachable Attachable;
        public string OverrideHandPose;
        public float OverrideHandPoseWeight = 1f;
        public bool OverrideHandPoseHighPriority = false;
        protected bool HideOverrideHandPose() => throw new NotImplementedException();
        public bool CollisionEnabled = false;
        public BlendShapeEntry[] DefaultBlendShapes;
        public MaterialPropertyEntry[] DefaultMaterialProperties;
        public class BlendShapeEntry : BlendShapeEntryDataBase<PropAsset>
        {
            protected override Dictionary<string, SkinnedMeshRenderer> ParentSkinnedMeshRenderers => throw new NotImplementedException();
            protected override bool ParentActive => throw new NotImplementedException();
            protected override CharacterAsset ParentCharacter => throw new NotImplementedException();
        }

        public class MaterialPropertyEntry : MaterialPropertyEntryBase<PropAsset>
        {
            protected override bool ParentActive => throw new NotImplementedException();
            protected override Dictionary<string, List<Material>> ParentMaterials => throw new NotImplementedException();
            protected override Dictionary<string, List<ShaderProperty>> ParentMaterialProperties => throw new NotImplementedException();
            protected override CharacterAsset ParentCharacter => throw new NotImplementedException();
            protected override bool HideTransitionDataInputs() => throw new NotImplementedException();
        }

        public MeshData<PropAsset>[] Meshes;
        public Dictionary<string, SkinnedMeshRenderer> SkinnedMeshRenderers { get; private set; }

        public Dictionary<string, MeshRenderer> MeshRenderers { get; private set; }

        public Dictionary<string, List<Material>> Materials { get; private set; }

        public Dictionary<string, List<ShaderProperty>> MaterialProperties { get; private set; }

        public MeshUpdater MeshUpdater { get; private set; }

        public List<CharacterAttachmentRotationConstraint> AttachmentRotationConstraints { get; private set; }

        protected override async UniTask<AutoCompleteList> GetSources()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedAsset serialized)
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected override GameObject CreateGameObject()
        {
            throw new NotImplementedException();
        }

        protected override void OnGameObjectCreated()
        {
            throw new NotImplementedException();
        }

        public override void OnPostLateUpdate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}