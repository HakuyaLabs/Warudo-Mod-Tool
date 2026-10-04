using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public class GetBooleanVariableNode : GetVariableNode<bool>
    {
        public override GraphVariableType VariableType => throw new NotImplementedException();
        public override bool Get(GraphVariable variable) => throw new NotImplementedException();
    }
}