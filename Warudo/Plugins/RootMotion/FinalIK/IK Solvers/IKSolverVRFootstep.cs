using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class IKSolverVR : IKSolver
    {
        public class Footstep
        {
            public float stepSpeed = 3f;
            public Vector3 characterSpaceOffset;
            public Vector3 position;
            public Quaternion rotation = Quaternion.identity;
            public Quaternion stepToRootRot = Quaternion.identity;
            public bool isStepping
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public bool isSupportLeg;
            public bool relaxFlag;
            public float stepProgress { get; private set; }

            public Vector3 stepFrom;
            public Vector3 stepTo;
            public Quaternion stepFromRot = Quaternion.identity;
            public Quaternion stepToRot = Quaternion.identity;
            public Footstep(Quaternion rootRotation, Vector3 footPosition, Quaternion footRotation, Vector3 characterSpaceOffset)
            {
                throw new NotImplementedException();
            }

            public void Reset(Quaternion rootRotation, Vector3 footPosition, Quaternion footRotation)
            {
                throw new NotImplementedException();
            }

            public void StepTo(Vector3 p, Quaternion rootRotation, float stepThreshold)
            {
                throw new NotImplementedException();
            }

            public void UpdateStepping(Vector3 p, Quaternion rootRotation, float speed, float deltaTime)
            {
                throw new NotImplementedException();
            }

            public void UpdateStanding(Quaternion rootRotation, float minAngle, float speed, float deltaTime)
            {
                throw new NotImplementedException();
            }

            public void Update(InterpolationMode interpolation, UnityEvent onStep, float deltaTime)
            {
                throw new NotImplementedException();
            }
        }
    }
}