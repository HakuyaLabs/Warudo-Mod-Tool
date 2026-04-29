using DG.Tweening;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Cinematography;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetCameraFieldOfViewNode : Node
    {
        public CameraAsset Camera;
        public float FieldOfView = 35f;
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