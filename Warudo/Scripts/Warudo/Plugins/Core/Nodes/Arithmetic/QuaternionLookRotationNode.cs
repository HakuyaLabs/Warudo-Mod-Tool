using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class QuaternionLookRotationNode : Node
    {
        public Vector3 Forward = Vector3.forward;
        public Vector3 Upwards = Vector3.up;
        public Quaternion OutputQuaternion()
        {
            throw new NotImplementedException();
        }

        public Vector3 OutputVector3()
        {
            throw new NotImplementedException();
        }
    }
}