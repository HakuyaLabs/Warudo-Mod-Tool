using System;
using System.Reflection;
using UniVRM10;
using UnityEngine;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public enum CharacterRigBackendType
    {
        DirectNormalized = 0,
        Vrm10ControlRig = 1
    }

    public enum CharacterBoneLayer
    {
        Normalized = 0,
        Raw = 1
    }

    public sealed class CharacterRigDescriptor : MonoBehaviour
    {
        public const int CurrentSchemaVersion = 1;
        public int SchemaVersion => throw new NotImplementedException();
        public CharacterRigBackendType Backend => throw new NotImplementedException();
        public Vrm10Instance Vrm10Instance => throw new NotImplementedException();
        public bool UsesVrm10ControlRig => throw new NotImplementedException();
        public void ConfigureVrm10(Vrm10Instance instance)
        {
            throw new NotImplementedException();
        }

        public Vrm10Runtime EnsureVrm10Runtime()
        {
            throw new NotImplementedException();
        }
    }
}