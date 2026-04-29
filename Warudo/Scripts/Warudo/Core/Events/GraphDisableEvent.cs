using Warudo.Core.Graphs;

namespace Warudo.Core.Events {
    public class GraphDisableEvent : Event {
        public Graph Graph { get; }
        public GraphDisableEvent(Graph graph) {
            Graph = graph;
        }
    }
}
