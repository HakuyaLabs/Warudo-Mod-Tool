using UnityEngine;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public class CharacterAnimationJob : ICharacterAnimationJob
    {
        public Vector3[] OriginalBoneWorldPositions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Quaternion[] OriginalBoneWorldRotations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vector3[] FinalBoneWorldPositions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Quaternion[] FinalBoneWorldRotations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vector3[] FinalBonePositions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Quaternion[] FinalBoneRotations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vector3[] OverrideBonePositions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float[] OverrideBonePositionWeights { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vector3 OverrideRootPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float OverrideRootPositionWeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Quaternion[] OverrideBoneRotations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float[] OverrideBoneRotationWeights { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Quaternion[] BoneRotationOffsets { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vector3[] BonePositionOffsets { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Quaternion[] AdditionalBoneRotationOffsets { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CharacterAnimationJob(Animator animator)
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public void OnUpdate(ICharacterAnimationJob previousJob)
        {
            throw new NotImplementedException();
        }
    }
}