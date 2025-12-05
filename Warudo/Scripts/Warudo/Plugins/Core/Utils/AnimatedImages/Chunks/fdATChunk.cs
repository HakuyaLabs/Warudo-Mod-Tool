using System;
using System.IO;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    internal class fdATChunk : Chunk
    {
        public fdATChunk(byte[] bytes) : base(bytes)
        {
            throw new NotImplementedException();
        }

        public fdATChunk(MemoryStream ms) : base(ms)
        {
            throw new NotImplementedException();
        }

        public fdATChunk(Chunk chunk) : base(chunk)
        {
            throw new NotImplementedException();
        }

        public uint SequenceNumber
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

        public byte[] FrameData
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

        public IDATChunk ToIDATChunk()
        {
            throw new NotImplementedException();
        }

        public static fdATChunk FromIDATChunk(IDATChunk idatChunk, uint sequenceNumber)
        {
            throw new NotImplementedException();
        }
    }
}