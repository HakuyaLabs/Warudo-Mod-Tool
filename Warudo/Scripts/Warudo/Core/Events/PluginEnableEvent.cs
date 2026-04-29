using Warudo.Core.Plugins;

namespace Warudo.Core.Events {
    public class PluginEnableEvent : Event {
        public Plugin Plugin { get; }
        public PluginEnableEvent(Plugin plugin) {
            Plugin = plugin;
        }
    }
}
