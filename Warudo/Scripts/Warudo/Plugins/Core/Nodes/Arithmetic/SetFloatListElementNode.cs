using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetFloatListElementNode : Node
    {
        public float[] FloatList;
        public int Index;
        public float Value;
        public float[] OutputList()
        {
            throw new NotImplementedException();
        }
    }
}