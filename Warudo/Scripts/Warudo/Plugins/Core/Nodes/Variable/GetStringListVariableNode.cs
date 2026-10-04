using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public class GetStringListVariableNode : GetVariableNode<string[]>
    {
        public override GraphVariableType VariableType => throw new NotImplementedException();
        public override string[] Get(GraphVariable variable) => throw new NotImplementedException();
    }
}