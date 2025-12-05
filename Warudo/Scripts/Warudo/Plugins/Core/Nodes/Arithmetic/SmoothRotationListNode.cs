using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SmoothRotationListNode : Node
    {
        public Quaternion[] Rotations;
        public float SmoothTime = 0.4f;
        public Quaternion[] SmoothedRotations()
        {
            throw new NotImplementedException();
        }
    }
}