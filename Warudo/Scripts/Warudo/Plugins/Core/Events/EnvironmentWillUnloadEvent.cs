using Warudo.Core.Events;
using Warudo.Plugins.Core.Assets.Environment;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class EnvironmentWillUnloadEvent : Event
    {
        public EnvironmentAsset Environment { get; }

        public EnvironmentWillUnloadEvent(EnvironmentAsset environment)
        {
            throw new NotImplementedException();
        }
    }
}