using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OverrideCharacterBonePositionsNode : Node
    {
        public CharacterAsset Character;
        public Vector3[] BoneLocalPositions;
        public float[] BonePositionWeights;
        public bool Immediate = false;
        public bool SkipNonHipsBones = true;
        public bool SkipEyeBones = true;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}