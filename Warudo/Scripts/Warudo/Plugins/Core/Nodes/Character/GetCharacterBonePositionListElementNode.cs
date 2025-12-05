using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetCharacterBonePositionListElementNode : Node
    {
        public Vector3[] BonePositions;
        public HumanBodyBones Index;
        public Vector3 OutputVector3()
        {
            throw new NotImplementedException();
        }
    }
}