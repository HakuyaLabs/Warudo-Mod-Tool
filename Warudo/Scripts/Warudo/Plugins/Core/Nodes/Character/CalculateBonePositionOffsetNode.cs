using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Character
{
    public class CalculateCharacterBonePositionOffsetNode : Node
    {
        public CharacterAsset Character;
        public HumanBodyBones Bone;
        public Vector3 PositionOffset()
        {
            throw new NotImplementedException();
        }

        public override void OnEndOfFrame()
        {
            throw new NotImplementedException();
        }
    }
}