using UnityEngine;
using System;
using Object = UnityEngine.Object;

public interface ICharacterAnimationJob
{
    public Vector3[] OriginalBoneWorldPositions { get; }

    public Quaternion[] OriginalBoneWorldRotations { get; }

    public Vector3[] FinalBoneWorldPositions { get; }

    public Quaternion[] FinalBoneWorldRotations { get; }

    public Vector3[] FinalBonePositions { get; }

    public Quaternion[] FinalBoneRotations { get; }

    public Vector3[] OverrideBonePositions { get; set; }

    public float[] OverrideBonePositionWeights { get; set; }

    public Vector3 OverrideRootPosition { get; set; }

    public float OverrideRootPositionWeight { get; set; }

    public Quaternion[] OverrideBoneRotations { get; set; }

    public float[] OverrideBoneRotationWeights { get; set; }

    public Quaternion[] BoneRotationOffsets { get; set; }

    public Vector3[] BonePositionOffsets { get; set; }

    public Quaternion[] AdditionalBoneRotationOffsets { get; set; }

    public void Destroy();
    public void OnUpdate(ICharacterAnimationJob previousJob);
}