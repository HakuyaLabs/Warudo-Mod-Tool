using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralVector2Node : Node
    {
        public float X;
        public float Y;
        public Vector2 Output()
        {
            throw new NotImplementedException();
        }
    }
}