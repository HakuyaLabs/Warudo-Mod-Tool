using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralQuaternionNode : Node
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public Quaternion OutputQuaternion()
        {
            throw new NotImplementedException();
        }

        public Vector3 Output()
        {
            throw new NotImplementedException();
        }
    }
}