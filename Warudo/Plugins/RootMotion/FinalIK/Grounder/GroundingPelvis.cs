using UnityEngine;
using System.Collections;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class Grounding
    {
        public class Pelvis
        {
            public Vector3 IKOffset { get; private set; }

            public float heightOffset { get; private set; }

            public void Initiate(Grounding grounding)
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void OnEnable()
            {
                throw new NotImplementedException();
            }

            public void Process(float lowestOffset, float highestOffset, bool isGrounded)
            {
                throw new NotImplementedException();
            }
        }
    }
}