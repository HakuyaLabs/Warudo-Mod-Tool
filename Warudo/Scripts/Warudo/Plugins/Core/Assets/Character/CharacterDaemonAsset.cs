using UniGLTF;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Scenes;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public abstract class CharacterDaemonAsset : Asset
    {
        public CharacterAsset Character;
        public bool ShowCharacterDaemon = false;
        protected virtual bool HideCharacterDataInput() => throw new NotImplementedException();
        protected bool HideShowCharacterDaemon() => throw new NotImplementedException();
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

        protected virtual void OnCreateCharacterDaemon()
        {
            throw new NotImplementedException();
        }
    }
}