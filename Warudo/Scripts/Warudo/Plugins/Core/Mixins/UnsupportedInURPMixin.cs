using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Rendering;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Mixins
{
    public class UnsupportedInURPMixin : Mixin
    {
        public string Message = "THIS_NODE_IS_NOT_SUPPORTED_IN_URP".Localized();
        public bool HideMessage() => throw new NotImplementedException();
    }
}