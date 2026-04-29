using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vexe.Fast.Reflection;
using Warudo.Core;
using Warudo.Core.Data;
using Warudo.Core.Events;
using Warudo.Core.Plugins;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core
{
    public partial class CorePlugin
    {
        public void RegisterCharacterTrackingTemplate(Plugin owner, Type templateType)
        {
            throw new NotImplementedException();
        }

        public void RegisterCharacterTrackingTemplate<T>(Plugin owner)
        {
            throw new NotImplementedException();
        }

        public void UnregisterCharacterTrackingTemplate(Type templateType)
        {
            throw new NotImplementedException();
        }

        public CharacterTrackingTemplate CreateCharacterTrackingTemplate(Guid id)
        {
            throw new NotImplementedException();
        }

        public AutoCompleteList AutoCompleteCharacterTrackingTemplates(CharacterTrackingTemplateType type)
        {
            throw new NotImplementedException();
        }
    }
}