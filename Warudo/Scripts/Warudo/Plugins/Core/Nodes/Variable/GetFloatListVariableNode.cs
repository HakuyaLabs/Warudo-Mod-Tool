using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public class GetFloatListVariableNode : GetVariableNode<float[]>
    {
        public override GraphVariableType VariableType => throw new NotImplementedException();
        public override float[] Get(GraphVariable variable) => throw new NotImplementedException();
    }
}