using System;
using System.Drawing;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    public interface IAnimatedImage
    {
        Bitmap this[int index] { get; }

        int FrameRate { get; set; }

        int FrameCount { get; }

        int PlayCount { get; set; }

        int GetFrameRate(int index);
        void SetFrameRate(int index, int frameRate);
        DisposeOps GetDisposeOperationFor(int index);
        BlendOps GetBlendOperationFor(int index);
        Bitmap GetDefaultImage();
        Size ViewSize { get; set; }

        Size ActualSize { get; set; }
    }
}