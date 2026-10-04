using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    public class APNG : IAnimatedImage
    {
        public void Load(string filename)
        {
            throw new NotImplementedException();
        }

        public void Load(byte[] fileBytes)
        {
            throw new NotImplementedException();
        }

        internal void Load(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public void Save(string filename)
        {
            throw new NotImplementedException();
        }

        public bool IsSimplePNG { get; private set; }

        public bool DefaultImageIsAnimated { get; private set; }

        public Frame DefaultImage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Frame[] Frames
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DisposeOps GetDisposeOperationFor(int index)
        {
            throw new NotImplementedException();
        }

        public BlendOps GetBlendOperationFor(int index)
        {
            throw new NotImplementedException();
        }

        public Bitmap GetDefaultImage()
        {
            throw new NotImplementedException();
        }

        public Bitmap this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int FrameCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int FrameRate
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int GetFrameRate(int index)
        {
            throw new NotImplementedException();
        }

        public void SetFrameRate(int index, int frameRate)
        {
            throw new NotImplementedException();
        }

        public Size ViewSize
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Size ActualSize
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int PlayCount
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        internal IHDRChunk IHDRChunk { get; private set; }

        internal acTLChunk acTLChunk { get; private set; }

        public void SetDefaultImage(Image image)
        {
            throw new NotImplementedException();
        }

        public void AddFrame(Image image)
        {
            throw new NotImplementedException();
        }

        public void RemoveFrame(int index)
        {
            throw new NotImplementedException();
        }

        public void ClearFrames()
        {
            throw new NotImplementedException();
        }

        public static APNG FromFile(string filename)
        {
            throw new NotImplementedException();
        }

        public static APNG FromStream(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public static APNG FromImage(Image image)
        {
            throw new NotImplementedException();
        }
    }
}