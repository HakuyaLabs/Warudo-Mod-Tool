using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data.Models;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OverrideCharacterHeadIKNode : Node
    {
        public CharacterAsset Character;
        public PositionRotationData Target;
        public float PositionWeight = 1f;
        public float RotationWeight = 1f;
        public bool IsRelative = true;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}