using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class FBIKChain
    {
        public class ChildConstraint
        {
            public float pushElasticity = 0f;
            public float pullElasticity = 0f;
            public float nominalDistance { get; private set; }

            public bool isRigid { get; private set; }

            public ChildConstraint(Transform bone1, Transform bone2, float pushElasticity = 0f, float pullElasticity = 0f)
            {
                throw new NotImplementedException();
            }

            public void Initiate(IKSolverFullBody solver)
            {
                throw new NotImplementedException();
            }

            public void OnPreSolve(IKSolverFullBody solver)
            {
                throw new NotImplementedException();
            }

            public void Solve(IKSolverFullBody solver)
            {
                throw new NotImplementedException();
            }
        }

        public enum Smoothing
        {
            None,
            Exponential,
            Cubic
        }

        public float pin;
        public float pull = 1f;
        public float push;
        public float pushParent;
        public float reach = 0.1f;
        public Smoothing reachSmoothing = Smoothing.Exponential;
        public Smoothing pushSmoothing = Smoothing.Exponential;
        public IKSolver.Node[] nodes = new IKSolver.Node[0];
        public int[] children = new int[0];
        public ChildConstraint[] childConstraints = new ChildConstraint[0];
        public IKConstraintBend bendConstraint = new IKConstraintBend();
        public FBIKChain()
        {
            throw new NotImplementedException();
        }

        public FBIKChain(float pin, float pull, params Transform[] nodeTransforms)
        {
            throw new NotImplementedException();
        }

        public void SetNodes(params Transform[] boneTransforms)
        {
            throw new NotImplementedException();
        }

        public int GetNodeIndex(Transform boneTransform)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(ref string message)
        {
            throw new NotImplementedException();
        }

        public void Initiate(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public void ReadPose(IKSolverFullBody solver, bool fullBody)
        {
            throw new NotImplementedException();
        }

        public void Reach(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public Vector3 Push(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public void SolveTrigonometric(IKSolverFullBody solver, bool calculateBendDirection = false)
        {
            throw new NotImplementedException();
        }

        public void Stage1(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public void Stage2(IKSolverFullBody solver, Vector3 position)
        {
            throw new NotImplementedException();
        }

        public void SolveConstraintSystems(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        protected Vector3 GetDirToBendPoint(Vector3 direction, Vector3 bendDirection, float directionMagnitude)
        {
            throw new NotImplementedException();
        }

        public void ForwardReach(Vector3 position)
        {
            throw new NotImplementedException();
        }
    }
}