using System;
using System.Collections.Generic;

namespace Warudo.Core.Utils {
    public class DirectedGraph {
        private readonly Dictionary<Guid, List<Guid>> next = new();
        private readonly Dictionary<Guid, List<Guid>> prev = new();

        internal DirectedGraph(IEnumerable<Guid> guids) {
            foreach (var guid in guids) {
                next[guid] = new List<Guid>();
                prev[guid] = new List<Guid>();
            }
        }

        public void AddDirectedEdge(Guid v, Guid w) {
            next[v].Add(w);
            prev[w].Add(v);
        }

        public bool WillCreateCycle(Guid v, Guid w) {
            var stack = new Stack<Guid>();
            stack.Push(v);
            while (stack.Count > 0) {
                var node = stack.Pop();
                if (node == w) {
                    return true;
                }
                foreach (var parent in prev[node]) {
                    stack.Push(parent);
                }
            }
            return false;
        }

        public List<Guid> GetDependencies(Guid v) {
            return prev[v];
        }
        
        public List<Guid> GetDependents(Guid v) {
            return next[v];
        }

        public List<Guid> TopologicalSort() {
            var order = new List<Guid>();

            var indegrees = new Dictionary<Guid, int>();
            foreach (var v in next.Keys) {
                indegrees[v] = 0;
            }

            foreach (var (_, ws) in next) {
                foreach (var w in ws) {
                    indegrees[w]++;
                }
            }

            var q = new Queue<Guid>();
            foreach (var v in next.Keys) {
                if (indegrees[v] == 0) {
                    q.Enqueue(v);
                }
            }

            var count = 0;
            while (q.Count > 0) {
                var v = q.Dequeue();
                order.Add(v);
                foreach (var w in next[v]) {
                    if (--indegrees[w] == 0) {
                        q.Enqueue(w);
                    }
                }
                count++;
            }

            if (count != next.Count) {
                throw new Exception("There exists a cycle in the graph");
            }

            return order;
        }
    }
}
