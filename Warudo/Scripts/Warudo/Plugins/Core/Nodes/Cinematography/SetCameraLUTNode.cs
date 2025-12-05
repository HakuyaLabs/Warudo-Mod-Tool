using Cysharp.Threading.Tasks;
using DG.Tweening;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Resource;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Cinematography;
using Warudo.Plugins.Core.Mixins;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetCameraLUTNode : Node
    {
        public UnsupportedInURPMixin UnsupportedInURP;
        public CameraAsset Camera;
        public string LUTTexture;
        public float LUTIntensity = 1f;
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