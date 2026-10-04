using System;
using System.Collections.Generic;
using Warudo.Core.Graphs;

namespace Warudo.Core.Data {
    public class EntityTypeMeta {
        public string Id;
        public Type Type;
        public readonly List<ReflectedDataInputPortMeta> DataInputs = new();
        public readonly List<ReflectedTriggerPortMeta> Triggers = new();
        public readonly List<ReflectedMixinMeta> Mixins = new();
    }
}
