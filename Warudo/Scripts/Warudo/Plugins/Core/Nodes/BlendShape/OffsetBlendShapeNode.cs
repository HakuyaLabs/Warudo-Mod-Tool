using System.Collections.Generic;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OffsetBlendShapeNode : ProcessBlendShapesNode
    {
        public string BlendShape;
        public float Offset = 0f;
        public bool Clamp = true;
        public Dictionary<string, float> OutputBlendShapes()
        {
            throw new NotImplementedException();
        }
    }
}