using UnityEngine;

using Warudo.Core.Attributes;
using Warudo.Plugins.Core.Assets.Environment;

namespace Warudo.Plugins.Core.Assets {
    [AssetType(Id = "ab31f6f8-8140-4612-8986-0ada4499eee2", Title = "VOLUMETRIC_LIGHT", Category = "CATEGORY_ENVIRONMENTS", CategoryOrder = -498)]
    public class VolumetricLightAsset : LightAsset {
        
        [DataInput(order: 19)]
        [Label("SIDE_SOFTNESS")]
        [FloatSlider(0.0001f, 10f, 0.01f)]
        public float SideSoftness = 1f;
        
        [DataInput(order: 20)]
        [Label("SOURCE_RADIUS")]
        [FloatSlider(0f, 1f)]
        public float SourceRadius = 0.1f;
        
        [DataInput(order: 21)]
        [Label("ANGLE")]
        [FloatSlider(1f, 180f)]
        public float Angle = 40f;

        [Section("NOISE")]
        
        [DataInput(order: 1000)]
        [Label("ENABLED")]
        public bool NoiseEnabled = true;

        [DataInput(order: 1001)]
        [Label("INTENSITY")]
        [FloatSlider(0f, 1f)]
        public float NoiseIntensity = 0.5f;
        
        [Section("JITTERING")]
        
        [DataInput(order: 1002)]
        [Label("ENABLED")]
        public bool JitteringEnabled = false;

        [DataInput(order: 1003)]
        [Label("INTENSITY")]
        [FloatSlider(0f, 10f)]
        public float JitteringIntensity = 5f;
        
        protected override bool IsRangeSupported() => true;

        protected override GameObject CreateGameObject() {
            var gameObject = new GameObject("Volumetric Light");
            Light = gameObject.AddComponent<Light>();
            Light.type = LightType.Spot;

            Transform.Position = new Vector3(0, 2, 0);
            Transform.Rotation = new Vector3(90, 0, 0);
            return gameObject;
        }

        public void ResetVLB() {
            if (GameObject == null) {
                return;
            }

        }
    }
}
