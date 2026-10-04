using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GateNode : Node
    {
        public bool Opened = true;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Open()
        {
            throw new NotImplementedException();
        }

        public Continuation Close()
        {
            throw new NotImplementedException();
        }

        public Continuation Toggle()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}