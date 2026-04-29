using System.IO;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    internal class IENDChunk : Chunk
    {
        public IENDChunk(byte[] bytes) : base(bytes)
        {
            throw new NotImplementedException();
        }

        public IENDChunk(MemoryStream ms) : base(ms)
        {
            throw new NotImplementedException();
        }

        public IENDChunk(Chunk chunk) : base(chunk)
        {
            throw new NotImplementedException();
        }
    }
}