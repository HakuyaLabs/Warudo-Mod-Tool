using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class FlipFlopNode : Node
    {
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation A;
        public Continuation B;
        public bool IsA()
        {
            throw new NotImplementedException();
        }
    }
}