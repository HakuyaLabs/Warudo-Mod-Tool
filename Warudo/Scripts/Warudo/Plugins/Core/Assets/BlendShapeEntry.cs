using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets
{
    public interface IBlendShapeEntry
    {
        bool GetUseVRMBlendShapeProxy();
        bool GetApplyToAllSkinnedMeshes();
        string GetTargetSkinnedMesh();
        string GetBlendShape();
        float GetValue();
    }

    public class BlendShapeEntry : IBlendShapeEntry
    {
        public bool UseVRMBlendShapeProxy;
        public bool ApplyToAllSkinnedMeshes;
        public string TargetSkinnedMesh;
        public string BlendShape;
        public float Value;
        public bool GetUseVRMBlendShapeProxy() => throw new NotImplementedException();
        public bool GetApplyToAllSkinnedMeshes() => throw new NotImplementedException();
        public string GetTargetSkinnedMesh() => throw new NotImplementedException();
        public string GetBlendShape() => throw new NotImplementedException();
        public float GetValue() => throw new NotImplementedException();
    }

    public interface IBlendShapeEntryProvider
    {
        IEnumerable<IBlendShapeEntry> ProvideBlendShapeEntries();
    }

    public abstract class BlendShapeEntryDataBase<TParent> : StructuredData<TParent>, IBlendShapeEntry, ICollapsibleStructuredData where TParent : Entity
    {
        protected abstract Dictionary<string, SkinnedMeshRenderer> ParentSkinnedMeshRenderers { get; }

        protected abstract bool ParentActive { get; }

        protected abstract CharacterAsset ParentCharacter { get; }

        public bool UseVRMBlendShapeProxy = false;
        protected bool HideUseVRMBlendShapeProxy() => throw new NotImplementedException();
        public bool ApplyToAllSkinnedMeshes = true;
        protected bool HideApplyToAllSkinnedMeshes() => throw new NotImplementedException();
        public string TargetSkinnedMesh;
        protected bool HideTargetSkinnedMesh() => throw new NotImplementedException();
        public string BlendShape;
        public float DefaultValue = 1f;
        protected async UniTask<AutoCompleteList> AutoCompleteSkinnedMesh()
        {
            throw new NotImplementedException();
        }

        protected async UniTask<AutoCompleteList> AutoCompleteBlendShapes()
        {
            throw new NotImplementedException();
        }

        public virtual bool GetUseVRMBlendShapeProxy() => throw new NotImplementedException();
        public virtual bool GetApplyToAllSkinnedMeshes() => throw new NotImplementedException();
        public virtual string GetTargetSkinnedMesh() => throw new NotImplementedException();
        public virtual string GetBlendShape() => throw new NotImplementedException();
        public virtual float GetValue() => throw new NotImplementedException();
        public virtual string GetHeader()
        {
            throw new NotImplementedException();
        }
    }
}