using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralHDRColorNode : Node
    {
        public Color Value;
        public Color Output()
        {
            throw new NotImplementedException();
        }
    }
}