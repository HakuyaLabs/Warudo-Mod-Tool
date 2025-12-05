using System;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Cinematography;
using Warudo.Plugins.Core.Assets.Mixins;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Utility
{
    public class AnchorAsset : GameObjectAsset
    {
        public Attachable Attachable;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedAsset serialized)
        {
            throw new NotImplementedException();
        }

        protected override GameObject CreateGameObject()
        {
            throw new NotImplementedException();
        }

        public void TeleportToActiveCamera()
        {
            throw new NotImplementedException();
        }

        protected CorePlugin CorePlugin => throw new NotImplementedException();
    }
}