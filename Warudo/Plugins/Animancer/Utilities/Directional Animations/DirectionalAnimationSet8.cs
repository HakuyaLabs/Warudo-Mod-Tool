using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class DirectionalAnimationSet8 : DirectionalAnimationSet
    {
        public AnimationClip UpRight
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public AnimationClip DownRight
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public AnimationClip DownLeft
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public AnimationClip UpLeft
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public override AnimationClip GetClip(Vector2 direction)
        {
            throw new NotImplementedException();
        }

        public static class Diagonals
        {
            public const float OneOverSqrt2 = 0.70710678118f;
            public static Vector2 UpRight => throw new NotImplementedException();
            public static Vector2 DownRight => throw new NotImplementedException();
            public static Vector2 DownLeft => throw new NotImplementedException();
            public static Vector2 UpLeft => throw new NotImplementedException();
        }

        public override int ClipCount => throw new NotImplementedException();
        public new enum Direction
        {
            Up,
            Right,
            Down,
            Left,
            UpRight,
            DownRight,
            DownLeft,
            UpLeft,
        }

        protected override string GetDirectionName(int direction) => throw new NotImplementedException();
        public AnimationClip GetClip(Direction direction)
        {
            throw new NotImplementedException();
        }

        public override AnimationClip GetClip(int direction) => throw new NotImplementedException();
        public void SetClip(Direction direction, AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        public override void SetClip(int direction, AnimationClip clip) => throw new NotImplementedException();
        public static Vector2 DirectionToVector(Direction direction)
        {
            throw new NotImplementedException();
        }

        public override Vector2 GetDirection(int direction) => throw new NotImplementedException();
        public new static Direction VectorToDirection(Vector2 vector)
        {
            throw new NotImplementedException();
        }

        public new static Vector2 SnapVectorToDirection(Vector2 vector)
        {
            throw new NotImplementedException();
        }

        public override Vector2 Snap(Vector2 vector) => throw new NotImplementedException();
    }
}