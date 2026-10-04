using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class IfBranchNode : Node
    {
        public bool Condition;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation IfTrue;
        public Continuation IfFalse;
    }
}