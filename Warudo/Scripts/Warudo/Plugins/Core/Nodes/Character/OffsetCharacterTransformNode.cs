using Warudo.Core.Attributes;
using Warudo.Core.Data.Models;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OffsetCharacterTransformNode : Node
    {
        public CharacterAsset Character;
        public TransformData Offset;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}