using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class GrounderIK : Grounder
    {
        protected override void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        protected override void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        public IK[] legs;
        public Transform pelvis;
        public Transform characterRoot;
        public float rootRotationWeight;
        public float rootRotationSpeed = 5f;
        public float maxRootRotationAngle = 45f;
        public override void ResetPosition()
        {
            throw new NotImplementedException();
        }

        void OnDisable()
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            throw new NotImplementedException();
        }

        void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}