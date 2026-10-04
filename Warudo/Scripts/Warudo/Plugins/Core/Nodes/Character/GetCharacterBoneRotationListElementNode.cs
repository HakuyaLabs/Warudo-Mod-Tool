using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetCharacterBoneRotationListElementNode : Node
    {
        public Quaternion[] BoneRotations;
        public HumanBodyBones Index;
        public Quaternion OutputQuaternion()
        {
            throw new NotImplementedException();
        }
    }
}