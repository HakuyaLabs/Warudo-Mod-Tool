using Cinemachine;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Cinematography;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ShakeCameraNode : Node
    {
        public CameraAsset Camera;
        public ShakeType ShakeType = ShakeType.Shake;
        public float Amplitude = 1f;
        public float SustainTime = 0.2f;
        public float DecayTime = 0.7f;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }

    public enum ShakeType
    {
        Shake,
        Wobble
    }
}