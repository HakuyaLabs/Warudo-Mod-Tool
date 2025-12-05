using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Vexe.Fast.Reflection;
using Warudo.Core.Attributes;
using Warudo.Core.Events;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using static Warudo.Core.ModUtils.PluginRouter;
using Event = Warudo.Core.Events.Event;
using Object = System.Object;

namespace Warudo.Core.Data {
    public abstract class Entity {
        public bool Created { get; private set; }

        public abstract bool CanReceiveEvents { get; }

        /// <summary>
        /// Returns the current version of this entity type.
        /// Override this to enable version migration when the data structure changes.
        /// Increment this value whenever you make breaking changes to DataInputs.
        /// </summary>
        /// <returns>The current version number (default is 0)</returns>
        public virtual long GetVersion() => 0;

        // This is a very interesting property.
        // It is really just used by SetAssetDataInputNode, so that StructuredData objects created for the fake port (TargetValue) have their parent assigned to the Asset entity,
        // not SetAssetDataInputNode itself.
        // TODO: More elegant solution? / Better naming?
        public virtual Entity StructuredDataParent => this;

        private readonly List<Guid> watcherHandles = new();
        private readonly List<(Guid entityId, Guid handle)> entityWatcherHandles = new();
        protected readonly List<Mixin> mixins = new();

        private Guid id = Guid.NewGuid();
        private string idString;
        
        public Guid Id => id;

        public string IdString => idString ??= id.ToString();
        
        public DataInputPortCollection DataInputPortCollection { get; } = new();
        
        public TriggerPortCollection TriggerPortCollection { get; } = new();

        internal Entity() {
            DataInputPortCollection.Parent = this;
        }

        public virtual void Store(Guid newId) {
            if (id == newId && Context.EntityStore.Get(newId) == this) {
                return;
            }
            if (newId == default) {
                throw new ArgumentException("Entity id cannot be default");
            }
            if (Context.EntityStore.Get(id) != null && Context.EntityStore.Get(id) != this) {
                throw new ArgumentException($"Entity has id {id}, but another entity {Context.EntityStore.Get(newId).GetType().Name} already has the same id");
            }
            if (Context.EntityStore.Get(newId) != null) {
                throw new ArgumentException($"Trying to store {GetType().Name} entity with id {newId}, but another entity {Context.EntityStore.Get(newId).GetType().Name} already uses the same id");
            }
            Context.EntityStore.Remove(id);
            id = newId;
            idString = newId.ToString();
            Context.EntityStore.Put(this);
            // Debug.Log("Stored entity " + GetType().Name + " with id " + id);
        }

        public virtual void Create() {
            if (Created) {
                throw new Exception($"Attempting to create {GetType().Name} ({Id}) which is already created");
            }
            
            EvaluateClientFunctions();
            OnCreate();
            foreach (var mixin in mixins) mixin.OnCreate();
            Created = true;

            Store(id);
        }
        
        protected virtual void OnCreate() {
        }

        public virtual void Destroy() {
            if (!Created) {
                return;
                // throw new Exception($"Attempting to destroy {GetType().Name} ({Id}) which is already destroyed");
            }

            foreach (var (type, handles) in eventSubscribers) {
                foreach (var handle in handles) {
                    Context.EventBus.Unsubscribe(type, handle);
                }
            }
            eventSubscribers.Clear();
            foreach (var connectionId in signalConnections.ToList()) {
                Context.PluginRouter.DisconnectSlot(connectionId);
            }
            signalConnections.Clear();
            foreach (var commandId in commandConnections.ToList()) { 
                Context.PluginRouter.UnregisterCommand(commandId);
            }
            commandConnections.Clear();

            foreach (var handle in watcherHandles.ToList()) {
                Unwatch(handle);
            }
            watcherHandles.Clear();
            foreach (var (entityId, handle) in entityWatcherHandles.ToList()) {
                Unwatch(entityId, handle);
            }
            entityWatcherHandles.Clear();
            // Destroy all structured data entities
            foreach (var (_, port) in DataInputPortCollection.GetPorts()) {
                if (port.Type.GetKind() == TypeKind.StructuredData) {
                    (port.Getter() as StructuredData)?.Destroy();
                } else if (port.Type.GetKind() == TypeKind.StructuredDataArray) {
                    if (port.Getter() is Array arr) {
                        foreach (var sd in arr) {
                            (sd as StructuredData)?.Destroy();
                        }
                    }
                }
            }
            DataInputPortCollection.Clear();
            TriggerPortCollection.Clear();
            ClientFunctionWatchers.Clear();
            
            Created = false;

            try {
                OnDestroy();
                foreach (var mixin in mixins) mixin.OnDestroy();
            } catch (Exception e) {
                Log.Error($"Error while destroying {GetType().Name} ({Id})", e);
            }

            Context.EntityStore.Remove(Id);
        }

