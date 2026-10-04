using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class IntegerClampNode : Node
    {
        public int A;
        public int Min = 0;
        public int Max = 10;
        public int Result() => throw new NotImplementedException();
    }
}