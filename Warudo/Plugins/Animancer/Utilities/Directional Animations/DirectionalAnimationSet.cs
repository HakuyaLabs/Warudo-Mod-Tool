using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class DirectionalAnimationSet : ScriptableObject, IAnimationClipSource
    {
        public AnimationClip Up
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public AnimationClip Right
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public AnimationClip Down
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public AnimationClip Left
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public void AllowSetClips(bool allow = true)
        {
            throw new NotImplementedException();
        }

        public void AssertCanSetClips()
        {
            throw new NotImplementedException();
        }

        public virtual AnimationClip GetClip(Vector2 direction)
        {
            throw new NotImplementedException();
        }

        public virtual int ClipCount => throw new NotImplementedException();
        public enum Direction
        {
            Up,
            Right,
            Down,
            Left,
        }

        protected virtual string GetDirectionName(int direction) => throw new NotImplementedException();
        public AnimationClip GetClip(Direction direction)
        {
            throw new NotImplementedException();
        }

        public virtual AnimationClip GetClip(int direction) => throw new NotImplementedException();
        public void SetClip(Direction direction, AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        public virtual void SetClip(int direction, AnimationClip clip) => throw new NotImplementedException();
        public static Vector2 DirectionToVector(Direction direction)
        {
            throw new NotImplementedException();
        }

        public virtual Vector2 GetDirection(int direction) => throw new NotImplementedException();
        public static Direction VectorToDirection(Vector2 vector)
        {
            throw new NotImplementedException();
        }

        public static Vector2 SnapVectorToDirection(Vector2 vector)
        {
            throw new NotImplementedException();
        }

        public virtual Vector2 Snap(Vector2 vector) => throw new NotImplementedException();
        public void AddClips(AnimationClip[] clips, int index)
        {
            throw new NotImplementedException();
        }

        public void GetAnimationClips(List<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }

        public void AddDirections(Vector2[] directions, int index)
        {
            throw new NotImplementedException();
        }

        public void AddClipsAndDirections(AnimationClip[] clips, Vector2[] directions, int index)
        {
            throw new NotImplementedException();
        }
    }
}