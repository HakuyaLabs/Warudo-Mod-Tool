using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralFloatListNode : Node
    {
        public float[] Value;
        public float[] Output()
        {
            throw new NotImplementedException();
        }
    }
}