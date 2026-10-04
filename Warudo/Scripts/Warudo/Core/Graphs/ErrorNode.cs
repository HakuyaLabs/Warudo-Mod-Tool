using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Serializations;

namespace Warudo.Core.Graphs {
    [NodeType(Id = TypeId, Title = "ERROR_NODE")]
    public sealed class ErrorNode : PlaceholderNode {
        public const string TypeId = "2d197d20-0147-4e25-9e6b-3c23f9c1e69a";
        public const string RecoverTriggerKey = "__recover__";
        private readonly Dictionary<string, TypeKind> brokenPorts = new();
        public string RecoveryTriggerKey { get; private set; } = RecoverTriggerKey;

        public IReadOnlyCollection<string> BrokenSdPorts => brokenPorts.Keys;
        public bool CanRecover => brokenPorts.Count > 0 && brokenPorts.Values.All(it => it == TypeKind.StructuredDataArray)
            && brokenPorts.Keys.All(key => Raw?.dataInputs != null && Raw.dataInputs.TryGetValue(key, out var port) && port != null)
            && Context.NodeTypeRegistry.IsTypeRegistered(OriginalTypeId);

        protected override void OnCreate() {
            base.OnCreate();
            AddTriggerPort(RecoverTriggerKey, Recover, new TriggerProperties {
                label = "RECOVER_NODE", transient = true, disabled = true
            });
        }

        public override void Deserialize(SerializedNode serialized) {
            base.Deserialize(serialized);
            var key = RecoverTriggerKey;
            for (var suffix = 2; Raw.triggers?.ContainsKey(key) == true; suffix++) key = RecoverTriggerKey + suffix;
            if (key == RecoveryTriggerKey) return;
            TriggerPortCollection.RemovePort(RecoveryTriggerKey);
            RecoveryTriggerKey = key;
            AddTriggerPort(key, Recover, new TriggerProperties { label = "RECOVER_NODE", transient = true, disabled = true });
        }

        internal void SetBrokenPorts(Dictionary<string, TypeKind> ports) {
            brokenPorts.Clear();
            foreach (var (key, kind) in ports) brokenPorts[key] = kind;
            GetTriggerPort(RecoveryTriggerKey).Properties.disabled = !CanRecover;
        }

        private void Recover() {
            if (!CanRecover || Graph == null) return;
            var snapshot = GetSnapshot();
            foreach (var key in brokenPorts.Keys) snapshot.dataInputs[key].value = "[]";
            Graph.ReplaceNode(this, snapshot);
        }

        public override SerializedNode Serialize() {
            var serialized = base.Serialize();
            serialized.errorPorts = brokenPorts.Keys.ToArray();
            serialized.triggers ??= new();
            var trigger = GetTriggerPort(RecoveryTriggerKey);
            trigger.Properties.disabled = !CanRecover;
            serialized.triggers[RecoveryTriggerKey] = trigger.Serialize();
            return serialized;
        }
    }
}
