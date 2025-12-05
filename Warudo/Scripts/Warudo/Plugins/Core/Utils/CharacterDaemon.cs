using System;
using System.Collections.Generic;
using Animancer;
using UnityEngine;
using UnityEngine.Animations;
using UniVRM10;
using Warudo.Core.Data;
using Warudo.Core.Scenes;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Utils
{
    public class CharacterDaemon
    {
        public bool FollowRootRotation { get; set; }

        public bool FollowRootPosition { get; set; }

        public CharacterAsset Character => throw new NotImplementedException();
        public bool ShowGameObject => throw new NotImplementedException();
        public CharacterDaemon(Entity entity, Action onCreate, Func<CharacterAsset> characterGetter, Func<bool> showGameObjectGetter, bool keepCharacterDaemonRenderers)
        {
            throw new NotImplementedException();
        }

        public bool IsCreated() => throw new NotImplementedException();
        public GameObject GameObject { get; private set; }

        public Animator Animator { get; private set; }

        public AnimancerComponent Animancer { get; private set; }

        public Dictionary<HumanBodyBones, Transform> HumanBodyBoneToBodyTransforms { get; }

        public Vector3[] BonePositions { get; }

        public Vector3[] BoneWorldPositions { get; }

        public Quaternion[] BoneRotations { get; }

        public Quaternion[] BoneWorldRotations { get; }

        public Vector3 RootRelativePosition => throw new NotImplementedException();
        public void WatchCharacterProperty()
        {
            throw new NotImplementedException();
        }

        public void ResetCharacterDaemon()
        {
            throw new NotImplementedException();
        }

        public void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public void OnLateUpdate()
        {
            throw new NotImplementedException();
        }
    }
}