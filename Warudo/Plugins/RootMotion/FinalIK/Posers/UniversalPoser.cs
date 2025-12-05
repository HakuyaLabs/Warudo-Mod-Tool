using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class UniversalPoser : Poser
    {
        public class Map
        {
            public Transform bone;
            public Transform target;
            public Map(Transform bone, Transform target)
            {
                throw new NotImplementedException();
            }

            public void StoreDefaultState()
            {
                throw new NotImplementedException();
            }

            public void FixTransform()
            {
                throw new NotImplementedException();
            }

            public void Update(float localRotationWeight, float localPositionWeight, Vector3 targetAxis1, Vector3 targetAxis2, Vector3 axis1, Vector3 axis2)
            {
                throw new NotImplementedException();
            }
        }

        public Vector3 targetAxis1, targetAxis2, axis1, axis2;
        public Map[] bones;
        public override void AutoMapping()
        {
            throw new NotImplementedException();
        }

        public override void AutoMapping(Transform[] bones)
        {
            throw new NotImplementedException();
        }

        protected override void InitiatePoser()
        {
            throw new NotImplementedException();
        }

        protected override void UpdatePoser()
        {
            throw new NotImplementedException();
        }

        protected override void FixPoserTransforms()
        {
            throw new NotImplementedException();
        }
    }
}