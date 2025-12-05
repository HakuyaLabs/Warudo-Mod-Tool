using System;
using System.Collections.Generic;
using Warudo.Core.Scenes;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using Debug = UnityEngine.Debug;

namespace Warudo.Core.Data {
    public class StructuredData : Entity<StructuredDataTypeMeta, SerializedStructuredData> {
        public static T Create<T>(Action<T> initializer = default) where T : StructuredData {
            var sd = (T) Context.StructuredDataTypeRegistry.CreateEntity(typeof(T));
            initializer?.Invoke(sd);
            return sd;
        }
        
        public static T Create<T, TP>(TP parent = null, Action<T> initializer = default) where T : StructuredData<TP> where TP : Entity {
            var sd = (T) Context.StructuredDataTypeRegistry.CreateEntity(typeof(T));
            initializer?.Invoke(sd);
            sd.Parent = parent;
            return sd;
        }
        
        public virtual string PortKey { get; set; }
        
        public bool CollapsedSelf { get; set; }
        
        public bool CollapsedInHierarchy => CollapsedSelf || Parent is StructuredData { CollapsedInHierarchy: true };

        private Entity parent;

        public virtual Entity Parent {
            get => parent;
            set {
                parent = value;
                if (parent != null) OnAssignedParent();
            }
        }
        
        public virtual Entity EvaluateClientFunctionsParent { get; set; }
        public bool ShouldSerializeTriggers { get; set; } = true;

        public virtual Scene Scene { get; set; }
        
        public override bool CanReceiveEvents => false;

        public override bool ShouldEvaluateClientFunctions => (Parent == null || (EvaluateClientFunctionsParent ?? Parent).ShouldEvaluateClientFunctionsThisFrame()) && !CollapsedInHierarchy && base.ShouldEvaluateClientFunctions;

        private bool dirty;
        private ComputedValueWatcher<string> headerWatcher;

        public override StructuredDataTypeMeta GetTypeMeta() => Context.StructuredDataTypeRegistry.GetTypeMeta(GetType());

        protected override void Define(StructuredDataTypeMeta meta) {
            Define(meta.DataInputs, meta.Triggers, meta.Mixins, this);
            if (this is ICollapsibleStructuredData c) {
                string header = null;
                headerWatcher = new ComputedValueWatcher<string>(
                    () => c.GetHeader(),
                    () => header,
                    v => header = v,
                    _ => Context.ServiceMessageQueue.QueueEntityHeader(c));
                CollapsedSelf = true;
            }
        }

        protected StructuredData() {
        }

        public override void Create() {
            base.Create();
            AddWatchers();
        }
        
        protected virtual void OnAssignedParent() {
        }
        
        private readonly Dictionary<string, Guid> watcherHandles = new();

        private void AddWatchers() {
            foreach (var key in new List<string>(DataInputPortCollection.GetPorts().Keys)) {
                watcherHandles[key] = DataInputPortCollection.WatchValueChange<object>(key, (_, _) => dirty = true);
            }
        }
        
        private void RemoveWatchers() {
            foreach (var key in new List<string>(DataInputPortCollection.GetPorts().Keys)) {
                if (watcherHandles.TryGetValue(key, out var handle)) {
                    DataInputPortCollection.UnwatchValueChange(key, handle);
                }
            }
        }
        
        protected void NotifyParentChanged() {
            Parent?.DataInputPortCollection.NotifyValueWatchers(PortKey, this, this, true);
        }

        public void Update() {
            EvaluatedShouldEvaluateClientFunctionsThisFrame = false;
            var shouldEvaluateClientFunctionsThisFrame = ShouldEvaluateClientFunctionsThisFrame();
            if (shouldEvaluateClientFunctionsThisFrame) {
                EvaluateClientFunctions();
            }
            if (shouldEvaluateClientFunctionsThisFrame || (Parent != null && Parent.ShouldEvaluateClientFunctionsThisFrame())) {
                if (headerWatcher != null && Parent is null or not StructuredData or StructuredData { CollapsedInHierarchy: false }) {
                    headerWatcher.Evaluate();
                }
            }
            
            OnUpdate();

            if (!dirty || Parent == null) return;
            dirty = false;

            NotifyParentChanged();
        }

        protected virtual void OnUpdate() {
        }

        public override SerializedStructuredData Serialize() {
            return new SerializedStructuredData {
                id = Id,
                dataInputs = DataInputPortCollection.Serialize(),
                triggers = ShouldSerializeTriggers ? TriggerPortCollection.Serialize() : new(),
                header = (this is ICollapsibleStructuredData c && Created) ? c.GetHeader() : null,
                collapsed = CollapsedSelf
            }.Also(it => it.Localize());
        }
        
        public override void Deserialize(SerializedStructuredData serialized) {
            // Removed: Plugin can have null Scene for structured data
            // if (Scene == null) {
            //     throw new ArgumentNullException(nameof(Scene));
            // }
            
            Store(serialized.id);
            CollapsedSelf = serialized.collapsed;

            RemoveWatchers();
            if (serialized.dataInputs != null) {
                foreach (var (key, serializedPort) in serialized.dataInputs) {
                    var port = DataInputPortCollection.GetPort(key);
                    if (port == null) {
                        Debug.LogWarning($"{GetType().Name}::{key} was serialized but this port no longer exists. Skipping deserialization.");
                        continue;
                    }
                    if (port.Properties.transient) {
                        continue;
                    }

                    try {
                        // var dataType = Context.TypeRegistry.GetType(serializedPort.type);
                        // if (dataType == null) {
                        //     throw new Exception($"Cannot find data type {serializedPort.type} for {GetType().Name}::{key}. Does it belong to a plugin that is not currently loaded?");
                        // }
                        // if (dataType != port.Type) {
                        //     throw new Exception($"Serialized data type {serializedPort.type} does not match actual data type {port.Type.FriendlyFullName()}");
                        // }

                        port.SetSerializedValue(serializedPort.value, Scene, this);
                        // Debug.Log("Deserialized " + GetType().Name + "::" + key);
                    } catch (Exception e) {
                        Log.UserError($"Failed to set data input port value for structured data {GetType().Name}::{port.Key} = {serializedPort.value}", e);
                    }
                }
            }
            AddWatchers();
        }
    }

    public class StructuredData<TParent> : StructuredData where TParent : Entity {

        public new TParent Parent {
            get => base.Parent as TParent;
            set => base.Parent = value;
        }

    }
    
    public interface IKeyIndexedStructuredData {
        string StructuredDataKey { get; }
    }
}