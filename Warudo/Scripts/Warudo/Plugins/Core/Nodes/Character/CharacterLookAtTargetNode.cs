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
    public class CharacterLookAtTargetNode : Node
    {
        public Quaternion[] BoneRotations;
        public CharacterAsset Character;
        public GameObjectAsset Target;
        public bool Enabled = true;
        public float Weight = 1f;
        public float HeadWeight = 0.66f;
        public float EyesWeight = 0.33f;
        public float MaximumLookAtAngle = 135f;
        public Vector3 MaximalHeadRotation = new Vector3(30f, 30f, 30f);
        public Vector2 MaximalEyeRotation = new Vector2(10f, 5f);
        public float SmoothHeadTime = 3.5f;
        public float SmoothEyesTime = 2f;
        public Quaternion[] OutputBoneRotations()
        {
            throw new NotImplementedException();
        }

        public override void OnEndOfFrame()
        {
            throw new NotImplementedException();
        }
    }
}