using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RuntimeGizmos
{
    public struct AxisInfo
    {
        public Vector3 pivot;
        public Vector3 xDirection;
        public Vector3 yDirection;
        public Vector3 zDirection;
        public void Set(Transform target, Vector3 pivot, TransformSpace space)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetXAxisEnd(float size)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetYAxisEnd(float size)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetZAxisEnd(float size)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetAxisEnd(Vector3 direction, float size)
        {
            throw new NotImplementedException();
        }
    }
}