using System;
using System.Collections.Generic;

namespace Warudo.Core.Data {
    public class PortCollection<TPort> where TPort : Port {
        protected readonly Dictionary<string, TPort> Ports = new();
        
        public virtual void AddPort(TPort port) {
            if (Ports.ContainsKey(port.Key)) {
                throw new ArgumentException($"{port.Key} is already defined");
            }
            if (port.Key[0] >= '0' && port.Key[0] <= '9') {
                throw new ArgumentException($"{port.Key} cannot start with a digit");
            }
            if (port.Key[0] == '@') {
                throw new ArgumentException($"{port.Key} cannot start with an @");
            }
            Ports[port.Key] = port;
        }

        public virtual void RemovePort(string key) {
            Ports.Remove(key);
        }
        
        public bool ContainsPort(string key) => Ports.ContainsKey(key);

        public TPort GetPort(string key) => Ports.GetValueOrDefault(key);
        
        public Dictionary<string, TPort> GetPorts() => Ports;

        public virtual void Clear() => Ports.Clear();
    }
}
