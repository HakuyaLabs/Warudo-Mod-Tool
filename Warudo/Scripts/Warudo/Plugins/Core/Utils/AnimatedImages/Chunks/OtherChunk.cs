using System.IO;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    internal class OtherChunk : Chunk
    {
        public OtherChunk(byte[] bytes) : base(bytes)
        {
            throw new NotImplementedException();
        }

        public OtherChunk(MemoryStream ms) : base(ms)
        {
            throw new NotImplementedException();
        }

        public OtherChunk(Chunk chunk) : base(chunk)
        {
            throw new NotImplementedException();
        }

        protected override void ParseData(MemoryStream ms)
        {
            throw new NotImplementedException();
        }
    }
}