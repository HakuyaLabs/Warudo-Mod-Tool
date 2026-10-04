using System;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class StringSplitNode : Node
    {
        public string A = "";
        public string Separator = "";
        public bool RemoveEmptyEntries = true;
        public string[] Result()
        {
            throw new NotImplementedException();
        }
    }
}