using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public abstract class RotationLimit : MonoBehaviour
    {
        public Vector3 axis = Vector3.forward;
        public void SetDefaultLocalRotation()
        {
            throw new NotImplementedException();
        }

        public void SetDefaultLocalRotation(Quaternion localRotation)
        {
            throw new NotImplementedException();
        }

        public Quaternion GetLimitedLocalRotation(Quaternion localRotation, out bool changed)
        {
            throw new NotImplementedException();
        }

        public bool Apply()
        {
            throw new NotImplementedException();
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }

        public Vector3 secondaryAxis
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Vector3 crossAxis
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Quaternion defaultLocalRotation;
        public bool defaultLocalRotationOverride { get; private set; }

        protected abstract Quaternion LimitRotation(Quaternion rotation);
        void Awake()
        {
            throw new NotImplementedException();
        }

        void LateUpdate()
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }

        protected static Quaternion Limit1DOF(Quaternion rotation, Vector3 axis)
        {
            throw new NotImplementedException();
        }

        protected static Quaternion LimitTwist(Quaternion rotation, Vector3 axis, Vector3 orthoAxis, float twistLimit)
        {
            throw new NotImplementedException();
        }

        protected static float GetOrthogonalAngle(Vector3 v1, Vector3 v2, Vector3 normal)
        {
            throw new NotImplementedException();
        }
    }
}