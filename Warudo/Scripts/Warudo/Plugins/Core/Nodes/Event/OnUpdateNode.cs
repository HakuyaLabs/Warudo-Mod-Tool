using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Event
{
    public class OnUpdateNode : Node
    {
        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}