using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class FABRIKBendGoal : MonoBehaviour
    {
        public FABRIK ik;
        public float weight = 1f;
        void OnPreIteration(int it)
        {
            throw new NotImplementedException();
        }
    }
}