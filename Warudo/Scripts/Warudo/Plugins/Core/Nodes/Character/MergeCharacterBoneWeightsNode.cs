using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class MergeCharacterBoneWeightsNode : Node
    {
        public float[] Face;
        public float[] Head;
        public float[] Pelvis;
        public float[] LeftArm;
        public float[] RightArm;
        public float[] LeftFingers;
        public float[] RightFingers;
        public float[] LeftLeg;
        public float[] RightLeg;
        public float[] BoneWeights()
        {
            throw new NotImplementedException();
        }
    }
}