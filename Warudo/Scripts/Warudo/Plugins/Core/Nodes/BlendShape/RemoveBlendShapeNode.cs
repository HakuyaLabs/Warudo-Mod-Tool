using System.Collections.Generic;
using Warudo.Core.Attributes;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class RemoveBlendShapeNode : ProcessBlendShapesNode
    {
        public string BlendShape;
        public Dictionary<string, float> OutputBlendShapes()
        {
            throw new NotImplementedException();
        }
    }
}