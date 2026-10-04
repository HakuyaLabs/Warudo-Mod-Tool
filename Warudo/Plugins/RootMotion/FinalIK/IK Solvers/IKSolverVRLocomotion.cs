using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class IKSolverVR : IKSolver
    {
        public partial class Locomotion
        {
            public enum Mode
            {
                Procedural = 0,
                Animated = 1,
            }

            public Mode mode;
            public float weight = 1f;
            public void Initiate(Animator animator, Vector3[] positions, Quaternion[] rotations, bool hasToes, float scale)
            {
                throw new NotImplementedException();
            }

            public void Reset(Vector3[] positions, Quaternion[] rotations)
            {
                throw new NotImplementedException();
            }

            public void Relax()
            {
                throw new NotImplementedException();
            }

            public void AddDeltaRotation(Quaternion delta, Vector3 pivot)
            {
                throw new NotImplementedException();
            }

            public void AddDeltaPosition(Vector3 delta)
            {
                throw new NotImplementedException();
            }
        }
    }
}