using System.IO;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    internal class IDATChunk : Chunk
    {
        public IDATChunk(byte[] bytes) : base(bytes)
        {
            throw new NotImplementedException();
        }

        public IDATChunk(MemoryStream ms) : base(ms)
        {
            throw new NotImplementedException();
        }

        public IDATChunk(Chunk chunk) : base(chunk)
        {
            throw new NotImplementedException();
        }
    }
}