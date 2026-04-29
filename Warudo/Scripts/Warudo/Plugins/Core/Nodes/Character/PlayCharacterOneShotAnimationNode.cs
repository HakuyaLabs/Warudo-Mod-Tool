using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class PlayOneShotCharacterAnimationNode : Node
    {
        public CharacterAsset Character;
        public string Animation;
        public float TransitionTime = 1.2f;
        public float Weight = 1f;
        public float Speed = 1f;
        public bool Masked = false;
        public CharacterAsset.AnimationMaskedBodyPart[] MaskedBodyParts;
        public void MaskUpperBody()
        {
            throw new NotImplementedException();
        }

        public void MaskLowerBody()
        {
            throw new NotImplementedException();
        }

        public bool Additive;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnAnimationEnd;
    }
}