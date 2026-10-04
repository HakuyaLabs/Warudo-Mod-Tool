using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GenerateRandomFloatNode : Node
    {
        public float ValueMin = 0f;
        public float ValueMax = 1f;
        public float Result()
        {
            throw new NotImplementedException();
        }
    }
}