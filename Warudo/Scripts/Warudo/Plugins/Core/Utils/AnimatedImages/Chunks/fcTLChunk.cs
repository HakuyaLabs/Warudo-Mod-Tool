using System.IO;
using System;
using System;
using Object = UnityEngine.Object;

namespace AnimatedImages
{
    public enum DisposeOps
    {
        APNGDisposeOpNone = 0,
        APNGDisposeOpBackground = 1,
        APNGDisposeOpPrevious = 2,
    }

    public enum BlendOps
    {
        APNGBlendOpSource = 0,
        APNGBlendOpOver = 1,
    }

    internal class fcTLChunk : Chunk
    {
        internal fcTLChunk()
        {
            throw new NotImplementedException();
        }

        public fcTLChunk(byte[] bytes) : base(bytes)
        {
            throw new NotImplementedException();
        }

        public fcTLChunk(MemoryStream ms) : base(ms)
        {
            throw new NotImplementedException();
        }

        public fcTLChunk(Chunk chunk) : base(chunk)
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

        public uint Width
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

        public uint Height
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

        public uint XOffset
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

        public uint YOffset
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

        public ushort DelayNumerator
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

        public ushort DelayDenominator
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

        public DisposeOps DisposeOp
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

        public BlendOps BlendOp
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