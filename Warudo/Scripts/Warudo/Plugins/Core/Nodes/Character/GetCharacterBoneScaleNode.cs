using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetCharacterBoneScaleNode : Node
    {
        public CharacterAsset Character;
        public HumanBodyBones Bone;
        public Vector3 BoneScale()
        {
            throw new NotImplementedException();
        }
    }
}