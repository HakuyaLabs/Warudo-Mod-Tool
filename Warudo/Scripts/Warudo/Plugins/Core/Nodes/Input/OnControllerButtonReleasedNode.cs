using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OnControllerButtonReleasedNode : ControllerButtonNode
    {
        public Continuation Exit;
        protected override void OnButtonReleased()
        {
            throw new NotImplementedException();
        }
    }
}