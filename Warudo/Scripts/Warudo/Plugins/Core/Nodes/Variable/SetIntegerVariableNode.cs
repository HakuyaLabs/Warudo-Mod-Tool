using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public class SetIntegerVariableNode : SetVariableNode<int>
    {
        public override GraphVariableType VariableType => throw new NotImplementedException();
        public override void SetAndBroadcast(GraphVariable variable, int value)
        {
            throw new NotImplementedException();
        }
    }
}