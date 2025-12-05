using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ScaleCharacterBoneRotationListNode : Node
    {
        public Quaternion[] Rotations;
        public HumanBodyBones[] Bones;
        public float Scale = 1f;
        public Quaternion[] OutputRotations()
        {
            throw new NotImplementedException();
        }
    }
}