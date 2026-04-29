using System;
using System.Collections.Generic;
using Animancer;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Resource;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class PlayCharacterIdleAnimationNode : Node
    {
        public CharacterAsset Character;
        public string Animation;
        public float TransitionTime = 1.2f;
        public Ease TransitionEasing = Ease.OutCubic;
        public bool RestartIfPlaying = false;
        public bool ResetIfPlaying = true;
        public string ResetToAnimation = CharacterAsset.DefaultIdleAnimationUri;
        public bool ResetRootMotion = true;
        protected bool HideResetToAnimation() => throw new NotImplementedException();
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

        public Continuation Exit;
        public Continuation OnTransitionEnd;
    }

    public class AnimationClipCache
    {
        public AnimationClip Get(string uri)
        {
            throw new NotImplementedException();
        }

        public void Clear() => throw new NotImplementedException();
    }
}