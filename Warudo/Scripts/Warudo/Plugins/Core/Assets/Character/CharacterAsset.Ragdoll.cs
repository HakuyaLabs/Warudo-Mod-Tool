using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using RootMotion.Dynamics;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Plugins.Core.Events;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public partial class CharacterAsset
    {
        public class RagdollMuscleData : StructuredData<CharacterAsset>, ICollapsibleStructuredData
        {
            public Collider Collider { get; set; }

            public HumanBodyBones Bone;
            public bool ColliderEnabled = true;
            public RagdollColliderType ColliderType = RagdollColliderType.Capsule;
            public Vector3 ColliderCenter;
            public Vector3 ColliderSize;
            public float ColliderRadius;
            public float ColliderHeight;
            public RagdollColliderDirection ColliderDirection;
            public enum RagdollColliderType
            {
                Box,
                Capsule,
                Sphere
            }

            public enum RagdollColliderDirection
            {
                X,
                Y,
                Z
            }

            public string GetHeader() => throw new NotImplementedException();
            public void CopyFrom(RagdollMuscleData other)
            {
                throw new NotImplementedException();
            }
        }
    }
}