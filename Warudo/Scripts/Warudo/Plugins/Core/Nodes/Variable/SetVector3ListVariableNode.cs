using System;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public class SetVector3ListVariableNode : SetVariableNode<Vector3[]>
    {
        public override GraphVariableType VariableType => throw new NotImplementedException();
        public override void SetAndBroadcast(GraphVariable variable, Vector3[] value)
        {
            throw new NotImplementedException();
        }
    }
}