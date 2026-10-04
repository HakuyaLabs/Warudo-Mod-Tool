using System.Collections.Generic;
using System.Linq;

namespace Warudo.Core.Serializations {
    internal static class SerializedEntitySnapshot {
        // Clone DTOs without parsing value strings. Localization and persistence
        // filtering must never mutate the retained snapshot.
        internal static SerializedNode Clone(SerializedNode value) => new() {
            id = value.id, version = value.version, typeId = value.typeId,
            name = value.name, x = value.x, y = value.y,
            dataInputs = CloneInputs(value.dataInputs), triggers = CloneTriggers(value.triggers),
            dataOutputs = value.dataOutputs?.ToDictionary(it => it.Key, it => it.Value == null ? null : new SerializedDataOutputPort {
                key = it.Value.key, type = it.Value.type, properties = it.Value.properties?.Clone()
            }),
            flowInputs = value.flowInputs?.ToDictionary(it => it.Key, it => it.Value == null ? null : new SerializedFlowInputPort {
                key = it.Value.key, properties = it.Value.properties?.Clone()
            }),
            flowOutputs = value.flowOutputs?.ToDictionary(it => it.Key, it => it.Value == null ? null : new SerializedFlowOutputPort {
                key = it.Value.key, properties = it.Value.properties?.Clone()
            })
        };

        internal static SerializedAsset Clone(SerializedAsset value) => new() {
            id = value.id, version = value.version, typeId = value.typeId,
            name = value.name, active = value.active,
            dataInputs = CloneInputs(value.dataInputs), triggers = CloneTriggers(value.triggers)
        };

        private static Dictionary<string, SerializedDataInputPort> CloneInputs(Dictionary<string, SerializedDataInputPort> ports)
            => ports?.ToDictionary(it => it.Key, it => it.Value?.Clone());

        private static Dictionary<string, SerializedTriggerPort> CloneTriggers(Dictionary<string, SerializedTriggerPort> ports)
            => ports?.ToDictionary(it => it.Key, it => it.Value?.Clone());

        internal static void StripTransient(SerializedEntity entity) {
            entity.dataInputs = entity.dataInputs?.Where(it => it.Value?.properties?.transient != true).ToDictionary(it => it.Key, it => it.Value);
            entity.triggers = entity.triggers?.Where(it => it.Value?.properties?.transient != true).ToDictionary(it => it.Key, it => it.Value);
            entity.placeholderKind = null;
            entity.placeholderTypeId = null;
            entity.errorPorts = null;
        }
    }
}
