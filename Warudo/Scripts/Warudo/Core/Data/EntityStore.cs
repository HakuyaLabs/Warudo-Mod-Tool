using System;
using System.Collections.Generic;

namespace Warudo.Core.Data {
    // TODO: Add GC to cleanup unused entity objects. Watch out for prompted structured data...
    public class EntityStore {
        
        private readonly Dictionary<Guid, Entity> entities = new();
        private readonly Dictionary<Guid, StructuredData> structuredDataEntities = new();

        public void Put(Entity e) {
            entities[e.Id] = e;
            if (e is StructuredData sd) {
                structuredDataEntities[sd.Id] = sd;
            }
        }

        public Entity Get(Guid id) {
            return entities.GetValueOrDefault(id);
        }
        
        public void Remove(Guid id) {
            entities.Remove(id);
            if (structuredDataEntities.ContainsKey(id)) {
                structuredDataEntities.Remove(id);
            }
        }

        public void Dispose() {
            entities.Clear();
            structuredDataEntities.Clear();
        }
        
        public Dictionary<Guid, Entity> GetEntities() {
            return entities;
        }
        
        public Dictionary<Guid, StructuredData> GetStructuredDataEntities() {
            return structuredDataEntities;
        }

    }
}
