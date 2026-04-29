using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OnControllerButtonPressedNode : ControllerButtonNode
    {
        public Continuation Exit;
        protected override void OnButtonPressed()
        {
            throw new NotImplementedException();
        }
    }
}