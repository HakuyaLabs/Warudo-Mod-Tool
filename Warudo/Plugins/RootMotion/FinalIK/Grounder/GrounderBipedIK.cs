using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class GrounderBipedIK : Grounder
    {
        protected override void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        protected override void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        public BipedIK ik;
        public float spineBend = 7f;
        public float spineSpeed = 3f;
        public override void ResetPosition()
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            throw new NotImplementedException();
        }

        void OnDisable()
        {
            throw new NotImplementedException();
        }

        void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}