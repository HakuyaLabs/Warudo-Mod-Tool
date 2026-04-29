using System;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class StringReplaceNode : Node
    {
        public string A;
        public string SearchText;
        public string ReplacementText;
        public bool IgnoreCase;
        public string Result()
        {
            throw new NotImplementedException();
        }
    }
}