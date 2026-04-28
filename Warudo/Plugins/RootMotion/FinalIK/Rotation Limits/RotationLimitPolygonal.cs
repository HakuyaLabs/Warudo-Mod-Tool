using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class RotationLimitPolygonal : RotationLimit
    {
        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public float twistLimit = 180;
        public int smoothIterations = 0;
        public void SetLimitPoints(LimitPoint[] points)
        {
            throw new NotImplementedException();
        }

        protected override Quaternion LimitRotation(Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public class ReachCone
        {
            public Vector3[] tetrahedron;
            public float volume;
            public Vector3 S, B;
            public Vector3 o
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Vector3 a
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Vector3 b
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Vector3 c
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public ReachCone(Vector3 _o, Vector3 _a, Vector3 _b, Vector3 _c)
            {
                throw new NotImplementedException();
            }

            public bool isValid
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void Calculate()
            {
                throw new NotImplementedException();
            }
        }

        public class LimitPoint
        {
            public Vector3 point;
            public float tangentWeight;
            public LimitPoint()
            {
                throw new NotImplementedException();
            }
        }

        public LimitPoint[] points;
        public Vector3[] P;
        public ReachCone[] reachCones = new ReachCone[0];
        void Start()
        {
            throw new NotImplementedException();
        }

        public void ResetToDefault()
        {
            throw new NotImplementedException();
        }

        public void BuildReachCones()
        {
            throw new NotImplementedException();
        }
    }
}