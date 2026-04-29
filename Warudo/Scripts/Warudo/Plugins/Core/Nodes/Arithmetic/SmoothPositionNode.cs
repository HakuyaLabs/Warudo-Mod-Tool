using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SmoothPositionNode : Node
    {
        public Vector3 InputPosition;
        public float SmoothTime = 0.4f;
        public Vector3 SmoothedPosition()
        {
            throw new NotImplementedException();
        }
    }
}