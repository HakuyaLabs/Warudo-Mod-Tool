using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class FloatInverseLerpNode : Node
    {
        public float A;
        public float B;
        public float Value;
        public float Result()
        {
            throw new NotImplementedException();
        }
    }
}