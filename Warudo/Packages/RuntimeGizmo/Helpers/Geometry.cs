using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RuntimeGizmos
{
    public static class Geometry
    {
        public static float LinePlaneDistance(Vector3 linePoint, Vector3 lineVec, Vector3 planePoint, Vector3 planeNormal)
        {
            throw new NotImplementedException();
        }

        public static Vector3 LinePlaneIntersect(Vector3 linePoint, Vector3 lineVec, Vector3 planePoint, Vector3 planeNormal)
        {
            throw new NotImplementedException();
        }

        public static IntersectPoints ClosestPointsOnTwoLines(Vector3 point1, Vector3 point1Direction, Vector3 point2, Vector3 point2Direction)
        {
            throw new NotImplementedException();
        }

        public static IntersectPoints ClosestPointsOnSegmentToLine(Vector3 segment0, Vector3 segment1, Vector3 linePoint, Vector3 lineDirection)
        {
            throw new NotImplementedException();
        }

        public static Vector3 ClampToSegment(Vector3 point, Vector3 linePoint1, Vector3 linePoint2)
        {
            throw new NotImplementedException();
        }
    }
}