        protected virtual void OnDestroy() {
        }

        public Guid Watch<T>(string dataInputKey, Action<T, T> onChange, bool deep = true) {
            var handle = DataInputPortCollection.WatchValueChange(dataInputKey, onChange, deep);
            watcherHandles.Add(handle);
            return handle;
        }

        public Guid Watch<T>(Entity otherEntity, string dataInputKey, Action<T, T> onChange, bool deep = true) {
            var handle = otherEntity.DataInputPortCollection.WatchValueChange(dataInputKey, onChange, deep);
            entityWatcherHandles.Add((otherEntity.Id, handle));
            return handle;
        }

        public Guid Watch(string dataInputKey, Action onChange, bool deep = true) {
            var handle = DataInputPortCollection.WatchValueChange<object>(dataInputKey, (_, _) => onChange(), deep);
            watcherHandles.Add(handle);
            return handle;
        }

        public Guid Watch(Entity otherEntity, string dataInputKey, Action onChange, bool deep = true) {
            var handle = otherEntity.DataInputPortCollection.WatchValueChange<object>(dataInputKey, (_, _) => onChange(), deep);
            entityWatcherHandles.Add((otherEntity.Id, handle));
            return handle;
        }
        
        public Guid WatchAssetState(string dataInputKey, Action<bool> onStateChange) {
            var port = DataInputPortCollection.GetPort(dataInputKey);
            if (port == null) throw new Exception($"No port with key {dataInputKey} found");
            if (port.Type.GetKind() != TypeKind.Asset) throw new Exception($"{dataInputKey} is not an asset");
            var handle = DataInputPortCollection.WatchAssetStateChange(dataInputKey, onStateChange);
            watcherHandles.Add(handle);
            return handle;
        }
        
        public Guid WatchAssetState(Entity otherEntity, string dataInputKey, Action<bool> onStateChange) {
            var port = otherEntity.DataInputPortCollection.GetPort(dataInputKey);
            if (port == null) throw new Exception($"No port with key {dataInputKey} found");
            if (port.Type.GetKind() != TypeKind.Asset) throw new Exception($"{dataInputKey} is not an asset");
            var handle = otherEntity.DataInputPortCollection.WatchAssetStateChange(dataInputKey, onStateChange);
            entityWatcherHandles.Add((otherEntity.Id, handle));
            return handle;
        }
        
        public Guid WatchAssetState(string dataInputKey, Action onStateChange) {
            return WatchAssetState(dataInputKey, _ => onStateChange());
        }
        
        public Guid WatchAssetState(Entity otherEntity, string dataInputKey, Action onStateChange) {
            return WatchAssetState(otherEntity, dataInputKey, _ => onStateChange());
        }

        public Guid[] WatchAsset(string dataInputKey, Action onChange) {
            var handles = new Guid[2];
            handles[0] = Watch(dataInputKey, onChange);
            handles[1] = WatchAssetState(dataInputKey, onChange);
            return handles;
        }
        
        public Guid[] WatchAsset(Entity otherEntity, string dataInputKey, Action onChange) {
            var handles = new Guid[2];
            handles[0] = Watch(otherEntity, dataInputKey, onChange);
            handles[1] = WatchAssetState(otherEntity, dataInputKey, onChange);
            return handles;
        }
        
