using System;
using Animancer;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Animations;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public class CharacterAnimancerJob : AnimancerJob<CharacterAnimancerJob.Job>, ICharacterAnimationJob, IDisposable
    {
        public Vector3[] OriginalBoneWorldPositions
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public Quaternion[] OriginalBoneWorldRotations
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public Vector3[] FinalBoneWorldPositions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Quaternion[] FinalBoneWorldRotations
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Vector3[] FinalBonePositions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Quaternion[] FinalBoneRotations
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Vector3[] OverrideBonePositions
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public float[] OverrideBonePositionWeights
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public Vector3 OverrideRootPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float OverrideRootPositionWeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Quaternion[] OverrideBoneRotations
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public float[] OverrideBoneRotationWeights
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public Quaternion[] BoneRotationOffsets
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public Vector3[] BonePositionOffsets
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public Quaternion[] AdditionalBoneRotationOffsets
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public CharacterAnimancerJob(AnimancerPlayable animancer)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose() => throw new NotImplementedException();
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public void OnUpdate(ICharacterAnimationJob previousJob)
        {
            throw new NotImplementedException();
        }

        public struct Job : IAnimationJob
        {
            public TransformStreamHandle Root;
            public NativeArray<TransformStreamHandle> Bones;
            public NativeArray<Vector3> OriginalBoneWorldPositions;
            public NativeArray<Quaternion> OriginalBoneWorldRotations;
            public NativeArray<Vector3> FinalBoneWorldPositions;
            public NativeArray<Quaternion> FinalBoneWorldRotations;
            public NativeArray<Vector3> FinalBonePositions;
            public NativeArray<Quaternion> FinalBoneRotations;
            public NativeArray<Vector3> OverrideRootPosition;
            public NativeArray<float> OverrideRootPositionWeight;
            public NativeArray<Vector3> OverrideBonePositions;
            public NativeArray<float> OverrideBonePositionWeights;
            public NativeArray<Quaternion> OverrideBoneRotations;
            public NativeArray<float> OverrideBoneRotationWeights;
            public NativeArray<Quaternion> BoneRotationOffsets;
            public NativeArray<Vector3> BonePositionOffsets;
            public NativeArray<Quaternion> AdditionalBoneRotationOffsets;
            public NativeArray<Vector3> TempLocalPositions;
            public NativeArray<Quaternion> TempLocalRotations;
            public void ProcessAnimation(AnimationStream stream)
            {
                throw new NotImplementedException();
            }

            public void ProcessRootMotion(AnimationStream stream)
            {
                throw new NotImplementedException();
            }
        }
    }
}