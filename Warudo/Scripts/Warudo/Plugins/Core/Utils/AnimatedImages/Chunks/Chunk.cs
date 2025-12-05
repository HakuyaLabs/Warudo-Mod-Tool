using System;
using System.IO;
using System.Text;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    public class Chunk
    {
        internal Chunk()
        {
            throw new NotImplementedException();
        }

        internal Chunk(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        internal Chunk(MemoryStream ms)
        {
            throw new NotImplementedException();
        }

        internal Chunk(Chunk chunk)
        {
            throw new NotImplementedException();
        }

        public uint Length { get; set; }

        public string ChunkType { get; set; }

        public byte[] ChunkData { get; set; }

        public uint Crc { get; set; }

        public byte[] RawData
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void ModifyChunkData(int postion, byte[] newData)
        {
            throw new NotImplementedException();
        }

        public void ModifyChunkData(int postion, uint newData)
        {
            throw new NotImplementedException();
        }

        protected virtual void ParseData(MemoryStream ms)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}