        public Guid[] WatchAll(string[] dataInputKeys, Action onChange) {
            var handles = new Guid[dataInputKeys.Length];
            for (var index = 0; index < dataInputKeys.Length; index++) {
                var dataInputKey = dataInputKeys[index];
                handles[index] = Watch(dataInputKey, onChange);
            }
            return handles;
        }
        
        public Guid[] WatchAll(Entity otherEntity, string[] dataInputKeys, Action onChange) {
            var handles = new Guid[dataInputKeys.Length];
            for (var index = 0; index < dataInputKeys.Length; index++) {
                var dataInputKey = dataInputKeys[index];
                handles[index] = Watch(otherEntity, dataInputKey, onChange);
            }
            return handles;
        }

        public void Unwatch(Guid watcherHandle) {
            DataInputPortCollection.UnwatchValueChange(watcherHandle);
            DataInputPortCollection.UnwatchAssetStateChange(watcherHandle);
            watcherHandles.Remove(watcherHandle);
        }

        public void Unwatch(Guid entityId, Guid watcherHandle) {
            var entity = Context.EntityStore.Get(entityId);
            if (entity == null) {
                entityWatcherHandles.Remove((entityId, watcherHandle));
                return;
            }
            entity.DataInputPortCollection.UnwatchValueChange(watcherHandle);
            entity.DataInputPortCollection.UnwatchAssetStateChange(watcherHandle);
            entityWatcherHandles.Remove((entityId, watcherHandle));
        }
        
        public void Unwatch(Entity otherEntity, Guid watcherHandle) {
            Unwatch(otherEntity.id, watcherHandle);
        }

        public object GetDataInput(string key) {
            return DataInputPortCollection.GetPortValue(key);
        }

        public T GetDataInput<T>(string key) {
            return DataInputPortCollection.GetPortValue<T>(key);
        }
        
        public DataInputPort GetDataInputPort(string key) {
            return DataInputPortCollection.GetPort(key);
        }

        public void SetDataInput(string key, object value, bool broadcast = false) {
            var changed = !Equals(DataInputPortCollection.GetPortValue(key), value);
            DataInputPortCollection.SetPortValue(key, value);
            if (broadcast && changed) BroadcastDataInput(key);
        }

        public void BroadcastDataInput(string key) {
            if (key == null) {
                Log.Error("Attempting to broadcast data input port with null key. Did you use nameof()?");
                return;
            }
            var port = DataInputPortCollection.GetPort(key);
            if (port == null) {
                Log.Error("Attempting to broadcast data input port with unknown key: " + key + ". Did you use nameof()?");
                return;
            }
            Context.ServiceMessageQueue.QueueEntityDataInput(this, key);
        }

        public void BroadcastDataInputProperties(string key) {
            if (key == null) {
                Log.Error("Attempting to broadcast data input port with null key. Did you use nameof()?");
                return;
            }
            var port = DataInputPortCollection.GetPort(key);
            if (port == null) {
                Log.Error("Attempting to broadcast data input port with unknown key: " + key + ". Did you use nameof()?");
                return;
            }
            Context.ServiceMessageQueue.QueueEntityDataInputProperties(this, key);
        }

        public TriggerPort GetTriggerPort(string key) {
            return TriggerPortCollection.GetPort(key);
        }
        
        public void BroadcastTriggerProperties(string key) {
            if (key == null) {
                Log.Error("Attempting to broadcast trigger port with null key. Did you use nameof()?");
                return;
            }
            var port = TriggerPortCollection.GetPort(key);
            if (port == null) {
                Log.Error("Attempting to broadcast trigger port with unknown key: " + key + ". Did you use nameof()?");
                return;
            }
            Context.ServiceMessageQueue.QueueEntityTriggerProperties(this, key);
        }

        public abstract void Broadcast();

        public void ResetDataInput(string key, bool broadcast = true) {
            var port = DataInputPortCollection.GetPort(key);
            if (port == null) {
                Log.Error("Attempting to reset data input port with unknown key: " + key + ". Did you use nameof()?");
                return;
            }
            
            port.SetSerializedValue(port.DefaultValue, Context.OpenedScene, this);
            if (broadcast) BroadcastDataInput(key);
        }
        
