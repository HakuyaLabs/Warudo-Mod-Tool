using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    public class Frame
    {
        public static byte[] Signature = {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A};
        internal IHDRChunk IHDRChunk { get; set; }

        internal fcTLChunk fcTLChunk { get; set; }

        internal IENDChunk IENDChunk { get; set; }

        internal List<OtherChunk> OtherChunks
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

        internal List<IDATChunk> IDATChunks
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

        internal void AddOtherChunk(OtherChunk chunk)
        {
            throw new NotImplementedException();
        }

        internal void AddIDATChunk(IDATChunk chunk)
        {
            throw new NotImplementedException();
        }

        public MemoryStream GetStream()
        {
            throw new NotImplementedException();
        }

        public Bitmap ToBitmap()
        {
            throw new NotImplementedException();
        }

        public int FrameRate
        {
            get
            {
                throw new NotImplementedException();
            }

            internal set
            {
                throw new NotImplementedException();
            }
        }
    }
}