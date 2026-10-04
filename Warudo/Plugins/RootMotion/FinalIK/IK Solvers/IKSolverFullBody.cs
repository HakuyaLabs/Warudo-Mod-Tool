using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverFullBody : IKSolver
    {
        public int iterations = 4;
        public FBIKChain[] chain = new FBIKChain[0];
        public IKEffector[] effectors = new IKEffector[0];
        public IKMappingSpine spineMapping = new IKMappingSpine();
        public IKMappingBone[] boneMappings = new IKMappingBone[0];
        public IKMappingLimb[] limbMappings = new IKMappingLimb[0];
        public bool FABRIKPass = true;
        public IKEffector GetEffector(Transform t)
        {
            throw new NotImplementedException();
        }

        public FBIKChain GetChain(Transform transform)
        {
            throw new NotImplementedException();
        }

        public int GetChainIndex(Transform transform)
        {
            throw new NotImplementedException();
        }

        public IKSolver.Node GetNode(int chainIndex, int nodeIndex)
        {
            throw new NotImplementedException();
        }

        public void GetChainAndNodeIndexes(Transform transform, out int chainIndex, out int nodeIndex)
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

        public override bool IsValid(ref string message)
        {
            throw new NotImplementedException();
        }

        public UpdateDelegate OnPreRead;
        public UpdateDelegate OnPreSolve;
        public IterationDelegate OnPreIteration;
        public IterationDelegate OnPostIteration;
        public UpdateDelegate OnPreBend;
        public UpdateDelegate OnPostSolve;
        public UpdateDelegate OnStoreDefaultLocalState;
        public UpdateDelegate OnFixTransforms;
        public override void StoreDefaultLocalState()
        {
            throw new NotImplementedException();
        }

        public override void FixTransforms()
        {
            throw new NotImplementedException();
        }

        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected virtual void ReadPose()
        {
            throw new NotImplementedException();
        }

        protected virtual void Solve()
        {
            throw new NotImplementedException();
        }

        protected virtual void ApplyBendConstraints()
        {
            throw new NotImplementedException();
        }

        protected virtual void WritePose()
        {
            throw new NotImplementedException();
        }
    }
}