        public DataInputPort AddDataInputPort(string key, Type type, object defaultValue, DataInputProperties properties = null) {
            properties ??= new DataInputProperties {
                label = key.ToSpacedPascalCase(),
                order = DataInputPortCollection.GetPorts().Max(p => p.Value.Properties.order) + 1
            };
            var data = defaultValue;
            var port = new DataInputPort(key, type, DataInputPort.Serialize(type, defaultValue), () => data, v => data = v, properties.Clone(), null);
            DataInputPortCollection.AddPort(port);
            return port;
        }

        public DataInputPort AddDataInputPort<T>(string key, T defaultValue, DataInputProperties properties = null) => AddDataInputPort(key, typeof(T), defaultValue, properties);

        public TriggerPort AddTriggerPort(string key, Action onTrigger, TriggerProperties properties = null) {
            properties ??= new TriggerProperties {
                label = key.ToSpacedPascalCase(),
                order = TriggerPortCollection.GetPorts().Max(p => p.Value.Properties.order) + 1
            };
            var port = new TriggerPort(key, onTrigger, properties.Clone());
            TriggerPortCollection.AddPort(port);
            return port;
        }
        
        public void InvokeTrigger(string triggerPortKey) {
            var port = TriggerPortCollection.GetPort(triggerPortKey);
            if (port == null) {
                throw new Exception($"Trigger port {triggerPortKey} does not exist");
            }

            port.OnTrigger();
        }
        
        public bool InvokeTriggerAtPath(string path) {
            var triggerPort = TriggerPortCollection.GetPort(path);
            if (triggerPort != null) {
                triggerPort.OnTrigger();
                return true;
            }

            if (path.IndexOf('.') < 0) {
                Log.UserError("Invalid trigger path: " + path);
                return false;
            }

            var portKey = path[..path.IndexOf('.')];
            var dataPort = DataInputPortCollection.GetPort(portKey);
            if (dataPort == null) {
                Log.UserError("Invalid data path: " + path);
                return false;
            }

            var obj = dataPort.Getter();
            
            var remainingPath = path[(path.IndexOf('.') + 1)..];
            while (remainingPath.Length > 0) {
                var hasAccessor = remainingPath.IndexOf('.') >= 0;
                var remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                if (dataPort.Type.GetKind() == TypeKind.StructuredDataArray) {
                    if (int.TryParse(remainingPathKey, out var idx)) {
                        if (obj is not Array arrayValue) {
                            Log.UserError("Unexpected non-array value at data path: " + path);
                            return false;
                        }

                        if (!hasAccessor) {
                            Log.UserError("Invalid trigger path: " + path);
                            return false;
                        }
                        
                        var array = (Array) dataPort.Getter();
                        if (array.Length <= idx) {
                            Log.UserError($"Array index {idx} out of bounds for {dataPort.Key}");
                            return false;
                        }
                        if (array.GetValue(idx) is not StructuredData sd) return false;

                        remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];

                        hasAccessor = remainingPath.IndexOf('.') >= 0;
                        remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                        
                        triggerPort = sd.TriggerPortCollection.GetPort(remainingPathKey);
                        if (triggerPort != null) {
                            triggerPort.OnTrigger();
                            return true;
                        }
                        
                        dataPort = sd.DataInputPortCollection.GetPort(remainingPathKey);
                        if (dataPort == null) {
                            Log.UserError($"Invalid key {remainingPathKey} at data path: " + path);
                            return false;
                        }

                        if (!hasAccessor) {
                            Log.UserError("Invalid trigger path: " + path);
                            return true;
                        }

                        remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                    } else {
                        Log.UserError($"Invalid index {remainingPathKey} at data path: " + path);
                        return false;
                    }
                } else if (dataPort.Type.GetKind() == TypeKind.StructuredData) {
                    if (dataPort.Getter() is not StructuredData sd) return false;
                    
                    hasAccessor = remainingPath.IndexOf('.') >= 0;
                    remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                    
                    triggerPort = sd.TriggerPortCollection.GetPort(remainingPathKey);
                    if (triggerPort != null) {
                        triggerPort.OnTrigger();
                        return true;
                    }
                    
                    dataPort = sd.DataInputPortCollection.GetPort(remainingPathKey);
                    if (dataPort == null) {
                        Log.UserError($"Invalid key {remainingPathKey} at data path: " + path);
                        return false;
                    }

                    if (!hasAccessor) {
                        Log.UserError("Invalid trigger path: " + path);
                        return true;
                    }

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                } else {
                    Log.UserError($"Invalid trigger path: " + path);
                    return false;
                }
            }
            Log.UserError("Invalid trigger path: " + path);
            return false;
        }

