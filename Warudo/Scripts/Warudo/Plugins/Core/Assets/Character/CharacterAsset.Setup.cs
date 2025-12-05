using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cysharp.Threading.Tasks;
using UniGLTF.Extensions.VRMC_vrm;
using Unity.Services.Analytics;
using UnityEngine;
using UniVRM10;
using VRM;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Scenes;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Events;
using Warudo.Plugins.Core.Nodes;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public partial class CharacterAsset
    {
        public static bool IsVRM0XBlendShapePresetExpressionCandidate(BlendShapePreset preset)
        {
            throw new NotImplementedException();
        }

        public static bool IsVRM0XUnknownBlendShapeClipNameFaceTrackingBlendShape(string customBlendShapeName)
        {
            throw new NotImplementedException();
        }

        public static bool IsVRM10ExpressionPresetExpressionCandidate(ExpressionPreset preset)
        {
            throw new NotImplementedException();
        }

        public static bool IsVRM10CustomExpressionClipNameFaceTrackingBlendShape(string customBlendShapeName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetEligibleVRMExpressionNames()
        {
            throw new NotImplementedException();
        }

        public class SetupFaceTrackingData : SetupTrackingData
        {
            public string FaceTracking;
            protected override void OnCreate()
            {
                throw new NotImplementedException();
            }
        }

        public class SetupPoseTrackingData : SetupTrackingData
        {
            public string PoseTracking;
            protected override void OnCreate()
            {
                throw new NotImplementedException();
            }
        }

        public abstract class SetupTrackingData : StructuredData
        {
            public CharacterAsset Character { get; set; }

            public CharacterTemplateOptions TemplateOptions { get; private set; }

            public void WatchTemplatePort(string portKey)
            {
                throw new NotImplementedException();
            }

            public void UpdateOptionsPort()
            {
                throw new NotImplementedException();
            }

            public CharacterTrackingTemplate CreateTemplate()
            {
                throw new NotImplementedException();
            }
        }

        public class SelectAssetDependenciesData : StructuredData
        {
            public string Info = "SELECT_ASSET_DEPENDENCIES_INFO".Localized();
            public Asset GetSelectedDependency(Type type)
            {
                throw new NotImplementedException();
            }

            public void SetSelectedDependency(Type type, Asset asset)
            {
                throw new NotImplementedException();
            }

            public Dictionary<Type, Asset> GetSelectedDependencies()
            {
                throw new NotImplementedException();
            }
        }

        public async partial void SetupTracking()
        {
            throw new NotImplementedException();
        }

        public async UniTask SetupTracking(Func<SetupFaceTrackingData, UniTask<SetupFaceTrackingData>> setupFaceTracking, Func<SetupPoseTrackingData, UniTask<SetupPoseTrackingData>> setupPoseTracking, bool silent)
        {
            throw new NotImplementedException();
        }

        public async partial void RemoveTracking()
        {
            throw new NotImplementedException();
        }

        public void RemoveTrackingBase()
        {
            throw new NotImplementedException();
        }

        public class QuickCalibrationData : StructuredData<CharacterAsset>
        {
            public void Evaluate()
            {
                throw new NotImplementedException();
            }

            public bool ShouldHide() => throw new NotImplementedException();
        }

        public class BlueprintNavigationData : StructuredData<CharacterAsset>
        {
            public void ConfigureIdleHeadAnimation()
            {
                throw new NotImplementedException();
            }

            protected bool HideConfigureIdleHeadAnimation() => throw new NotImplementedException();
            public void ConfigureLookAt()
            {
                throw new NotImplementedException();
            }

            protected bool HideConfigureLookAt() => throw new NotImplementedException();
            public void ConfigureLipSync()
            {
                throw new NotImplementedException();
            }

            protected bool HideConfigureLipSync() => throw new NotImplementedException();
            public void ConfigureInputInterfacesAnimation()
            {
                throw new NotImplementedException();
            }

            protected bool HideConfigureInputInterfacesAnimation() => throw new NotImplementedException();
            public void Evaluate()
            {
                throw new NotImplementedException();
            }

            public bool ShouldHide() => throw new NotImplementedException();
        }

        public async UniTask ImportVRMExpressions(bool promptImportNaturalExpression = true)
        {
            throw new NotImplementedException();
        }

        public partial void TriggerGenerateKeyBindingGraph()
        {
            throw new NotImplementedException();
        }

        public async partial void TriggerRemoveKeyBindingGraph()
        {
            throw new NotImplementedException();
        }
    }
}