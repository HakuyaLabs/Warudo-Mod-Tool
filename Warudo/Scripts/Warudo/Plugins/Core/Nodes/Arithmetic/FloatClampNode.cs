using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class FloatClampNode : Node
    {
        public float A;
        public float Min = 0;
        public float Max = 1;
        public float Result() => throw new NotImplementedException();
    }
}