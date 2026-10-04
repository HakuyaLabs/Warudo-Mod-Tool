using UnityEngine.SceneManagement;
using Warudo.Core.Events;
using Warudo.Plugins.Core.Assets.Environment;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class EnvironmentUnloadedEvent : Event
    {
        public EnvironmentAsset Environment { get; }

        public EnvironmentUnloadedEvent(EnvironmentAsset environment)
        {
            throw new NotImplementedException();
        }
    }
}