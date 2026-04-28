using UnityEngine.InputSystem.Controls;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetControllerAxisValueNode : Node
    {
        public ControllerIndex Controller;
        public ControllerAxis Axis;
        protected AxisControl AxisControl => throw new NotImplementedException();
        public float Value()
        {
            throw new NotImplementedException();
        }
    }
}