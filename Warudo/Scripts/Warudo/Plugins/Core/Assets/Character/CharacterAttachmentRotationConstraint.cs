using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public class CharacterAttachmentRotationConstraint : MonoBehaviour
    {
        public HumanBodyBones bindToBone;
        public float weight = 1f;
        public void Initialize(Animator animator)
        {
            throw new NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}