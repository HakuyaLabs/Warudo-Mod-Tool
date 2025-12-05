using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ControllerButtonNode : Node
    {
        public ControllerIndex Controller;
        public ControllerButton Button;
        protected ButtonControl ButtonControl => throw new NotImplementedException();
        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnButtonPressed()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnButtonReleased()
        {
            throw new NotImplementedException();
        }
    }
}