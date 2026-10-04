using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class GrounderQuadruped : Grounder
    {
        protected override void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        protected override void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        public Grounding forelegSolver = new Grounding();
        public float rootRotationWeight = 0.5f;
        public float minRootRotation = -25f;
        public float maxRootRotation = 45f;
        public float rootRotationSpeed = 5f;
        public float maxLegOffset = 0.5f;
        public float maxForeLegOffset = 0.5f;
        public float maintainHeadRotationWeight = 0.5f;
        public Transform characterRoot;
        public Transform pelvis;
        public Transform lastSpineBone;
        public Transform head;
        public IK[] legs;
        public IK[] forelegs;
        public Vector3 gravity = Vector3.down;
        public override void ResetPosition()
        {
            throw new NotImplementedException();
        }

        public struct Foot
        {
            public IKSolver solver;
            public Transform transform;
            public Quaternion rotation;
            public Grounding.Leg leg;
            public Foot(IKSolver solver, Transform transform)
            {
                throw new NotImplementedException();
            }
        }

        void OnDisable()
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            throw new NotImplementedException();
        }

        void LateUpdate()
        {
            throw new NotImplementedException();
        }

        void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}