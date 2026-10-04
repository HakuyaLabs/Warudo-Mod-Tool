using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class QuaternionFromToRotationNode : Node
    {
        public Vector3 FromDirection;
        public Vector3 ToDirection;
        public Quaternion OutputQuaternion()
        {
            throw new NotImplementedException();
        }
    }
}