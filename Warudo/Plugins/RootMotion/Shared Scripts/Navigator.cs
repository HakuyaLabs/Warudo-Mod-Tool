using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Demos
{
    public class Navigator
    {
        public enum State
        {
            Idle,
            Seeking,
            OnPath,
        }

        public bool activeTargetSeeking;
        public float cornerRadius = 0.5f;
        public float recalculateOnPathDistance = 1f;
        public float maxSampleDistance = 5f;
        public float nextPathInterval = 3f;
        public Vector3 normalizedDeltaPosition { get; private set; }

        public State state { get; private set; }

        public void Initiate(Transform transform)
        {
            throw new NotImplementedException();
        }

        public void Update(Vector3 targetPosition)
        {
            throw new NotImplementedException();
        }

        public void Visualize()
        {
            throw new NotImplementedException();
        }
    }
}