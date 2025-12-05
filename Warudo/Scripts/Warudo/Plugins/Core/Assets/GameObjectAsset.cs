using System;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data.Models;
using Warudo.Core.Scenes;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Assets
{
    public abstract class GameObjectAsset : Asset
    {
        public bool Enabled = true;
        public TransformData Transform;
        protected virtual bool HideTransform() => throw new NotImplementedException();
        public GameObject GameObject { get; protected set; }

        public Vector3 EndOfFrameWorldPosition { get; private set; }

        public Vector3 EndOfFrameWorldRotation { get; private set; }

        public Vector3 EndOfFrameWorldScale { get; private set; }

        protected abstract GameObject CreateGameObject();
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public virtual void EnableTransformGizmo()
        {
            throw new NotImplementedException();
        }

        public virtual void DisableTransformGizmo()
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

        public override void OnLateUpdate()
        {
            throw new NotImplementedException();
        }

        public override void OnEndOfFrame()
        {
            throw new NotImplementedException();
        }

        public void BroadcastTransformOptimized()
        {
            throw new NotImplementedException();
        }
    }

    public static class GameObjectAssetExtensions
    {
        public static bool IsNullOrInactiveOrDisabled(this GameObjectAsset asset)
        {
            throw new NotImplementedException();
        }

        public static bool IsNonNullAndActiveAndEnabled(this GameObjectAsset asset)
        {
            throw new NotImplementedException();
        }
    }
}