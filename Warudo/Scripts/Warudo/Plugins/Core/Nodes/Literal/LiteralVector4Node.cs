using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralVector4Node : Node
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public Vector4 Output()
        {
            throw new NotImplementedException();
        }
    }
}