using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Data.Models;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SmoothTransformNode : Node
    {
        public TransformData InputTransform;
        public float SmoothTime = 0.4f;
        public TransformData SmoothedTransform()
        {
            throw new NotImplementedException();
        }
    }
}