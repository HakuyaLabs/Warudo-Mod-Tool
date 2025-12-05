using Warudo.Core.Attributes;
using Warudo.Core.Events;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Event
{
    public class OnLateUpdateNode : Node
    {
        public override void OnLateUpdate()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}