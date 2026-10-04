using UnityEngine.SceneManagement;
using Warudo.Core.Events;
using Warudo.Plugins.Core.Assets.Environment;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class EnvironmentLoadedEvent : Event
    {
        public EnvironmentAsset Environment { get; }

        public Scene LoadedScene { get; }

        public EnvironmentLoadedEvent(EnvironmentAsset environment, Scene loadedScene)
        {
            throw new NotImplementedException();
        }
    }
}