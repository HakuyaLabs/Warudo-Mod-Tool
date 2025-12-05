using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Utility;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class EnableCharacterIKNode : Node
    {
        public CharacterAsset Character;
        public CharacterIK IK;
        public GameObjectAsset IkTarget;
        public float PositionWeight = 1;
        public float RotationWeight = 1;
        public GameObjectAsset BendGoalTarget;
        public float BendGoalWeight = 1;
        public float TransitionTime = 0.6f;
        public Ease TransitionEasing = Ease.OutCubic;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
    }

    public enum CharacterIK
    {
        Spine,
        LeftHand,
        RightHand,
        LeftFoot,
        RightFoot
    }

    public static class CharacterIkStateController
    {
        public class Token
        {
            public bool Invalidated { get; set; }
        }

        public static Token StartIK(CharacterAsset character, CharacterIK ik)
        {
            throw new NotImplementedException();
        }

        public static void StopIK(CharacterAsset character, CharacterIK ik, Token token)
        {
            throw new NotImplementedException();
        }
    }
}