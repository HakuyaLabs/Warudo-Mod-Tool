using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class BehaviourTemplate : BehaviourBase
    {
        protected override string GetTypeSpring()
        {
            throw new NotImplementedException();
        }

        public SubBehaviourCOM centerOfMass;
        public LayerMask groundLayers;
        public PuppetEvent onLoseBalance;
        public float loseBalanceAngle = 60f;
        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected override void OnActivate()
        {
            throw new NotImplementedException();
        }

        public override void OnReactivate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDeactivate()
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

        protected override void OnMuscleHitBehaviour(MuscleHit hit)
        {
            throw new NotImplementedException();
        }

        protected override void OnMuscleCollisionBehaviour(MuscleCollision m)
        {
            throw new NotImplementedException();
        }
    }
}