using UnityEngine;
using System.Collections;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class BehaviourFall : BehaviourBase
    {
        protected override string GetTypeSpring()
        {
            throw new NotImplementedException();
        }

        void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        public string stateName = "Falling";
        public float transitionDuration = 0.4f;
        public int layer;
        public float fixedTime;
        public LayerMask raycastLayers;
        public string blendParameter = "FallBlend";
        public float writheHeight = 4f;
        public float writheYVelocity = 1f;
        public float blendSpeed = 3f;
        public float blendMappingSpeed = 1f;
        public bool canEnd;
        public float minTime = 1.5f;
        public float maxEndVelocity = 0.5f;
        public PuppetEvent onEnd;
        protected override void OnActivate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDeactivate()
        {
            throw new NotImplementedException();
        }

        public override void OnReactivate()
        {
            throw new NotImplementedException();
        }

        protected override void OnFixedUpdate(float deltaTime)
        {
            throw new NotImplementedException();
        }

        protected override void OnLateUpdate(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public override void Resurrect()
        {
            throw new NotImplementedException();
        }

        public override void OnMuscleReconnected(Muscle m)
        {
            throw new NotImplementedException();
        }
    }
}