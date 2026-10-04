using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralBooleanListNode : Node
    {
        public bool[] Value;
        public bool[] Output()
        {
            throw new NotImplementedException();
        }
    }
}