        public Dictionary<string, string> SerializeDataInputPorts(params string[] portKeys) {
            var dict = new Dictionary<string, string>();
            foreach (var portKey in portKeys) {
                var port = GetDataInputPort(portKey);
                if (port == null) {
                    throw new ArgumentException($"Data input port {portKey} not found.");
                }
                dict[portKey] = port.SerializeValue();
            }
            return dict;
        }

        public void DeserializeDataInputPorts(Dictionary<string, string> portValues) {
            foreach (var (key, value) in portValues) {
                var port = GetDataInputPort(key);
                if (port == null) {
                    Debug.LogWarning("Data input port " + key + " not found.");
                    continue;
                }
                if (port.Properties.transient) {
                    continue;
                }
                port.SetSerializedValue(value, Context.OpenedScene, this);
            }
        }
        
        private readonly Dictionary<Type, HashSet<Guid>> eventSubscribers = new();
        private readonly HashSet<Guid> signalConnections = new();
        private readonly HashSet<Guid> commandConnections = new();

        public Guid Subscribe<T>(OnEvent<T> handler, bool alwaysReceiveEvent = false) where T : Event {
            if (!eventSubscribers.ContainsKey(typeof(T))) {
                eventSubscribers[typeof(T)] = new();
            }
            var handle = Context.EventBus.Subscribe<T>(e => {
                if (CanReceiveEvents || alwaysReceiveEvent) {
                    handler(e);
                }
            });
            eventSubscribers[typeof(T)].Add(handle);
            return handle;
        }

        public void EmitSignal<T>(T signalData) where T : Event
        {
            Context.PluginRouter.EmitSignal(this, signalData);
        }

        /// <summary>
        /// Connect a slot to receive signals from a specific entity type.
        /// The connection will be automatically cleaned up when this entity is destroyed.
        /// </summary>
        /// <typeparam name="T">The event type to listen for</typeparam>
        /// <param name="sourceEntityTypeId">The source entity type ID (from Attribute)</param>
        /// <param name="handler">The event handler</param>
        /// <returns>Connection handle that can be used to disconnect manually</returns>
        public Guid ConnectSlot<T>(string sourceEntityTypeId, OnSignal<T> handler) where T : Event {
            var connectionId = Context.PluginRouter.ConnectSlot<T>(this, sourceEntityTypeId, (e, s) => {
                if (CanReceiveEvents) {
                    handler(e, s);
                }
            });
            signalConnections.Add(connectionId);
            return connectionId;
        }

        /// <summary>
        /// Disconnect a signal slot connection
        /// </summary>
        /// <param name="connectionId">The connection handle returned from ConnectSlot</param>
        public void DisconnectSlot(Guid connectionId) {
            if (signalConnections.Remove(connectionId)) {
                Context.PluginRouter.DisconnectSlot(connectionId);
            }
        }

        public Guid RegisterCommand<TArgs, TResult>(string commandName, Func<TArgs, TResult> handler)
            where TArgs : class, new()
        { 
            var commandId = Context.PluginRouter.RegisterCommand<TArgs, TResult>(this, commandName, handler);
            commandConnections.Add(commandId);
            return commandId;
        }

        public void UnregisterCommand(Guid commandId) {
            if (commandConnections.Remove(commandId)) {
                Context.PluginRouter.UnregisterCommand(commandId);
            }
        }

        protected readonly List<ComputedValueWatcher> ClientFunctionWatchers = new();

