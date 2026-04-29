using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SmoothFloatListNode : Node
    {
        public float[] Floats;
        public float SmoothTime = 0.4f;
        public float[] SmoothedFloats()
        {
            throw new NotImplementedException();
        }
    }
}