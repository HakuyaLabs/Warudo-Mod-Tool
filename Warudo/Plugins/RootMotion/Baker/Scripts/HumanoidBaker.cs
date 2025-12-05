using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public class HumanoidBaker : Baker
    {
        public bool bakeHandIK = true;
        public float IKKeyReductionError;
        public int muscleFrameRateDiv = 1;
        void Awake()
        {
            throw new NotImplementedException();
        }

        protected override Transform GetCharacterRoot()
        {
            throw new NotImplementedException();
        }

        protected override void OnStartBaking()
        {
            throw new NotImplementedException();
        }

        protected override void OnSetLoopFrame(float time)
        {
            throw new NotImplementedException();
        }

        protected override void OnSetCurves(ref AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        protected override void OnSetKeyframes(float time, bool lastFrame)
        {
            throw new NotImplementedException();
        }
    }
}