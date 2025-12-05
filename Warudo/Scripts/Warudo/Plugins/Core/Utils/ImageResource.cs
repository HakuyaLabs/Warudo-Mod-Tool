using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using AnimatedImages;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class ImageResource
    {
        public ImageType Type { get; private set; }

        public List<Texture2D> Frames { get; private set; }

        public List<float> FrameDelays { get; private set; }

        public int FrameCount => throw new NotImplementedException();
        public float Duration { get; private set; }

        public Texture2D CurrentTexture
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ImageResource(ImageType type, List<Texture2D> frames, List<float> frameDelays)
        {
            throw new NotImplementedException();
        }

        public ImageResource(ImageType type, Texture2D texture)
        {
            throw new NotImplementedException();
        }

        public Texture2D GetTexture(float startTime, bool loop = true)
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public enum ImageType
    {
        JPG,
        PNG,
        APNG,
        WEBP,
        GIF
    }

    public static class ImageTypeExtensions
    {
        public static bool IsAnimated(this ImageType type) => throw new NotImplementedException();
    }

    public static class APNGExtensions
    {
        struct CombineBitmapsJob : IJobParallelFor
        {
            public NativeArray<Color32> dest;
            public NativeArray<Color32> src;
            public bool composite;
            public void Execute(int index)
            {
                throw new NotImplementedException();
            }
        }

        public static ImageResource ToImageResource(this APNG image)
        {
            throw new NotImplementedException();
        }
    }
}