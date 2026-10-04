using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class StringSliceNode : Node
    {
        public string A;
        public int SliceStartIndex;
        public int Length = 0;
        public string Result()
        {
            throw new NotImplementedException();
        }
    }
}