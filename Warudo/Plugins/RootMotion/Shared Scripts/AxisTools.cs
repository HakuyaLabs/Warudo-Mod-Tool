using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public enum Axis
    {
        X,
        Y,
        Z
    }

    public class AxisTools
    {
        public static Vector3 ToVector3(Axis axis)
        {
            throw new NotImplementedException();
        }

        public static Axis ToAxis(Vector3 v)
        {
            throw new NotImplementedException();
        }

        public static Axis GetAxisToPoint(Transform t, Vector3 worldPosition)
        {
            throw new NotImplementedException();
        }

        public static Axis GetAxisToDirection(Transform t, Vector3 direction)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetAxisVectorToPoint(Transform t, Vector3 worldPosition)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetAxisVectorToDirection(Transform t, Vector3 direction)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetAxisVectorToDirection(Quaternion r, Vector3 direction)
        {
            throw new NotImplementedException();
        }
    }
}