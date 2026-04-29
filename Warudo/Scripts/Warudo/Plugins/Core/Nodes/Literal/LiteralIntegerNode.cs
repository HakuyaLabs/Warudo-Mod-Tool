using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralIntegerNode : Node
    {
        public int Value;
        public int Output()
        {
            throw new NotImplementedException();
        }
    }
}