using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public enum ControllerButton
    {
        X,
        Y,
        A,
        B,
        LB,
        RB,
        LT,
        RT,
        LSB,
        RSB,
        DPadUp,
        DPadDown,
        DPadLeft,
        DPadRight,
        View,
        Menu,
    }

    public static class ControllerButtonExtensions
    {
        public static ButtonControl GetButtonControl(this ControllerButton button, int controllerIndex)
        {
            throw new NotImplementedException();
        }
    }
}