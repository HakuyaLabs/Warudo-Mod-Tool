using Animancer;
using DG.Tweening;
using Warudo.Core.Attributes;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetCharacterOverlappingAnimationSpeedNode : SetCharacterOverlappingAnimationPropertyNode
    {
        public float Speed = 1f;
        public float TransitionTime = 1.2f;
        public Ease TransitionEasing = Ease.OutCubic;
        protected override void SetLayerProperty(CharacterAsset.OverlappingAnimationData layer)
        {
            throw new NotImplementedException();
        }

        protected override void ApplyAnimancerProperty(CharacterAsset.OverlappingAnimationData layer, AnimancerComponent animancer, int layerIndex)
        {
            throw new NotImplementedException();
        }
    }
}