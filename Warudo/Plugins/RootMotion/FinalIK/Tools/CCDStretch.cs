using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class CCDStretch : MonoBehaviour
    {
        public CCDIK ik;
        public float maxSquash = 0f;
        public float maxStretch = 2f;
    }
}