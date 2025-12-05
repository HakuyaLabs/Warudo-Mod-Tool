#define VERBATIM
using UnityEngine;

#if UNITY_EDITOR
#endif
namespace Warudo.Plugins.Core.Assets.Character
{
    public class CharacterAttachmentSettings : MonoBehaviour
    {
        public HumanBodyBones attachToBone = HumanBodyBones.Head;
        public string overrideHandPose;
    }
}