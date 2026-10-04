using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Cinematography;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class CameraOrbitCharacterNode : Node
    {
        public CameraAsset Camera;
        public float TransitionTime = 3f;
        public Ease TransitionEasing = Ease.OutCubic;
        public float X = -180;
        public float Y = 0.5f;
        public Vector3 Offset;
        public TargetData Target;
        public bool v0_13_1_MigratedTargetData = false;
        public class TargetData : StructuredData, ICollapsibleStructuredData
        {
            public float X = 0.5f;
            public float Y = 180f;
            public Vector3 Offset;
            public string GetHeader() => throw new NotImplementedException();
        }

        public async void AlignTargetWithMainCamera()
        {
            throw new NotImplementedException();
        }

        public void AlignMainCameraWithTarget()
        {
            throw new NotImplementedException();
        }

        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Stop()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
        public class AnimationData
        {
            public CameraAsset Camera;
            public float StartTime;
            public float EndTime;
            public Vector2 StartAngle;
            public Vector3 StartOffset;
            public Vector2 TargetAngle;
            public Vector3 TargetOffset;
        }

        public override void Deserialize(SerializedNode serialized)
        {
            throw new NotImplementedException();
        }
    }
}