using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverHeuristic : IKSolver
    {
        public Transform target;
        public float tolerance = 0f;
        public int maxIterations = 4;
        public bool useRotationLimits = true;
        public bool XY;
        public Bone[] bones = new Bone[0];
        public bool SetChain(Transform[] hierarchy, Transform root)
        {
            throw new NotImplementedException();
        }

        public void AddBone(Transform bone)
        {
            throw new NotImplementedException();
        }

        public override void StoreDefaultLocalState()
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

        protected virtual int minBones
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected virtual bool boneLengthCanBeZero
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected virtual bool allowCommonParent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected Vector3 lastLocalDirection;
        protected float chainLength;
        protected void InitiateBones()
        {
            throw new NotImplementedException();
        }

        protected virtual Vector3 localDirection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected float positionOffset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected Vector3 GetSingularityOffset()
        {
            throw new NotImplementedException();
        }
    }
}