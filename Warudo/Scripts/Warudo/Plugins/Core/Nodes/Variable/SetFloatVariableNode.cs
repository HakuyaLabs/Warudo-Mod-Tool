using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public class SetFloatVariableNode : SetVariableNode<float>
    {
        public override GraphVariableType VariableType => throw new NotImplementedException();
        public override void SetAndBroadcast(GraphVariable variable, float value)
        {
            throw new NotImplementedException();
        }
    }
}