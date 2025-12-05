using System.Collections.Generic;
using Warudo.Core.Attributes;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Nodes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class BinarizeBlendShapesNode : ProcessBlendShapesNode
    {
        public bool BinarizeAllBlendShapes = true;
        public string[] BinarizedBlendShapes;
        public float Threshold = 0.5f;
        public Dictionary<string, float> OutputBlendShapes()
        {
            throw new NotImplementedException();
        }
    }
}