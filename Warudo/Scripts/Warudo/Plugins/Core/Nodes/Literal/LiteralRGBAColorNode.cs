using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralRGBAColorNode : Node
    {
        public float R;
        public float G;
        public float B;
        public float A;
        public Color Output()
        {
            throw new NotImplementedException();
        }
    }
}