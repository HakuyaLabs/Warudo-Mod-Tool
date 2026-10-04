using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Prop;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Mixins
{
    public class Attachable : BehavioralMixin
    {
        public GameObjectAsset Parent;
        public AttachType AttachType = AttachType.HumanBodyBone;
        protected bool HideAttachType() => throw new NotImplementedException();
        public HumanBodyBones AttachToBone = HumanBodyBones.Head;
        protected bool HideAttachToBone() => throw new NotImplementedException();
        public string AttachToBoneDoesNotExist = "THIS_BONE_DOES_NOT_EXIST_ON_THE_CHARACTER".Localized();
        protected bool HideAttachToBoneDoesNotExist() => throw new NotImplementedException();
        public string AttachToTransform;
        protected bool HideAttachToTransform() => throw new NotImplementedException();
        public bool UseElasticity = false;
        public float StartElasticityDistance = 0.2f;
        public float StopElasticityDistance = 0.01f;
        public float ElasticityStiffness = 2f;
        public float ElasticityDamping = 3f;
        public float ElasticityMaxSpeed = 2f;
        protected bool HideElasticitySettings() => throw new NotImplementedException();
        public async UniTask<AutoCompleteList> GetTransforms()
        {
            throw new NotImplementedException();
        }

        public Transform Transform { get; private set; }

        public void Initialize(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override void OnPostLateUpdate()
        {
            throw new NotImplementedException();
        }

        public override void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }

    public enum AttachType
    {
        HumanBodyBone,
        TransformPath
    }
}