using System;
using Animancer;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetCharacterOverlappingAnimationWeightNode : SetCharacterOverlappingAnimationPropertyNode
    {
        public float Weight = 1f;
        public float TransitionTime = 1.2f;
        public Ease TransitionEasing = Ease.OutCubic;
        protected override void SetLayerProperty(CharacterAsset.OverlappingAnimationData layer)
        {
            throw new NotImplementedException();
        }

        protected override async void ApplyAnimancerProperty(CharacterAsset.OverlappingAnimationData layer, AnimancerComponent animancer, int layerIndex)
        {
            throw new NotImplementedException();
        }
    }
}