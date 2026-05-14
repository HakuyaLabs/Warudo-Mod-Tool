using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class MergeCharacterBoneRotationListNode : Node
    {
        public Quaternion[] Face;
        public Quaternion[] Head;
        public Quaternion[] Pelvis;
        public Quaternion[] LeftArm;
        public Quaternion[] RightArm;
        public Quaternion[] LeftFingers;
        public Quaternion[] RightFingers;
        public Quaternion[] LeftLeg;
        public Quaternion[] RightLeg;
        public Quaternion[] BoneRotations()
        {
            throw new NotImplementedException();
        }
    }
}