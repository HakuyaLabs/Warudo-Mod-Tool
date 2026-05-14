using Warudo.Core.Events;
using Warudo.Core.Scenes;
using Warudo.Core.Serializations;

namespace Warudo.Scripts.Warudo.Core.Events {
    public class SceneSaveEvent : Event {
        public string Name { get; }
        public SerializedScene SerializedScene { get; }
        public bool IsNewScene { get; }
        public SceneSaveEvent(string name, SerializedScene serializedScene, bool isNewScene) {
            Name = name;
            SerializedScene = serializedScene;
            IsNewScene = isNewScene;
        }
    }
}