        protected void Define(List<ReflectedDataInputPortMeta> dataInputPorts, List<ReflectedTriggerPortMeta> triggerPorts, List<ReflectedMixinMeta> mixins, Entity structuredDataParent) {
            foreach (var portMeta in dataInputPorts) {
                var port = DataInputPort.CreateDataInputPortFromReflectionMeta(portMeta, this, this, structuredDataParent, Context.OpenedScene);
                DataInputPortCollection.AddPort(port);
                SetupPredicateAttribute(port.Key, portMeta.HiddenIfAttribute, portMeta.HiddenIfMethodInfo, this, () => port.Properties.hidden, v => port.Properties.hidden = v, _ => BroadcastDataInputProperties(port.Key));
                SetupPredicateAttribute(port.Key, portMeta.DisabledIfAttribute, portMeta.DisabledIfMethodInfo, this, () => port.Properties.disabled, v => port.Properties.disabled = v, _ => BroadcastDataInputProperties(port.Key));
                SetupPredicateAttribute(port.Key, portMeta.SectionHiddenIfAttribute, portMeta.SectionHiddenIfMethodInfo, this, () => port.Properties.sectionHidden, v => port.Properties.sectionHidden = v, _ => BroadcastDataInputProperties(port.Key));
            }
            foreach (var portMeta in triggerPorts) {
                var port = TriggerPort.CreateTriggerPortFromReflectionMeta(portMeta, this);
                TriggerPortCollection.AddPort(port);
                SetupPredicateAttribute(port.Key, portMeta.HiddenIfAttribute, portMeta.HiddenIfMethodInfo, this, () => port.Properties.hidden, v => port.Properties.hidden = v, _ => BroadcastTriggerProperties(port.Key));
                SetupPredicateAttribute(port.Key, portMeta.DisabledIfAttribute, portMeta.DisabledIfMethodInfo, this, () => port.Properties.disabled, v => port.Properties.disabled = v, _ => BroadcastTriggerProperties(port.Key));
                SetupPredicateAttribute(port.Key, portMeta.SectionHiddenIfAttribute, portMeta.SectionHiddenIfMethodInfo, this, () => port.Properties.sectionHidden, v => port.Properties.sectionHidden = v, _ => BroadcastTriggerProperties(port.Key));
            }
            foreach (var mixinMeta in mixins) {
                var mixin = Mixin.CreateMixinFromReflectionMeta(mixinMeta, this, out var createdDataInputPorts, out var createdTriggerPorts);
                this.mixins.Add(mixin);
                foreach (var (port, portMeta) in createdDataInputPorts) {
                    SetupPredicateAttribute(port.Key, portMeta.HiddenIfAttribute, portMeta.HiddenIfMethodInfo, mixin, mixinMeta.HiddenIfAttribute, mixinMeta.HiddenIfMethodInfo, this, () => port.Properties.hidden, v => port.Properties.hidden = v, _ => BroadcastDataInputProperties(port.Key));
                    SetupPredicateAttribute(port.Key, portMeta.DisabledIfAttribute, portMeta.DisabledIfMethodInfo, mixin, mixinMeta.DisabledIfAttribute, mixinMeta.DisabledIfMethodInfo, this, () => port.Properties.disabled, v => port.Properties.disabled = v, _ => BroadcastDataInputProperties(port.Key));
                    SetupPredicateAttribute(port.Key, portMeta.SectionHiddenIfAttribute, portMeta.SectionHiddenIfMethodInfo, mixin, () => port.Properties.sectionHidden, v => port.Properties.sectionHidden = v, _ => BroadcastDataInputProperties(port.Key));
                    
                }
                foreach (var (port, portMeta) in createdTriggerPorts) {
                    SetupPredicateAttribute(port.Key, portMeta.HiddenIfAttribute, portMeta.HiddenIfMethodInfo, mixin, mixinMeta.HiddenIfAttribute, mixinMeta.HiddenIfMethodInfo, this, () => port.Properties.hidden, v => port.Properties.hidden = v, _ => BroadcastTriggerProperties(port.Key));
                    SetupPredicateAttribute(port.Key, portMeta.DisabledIfAttribute, portMeta.DisabledIfMethodInfo, mixin, mixinMeta.DisabledIfAttribute, mixinMeta.DisabledIfMethodInfo, this, () => port.Properties.disabled, v => port.Properties.disabled = v, _ => BroadcastTriggerProperties(port.Key));
                    SetupPredicateAttribute(port.Key, portMeta.SectionHiddenIfAttribute, portMeta.SectionHiddenIfMethodInfo, mixin, () => port.Properties.sectionHidden, v => port.Properties.sectionHidden = v, _ => BroadcastTriggerProperties(port.Key));
                }
            }
        }

