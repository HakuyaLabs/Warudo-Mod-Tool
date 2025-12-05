using UnityEngine;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public static class LayerMaskExtensions
    {
        public static bool Contains(LayerMask mask, int layer)
        {
            throw new NotImplementedException();
        }

        public static LayerMask Create(params string[] layerNames)
        {
            throw new NotImplementedException();
        }

        public static LayerMask Create(params int[] layerNumbers)
        {
            throw new NotImplementedException();
        }

        public static LayerMask NamesToMask(params string[] layerNames)
        {
            throw new NotImplementedException();
        }

        public static LayerMask LayerNumbersToMask(params int[] layerNumbers)
        {
            throw new NotImplementedException();
        }

        public static LayerMask Inverse(this LayerMask original)
        {
            throw new NotImplementedException();
        }

        public static LayerMask AddToMask(this LayerMask original, params string[] layerNames)
        {
            throw new NotImplementedException();
        }

        public static LayerMask RemoveFromMask(this LayerMask original, params string[] layerNames)
        {
            throw new NotImplementedException();
        }

        public static string[] MaskToNames(this LayerMask original)
        {
            throw new NotImplementedException();
        }

        public static int[] MaskToNumbers(this LayerMask original)
        {
            throw new NotImplementedException();
        }

        public static string MaskToString(this LayerMask original)
        {
            throw new NotImplementedException();
        }

        public static string MaskToString(this LayerMask original, string delimiter)
        {
            throw new NotImplementedException();
        }
    }
}