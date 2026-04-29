using DG.Tweening;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Cinematography;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetAssetScaleNode : Node
    {
        public GameObjectAsset Asset;
        public Vector3 Scale;
        public float TransitionTime = 0f;
        public Ease TransitionEasing = Ease.OutCubic;
        public void AlignTargetWithAsset()
        {
            throw new NotImplementedException();
        }

        public void AlignAssetWithTarget()
        {
            throw new NotImplementedException();
        }

        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}