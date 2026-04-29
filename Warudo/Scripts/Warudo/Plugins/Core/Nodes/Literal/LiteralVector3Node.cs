using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralVector3Node : Node
    {
        public float X;
        public float Y;
        public float Z;
        public Vector3 Output()
        {
            throw new NotImplementedException();
        }
    }
}