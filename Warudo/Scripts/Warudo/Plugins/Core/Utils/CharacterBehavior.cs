using RootMotion.Dynamics;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class CharacterBehavior : BehaviourBase
    {
        protected override string GetTypeSpring() => throw new NotImplementedException();
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

        public void UnPin(int muscleIndex, float unpin)
        {
            throw new NotImplementedException();
        }

        protected override void OnMuscleCollisionBehaviour(MuscleCollision m)
        {
            throw new NotImplementedException();
        }
    }
}