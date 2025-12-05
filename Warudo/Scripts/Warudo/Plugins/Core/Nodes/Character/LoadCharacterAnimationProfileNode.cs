using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Animancer;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Newtonsoft.Json;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LoadCharacterAnimationProfileNode : Node
    {
        public CharacterAsset Character;
        public string AnimationProfile;
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