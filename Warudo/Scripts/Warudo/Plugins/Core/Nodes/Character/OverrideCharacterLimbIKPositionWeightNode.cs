using System;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OverrideCharacterLimbIKPositionWeightNode : Node
    {
        public CharacterAsset Character;
        public Limb Limb;
        public float PositionWeight;
        public bool RelativeToConfiguredWeight = true;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}