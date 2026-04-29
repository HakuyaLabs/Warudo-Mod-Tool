using System;
using DG.Tweening;
using UnityEngine;
using Warudo.Core.Attributes;

namespace Warudo.Core.Data.Models {
    public class PositionRotationData : StructuredData {
        [DataInput]
        [Label("POSITION")]
        public Vector3 Position = Vector3.zero;
        
        [DataInput]
        [Label("ROTATION")]
        public Vector3 Rotation = Vector3.zero;
        
        public Quaternion RotationQuaternion {
            get => Quaternion.Euler(Rotation);
            set => Rotation = value.eulerAngles;
        }

        public void ApplyAsLocalTransform(Transform unityTransform) {
            unityTransform.localPosition = Position;
            unityTransform.localRotation = RotationQuaternion;
        }

        public void ApplyAsWorldTransform(Transform unityTransform, float tweenDuration = 0) {
            if (tweenDuration == 0) {
                unityTransform.position = Position;
                unityTransform.rotation = RotationQuaternion;
            } else {
                unityTransform.DOMove(Position, tweenDuration).SetEase(Ease.OutCubic);
                unityTransform.DORotate(RotationQuaternion.eulerAngles, tweenDuration).SetEase(Ease.OutCubic);
            }
        }

        public void CopyFromLocalTransform(Transform unityTransform) {
            Position = unityTransform.localPosition;
            Rotation = unityTransform.localRotation.eulerAngles;
        }
        
        public void CopyFromWorldTransform(Transform unityTransform) {
            Position = unityTransform.position;
            Rotation = unityTransform.rotation.eulerAngles;
        }

        public void CopyFrom(PositionRotationData data) {
            Position = data.Position;
            Rotation = data.Rotation;
        }

        private bool Equals(PositionRotationData other) {
            return Position.Equals(other.Position) && Rotation.Equals(other.Rotation);
        }
        
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PositionRotationData)obj);
        }
        
        public override int GetHashCode() {
            return HashCode.Combine(Position, Rotation);
        }

        public override string ToString() {
            return $"{nameof(Position)}: {Position}, {nameof(Rotation)}: {Rotation}";
        }
    }
}
