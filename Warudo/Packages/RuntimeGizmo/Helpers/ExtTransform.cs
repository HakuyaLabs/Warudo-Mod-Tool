using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RuntimeGizmos
{
    public static class ExtTransform
    {
        public static void SetScaleFrom(this Transform target, Vector3 worldPivot, Vector3 newScale)
        {
            throw new NotImplementedException();
        }

        public static void SetScaleFromOffset(this Transform target, Vector3 worldPivot, Vector3 newScale)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetCenter(this Transform transform, CenterType centerType)
        {
            throw new NotImplementedException();
        }

        static void GetCenterAll(this Transform transform, ref Bounds currentTotalBounds)
        {
            throw new NotImplementedException();
        }
    }
}