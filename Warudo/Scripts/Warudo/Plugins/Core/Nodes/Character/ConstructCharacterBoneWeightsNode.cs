using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ConstructCharacterBoneWeightsNode : Node
    {
        public float Face = 1f;
        public float Head = 1f;
        public float Pelvis = 1f;
        public float LeftArm = 1f;
        public float RightArm = 1f;
        public float LeftFingers = 1f;
        public float RightFingers = 1f;
        public float LeftLeg = 1f;
        public float RightLeg = 1f;
        public float[] BoneWeights()
        {
            throw new NotImplementedException();
        }
    }
}