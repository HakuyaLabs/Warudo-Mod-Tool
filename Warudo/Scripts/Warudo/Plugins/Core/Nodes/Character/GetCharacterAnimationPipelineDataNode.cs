using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetCharacterAnimationPipelineDataNode : Node
    {
        public CharacterAsset Character;
        public Vector3[] OriginalBonePositions()
        {
            throw new NotImplementedException();
        }

        public Quaternion[] OriginalBoneRotations()
        {
            throw new NotImplementedException();
        }

        public Vector3 OverrideRootPosition()
        {
            throw new NotImplementedException();
        }

        public float OverrideRootPositionWeight()
        {
            throw new NotImplementedException();
        }

        public Vector3[] OverrideBonePositions()
        {
            throw new NotImplementedException();
        }

        public float[] OverrideBonePositionWeights()
        {
            throw new NotImplementedException();
        }

        public Quaternion[] OverrideBoneRotations()
        {
            throw new NotImplementedException();
        }

        public float[] OverrideBoneRotationWeights()
        {
            throw new NotImplementedException();
        }

        public Vector3[] BonePositionOffsets()
        {
            throw new NotImplementedException();
        }

        public Quaternion[] BoneRotationOffsets()
        {
            throw new NotImplementedException();
        }
    }
}