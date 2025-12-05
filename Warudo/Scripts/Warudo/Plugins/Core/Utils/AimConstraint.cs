using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class AimConstraint : MonoBehaviour, ITransformConstraint
    {
        public Transform source;
        public float weight;
        public Vector3 aimAxis = Vector3.right;
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public void OnDrawGizmosSelected()
        {
            throw new NotImplementedException();
        }
    }
}