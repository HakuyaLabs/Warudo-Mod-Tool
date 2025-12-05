using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetCharacterBonePositionNode : Node
    {
        public CharacterAsset Character;
        public HumanBodyBones Bone;
        public BonePositionType Type = BonePositionType.WorldPosition;
        public enum BonePositionType
        {
            WorldPosition,
            LocalPosition
        }

        public Vector3 BoneWorldPosition()
        {
            throw new NotImplementedException();
        }
    }
}