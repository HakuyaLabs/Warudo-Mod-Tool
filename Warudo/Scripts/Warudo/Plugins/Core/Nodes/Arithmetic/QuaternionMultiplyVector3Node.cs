using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class QuaternionMultiplyVector3Node : Node
    {
        public Quaternion A;
        public Vector3 B;
        public Vector3 Result()
        {
            throw new NotImplementedException();
        }
    }
}