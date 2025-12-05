using Warudo.Core.Events;
using Warudo.Core.Graphs;

namespace Warudo.Plugins.Core.Events {
    public class ClientConnectedEvent : Event {
        public string ClientId { get; }
        public ClientConnectedEvent(string clientId) {
            ClientId = clientId;
        }
    }
}
