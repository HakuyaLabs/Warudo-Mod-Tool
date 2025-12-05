using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class StringTrimWhitespacesNode : Node
    {
        public string A;
        public bool TrimStart = true;
        public bool TrimEnd = true;
        public string Result()
        {
            throw new NotImplementedException();
        }
    }
}