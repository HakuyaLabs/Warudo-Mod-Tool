using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class QuaternionMultiplyQuaternionNode : Node
    {
        public Quaternion A;
        public Quaternion B;
        public Quaternion OutputQuaternion()
        {
            throw new NotImplementedException();
        }
    }
}