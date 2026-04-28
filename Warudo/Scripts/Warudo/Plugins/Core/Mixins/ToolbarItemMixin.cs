using System;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Plugins;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Mixins
{
    public class ToolbarItemMixin : BehavioralMixin
    {
        public Action OnTrigger { get; set; }

        public void SetEnabled(bool enabled)
        {
            throw new NotImplementedException();
        }

        public void SetTooltip(string tooltip)
        {
            throw new NotImplementedException();
        }

        public void SetIcon(string icon)
        {
            throw new NotImplementedException();
        }

        public override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}