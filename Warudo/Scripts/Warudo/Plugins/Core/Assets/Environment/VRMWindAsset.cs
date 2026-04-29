using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRM;
using Warudo.Core.Attributes;
using Warudo.Core.Localization;
using Warudo.Core.Scenes;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Environment
{
    public class VRMWindAsset : Asset
    {
        public string Hint = "VRM_WIND_HINT".Localized();
        public bool Enabled = true;
        public float Strength = 2f;
        public float Speed = 1f;
        public Vector3 Direction = new(1f, 0f, 0f);
        public float Turbulence = 0.2f;
        public bool SkipChestBones = true;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public class Entry
        {
            public CharacterAsset Character;
            public Transform VRMRoot;
            public VRMWind Wind;
        }
    }

    public class VRMWind : MonoBehaviour
    {
        class WindItem
        {
            public WindItem(Vector3 orientation, float riseCount, float sitCount, float maxFactor)
            {
                throw new NotImplementedException();
            }

            public Vector3 Orientation { get; }

            public float RiseCount { get; }

            public float SitCount { get; }

            public float MaxFactor { get; }

            public float TotalTime { get; }

            public float TimeCount { get; set; }

            public float CurrentFactor => throw new NotImplementedException();
        }

        public float _windGenerateCount = 0;
        public bool EnableWind
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public Vector3 WindBaseOrientation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float WindOrientationRandomPower { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float StrengthFactor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float TimeFactor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool SkipChest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void LoadVrm(Transform vrmRoot)
        {
            throw new NotImplementedException();
        }

        public void UnloadVrm()
        {
            throw new NotImplementedException();
        }
    }
}