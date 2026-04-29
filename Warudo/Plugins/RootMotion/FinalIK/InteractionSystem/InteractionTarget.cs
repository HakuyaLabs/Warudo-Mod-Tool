using UnityEngine;
using System.Collections;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class InteractionTarget : MonoBehaviour
    {
        public enum RotationMode
        {
            TwoDOF = 0,
            ThreeDOF = 1
        }

        void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial1()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial2()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial3()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial4()
        {
            throw new NotImplementedException();
        }

        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public class Multiplier
        {
            public InteractionObject.WeightCurve.Type curve;
            public float multiplier;
        }

        public FullBodyBipedEffector effectorType;
        public Multiplier[] multipliers;
        public float interactionSpeedMlp = 1f;
        public Transform pivot;
        public RotationMode rotationMode;
        public Vector3 twistAxis = Vector3.up;
        public float twistWeight = 1f;
        public float swingWeight;
        public float threeDOFWeight = 1f;
        public bool rotateOnce = true;
        public bool usePoser = true;
        public Transform[] bones = new Transform[0];
        public float GetValue(InteractionObject.WeightCurve.Type curveType)
        {
            throw new NotImplementedException();
        }

        public void ResetRotation()
        {
            throw new NotImplementedException();
        }

        public void RotateTo(Transform bone)
        {
            throw new NotImplementedException();
        }
    }
}