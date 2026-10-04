using DG.Tweening;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Cinematography;
using Warudo.Plugins.Core.Mixins;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class FocusCameraOnCharacterNode : Node
    {
        public UnsupportedInURPMixin UnsupportedInURP;
        public CameraAsset Camera;
        public CharacterAsset Character;
        public float Aperture = 2.8f;
        public float TransitionTime = 0.4f;
        public Ease TransitionEasing = Ease.OutCubic;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
    }
}