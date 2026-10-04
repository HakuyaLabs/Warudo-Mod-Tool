using Warudo.Core.Graphs;

namespace Warudo.Core.Events {
    public class GraphEnableEvent : Event {
        public Graph Graph { get; }
        public GraphEnableEvent(Graph graph) {
            Graph = graph;
        }
    }
}
