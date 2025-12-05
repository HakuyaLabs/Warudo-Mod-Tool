using System.Collections.Generic;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class EmptyBlendShapeListNode : Node
    {
        public Dictionary<string, float> Output()
        {
            throw new NotImplementedException();
        }
    }
}