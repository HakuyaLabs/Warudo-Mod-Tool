using UnityEngine;
using System.Collections;
using RootMotion;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class Finger
    {
        public enum DOF
        {
            One,
            Three
        }

        public float weight = 1f;
        public float rotationWeight = 1f;
        public DOF rotationDOF;
        public bool fixBone1Twist;
        public Transform bone1;
        public Transform bone2;
        public Transform bone3;
        public Transform tip;
        public Transform target;
        public bool initiated { get; private set; }

        public Vector3 IKPosition
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Quaternion IKRotation
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsValid(ref string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void Initiate(Transform hand, int index)
        {
            throw new NotImplementedException();
        }

        public void FixTransforms()
        {
            throw new NotImplementedException();
        }

        public void StoreDefaultLocalState()
        {
            throw new NotImplementedException();
        }

        public void Update(float masterWeight)
        {
            throw new NotImplementedException();
        }
    }

    public class FingerRig : SolverManager
    {
        public float weight = 1f;
        public Finger[] fingers = new Finger[0];
        public bool initiated { get; private set; }

        public bool IsValid(ref string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void AutoDetect()
        {
            throw new NotImplementedException();
        }

        public void AddFinger(Transform bone1, Transform bone2, Transform bone3, Transform tip, Transform target = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveFinger(int index)
        {
            throw new NotImplementedException();
        }

        protected override void InitiateSolver()
        {
            throw new NotImplementedException();
        }

        public void UpdateFingerSolvers()
        {
            throw new NotImplementedException();
        }

        public void FixFingerTransforms()
        {
            throw new NotImplementedException();
        }

        public void StoreDefaultLocalState()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateSolver()
        {
            throw new NotImplementedException();
        }

        protected override void FixTransforms()
        {
            throw new NotImplementedException();
        }
    }
}