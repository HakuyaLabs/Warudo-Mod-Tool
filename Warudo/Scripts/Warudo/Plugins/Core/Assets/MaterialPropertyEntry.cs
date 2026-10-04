using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Scenes;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets
{
    public enum MaterialPropertyType
    {
        Color,
        Vector,
        Float,
        Int,
        Texture
    }

    public static class MaterialPropertyTypeExtensions
    {
        public static MaterialPropertyType ToMaterialPropertyType(this ShaderPropertyType type)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMaterialPropertyEntry
    {
        bool GetUseVRMBlendShapeProxy();
        string GetVRMBlendShapeClip();
        string GetMaterial();
        string GetProperty();
        MaterialPropertyType GetPropertyType();
        object GetValue();
    }

    public class MaterialPropertyEntry : IMaterialPropertyEntry
    {
        public bool UseVRMBlendShapeProxy;
        public string VRMBlendShapeClip;
        public string Material;
        public string Property;
        public MaterialPropertyType PropertyType;
        public object Value;
        public bool GetUseVRMBlendShapeProxy() => throw new NotImplementedException();
        public string GetVRMBlendShapeClip() => throw new NotImplementedException();
        public string GetMaterial() => throw new NotImplementedException();
        public string GetProperty() => throw new NotImplementedException();
        public MaterialPropertyType GetPropertyType() => throw new NotImplementedException();
        public object GetValue() => throw new NotImplementedException();
    }

    public interface IMaterialPropertyEntryProvider
    {
        IEnumerable<IMaterialPropertyEntry> ProvideMaterialPropertyEntries();
    }

    public class ShaderProperty
    {
        public string Shader;
        public string Name;
        public string Description;
        public MaterialPropertyType Type;
        public List<string> Attributes;
        public ShaderPropertyFlags Flags;
        public float DefaultFloatValue;
        public Vector4 DefaultVectorValue;
        public Vector2? RangeLimits;
        public TextureDimension TextureDimension;
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public ShaderProperty Clone()
        {
            throw new NotImplementedException();
        }
    }

    public static class ShaderPropertyExtensions
    {
        public static List<ShaderProperty> GetShaderProperties(this Shader shader)
        {
            throw new NotImplementedException();
        }
    }

    public class MaterialPropertyAccessorMixin : Mixin
    {
        public Func<bool> GetParentActive { get; set; }

        public Func<Dictionary<string, List<Material>>> GetMaterials { get; set; }

        public Func<Dictionary<string, List<ShaderProperty>>> GetMaterialProperties { get; set; }

        public Func<bool> GetHideDataInputs { get; set; }

        public Func<bool> GetHideSetterDataInputs { get; set; }

        public string Material;
        protected async UniTask<AutoCompleteList> AutoCompleteMaterial()
        {
            throw new NotImplementedException();
        }

        public string Property;
        public string InvalidPropertyHint = "INVALID_MATERIAL_PROPERTY".Localized();
        protected bool HideInvalidProperty() => throw new NotImplementedException();
        public bool IsSelectedPropertyValid()
        {
            throw new NotImplementedException();
        }

        public MaterialPropertyType PropertyType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected async UniTask<AutoCompleteList> AutoCompleteProperty()
        {
            throw new NotImplementedException();
        }

        public Color TargetColorValue;
        protected bool HideTargetColorValue() => throw new NotImplementedException();
        public Vector4 TargetVectorValue;
        protected bool HideTargetVectorValue() => throw new NotImplementedException();
        public float TargetFloatValue;
        protected bool HideTargetFloatValue() => throw new NotImplementedException();
        public int TargetIntValue;
        protected bool HideTargetIntValue() => throw new NotImplementedException();
        public string OverrideTexture;
        protected bool HideOverrideTexture() => throw new NotImplementedException();
        public void OpenImagesFolder()
        {
            throw new NotImplementedException();
        }

        public override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public object GetValue()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class MaterialPropertyEntryBase<TParent> : StructuredData<TParent>, IMaterialPropertyEntry, ICollapsibleStructuredData where TParent : Entity
    {
        protected abstract bool ParentActive { get; }

        protected abstract Dictionary<string, List<Material>> ParentMaterials { get; }

        protected abstract Dictionary<string, List<ShaderProperty>> ParentMaterialProperties { get; }

        protected abstract CharacterAsset ParentCharacter { get; }

        protected virtual bool HideVRMBlendShapeProxyDataInputs() => throw new NotImplementedException();
        protected virtual bool HideTransitionDataInputs() => throw new NotImplementedException();
        protected virtual bool DisableFadeDataInputs() => throw new NotImplementedException();
        public bool UseVRMBlendShapeProxy = false;
        public string BlendShape;
        protected async UniTask<AutoCompleteList> AutoCompleteBlendShapes()
        {
            throw new NotImplementedException();
        }

        public float TargetValue = 1f;
        public MaterialPropertyAccessorMixin MaterialPropertyAccessor;
        public bool IsBinary = false;
        protected bool HideTransitionDataInputsOrIsBinary() => throw new NotImplementedException();
        public float EnterDuration = 0.4f;
        public Ease EnterEase = Ease.OutCubic;
        public float EnterDelay = 0f;
        public float ExitDuration = 0.4f;
        public Ease ExitEase = Ease.Linear;
        public float ExitDelay = 0f;
        public virtual bool GetUseVRMBlendShapeProxy() => throw new NotImplementedException();
        public virtual string GetVRMBlendShapeClip() => throw new NotImplementedException();
        public virtual string GetMaterial() => throw new NotImplementedException();
        public virtual string GetProperty() => throw new NotImplementedException();
        public virtual MaterialPropertyType GetPropertyType() => throw new NotImplementedException();
        public virtual object GetValue() => throw new NotImplementedException();
        public virtual string GetHeader()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}