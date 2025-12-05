using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetBooleanListElementNode : Node
    {
        public bool[] BooleanList;
        public int Index;
        public bool Value;
        public bool[] OutputList()
        {
            throw new NotImplementedException();
        }
    }
}