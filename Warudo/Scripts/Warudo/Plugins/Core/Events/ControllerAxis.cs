using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public enum ControllerAxis
    {
        LeftStickX,
        LeftStickY,
        RightStickX,
        RightStickY,
        LeftTrigger,
        RightTrigger,
    }

    public static class ControllerAxisExtensions
    {
        public static AxisControl GetAxisControl(this ControllerAxis axis, int controllerIndex)
        {
            throw new NotImplementedException();
        }
    }
}