using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class BipedIKSolvers
    {
        public IKSolverLimb leftFoot = new IKSolverLimb(AvatarIKGoal.LeftFoot);
        public IKSolverLimb rightFoot = new IKSolverLimb(AvatarIKGoal.RightFoot);
        public IKSolverLimb leftHand = new IKSolverLimb(AvatarIKGoal.LeftHand);
        public IKSolverLimb rightHand = new IKSolverLimb(AvatarIKGoal.RightHand);
        public IKSolverFABRIK spine = new IKSolverFABRIK();
        public IKSolverLookAt lookAt = new IKSolverLookAt();
        public IKSolverAim aim = new IKSolverAim();
        public Constraints pelvis = new Constraints();
        public IKSolverLimb[] limbs
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKSolver[] ikSolvers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void AssignReferences(BipedReferences references)
        {
            throw new NotImplementedException();
        }
    }
}