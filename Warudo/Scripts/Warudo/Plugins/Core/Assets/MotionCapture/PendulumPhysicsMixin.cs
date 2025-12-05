using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Nodes;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.MotionCapture
{
    public class PendulumPhysicsMixin : BehavioralMixin
    {
        public bool IsSupported()
        {
            throw new NotImplementedException();
        }

        public override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public override void OnFixedUpdate()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public override void OnPostLateUpdate()
        {
            throw new NotImplementedException();
        }

        public const string PendulumPhysicsProfileDirectory = "PendulumPhysicsProfiles";
        protected bool HidePendulumPhysics()
        {
            throw new NotImplementedException();
        }

        protected async void SavePendulumPhysicsProfile()
        {
            throw new NotImplementedException();
        }

        protected async void LoadPendulumPhysicsProfile()
        {
            throw new NotImplementedException();
        }

        public void OpenPendulumPhysicsProfilesFolder()
        {
            throw new NotImplementedException();
        }

        public async UniTask SavePendulumPhysicsProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public static async UniTask<Dictionary<string, string>> LoadSerializedPendulumPhysicsProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, string> LoadSerializedPendulumPhysicsProfileSync(string profileName)
        {
            throw new NotImplementedException();
        }

        public async UniTask LoadPendulumPhysicsProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public class SavePendulumPhysicsData : StructuredData
        {
            public string ProfileName;
        }

        public class LoadPendulumPhysicsData : StructuredData
        {
            public PendulumPhysicsMixin Mixin { get; set; }

            public string ProfileName;
            public ImportType HowImport;
            public string[] EntriesToImport;
            protected bool HideEntriesToImport()
            {
                throw new NotImplementedException();
            }

            public enum ImportType
            {
                Override,
                Append
            }

            protected override void OnCreate()
            {
                throw new NotImplementedException();
            }
        }

        public bool PendulumPhysicsEnabled = true;
        public float PendulumPhysicsIntensity = 0.5f;
        public PendulumPhysicsData[] PendulumPhysics;
        protected void InitializePendulumPhysicsData(PendulumPhysicsData data)
        {
            throw new NotImplementedException();
        }

        public void ImportDefaultPendulumPhysics()
        {
            throw new NotImplementedException();
        }

        public class PendulumPhysicsData : StructuredData<GenericTrackerAsset>, ICollapsibleStructuredData
        {
            public string Name = "";
            public bool Enabled = true;
            public float Weight = 1f;
            public InputData[] Inputs;
            public class InputData : StructuredData<PendulumPhysicsData>, ICollapsibleStructuredData
            {
                public float Weight = 1f;
                public PhysicsInputType InputType;
                public string UnsupportedTracker = "UNSUPPORTED_TRACKER_INPUT_TYPE".Localized();
                protected bool HideUnsupportedTracker()
                {
                    throw new NotImplementedException();
                }

                public string BlendShape;
                protected async UniTask<AutoCompleteList> AutoCompleteBlendShape()
                {
                    throw new NotImplementedException();
                }

                public bool UseAbsoluteValue = false;
                public float Multiplier = 5f;
                public float Offset = 0f;
                public bool ClampOverride = false;
                public Vector2 Clamp = new(-1f, 1f);
                protected override async void OnCreate()
                {
                    throw new NotImplementedException();
                }

                public float LastInputValue { get; set; }

                public float LastOutputValue { get; set; }

                public string GetHeader()
                {
                    throw new NotImplementedException();
                }
            }

            public float InputSmoothingDuration = 0.1f;
            public ArmData[] Arms;
            public bool ArmsDirty { get; set; }

            protected override void OnCreate()
            {
                throw new NotImplementedException();
            }

            public class ArmData : StructuredData, ICollapsibleStructuredData
            {
                public float ArmLength = 10f;
                public float ArmMass = 0.25f;
                public float ArmDrag = 0.25f;
                public float ArmSpring = 0.5f;
                public float ArmDamping = 0.5f;
                public float ArmGravity = 1f;
                public string GetHeader() => throw new NotImplementedException();
            }

            public AffectedBoneData[] AffectedBones;
            public class AffectedBoneData : StructuredData<PendulumPhysicsData>, ICollapsibleStructuredData
            {
                public HumanBodyBones[] Bones;
                public string[] ChildTransforms;
                public async UniTask<AutoCompleteList> AutoCompleteChildTransforms()
                {
                    throw new NotImplementedException();
                }

                public PhysicsOutputType OutputType = PhysicsOutputType.Rotation;
                public bool ResetChildTransforms = false;
                public Axes Axes = Axes.Z;
                public float Intensity1D = 5f;
                public Vector2 Intensity2D = new(5f, 5f);
                public Vector3 Intensity3D = new(5f, 5f, 5f);
                public float Offset1D = 0f;
                public Vector2 Offset2D = Vector2.zero;
                public Vector3 Offset3D = Vector3.zero;
                public string GetHeader()
                {
                    throw new NotImplementedException();
                }
            }

            public AffectedBlendShapeData[] AffectedBlendShapes;
            protected bool HideAffectedBlendShapes() => throw new NotImplementedException();
            public class AffectedBlendShapeData : BlendShapeEntryDataBase<PendulumPhysicsData>
            {
                protected override Dictionary<string, SkinnedMeshRenderer> ParentSkinnedMeshRenderers => throw new NotImplementedException();
                protected override bool ParentActive => throw new NotImplementedException();
                protected override CharacterAsset ParentCharacter => throw new NotImplementedException();
                public float Offset = 0f;
                public override string GetHeader()
                {
                    throw new NotImplementedException();
                }
            }

            public string GetHeader()
            {
                throw new NotImplementedException();
            }
        }
    }

    public enum BodyRotationType
    {
        None,
        Normal,
        Inverted,
        Custom
    }

    public enum Axes
    {
        X,
        Y,
        Z,
        XY,
        XZ,
        YZ,
        XYZ
    }

    public enum PhysicsInputType
    {
        HeadPositionX,
        HeadPositionY,
        HeadPositionZ,
        HeadRotationX,
        HeadRotationY,
        HeadRotationZ,
        BlendShape
    }

    public enum PhysicsOutputType
    {
        Position,
        Rotation,
        Scale
    }
}