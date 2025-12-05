using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetCharacterBoneRotationNode : Node
    {
        public CharacterAsset Character;
        public HumanBodyBones Bone;
        public BoneRotationType Type = BoneRotationType.LocalRotation;
        public enum BoneRotationType
        {
            WorldRotation,
            LocalRotation
        }

        public Quaternion BoneRotation()
        {
            throw new NotImplementedException();
        }

        public Vector3 BoneRotationEulerAngles()
        {
            throw new NotImplementedException();
        }
    }
}