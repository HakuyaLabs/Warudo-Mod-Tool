using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public class BipedReferences
    {
        public Transform root;
        public Transform pelvis;
        public Transform leftThigh;
        public Transform leftCalf;
        public Transform leftFoot;
        public Transform rightThigh;
        public Transform rightCalf;
        public Transform rightFoot;
        public Transform leftUpperArm;
        public Transform leftForearm;
        public Transform leftHand;
        public Transform rightUpperArm;
        public Transform rightForearm;
        public Transform rightHand;
        public Transform head;
        public Transform[] spine = new Transform[0];
        public Transform[] eyes = new Transform[0];
        public virtual bool isFilled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool isEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool IsEmpty(bool includeRoot)
        {
            throw new NotImplementedException();
        }

        public virtual bool Contains(Transform t, bool ignoreRoot = false)
        {
            throw new NotImplementedException();
        }

        public struct AutoDetectParams
        {
            public bool legsParentInSpine;
            public bool includeEyes;
            public AutoDetectParams(bool legsParentInSpine, bool includeEyes)
            {
                throw new NotImplementedException();
            }

            public static AutoDetectParams Default
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }

        public static bool AutoDetectReferences(ref BipedReferences references, Transform root, AutoDetectParams autoDetectParams)
        {
            throw new NotImplementedException();
        }

        public static void DetectReferencesByNaming(ref BipedReferences references, Transform root, AutoDetectParams autoDetectParams)
        {
            throw new NotImplementedException();
        }

        public static void AssignHumanoidReferences(ref BipedReferences references, Animator animator, AutoDetectParams autoDetectParams)
        {
            throw new NotImplementedException();
        }

        public static bool SetupError(BipedReferences references, ref string errorMessage)
        {
            throw new NotImplementedException();
        }

        public static bool SetupWarning(BipedReferences references, ref string warningMessage)
        {
            throw new NotImplementedException();
        }
    }
}