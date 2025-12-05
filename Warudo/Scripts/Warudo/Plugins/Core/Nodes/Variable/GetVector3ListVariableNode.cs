using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public class GetVector3ListVariableNode : GetVariableNode<Vector3[]>
    {
        public override GraphVariableType VariableType => throw new NotImplementedException();
        public override Vector3[] Get(GraphVariable variable) => throw new NotImplementedException();
    }
}