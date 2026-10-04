using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Character
{
    public abstract class CharacterDaemonNode : Node
    {
        public CharacterAsset Character;
        public bool ShowCharacterDaemon = false;
        protected bool HideCharacterDaemonDataInputs() => throw new NotImplementedException();
        protected CharacterDaemon CharacterDaemon { get; private set; }

        protected virtual bool KeepCharacterDaemonRenderers => throw new NotImplementedException();
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public override void OnLateUpdate()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnCreateCharacterDaemon()
        {
            throw new NotImplementedException();
        }
    }
}