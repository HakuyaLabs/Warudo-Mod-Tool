using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SmoothFloatNode : Node
    {
        public float Float;
        public float SmoothTime = 0.4f;
        public float SmoothedFloat()
        {
            throw new NotImplementedException();
        }
    }
}