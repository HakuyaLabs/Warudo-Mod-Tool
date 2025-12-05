using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetIntegerListElementNode : Node
    {
        public int[] IntegerList;
        public int Index;
        public int Value;
        public int[] OutputList()
        {
            throw new NotImplementedException();
        }
    }
}