using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class BodyTilt : OffsetModifier
    {
        public float tiltSpeed = 6f;
        public float tiltSensitivity = 0.07f;
        public OffsetPose poseLeft, poseRight;
        protected override void Start()
        {
            throw new NotImplementedException();
        }

        protected override void OnModifyOffset()
        {
            throw new NotImplementedException();
        }
    }
}