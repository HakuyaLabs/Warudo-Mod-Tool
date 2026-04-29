using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetFloatListElementNode : Node
    {
        public float[] FloatList;
        public int Index;
        public float OutputFloat()
        {
            throw new NotImplementedException();
        }
    }
}