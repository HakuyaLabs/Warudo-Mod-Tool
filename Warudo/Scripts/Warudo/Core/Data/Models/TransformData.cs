using System;
using UnityEngine;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Core.Data.Models
{
    public class TransformData : StructuredData
    {
        public Vector3 Position = Vector3.zero;
        public Vector3 Rotation = Vector3.zero;
        public Vector3 Scale = Vector3.one;
        public bool HideScale { get; set; }

        public Quaternion RotationQuaternion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ApplyAsLocalTransform(Transform unityTransform)
        {
            throw new NotImplementedException();
        }

        public void ApplyAsWorldTransform(Transform unityTransform)
        {
            throw new NotImplementedException();
        }

        public void CopyFromLocalTransform(Transform unityTransform)
        {
            throw new NotImplementedException();
        }

        public void CopyFromWorldTransform(Transform unityTransform)
        {
            throw new NotImplementedException();
        }

        public void CopyFrom(TransformData data)
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

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public string SerializeOptimized()
        {
            throw new NotImplementedException();
        }

        public class MessagePackObject
        {
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public float RotationX;
            public float RotationY;
            public float RotationZ;
            public float ScaleX;
            public float ScaleY;
            public float ScaleZ;
        }
    }
}