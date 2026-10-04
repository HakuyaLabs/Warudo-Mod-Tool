using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public abstract class SubBehaviourBase
    {
        protected BehaviourBase behaviour;
        protected static Vector2 XZ(Vector3 v)
        {
            throw new NotImplementedException();
        }

        protected static Vector3 XYZ(Vector2 v)
        {
            throw new NotImplementedException();
        }

        protected static Vector3 Flatten(Vector3 v)
        {
            throw new NotImplementedException();
        }

        protected static Vector3 SetY(Vector3 v, float y)
        {
            throw new NotImplementedException();
        }
    }
}