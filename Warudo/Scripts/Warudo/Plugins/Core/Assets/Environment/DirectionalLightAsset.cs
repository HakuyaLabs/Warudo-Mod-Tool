using UnityEngine;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Environment
{
    public class DirectionalLightAsset : LightAsset
    {
        protected override bool IsRangeSupported() => throw new NotImplementedException();
        protected override GameObject CreateGameObject()
        {
            throw new NotImplementedException();
        }
    }
}