using System;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OverrideCharacterLimbIKRotationWeightNode : Node
    {
        public CharacterAsset Character;
        public Limb Limb;
        public float RotationWeight;
        public bool RelativeToConfiguredWeight = true;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}