        protected void SetupPredicateAttribute(string owner, PredicateAttribute predicateAttribute, MethodInfo methodInfo, object methodProvider, Func<bool> getter, Action<bool> setter, Action<bool> onChanged) {
            if (predicateAttribute == null) return;
            SetupPredicateAttribute(CreateInvokeFunc(owner, predicateAttribute, methodInfo, methodProvider), getter, setter, onChanged);
        }
        
        protected void SetupPredicateAttribute(string owner, PredicateAttribute predicateAttribute, MethodInfo methodInfo, object methodProvider, PredicateAttribute orPredicateAttribute, MethodInfo orMethodInfo, object orMethodProvider, Func<bool> getter, Action<bool> setter, Action<bool> onChanged) {
            if (predicateAttribute == null && orPredicateAttribute == null) return;
            var func1 = CreateInvokeFunc(owner, predicateAttribute, methodInfo, methodProvider);
            var func2 = CreateInvokeFunc(owner, orPredicateAttribute, orMethodInfo, orMethodProvider);
            if (func1 != null && func2 != null) {
                SetupPredicateAttribute(() => func1() || func2(), getter, setter, onChanged);
            } else if (func1 != null) {
                SetupPredicateAttribute(func1, getter, setter, onChanged);
            } else if (func2 != null) {
                SetupPredicateAttribute(func2, getter, setter, onChanged);
            }
        }
        
        private Func<bool> CreateInvokeFunc(string owner, PredicateAttribute predicateAttribute, MethodInfo methodInfo, object methodProvider) {
            if (predicateAttribute == null) return null;
            if (predicateAttribute.Predicate == AttributePredicateType.Method) {
                if (methodInfo != null) {
                    var invoker = methodInfo.DelegateForCall();
                    return () => (bool)invoker.Invoke(methodProvider, Array.Empty<object>());
                }
            } else if (predicateAttribute.Predicate == AttributePredicateType.PortIf) {
                var portName = predicateAttribute.DataInputPortName;
                var value = predicateAttribute.Value;
                var @if = predicateAttribute.If;
                return () => {
                    var ifPort = GetDataInputPort(portName);
                    if (ifPort == null) {
                        Log.UserError($"{owner} HiddenIf tries to compare port {portName} to {value}, but port {portName} is not found");
                        return false;
                    }
                    return @if.Evaluate(ifPort.Getter(), value);
                };
            } else if (predicateAttribute.Predicate == AttributePredicateType.PortIs) {
                var portName = predicateAttribute.DataInputPortName;
                var @is = predicateAttribute.Is;
                return () => {
                    var ifPort = GetDataInputPort(portName);
                    if (ifPort == null) {
                        Log.UserError($"{owner} HiddenIf tries to check if port {portName} {@is}, but port {portName} is not found");
                        return false;
                    }
                    return @is.Evaluate(ifPort.Getter());
                };
            }
            return null;
        }
        
        protected void SetupPredicateAttribute(Func<bool> invokeFunc, Func<bool> getter, Action<bool> setter, Action<bool> onChanged) {
            ClientFunctionWatchers.Add(new ComputedValueWatcher<bool>(
                invokeFunc,
                getter,
                setter,
                onChanged));
        }

        public virtual bool ShouldEvaluateClientFunctions => Context.Service?.HasConnectedSessions() ?? false;
        
        protected bool EvaluatedShouldEvaluateClientFunctionsThisFrame;
        private bool shouldEvaluateClientFunctionsThisFrame;

        public bool ShouldEvaluateClientFunctionsThisFrame() {
            if (EvaluatedShouldEvaluateClientFunctionsThisFrame) {
                return shouldEvaluateClientFunctionsThisFrame;
            }
            shouldEvaluateClientFunctionsThisFrame = ShouldEvaluateClientFunctions;
            EvaluatedShouldEvaluateClientFunctionsThisFrame = true;
            return shouldEvaluateClientFunctionsThisFrame;
        }

