using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public static class V3Tools
    {
        public static float GetYaw(Vector3 forward)
        {
            throw new NotImplementedException();
        }

        public static float GetPitch(Vector3 forward)
        {
            throw new NotImplementedException();
        }

        public static float GetBank(Vector3 forward, Vector3 up)
        {
            throw new NotImplementedException();
        }

        public static float GetYaw(Vector3 spaceForward, Vector3 spaceUp, Vector3 forward)
        {
            throw new NotImplementedException();
        }

        public static float GetPitch(Vector3 spaceForward, Vector3 spaceUp, Vector3 forward)
        {
            throw new NotImplementedException();
        }

        public static float GetBank(Vector3 spaceForward, Vector3 spaceUp, Vector3 forward, Vector3 up)
        {
            throw new NotImplementedException();
        }

        public static Vector3 Lerp(Vector3 fromVector, Vector3 toVector, float weight)
        {
            throw new NotImplementedException();
        }

        public static Vector3 Slerp(Vector3 fromVector, Vector3 toVector, float weight)
        {
            throw new NotImplementedException();
        }

        public static Vector3 ExtractVertical(Vector3 v, Vector3 verticalAxis, float weight)
        {
            throw new NotImplementedException();
        }

        public static Vector3 ExtractHorizontal(Vector3 v, Vector3 normal, float weight)
        {
            throw new NotImplementedException();
        }

        public static Vector3 Flatten(Vector3 v, Vector3 normal)
        {
            throw new NotImplementedException();
        }

        public static Vector3 ClampDirection(Vector3 direction, Vector3 normalDirection, float clampWeight, int clampSmoothing)
        {
            throw new NotImplementedException();
        }

        public static Vector3 ClampDirection(Vector3 direction, Vector3 normalDirection, float clampWeight, int clampSmoothing, out bool changed)
        {
            throw new NotImplementedException();
        }

        public static Vector3 ClampDirection(Vector3 direction, Vector3 normalDirection, float clampWeight, int clampSmoothing, out float clampValue)
        {
            throw new NotImplementedException();
        }

        public static Vector3 LineToPlane(Vector3 origin, Vector3 direction, Vector3 planeNormal, Vector3 planePoint)
        {
            throw new NotImplementedException();
        }

        public static Vector3 PointToPlane(Vector3 point, Vector3 planePosition, Vector3 planeNormal)
        {
            throw new NotImplementedException();
        }

        public static Vector3 TransformPointUnscaled(Transform t, Vector3 point)
        {
            throw new NotImplementedException();
        }

        public static Vector3 InverseTransformPointUnscaled(Transform t, Vector3 point)
        {
            throw new NotImplementedException();
        }

        public static Vector3 InverseTransformPoint(Vector3 tPos, Quaternion tRot, Vector3 tScale, Vector3 point)
        {
            throw new NotImplementedException();
        }

        public static Vector3 TransformPoint(Vector3 tPos, Quaternion tRot, Vector3 tScale, Vector3 point)
        {
            throw new NotImplementedException();
        }

        public static Vector3 Div(Vector3 v1, Vector3 v2)
        {
            throw new NotImplementedException();
        }
    }
}