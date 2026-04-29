using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public enum FullBodyBipedEffector
    {
        Body,
        LeftShoulder,
        RightShoulder,
        LeftThigh,
        RightThigh,
        LeftHand,
        RightHand,
        LeftFoot,
        RightFoot
    }

    public enum FullBodyBipedChain
    {
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg
    }

    public class IKSolverFullBodyBiped : IKSolverFullBody
    {
        public Transform rootNode;
        public float spineStiffness = 0.5f;
        public float pullBodyVertical = 0.5f;
        public float pullBodyHorizontal = 0f;
        public IKEffector bodyEffector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKEffector leftShoulderEffector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKEffector rightShoulderEffector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKEffector leftThighEffector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKEffector rightThighEffector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKEffector leftHandEffector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKEffector rightHandEffector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKEffector leftFootEffector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKEffector rightFootEffector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public FBIKChain leftArmChain
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public FBIKChain rightArmChain
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public FBIKChain leftLegChain
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public FBIKChain rightLegChain
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKMappingLimb leftArmMapping
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKMappingLimb rightArmMapping
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKMappingLimb leftLegMapping
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKMappingLimb rightLegMapping
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IKMappingBone headMapping
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void SetChainWeights(FullBodyBipedChain c, float pull, float reach = 0f)
        {
            throw new NotImplementedException();
        }

        public void SetEffectorWeights(FullBodyBipedEffector effector, float positionWeight, float rotationWeight)
        {
            throw new NotImplementedException();
        }

        public FBIKChain GetChain(FullBodyBipedChain c)
        {
            throw new NotImplementedException();
        }

        public FBIKChain GetChain(FullBodyBipedEffector effector)
        {
            throw new NotImplementedException();
        }

        public IKEffector GetEffector(FullBodyBipedEffector effector)
        {
            throw new NotImplementedException();
        }

        public IKEffector GetEndEffector(FullBodyBipedChain c)
        {
            throw new NotImplementedException();
        }

        public IKMappingLimb GetLimbMapping(FullBodyBipedChain chain)
        {
            throw new NotImplementedException();
        }

        public IKMappingLimb GetLimbMapping(FullBodyBipedEffector effector)
        {
            throw new NotImplementedException();
        }

        public IKMappingSpine GetSpineMapping()
        {
            throw new NotImplementedException();
        }

        public IKMappingBone GetHeadMapping()
        {
            throw new NotImplementedException();
        }

        public IKConstraintBend GetBendConstraint(FullBodyBipedChain limb)
        {
            throw new NotImplementedException();
        }

        public override bool IsValid(ref string message)
        {
            throw new NotImplementedException();
        }

        public void SetToReferences(BipedReferences references, Transform rootNode = null)
        {
            throw new NotImplementedException();
        }

        public static Transform DetectRootNodeBone(BipedReferences references)
        {
            throw new NotImplementedException();
        }

        public void SetLimbOrientations(BipedLimbOrientations o)
        {
            throw new NotImplementedException();
        }

        public Vector3 pullBodyOffset { get; private set; }

        protected override void ReadPose()
        {
            throw new NotImplementedException();
        }

        protected override void ApplyBendConstraints()
        {
            throw new NotImplementedException();
        }

        protected override void WritePose()
        {
            throw new NotImplementedException();
        }
    }
}