using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Resource;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class EnableCharacterOverrideHandPoseNode : Node
    {
        public CharacterAsset Character;
        public Handedness Hand;
        public string Pose = "character-animation://resources/Animations/Handy Poses/Basic";
        public float Weight = 1f;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}