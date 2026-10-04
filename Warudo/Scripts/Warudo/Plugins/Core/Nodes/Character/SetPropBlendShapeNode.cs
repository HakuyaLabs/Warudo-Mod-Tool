using Cysharp.Threading.Tasks;
using DG.Tweening;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Prop;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetPropBlendShapeNode : Node
    {
        public PropAsset Prop;
        public string TargetSkinnedMesh;
        public async UniTask<AutoCompleteList> AutoCompleteSkinnedMesh()
        {
            throw new NotImplementedException();
        }

        public string BlendShape;
        protected async UniTask<AutoCompleteList> AutoCompleteBlendShapes()
        {
            throw new NotImplementedException();
        }

        public float Value = 1f;
        public float TransitionTime = 0f;
        public Ease TransitionEasing = Ease.OutCubic;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
    }
}