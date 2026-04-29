using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Cinematography
{
    public class FreeCamera
    {
        public float UserSensitivity = 1f;
        public float Sensitivity => throw new NotImplementedException();
        public Action OnTransformUpdated;
        float inputRotateAxisX, inputRotateAxisY;
        float inputPanAxisX, inputPanAxisY;
        bool leftShift;
        void UpdateInputs(Gamepad gamepad, float sensitivity)
        {
            throw new NotImplementedException();
        }

        public void OnUpdate(Transform transform, Gamepad gamepad, float sensitivity)
        {
            throw new NotImplementedException();
        }
    }
}