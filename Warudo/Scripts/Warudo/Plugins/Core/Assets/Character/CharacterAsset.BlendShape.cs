using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Newtonsoft.Json;
using UMod;
using UnityEngine;
using UniVRM10;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Utils;
using static Warudo.Plugins.Core.Assets.Character.CharacterAsset.ExpressionData.TriggerConditionEntry;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public partial class CharacterAsset
    {
        public IEnumerable<string> ExpressionNames => throw new NotImplementedException();
        public List<ExpressionLayer> ActiveExpressionLayers => throw new NotImplementedException();
        public HashSet<string> ActiveExpressions => throw new NotImplementedException();
        public Dictionary<string, Dictionary<string, float>> LastBlendShapes => throw new NotImplementedException();
        public Dictionary<string, Dictionary<string, object>> LastMaterialProperties => throw new NotImplementedException();
        public Dictionary<string, Dictionary<string, float>> TrackingBlendShapes = new(10);
        public Dictionary<string, Dictionary<string, float>> OverrideBlendShapes = new(10);
        public Dictionary<string, Dictionary<string, object>> TrackingMaterialProperties = new(10);
        public Dictionary<string, Dictionary<string, object>> OverrideMaterialProperties = new(10);
        public List<ExpressionLayer> ExpressionLayers = new();
        public void UpdateBlendShapes()
        {
            throw new NotImplementedException();
        }

        public void AddOverrideBlendShapeEntryProvider(IBlendShapeEntryProvider provider)
        {
            throw new NotImplementedException();
        }

        public void RemoveOverrideBlendShapeEntryProvider(IBlendShapeEntryProvider provider)
        {
            throw new NotImplementedException();
        }

        public void AddOverrideMaterialPropertyEntryProvider(IMaterialPropertyEntryProvider provider)
        {
            throw new NotImplementedException();
        }

        public void RemoveOverrideMaterialPropertyEntryProvider(IMaterialPropertyEntryProvider provider)
        {
            throw new NotImplementedException();
        }

        public bool HasExpression(string expressionName)
        {
            throw new NotImplementedException();
        }

        public void EnterExpression(string expressionName, bool transient)
        {
            throw new NotImplementedException();
        }

        public void ExitExpression(string expressionName)
        {
            throw new NotImplementedException();
        }

        public void ExitAllExpressions(bool fade = true)
        {
            throw new NotImplementedException();
        }

        public bool IsExpressionActive(string expressionName)
        {
            throw new NotImplementedException();
        }

        public async UniTask SaveExpressionProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public static async UniTask<Dictionary<string, string>> LoadSerializedExpressionProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public async UniTask LoadExpressionProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public class SaveExpressionProfileData : StructuredData
        {
            public string ProfileName;
        }

        public class LoadExpressionProfileData : StructuredData
        {
            public string ProfileName;
        }
    }
}