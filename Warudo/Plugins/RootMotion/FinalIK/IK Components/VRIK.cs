using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class VRIK : IK
    {
        public class References
        {
            public Transform root;
            public Transform pelvis;
            public Transform spine;
            public Transform chest;
            public Transform neck;
            public Transform head;
            public Transform leftShoulder;
            public Transform leftUpperArm;
            public Transform leftForearm;
            public Transform leftHand;
            public Transform rightShoulder;
            public Transform rightUpperArm;
            public Transform rightForearm;
            public Transform rightHand;
            public Transform leftThigh;
            public Transform leftCalf;
            public Transform leftFoot;
            public Transform leftToes;
            public Transform rightThigh;
            public Transform rightCalf;
            public Transform rightFoot;
            public Transform rightToes;
            public References()
            {
                throw new NotImplementedException();
            }

            public References(BipedReferences b)
            {
                throw new NotImplementedException();
            }

            public Transform[] GetTransforms()
            {
                throw new NotImplementedException();
            }

            public bool isFilled
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

            public static bool AutoDetectReferences(Transform root, out References references)
            {
                throw new NotImplementedException();
            }
        }

        protected override void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        protected override void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        void OpenSetupTutorial()
        {
            throw new NotImplementedException();
        }

        public References references = new References();
        public IKSolverVR solver = new IKSolverVR();
        public void AutoDetectReferences()
        {
            throw new NotImplementedException();
        }

        public void GuessHandOrientations()
        {
            throw new NotImplementedException();
        }

        public override IKSolver GetIKSolver()
        {
            throw new NotImplementedException();
        }

        protected override void InitiateSolver()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateSolver()
        {
            throw new NotImplementedException();
        }
    }
}