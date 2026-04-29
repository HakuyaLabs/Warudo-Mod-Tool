using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GenerateRandomIntegerNode : Node
    {
        public int ValueMin = 1;
        public int ValueMax = 6;
        public int Result()
        {
            throw new NotImplementedException();
        }
    }
}