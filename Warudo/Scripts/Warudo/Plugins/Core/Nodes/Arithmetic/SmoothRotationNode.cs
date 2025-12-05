using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data.Models;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SmoothRotationNode : Node
    {
        public Quaternion InputRotation;
        public float SmoothTime = 0.4f;
        public Quaternion SmoothedRotation()
        {
            throw new NotImplementedException();
        }
    }
}