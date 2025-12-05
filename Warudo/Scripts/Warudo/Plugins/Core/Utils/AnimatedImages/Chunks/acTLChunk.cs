using System.IO;
using System;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    internal class acTLChunk : Chunk
    {
        internal acTLChunk()
        {
            throw new NotImplementedException();
        }

        public acTLChunk(byte[] bytes) : base(bytes)
        {
            throw new NotImplementedException();
        }

        public acTLChunk(MemoryStream ms) : base(ms)
        {
            throw new NotImplementedException();
        }

        public acTLChunk(Chunk chunk) : base(chunk)
        {
            throw new NotImplementedException();
        }

        public uint FrameCount
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

        public uint PlayCount
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