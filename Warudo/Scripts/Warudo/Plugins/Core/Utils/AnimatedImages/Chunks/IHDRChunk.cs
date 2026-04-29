using System;
using System.IO;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    internal class IHDRChunk : Chunk
    {
        public IHDRChunk(byte[] chunkBytes) : base(chunkBytes)
        {
            throw new NotImplementedException();
        }

        public IHDRChunk(MemoryStream ms) : base(ms)
        {
            throw new NotImplementedException();
        }

        public IHDRChunk(Chunk chunk) : base(chunk)
        {
            throw new NotImplementedException();
        }

        public int Width
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

        public int Height
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

        public byte BitDepth
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

        public byte ColorType
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

        public byte CompressionMethod
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

        public byte FilterMethod
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

        public byte InterlaceMethod
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

        protected override void ParseData(MemoryStream ms)
        {
            throw new NotImplementedException();
        }
    }
}