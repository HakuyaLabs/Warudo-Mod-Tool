using UnityEngine;
using System.Collections;
using System;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class IKSolverVR : IKSolver
    {
        public Animator animator { get; private set; }

        public void SetToReferences(VRIK.References references)
        {
            throw new NotImplementedException();
        }

        public void GuessHandOrientations(VRIK.References references, bool onlyIfZero)
        {
            throw new NotImplementedException();
        }

        public void DefaultAnimationCurves()
        {
            throw new NotImplementedException();
        }

        public void AddPositionOffset(PositionOffset positionOffset, Vector3 value)
        {
            throw new NotImplementedException();
        }

        public void AddRotationOffset(RotationOffset rotationOffset, Vector3 value)
        {
            throw new NotImplementedException();
        }

        public void AddRotationOffset(RotationOffset rotationOffset, Quaternion value)
        {
            throw new NotImplementedException();
        }

        public void AddPlatformMotion(Vector3 deltaPosition, Quaternion deltaRotation, Vector3 platformPivot)
        {
            throw new NotImplementedException();
        }

        public void Reset()
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

        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public int LOD = 0;
        public float scale = 1f;
        public bool plantFeet = true;
        public VirtualBone rootBone { get; private set; }

        public Spine spine = new Spine();
        public Arm leftArm = new Arm();
        public Arm rightArm = new Arm();
        public Leg leftLeg = new Leg();
        public Leg rightLeg = new Leg();
        public Locomotion locomotion = new Locomotion();
    }
}