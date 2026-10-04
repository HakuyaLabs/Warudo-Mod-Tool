using Warudo.Core.Plugins;

namespace Warudo.Core.Events {
    public class PluginDisableEvent : Event {
        public Plugin Plugin { get; }
        public PluginDisableEvent(Plugin plugin) {
            Plugin = plugin;
        }
    }
}
