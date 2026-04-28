using System;
using System.Collections.Generic;
using System.Linq;
using Warudo.Core;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Scenes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public abstract class CharacterTrackingTemplate
    {
        public abstract Guid Id { get; }

        public abstract CharacterTrackingTemplateType Type { get; }

        public abstract string Name { get; }

        public abstract string AutoCompleteName { get; }

        public virtual Type OptionsType => throw new NotImplementedException();
        public abstract (List<Asset> trackingAssets, List<Graph> trackingGraphs) Apply(CharacterAsset character);
        public virtual List<Type> AssetDependencyTypes => throw new NotImplementedException();
        public Dictionary<Type, Asset> AssetDependencies { get; set; }

        protected T GetAssetDependency<T>(Scene scene)
            where T : Asset
        {
            throw new NotImplementedException();
        }

        protected object Options;
        internal void SetOptions(object options)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class CharacterTemplateOptions : StructuredData
    {
        public CharacterAsset Character { get; set; }
    }

    public enum CharacterTrackingTemplateType
    {
        Pose,
        Face
    }
}