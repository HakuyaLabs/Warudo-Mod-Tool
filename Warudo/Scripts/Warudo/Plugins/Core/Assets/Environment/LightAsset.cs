using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Environment
{
    public abstract class LightAsset : GameObjectAsset
    {
        public void SetDirectionFromMainCamera()
        {
            throw new NotImplementedException();
        }

        protected abstract bool IsRangeSupported();
        public Color Color = new(0.9960784314f, 0.9921568627f, 0.9803921569f);
        public float Range = 10f;
        protected bool HideRange() => throw new NotImplementedException();
        public float Intensity = 1f;
        public bool AffectCharacters = true;
        public bool AffectProps = true;
        public bool AffectEnvironment = false;
        public bool ShadowEnabled = true;
        public float ShadowIntensity = 1f;
        public bool SoftShadows = true;
        public float ShadowBias = 0.005f;
        public float ShadowNormalBias = 0.4f;
        protected Light Light;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedAsset serialized)
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}