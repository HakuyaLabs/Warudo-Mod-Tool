using System;
using UMod;
using UnityEngine;
using Warudo.Core.Data;
using Warudo.Core.Persistence;
using Warudo.Core.Scenes;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Plugins {
    public abstract class Plugin : BehavioralEntity<PluginTypeMeta, SerializedPlugin> {
        public virtual void OnApplicationQuit() {
        }

        public string PluginId => GetTypeMeta().PluginType.id;

        public ModHost ModHost { get; set; }

        protected PluginPersistentDataManager PersistentData { get; private set; }
        
        internal void SetPluginPersistentDataManager(PluginPersistentDataManager manager) {
            PersistentData = manager ?? throw new ArgumentNullException(nameof(manager));
        }
        
        public override bool CanReceiveEvents => true;

        public override bool ShouldEvaluateClientFunctions => base.ShouldEvaluateClientFunctions && Context.PluginManager.GetSelectedPlugin() == this;

        public override PluginTypeMeta GetTypeMeta() {
            return Context.PluginTypeRegistry.GetTypeMeta(GetType()) ?? throw new Exception($"{GetType()} is not registered as an plugin type");
        }

        protected override void Define(PluginTypeMeta meta) {
            Define(meta.DataInputs, meta.Triggers, meta.Mixins, this);
        }

        public override SerializedPlugin Serialize() {
            return new SerializedPlugin {
                id = Id,
                type = Context.PluginTypeRegistry.GetTypeMeta(GetType()).PluginType,
                version = GetVersion(),
                dataInputs = DataInputPortCollection.Serialize(),
                triggers = TriggerPortCollection.Serialize()
            };
        }

        public override void Deserialize(SerializedPlugin serialized) {
            Store(serialized.id);
            if (serialized.version != GetVersion()) {
                Debug.Log($"Plugin {GetType().Name} was serialized with version {serialized.version} but current version is {GetVersion()}. There may be compatibility issues.");
            }
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

                        port.SetSerializedValue(serializedPort.value, null, this);
                    } catch (Exception e) {
                        Log.UserError($"Failed to set data input port value for plugin {GetType().Name}::{port.Key} = {serializedPort.value}", e);
                    }
                }
            }
        }

        public virtual FeatureStatusData[] GetFeatureStatusData() {
            return Array.Empty<FeatureStatusData>();
        }

        public virtual void OneTimeSetup() {
        }

        public virtual void OnSceneLoaded(Scene scene, SerializedScene serializedScene) {
        }
        
        public virtual void OnSceneUnloaded(Scene scene) {
        }
        
        public virtual void OnMessageReceived(string action, string payload) {
        }
            
    }

    public abstract class Plugin<TSceneData> : Plugin, IUseSceneData where TSceneData : new() {

        public TSceneData SceneData => Context.OpenedScene.GetPluginData<TSceneData>(PluginId);

        Type IUseSceneData.SceneDataType => typeof(TSceneData);

    }
    
    internal interface IUseSceneData {
        
        internal Type SceneDataType { get; }
        
    }

    [Serializable]
    public class FeatureStatusData
    {
        public string Name;
        public FeatureStatus Status;
        public FeatureStatusData(string name, FeatureStatus status)
        {
            Name = name;
            Status = status;
        }
    }

    public enum FeatureStatus
    {
        NOT_CHECKED, VALID, INVALID
    }
}
