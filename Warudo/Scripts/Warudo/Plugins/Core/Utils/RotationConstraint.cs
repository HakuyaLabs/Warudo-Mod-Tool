using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class RotationConstraint : MonoBehaviour, ITransformConstraint
    {
        public Transform source;
        public float weight;
        public Vector3 rollAxis = Vector3.right;
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}