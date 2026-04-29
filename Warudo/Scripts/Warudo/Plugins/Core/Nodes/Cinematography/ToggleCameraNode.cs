using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Cinematography;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ToggleCameraNode : Node
    {
        public CameraAsset Camera;
        public float TransitionTime = 1.2f;
        public Ease TransitionEasing = Ease.Linear;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
    }
}