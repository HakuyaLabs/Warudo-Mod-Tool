using System.Collections.Generic;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class PrefixBlendShapeListNode : ProcessBlendShapesNode
    {
        public string Prefix;
        public Dictionary<string, float> OutputBlendShapes()
        {
            throw new NotImplementedException();
        }
    }
}