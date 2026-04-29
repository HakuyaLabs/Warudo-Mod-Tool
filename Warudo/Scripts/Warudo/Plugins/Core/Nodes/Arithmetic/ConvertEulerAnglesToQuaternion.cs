using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ConvertEulerAnglesToQuaternionNode : Node
    {
        public Vector3 Vector3;
        public Quaternion Quaternion()
        {
            throw new NotImplementedException();
        }
    }
}