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
    public class OverrideCharacterHandIKNode : Node
    {
        public CharacterAsset Character;
        public Handedness Hand;
        public PositionRotationData Target;
        public Vector3 BendGoalTarget;
        public float PositionWeight;
        public float RotationWeight;
        public float BendGoalWeight;
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

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}