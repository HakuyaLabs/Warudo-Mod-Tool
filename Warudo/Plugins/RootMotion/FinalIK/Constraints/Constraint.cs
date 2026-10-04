using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public abstract class Constraint
    {
        public Transform transform;
        public float weight;
        public bool isValid
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public abstract void UpdateConstraint();
    }
}