        public void EvaluateClientFunctions() {
            foreach (var watcher in ClientFunctionWatchers) {
                watcher.Evaluate();
            }
        }
    }
    
    public abstract class Entity<TMeta, TSerialized> : Entity, ISerializableEntity where TSerialized : SerializedEntity {
        public TMeta Type { get; set; }

        public override void Create() {
            if (Created) {
                throw new Exception($"Attempting to create {GetType().Name} ({Id}) which is already created");
            }
            
            Type = GetTypeMeta();
            Define(Type);
            base.Create();
        }

        public abstract TMeta GetTypeMeta();
        
        protected abstract void Define(TMeta meta);
        
        public abstract TSerialized Serialize();

        public abstract void Deserialize(TSerialized serialized);

        public override void Broadcast() {
            Context.ServiceMessageQueue.QueueEntity(this);
        }

        SerializedEntity ISerializableEntity.Serialize() => Serialize();

    }

    // TODO: When runtime supports covariant return types...
    public interface ISerializableEntity {

        public SerializedEntity Serialize();

    }

    public abstract class BehavioralEntity<TMeta, TSerialized> : Entity<TMeta, TSerialized> where TSerialized : SerializedEntity {
        public void FixedUpdate() {
            try {
                OnFixedUpdate();
                foreach (var mixin in mixins) if (mixin is BehavioralMixin bm) bm.OnFixedUpdate();
            } catch (Exception e) {
                Log.Error($"{GetType().Name}: Error in OnFixedUpdate", e);
            }
        }
        
        public void PreUpdate() {
            EvaluatedShouldEvaluateClientFunctionsThisFrame = false;
            if (ShouldEvaluateClientFunctionsThisFrame()) {
                EvaluateClientFunctions();
            }

            try {
                OnPreUpdate();
                foreach (var mixin in mixins) if (mixin is BehavioralMixin bm) bm.OnPreUpdate();
            } catch (Exception e) {
                Log.Error($"{GetType().Name}: Error in OnPreUpdate", e);
            }
        }

        public void Update() {
            try {
                OnUpdate();
                foreach (var mixin in mixins) if (mixin is BehavioralMixin bm) bm.OnUpdate();
            } catch (Exception e) {
                Log.Error($"{GetType().Name}: Error in OnUpdate", e);
            }
        }
        
        public void PostUpdate() {
            try {
                OnPostUpdate();
                foreach (var mixin in mixins) if (mixin is BehavioralMixin bm) bm.OnPostUpdate();
            } catch (Exception e) {
                Log.Error($"{GetType().Name}: Error in OnPostUpdate", e);
            }
        }

        public void LateUpdate() {
            try {
                OnLateUpdate();
                foreach (var mixin in mixins) if (mixin is BehavioralMixin bm) bm.OnLateUpdate();
            } catch (Exception e) {
                Log.Error($"{GetType().Name}: Error in OnLateUpdate", e);
            }
        }

        public void PostLateUpdate() {
            try {
                OnPostLateUpdate();
                foreach (var mixin in mixins) if (mixin is BehavioralMixin bm) bm.OnPostLateUpdate();
            } catch (Exception e) {
                Log.Error($"{GetType().Name}: Error in OnPostLateUpdate", e);
            }
        }
        
        public void EndOfFrame() {
            try {
                OnEndOfFrame();
                foreach (var mixin in mixins) if (mixin is BehavioralMixin bm) bm.OnEndOfFrame();
            } catch (Exception e) {
                Log.Error($"{GetType().Name}: Error in OnEndOfFrame", e);
            }
        }
        
        public virtual void OnDrawGizmos() {
        }
        
        public virtual void OnFixedUpdate() {
        }
        
        public virtual void OnPreUpdate() {
        }

        public virtual void OnUpdate() {
        }
        
        public virtual void OnPostUpdate() {
        }

        public virtual void OnLateUpdate() {
        }

        public virtual void OnPostLateUpdate() {
        }
        
        public virtual void OnEndOfFrame() {
        }
    }
}
