using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Plugins;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Scenes {
    public abstract class Asset : BehavioralEntity<AssetTypeMeta, SerializedAsset> {

        private string name;

        public string Name {
            get => name;
            set {
                if (name == value) return;
                name = value;
                OnNameChange.Invoke(value);
            }
        }

        public Scene Scene { get; set; }

        public bool Active { get; private set; }

        public int Order {
            get {
                var hierarchy = Scene.AssetHierarchy;
                if (hierarchy == null) {
                    return -1;
                }
                return hierarchy.GetOrder(Id.ToString());
            }
        }

        public readonly UnityEvent<bool> OnActiveStateChange = new();

        public readonly UnityEvent<bool> OnSelectedStateChange = new();
        
        public readonly UnityEvent<string> OnNameChange = new();

        public bool IsSelected => Context.OpenedScene?.GetSelectedAsset() == this;

        public Plugin Plugin => Type.OwnerPlugin;

        protected void SetActive(bool active) {
            if (Active == active) return;
            Active = active;
            OnActiveStateChange.Invoke(active);
            Context.ServiceMessageQueue.QueueAssetActiveState(this);
        }
        
        public override bool CanReceiveEvents => true;

        public override bool ShouldEvaluateClientFunctions => Context.OpenedScene != null && Context.OpenedScene.GetSelectedAsset() == this && base.ShouldEvaluateClientFunctions;

        public override AssetTypeMeta GetTypeMeta() => Context.AssetTypeRegistry.GetTypeMeta(GetType()) ?? throw new Exception($"{GetType()} is not registered as an asset type");
        
        protected override void Define(AssetTypeMeta meta) {
            Define(meta.DataInputs, meta.Triggers, meta.Mixins, this);
            Name ??= meta.AssetType.title.Localized();
        }
        
        public sealed override void Destroy() {
            base.Destroy();
            Active = false;
            OnActiveStateChange.RemoveAllListeners();
            OnSelectedStateChange.RemoveAllListeners();
        }
        
        public override SerializedAsset Serialize() {
            UpdateErrorRecoveryTrigger();
            return new SerializedAsset {
                id = Id,
                typeId = Type.AssetType.id,
                name = Name,
                active = Active,
                version = GetVersion(),
                dataInputs = DataInputPortCollection.Serialize(),
                triggers = TriggerPortCollection.Serialize(),
                placeholderKind = FailedSdPorts.Count > 0 ? "error" : null,
                errorPorts = FailedSdPorts.Count > 0 ? FailedSdPorts.ToArray() : null
            };
        }
        
        public override void Deserialize(SerializedAsset serialized) {
            if (Scene == null) {
                throw new ArgumentNullException(nameof(Scene));
            }
            
            Store(serialized.id);
            FailedSdPorts.Clear();
            if (serialized.version != GetVersion()) {
                Debug.Log($"Asset {GetType().Name} was serialized with version {serialized.version} but current version is {GetVersion()}. There may be compatibility issues.");
            }
            Name = serialized.name;
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
                    } catch (Exception e) {
                        Log.UserError($"Failed to set data input port value for asset {GetType().Name}::{port.Key} = {serializedPort.value}", e);
                    }
                }
            }
        }
        
        internal void UpdateErrorRecoveryTrigger() {
            if (FailedSdPorts.Count == 0) {
                if (errorRecoveryTriggerKey != null) TriggerPortCollection.RemovePort(errorRecoveryTriggerKey);
                errorRecoveryTriggerKey = null;
                return;
            }
            if (errorRecoveryTriggerKey == null) {
                errorRecoveryTriggerKey = "__recover__";
                for (var suffix = 2; GetTriggerPort(errorRecoveryTriggerKey) != null; suffix++) errorRecoveryTriggerKey = "__recover__" + suffix;
            }
            var key = errorRecoveryTriggerKey;
            bool CanRecover() => FailedSdPorts.All(portKey => DataInputPortCollection.GetPort(portKey)?.Type.GetKind() == TypeKind.StructuredDataArray);
            if (GetTriggerPort(key) == null) AddTriggerPort(key, () => {
                if (!CanRecover()) return;
                foreach (var portKey in FailedSdPorts.ToArray()) {
                    try { DataInputPortCollection.GetPort(portKey).SetSerializedValue("[]", Scene, this); }
                    catch (Exception e) { Log.UserError("Could not recover asset " + Name, e); }
                }
                UpdateErrorRecoveryTrigger();
                Broadcast();
            }, new TriggerProperties { label = "RECOVER_ASSET", transient = true });
            GetTriggerPort(key).Properties.disabled = !CanRecover();
        }

        private string errorRecoveryTriggerKey;

        public override void Broadcast() {
            // Do not broadcast if this asset is not added to a scene
            if (Scene == null) {
                return;
            }
            base.Broadcast();
        }
        
        public virtual void OnUserAddToScene() {
        }
    }
}
