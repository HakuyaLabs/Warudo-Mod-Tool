using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public interface ICollisionEventListener
    {
        void OnCollisionEnterEvent(Collision collision, CollisionEventBroadcaster broadcaster);
        void OnCollisionStayEvent(Collision collision, CollisionEventBroadcaster broadcaster);
        void OnCollisionExitEvent(Collision collision, CollisionEventBroadcaster broadcaster);
    }

    public class CollisionEventBroadcaster : MonoBehaviour
    {
        public ICollisionEventListener listener;
        public MuscleLite muscle;
    }
}