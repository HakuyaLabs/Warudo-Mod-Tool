using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public enum InterpolationMode
    {
        None,
        InOutCubic,
        InOutQuintic,
        InOutSine,
        InQuintic,
        InQuartic,
        InCubic,
        InQuadratic,
        InElastic,
        InElasticSmall,
        InElasticBig,
        InSine,
        InBack,
        OutQuintic,
        OutQuartic,
        OutCubic,
        OutInCubic,
        OutInQuartic,
        OutElastic,
        OutElasticSmall,
        OutElasticBig,
        OutSine,
        OutBack,
        OutBackCubic,
        OutBackQuartic,
        BackInCubic,
        BackInQuartic,
    }

    ;
    public class Interp
    {
        public static float Float(float t, InterpolationMode mode)
        {
            throw new NotImplementedException();
        }

        public static Vector3 V3(Vector3 v1, Vector3 v2, float t, InterpolationMode mode)
        {
            throw new NotImplementedException();
        }

        public static float LerpValue(float value, float target, float increaseSpeed, float decreaseSpeed)
        {
            throw new NotImplementedException();
        }
    }
}