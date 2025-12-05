using DG.Tweening;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Prop;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetPropMaterialPropertyNode : Node
    {
        public PropAsset Prop;
        public MaterialPropertyAccessorMixin MaterialPropertyAccessor;
        public float TransitionTime = 0f;
        public Ease TransitionEasing = Ease.OutCubic;
        protected bool HideTransitionDataInputs() => throw new NotImplementedException();
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}