using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class GenericPoser : Poser
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

            public void Update(float localRotationWeight, float localPositionWeight)
            {
                throw new NotImplementedException();
            }
        }

        public Map[] maps;
        public override void AutoMapping()
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