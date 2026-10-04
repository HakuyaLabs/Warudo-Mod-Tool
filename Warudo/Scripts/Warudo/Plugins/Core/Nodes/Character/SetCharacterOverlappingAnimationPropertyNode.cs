using System;
using System.Collections.Generic;
using System.Linq;
using Animancer;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class SetCharacterOverlappingAnimationPropertyNode : Node
    {
        public CharacterAsset Character;
        public string Layer;
        protected async UniTask<AutoCompleteList> AutoCompleteLayer()
        {
            throw new NotImplementedException();
        }

        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        protected abstract void SetLayerProperty(CharacterAsset.OverlappingAnimationData layer);
        protected abstract void ApplyAnimancerProperty(CharacterAsset.OverlappingAnimationData layer, AnimancerComponent animancer, int layerIndex);
    }
}