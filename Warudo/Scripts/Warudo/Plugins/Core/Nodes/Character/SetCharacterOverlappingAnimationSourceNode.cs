using Animancer;
using DG.Tweening;
using Warudo.Core.Attributes;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetCharacterOverlappingAnimationSourceNode : SetCharacterOverlappingAnimationPropertyNode
    {
        public string Source;
        public float TransitionTime = 1.2f;
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