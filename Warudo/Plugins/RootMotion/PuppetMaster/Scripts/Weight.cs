using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class Weight
    {
        public enum Mode
        {
            Float,
            Curve
        }

        public Mode mode;
        public float floatValue;
        public AnimationCurve curve;
        public string tooltip = "";
        public Weight(float floatValue)
        {
            throw new NotImplementedException();
        }

        public Weight(float floatValue, string tooltip)
        {
            throw new NotImplementedException();
        }

        public float GetValue(float param)
        {
            throw new NotImplementedException();
        }
    }
}