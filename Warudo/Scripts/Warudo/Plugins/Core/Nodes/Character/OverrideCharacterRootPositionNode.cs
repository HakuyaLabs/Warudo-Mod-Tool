using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OverrideCharacterRootPositionNode : Node
    {
        public CharacterAsset Character;
        public Vector3 RootPosition;
        public float RootPositionWeight;
        public bool Immediate = false;
        public bool AllowFloating = false;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}