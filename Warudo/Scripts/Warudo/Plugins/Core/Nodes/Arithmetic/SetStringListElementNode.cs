using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetStringListElementNode : Node
    {
        public string[] StringList;
        public int Index;
        public string Value;
        public string[] OutputList()
        {
            throw new NotImplementedException();
        }
    }
}