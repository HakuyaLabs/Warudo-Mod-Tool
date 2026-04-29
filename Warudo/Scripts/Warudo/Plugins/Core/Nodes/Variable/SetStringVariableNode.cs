using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public class SetStringVariableNode : SetVariableNode<string>
    {
        public override GraphVariableType VariableType => throw new NotImplementedException();
        public override void SetAndBroadcast(GraphVariable variable, string value)
        {
            throw new NotImplementedException();
        }
    }
}