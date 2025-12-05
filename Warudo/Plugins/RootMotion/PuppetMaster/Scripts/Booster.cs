using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class Booster
    {
        public bool fullBody;
        public ConfigurableJoint[] muscles = new ConfigurableJoint[0];
        public Muscle.Group[] groups = new Muscle.Group[0];
        public float immunity;
        public float impulseMlp;
        public float boostParents;
        public float boostChildren;
        public float delay;
        public void Boost(BehaviourPuppet puppet)
        {
            throw new NotImplementedException();
        }
    }
}