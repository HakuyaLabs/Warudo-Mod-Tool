using System.Collections.Generic;
using UnityEngine;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SmoothBlendShapeListNode : ProcessBlendShapesNode
    {
        public float SmoothTime = 0.4f;
        public Dictionary<string, float> SmoothedBlendShapes()
        {
            throw new NotImplementedException();
        }
    }
}