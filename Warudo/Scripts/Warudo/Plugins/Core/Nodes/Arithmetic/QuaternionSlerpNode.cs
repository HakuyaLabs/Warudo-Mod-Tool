using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class QuaternionSlerpNode : Node
    {
        public Quaternion A;
        public Quaternion B;
        public float T;
        public bool Unclamped;
        public Quaternion OutputQuaternion()
        {
            throw new NotImplementedException();
        }
    }
}