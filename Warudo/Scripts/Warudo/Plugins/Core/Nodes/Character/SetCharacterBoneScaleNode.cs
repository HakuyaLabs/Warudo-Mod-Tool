using DG.Tweening;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetCharacterBoneScaleNode : Node
    {
        public CharacterAsset Character;
        public HumanBodyBones Bone;
        public Vector3 Scale = Vector3.one;
        public float TransitionTime = 1.2f;
        public Ease TransitionEasing = Ease.OutCubic;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
    }
}