using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralBooleanNode : Node
    {
        public bool Value;
        public bool Output()
        {
            throw new NotImplementedException();
        }
    }
}