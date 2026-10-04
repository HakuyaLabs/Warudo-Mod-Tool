using System;

namespace Warudo.Core.Data {
    public record Port(string Key, PortProperties BaseProperties) {
        public Guid Id { get; } = Guid.NewGuid();
        
        public override string ToString() {
            return Key;
        }
        
        public override int GetHashCode() {
            return Id.GetHashCode();
        }
    }
}
