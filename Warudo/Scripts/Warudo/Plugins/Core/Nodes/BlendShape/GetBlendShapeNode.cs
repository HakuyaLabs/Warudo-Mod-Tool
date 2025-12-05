using System.Collections.Generic;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetBlendShapeNode : ProcessBlendShapesNode
    {
        public string BlendShape;
        public float OutputValue()
        {
            throw new NotImplementedException();
        }
    }
}