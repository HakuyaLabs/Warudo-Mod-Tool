using System;
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
    public class OverrideCharacterLimbIKTargetNode : Node
    {
        public CharacterAsset Character;
        public Limb Limb;
        public PositionRotationData Target;
        public bool Visualize = false;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}