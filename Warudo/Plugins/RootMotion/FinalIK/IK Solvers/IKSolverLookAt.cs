using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverLookAt : IKSolver
    {
        public Transform target;
        public LookAtBone[] spine = new LookAtBone[0];
        public LookAtBone head = new LookAtBone();
        public LookAtBone[] eyes = new LookAtBone[0];
        public float bodyWeight = 0.5f;
        public float headWeight = 0.5f;
        public float eyesWeight = 1f;
        public float clampWeight = 0.5f;
        public float clampWeightHead = 0.5f;
        public float clampWeightEyes = 0.5f;
        public int clampSmoothing = 2;
        public AnimationCurve spineWeightCurve = new AnimationCurve(new Keyframe[2]{new Keyframe(0f, 0.3f), new Keyframe(1f, 1f)});
        public Vector3 spineTargetOffset;
        public void SetLookAtWeight(float weight)
        {
            throw new NotImplementedException();
        }

        public void SetLookAtWeight(float weight, float bodyWeight)
        {
            throw new NotImplementedException();
        }

        public void SetLookAtWeight(float weight, float bodyWeight, float headWeight)
        {
            throw new NotImplementedException();
        }

        public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight)
        {
            throw new NotImplementedException();
        }

        public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight)
        {
            throw new NotImplementedException();
        }

        public void SetLookAtWeight(float weight, float bodyWeight = 0f, float headWeight = 1f, float eyesWeight = 0.5f, float clampWeight = 0.5f, float clampWeightHead = 0.5f, float clampWeightEyes = 0.3f)
        {
            throw new NotImplementedException();
        }

        public override void StoreDefaultLocalState()
        {
            throw new NotImplementedException();
        }

        public void SetDirty()
        {
            throw new NotImplementedException();
        }

        public override void FixTransforms()
        {
            throw new NotImplementedException();
        }

        public override bool IsValid(ref string message)
        {
            throw new NotImplementedException();
        }

        public override IKSolver.Point[] GetPoints()
        {
            throw new NotImplementedException();
        }

        public override IKSolver.Point GetPoint(Transform transform)
        {
            throw new NotImplementedException();
        }

        public class LookAtBone : IKSolver.Bone
        {
            public Vector3 baseForwardOffsetEuler;
            public LookAtBone()
            {
                throw new NotImplementedException();
            }

            public LookAtBone(Transform transform)
            {
                throw new NotImplementedException();
            }

            public void Initiate(Transform root)
            {
                throw new NotImplementedException();
            }

            public void LookAt(Vector3 direction, float weight)
            {
                throw new NotImplementedException();
            }

            public Vector3 forward
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }

        public bool SetChain(Transform[] spine, Transform head, Transform[] eyes, Transform root)
        {
            throw new NotImplementedException();
        }

        protected Vector3[] spineForwards = new Vector3[0];
        protected Vector3[] headForwards = new Vector3[1];
        protected Vector3[] eyeForward = new Vector3[1];
        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected bool spineIsValid
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected bool spineIsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected void SolveSpine()
        {
            throw new NotImplementedException();
        }

        protected bool headIsValid
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected bool headIsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected void SolveHead()
        {
            throw new NotImplementedException();
        }

        protected bool eyesIsValid
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected bool eyesIsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected void SolveEyes()
        {
            throw new NotImplementedException();
        }

        protected Vector3[] GetForwards(ref Vector3[] forwards, Vector3 baseForward, Vector3 targetForward, int bones, float clamp)
        {
            throw new NotImplementedException();
        }

        protected void SetBones(Transform[] array, ref LookAtBone[] bones)
        {
            throw new NotImplementedException();
        }
    }
}