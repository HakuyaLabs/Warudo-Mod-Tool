using Warudo.Core.Data;
using Warudo.Core.Events;

namespace Warudo.Core.ModUtils
{
    /// <summary>
    /// A non-generic signal wrapper that carries event data from a source entity (broadcast).
    /// Used by PluginRouter for cross-mod communication.
    /// Uses event type name matching to support events with same structure but different types across mods.
    /// </summary>
    public class SignalBase : Event
    {
        public string EntityTypeId;
        public string EventTypeName;
        public object Data;
        public Entity EntityInstance;
    }
}
