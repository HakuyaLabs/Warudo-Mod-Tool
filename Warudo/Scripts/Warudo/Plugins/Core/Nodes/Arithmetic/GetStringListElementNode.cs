using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetStringListElementNode : Node
    {
        public string[] StringList;
        public int Index;
        public string OutputString()
        {
            throw new NotImplementedException();
        }
    }
}