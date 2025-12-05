using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public partial class BehaviourPuppet : BehaviourBase
    {
        public void Unpin()
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

        public void UnPin(int muscleIndex, float unpin)
        {
            throw new NotImplementedException();
        }
    }
}