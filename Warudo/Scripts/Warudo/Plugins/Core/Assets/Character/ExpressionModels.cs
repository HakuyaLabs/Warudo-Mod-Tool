using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Serializations;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.MotionCapture;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public partial class CharacterAsset
    {
        public class VRMBlendShapeClipData
        {
            public string Name;
            public bool IsBinary;
            public List<(string smr, string name, float weight)> BlendShapes;
            public List<(string material, string property, Vector4 value)> MaterialProperties;
        }

        public class ExpressionData : StructuredData<CharacterAsset>, ICollapsibleStructuredData
        {
            public void EnterExpression()
            {
                throw new NotImplementedException();
            }

            protected bool HideEnterExpression() => throw new NotImplementedException();
            public void ExitExpression()
            {
                throw new NotImplementedException();
            }

            protected bool HideExitExpression() => throw new NotImplementedException();
            public string Name = "EXPRESSION".Localized();
            public int Layer = 0;
            public bool DisableEyeBlinkTracking = false;
            public string EyeBlinkTrackingConstraintBlendShape;
            protected async UniTask<AutoCompleteList> AutoCompleteTrackingConstraintBlendShape()
            {
                throw new NotImplementedException();
            }

            public bool DisableMouthTracking = false;
            public string MouthTrackingConstraintBlendShape;
            public bool DisableBrowTracking = false;
            public string BrowTrackingConstraintBlendShape;
            public bool IsBinary = false;
            public BlendShapeEntry[] BlendShapes;
            public MaterialPropertyEntry[] MaterialProperties;
            public async void BatchEditTargets()
            {
                throw new NotImplementedException();
            }

            public class BatchEditTargetsData : StructuredData
            {
                public float EnterDuration = 0.4f;
                public Ease EnterEase = Ease.OutCubic;
                public float EnterDelay = 0f;
                public float ExitDuration = 0.4f;
                public Ease ExitEase = Ease.Linear;
                public float ExitDelay = 0f;
            }

            public ConstrainedBlendShapeEntry[] ConstrainedBlendShapes;
            public ToggleGameObjectEntry[] ToggleGameObjects;
            public TriggerConditionEntry[] TriggerConditions;
            public class BlendShapeEntry : StructuredData<ExpressionData>, ICollapsibleStructuredData
            {
                protected bool DisableFade() => throw new NotImplementedException();
                public string TargetSkinnedMesh;
                public string BlendShape;
                public float TargetValue = 1f;
                public bool IsBinary = false;
                public float EnterDuration = 0.4f;
                public Ease EnterEase = Ease.OutCubic;
                public float EnterDelay = 0f;
                public float ExitDuration = 0.4f;
                public Ease ExitEase = Ease.Linear;
                public float ExitDelay = 0f;
                public string GetHeader() => throw new NotImplementedException();
                protected override void OnCreate()
                {
                    throw new NotImplementedException();
                }
            }

            public class ConstrainedBlendShapeEntry : StructuredData<ExpressionData>, ICollapsibleStructuredData
            {
                public bool ApplyToAllSkinnedMeshes = false;
                public string TargetSkinnedMesh;
                protected bool HideTargetSkinnedMesh() => throw new NotImplementedException();
                public string ConstrainedBlendShape;
                public string ConstraintBlendShape;
                public float MinValue = 0f;
                public float MaxValue = 1f;
                public float ConstraintMaxValue = 1f;
                public float ConstraintMinValue = 0f;
                public string GetHeader()
                {
                    throw new NotImplementedException();
                }
            }

            public class MaterialPropertyEntry : MaterialPropertyEntryBase<ExpressionData>
            {
                protected override bool ParentActive => throw new NotImplementedException();
                protected override Dictionary<string, List<Material>> ParentMaterials => throw new NotImplementedException();
                protected override Dictionary<string, List<ShaderProperty>> ParentMaterialProperties => throw new NotImplementedException();
                protected override CharacterAsset ParentCharacter => throw new NotImplementedException();
                protected override bool DisableFadeDataInputs() => throw new NotImplementedException();
                protected override bool HideVRMBlendShapeProxyDataInputs() => throw new NotImplementedException();
            }

            public class ToggleGameObjectEntry : StructuredData<ExpressionData>, ICollapsibleStructuredData
            {
                public string GameObjectPath;
                public async UniTask<AutoCompleteList> AutoCompleteGameObjectPath()
                {
                    throw new NotImplementedException();
                }

                public bool Enabled = true;
                public string GetHeader() => throw new NotImplementedException();
                protected override void OnCreate()
                {
                    throw new NotImplementedException();
                }
            }

            public class TriggerConditionEntry : StructuredData<ExpressionData>, ICollapsibleStructuredData
            {
                public ConditionEntry[] Conditions;
                public TriggerType TriggerWhenMet = TriggerType.Enter;
                public bool TriggerWhenMetIsTransient;
                public float TriggerWhenMetDelay = 0f;
                public TriggerType TriggerWhenNotMet = TriggerType.Exit;
                public bool TriggerWhenNotMetIsTransient;
                public float TriggerWhenNotMetDelay = 2f;
                public class ConditionEntry : StructuredData<TriggerConditionEntry>, ICollapsibleStructuredData
                {
                    public CharacterAsset Character => throw new NotImplementedException();
                    public string BlendShape;
                    protected async UniTask<AutoCompleteList> AutoCompleteBlendShapes()
                    {
                        throw new NotImplementedException();
                    }

                    public bool ReadBlendShapeFromTracker = false;
                    public string TargetSkinnedMesh = "";
                    public async UniTask<AutoCompleteList> AutoCompleteSkinnedMesh()
                    {
                        throw new NotImplementedException();
                    }

                    public GenericTrackerAsset FaceTrackingAsset;
                    protected bool FilterFaceTrackingAsset(GenericTrackerAsset asset)
                    {
                        throw new NotImplementedException();
                    }

                    public ConditionType Condition;
                    public float Value = 0.5f;
                    public enum ConditionType
                    {
                        GreaterThanOrEqual,
                        LessThanOrEqual
                    }

                    public string GetHeader()
                    {
                        throw new NotImplementedException();
                    }

                    public bool IsValid => throw new NotImplementedException();
                    public bool Evaluate(Dictionary<string, Dictionary<string, float>> blendShapes, Dictionary<string, float> vrmBlendShapeProxyWeights)
                    {
                        throw new NotImplementedException();
                    }
                }

                public string GetHeader()
                {
                    throw new NotImplementedException();
                }

                public bool IsValid => throw new NotImplementedException();
                public enum TriggerType
                {
                    DoNothing,
                    Enter,
                    Exit
                }

                public void EnterExpression(string expressionName, bool transient, float delay)
                {
                    throw new NotImplementedException();
                }

                public void ExitExpression(string expressionName, float delay)
                {
                    throw new NotImplementedException();
                }

                public void ResetNextEnterExpressionTime()
                {
                    throw new NotImplementedException();
                }

                public void ResetNextExitExpressionTime()
                {
                    throw new NotImplementedException();
                }
            }

            public bool IsActive => throw new NotImplementedException();
            public string GetHeader() => throw new NotImplementedException();
        }

        public class ExpressionState
        {
            public ExpressionData expression;
            public float aliveTime;
            public float exitTime = 99999999f;
            public bool isValid = true;
        }

        public class ExpressionLayer
        {
            public int layer;
            public readonly Dictionary<Guid, ExpressionState> states = new();
        }
    }
}