using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class TwistSolver
    {
        public Transform transform;
        public Transform parent;
        public Transform[] children = new Transform[0];
        public float weight = 1f;
        public float parentChildCrossfade = 0.5f;
        public float twistAngleOffset;
        public TwistSolver()
        {
            throw new NotImplementedException();
        }

        public TwistSolver(Transform t)
        {
            throw new NotImplementedException();
        }

        public void Initiate()
        {
            throw new NotImplementedException();
        }

        public void FixTransforms()
        {
            throw new NotImplementedException();
        }

        public void Relax()
        {
            throw new NotImplementedException();
        }
    }
}