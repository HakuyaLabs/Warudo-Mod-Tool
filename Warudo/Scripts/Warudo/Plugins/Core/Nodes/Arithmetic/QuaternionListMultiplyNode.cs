using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class QuaternionListMultiplyNode : Node
    {
        public Quaternion[] A;
        public Quaternion[] B;
        public Quaternion[] Result()
        {
            throw new NotImplementedException();
        }
    }
}