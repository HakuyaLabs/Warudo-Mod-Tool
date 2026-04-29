using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetBooleanListElementNode : Node
    {
        public bool[] BooleanList;
        public int Index;
        public bool OutputBoolean()
        {
            throw new NotImplementedException();
        }
    }
}