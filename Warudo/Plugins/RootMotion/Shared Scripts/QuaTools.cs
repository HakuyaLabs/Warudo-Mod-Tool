using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public static class QuaTools
    {
        public static float GetYaw(Quaternion space, Vector3 forward)
        {
            throw new NotImplementedException();
        }

        public static float GetPitch(Quaternion space, Vector3 forward)
        {
            throw new NotImplementedException();
        }

        public static float GetBank(Quaternion space, Vector3 forward, Vector3 up)
        {
            throw new NotImplementedException();
        }

        public static float GetYaw(Quaternion space, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public static float GetPitch(Quaternion space, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public static float GetBank(Quaternion space, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Lerp(Quaternion fromRotation, Quaternion toRotation, float weight)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Slerp(Quaternion fromRotation, Quaternion toRotation, float weight)
        {
            throw new NotImplementedException();
        }

        public static Quaternion LinearBlend(Quaternion q, float weight)
        {
            throw new NotImplementedException();
        }

        public static Quaternion SphericalBlend(Quaternion q, float weight)
        {
            throw new NotImplementedException();
        }

        public static Quaternion FromToAroundAxis(Vector3 fromDirection, Vector3 toDirection, Vector3 axis)
        {
            throw new NotImplementedException();
        }

        public static Quaternion RotationToLocalSpace(Quaternion space, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public static Quaternion FromToRotation(Quaternion from, Quaternion to)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetAxis(Vector3 v)
        {
            throw new NotImplementedException();
        }

        public static Quaternion ClampRotation(Quaternion rotation, float clampWeight, int clampSmoothing)
        {
            throw new NotImplementedException();
        }

        public static float ClampAngle(float angle, float clampWeight, int clampSmoothing)
        {
            throw new NotImplementedException();
        }

        public static Quaternion MatchRotation(Quaternion targetRotation, Vector3 targetAxis1, Vector3 targetAxis2, Vector3 axis1, Vector3 axis2)
        {
            throw new NotImplementedException();
        }

        public static Vector3 ToBiPolar(Vector3 euler)
        {
            throw new NotImplementedException();
        }

        public static float ToBiPolar(float angle)
        {
            throw new NotImplementedException();
        }

        public static Quaternion MirrorYZ(Quaternion r, Quaternion space)
        {
            throw new NotImplementedException();
        }

        public static Quaternion MirrorYZ(Quaternion r)
        {
            throw new NotImplementedException();
        }
    }
}