using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class FABRIKChain
    {
        public FABRIK ik;
        public float pull = 1f;
        public float pin = 1f;
        public int[] children = new int[0];
        public bool IsValid(ref string message)
        {
            throw new NotImplementedException();
        }

        public void Initiate()
        {
            throw new NotImplementedException();
        }

        public void Stage1(FABRIKChain[] chain)
        {
            throw new NotImplementedException();
        }

        public void Stage2(Vector3 rootPosition, FABRIKChain[] chain)
        {
            throw new NotImplementedException();
        }
    }
}