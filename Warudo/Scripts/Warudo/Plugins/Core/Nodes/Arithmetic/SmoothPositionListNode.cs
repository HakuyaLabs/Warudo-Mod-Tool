using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SmoothPositionListNode : Node
    {
        public Vector3[] Positions;
        public float SmoothTime = 0.4f;
        public Vector3[] SmoothedPositions()
        {
            throw new NotImplementedException();
        }
    }
}