using UnityEngine;
using System.Collections;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class InteractionLookAt
    {
        public LookAtIK ik;
        public float lerpSpeed = 5f;
        public float weightSpeed = 1f;
        public void Look(Transform target, float time)
        {
            throw new NotImplementedException();
        }

        public bool isPaused;
        public void OnFixTransforms()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void SolveSpine()
        {
            throw new NotImplementedException();
        }

        public void SolveHead()
        {
            throw new NotImplementedException();
        }
    }
}