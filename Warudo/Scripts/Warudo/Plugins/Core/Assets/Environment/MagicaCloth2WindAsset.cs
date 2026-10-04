using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Localization;
using Warudo.Core.Scenes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Environment
{
    public class MagicaCloth2WindAsset : Asset
    {
        public string Hint = "MAGICA_CLOTH_2_WIND_HINT".Localized();
        public bool Enabled = true;
        public float Strength = 5f;
        public Vector2 Direction = new(1f, 0f);
        public float Turbulence = 1f;
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
    }
}