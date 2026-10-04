using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetCharacterBlendShapeNode : Node
    {
        public CharacterAsset Character;
        public bool ApplyToAllSkinnedMeshes = true;
        protected bool HideApplyToAllSkinnedMeshes() => throw new NotImplementedException();
        public string TargetSkinnedMesh = "Body";
        public async UniTask<AutoCompleteList> AutoCompleteSkinnedMesh()
        {
            throw new NotImplementedException();
        }

        protected bool HideTargetSkinnedMesh() => throw new NotImplementedException();
        public bool UseVRMBlendShapeProxy = false;
        protected bool HideUseVRMBlendShapeProxy() => throw new NotImplementedException();
        public string BlendShape;
        public async UniTask<AutoCompleteList> AutoCompleteBlendShapes()
        {
            throw new NotImplementedException();
        }

        public float Value;
        public float TransitionTime = 0f;
        public Ease TransitionEasing = Ease.OutCubic;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}