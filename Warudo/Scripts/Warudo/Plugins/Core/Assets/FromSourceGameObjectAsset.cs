using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Utils;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Assets
{
    public abstract class FromSourceGameObjectAsset : GameObjectAsset
    {
        protected virtual bool UsePreviewGallery => throw new NotImplementedException();
        public string Source;
        public string SourceMeta;
        protected abstract UniTask<AutoCompleteList> GetSources();
        protected override GameObject CreateGameObject()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDestroyGameObject()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnGameObjectCreated()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}