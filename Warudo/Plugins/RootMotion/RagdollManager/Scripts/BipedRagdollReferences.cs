using UnityEngine;
using System.Collections;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public struct BipedRagdollReferences
    {
        public Transform root;
        public Transform hips;
        public Transform spine;
        public Transform chest;
        public Transform head;
        public Transform leftUpperLeg;
        public Transform leftLowerLeg;
        public Transform leftFoot;
        public Transform rightUpperLeg;
        public Transform rightLowerLeg;
        public Transform rightFoot;
        public Transform leftUpperArm;
        public Transform leftLowerArm;
        public Transform leftHand;
        public Transform rightUpperArm;
        public Transform rightLowerArm;
        public Transform rightHand;
        public bool IsValid(ref string msg)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty(bool considerRoot)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Transform t, bool ignoreRoot = false)
        {
            throw new NotImplementedException();
        }

        public Transform[] GetRagdollTransforms()
        {
            throw new NotImplementedException();
        }

        public static BipedRagdollReferences FromAvatar(Animator animator)
        {
            throw new NotImplementedException();
        }

        public static BipedRagdollReferences FromBipedReferences(BipedReferences biped)
        {
            throw new NotImplementedException();
        }
    }
}