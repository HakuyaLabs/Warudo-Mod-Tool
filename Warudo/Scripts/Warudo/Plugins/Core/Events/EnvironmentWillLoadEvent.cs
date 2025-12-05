using Warudo.Core.Events;
using Warudo.Plugins.Core.Assets.Environment;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class EnvironmentWillLoadEvent : Event
    {
        public EnvironmentAsset Environment { get; }

        public EnvironmentWillLoadEvent(EnvironmentAsset environment)
        {
            throw new NotImplementedException();
        }
    }
}