using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public abstract class Poser : SolverManager
    {
        public Transform poseRoot;
        public float weight = 1f;
        public float localRotationWeight = 1f;
        public float localPositionWeight;
        public abstract void AutoMapping();
        public virtual void AutoMapping(Transform[] bones)
        {
            throw new NotImplementedException();
        }

        public void UpdateManual()
        {
            throw new NotImplementedException();
        }

        protected abstract void InitiatePoser();
        protected abstract void UpdatePoser();
        protected abstract void FixPoserTransforms();
        protected override void UpdateSolver()
        {
            throw new NotImplementedException();
        }

        protected override void InitiateSolver()
        {
            throw new NotImplementedException();
        }

        protected override void FixTransforms()
        {
            throw new NotImplementedException();
        }
    }
}