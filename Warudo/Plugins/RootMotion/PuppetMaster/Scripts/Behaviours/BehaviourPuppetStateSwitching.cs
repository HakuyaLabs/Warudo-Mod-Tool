using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public partial class BehaviourPuppet : BehaviourBase
    {
        public Vector3 getUpPosition { get; set; }

        public void SetState(State newState)
        {
            throw new NotImplementedException();
        }

        public void SetColliders(bool unpinned)
        {
            throw new NotImplementedException();
        }

        public void SetColliders(Muscle m, bool unpinned)
        {
            throw new NotImplementedException();
        }

        public override void OnMuscleDisconnected(Muscle m)
        {
            throw new NotImplementedException();
        }

        public override void OnMuscleReconnected(Muscle m)
        {
            throw new NotImplementedException();
        }
    }
}