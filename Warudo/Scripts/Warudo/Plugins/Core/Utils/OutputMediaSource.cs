using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Utils
{
    public enum OutputMediaType
    {
        None,
        Image,
        Video,
        Spout,
        Ndi
    }

    public sealed class OutputMediaSource
    {
        public OutputMediaSource(Transform parent)
        {
            throw new NotImplementedException();
        }

        public Texture Texture => throw new NotImplementedException();
        public void Set(OutputMediaType newType, string newSource)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}