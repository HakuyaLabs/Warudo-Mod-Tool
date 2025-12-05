using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class GrounderFBBIK : Grounder
    {
        void OpenTutorial()
        {
            throw new NotImplementedException();
        }

        protected override void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        protected override void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        public class SpineEffector
        {
            public FullBodyBipedEffector effectorType;
            public float horizontalWeight = 1f;
            public float verticalWeight;
            public SpineEffector()
            {
                throw new NotImplementedException();
            }

            public SpineEffector(FullBodyBipedEffector effectorType, float horizontalWeight, float verticalWeight)
            {
                throw new NotImplementedException();
            }
        }

        public FullBodyBipedIK ik;
        public float spineBend = 2f;
        public float spineSpeed = 3f;
        public SpineEffector[] spine = new SpineEffector[0];
        public override void ResetPosition()
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            throw new NotImplementedException();
        }

        void FixedUpdate()
        {
            throw new NotImplementedException();
        }

        void LateUpdate()
        {
            throw new NotImplementedException();
        }

        void OnDrawGizmosSelected()
        {
            throw new NotImplementedException();
        }

        void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}