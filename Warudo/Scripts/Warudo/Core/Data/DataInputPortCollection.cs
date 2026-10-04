using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Events;
using Vexe.Fast.Reflection;
using Warudo.Core.Scenes;
using Warudo.Core.Graphs;
using Warudo.Core.Plugins;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using Debug = UnityEngine.Debug;

namespace Warudo.Core.Data {
    public class DataInputPortCollection : PortCollection<DataInputPort> {

        public Entity Parent { get; set; }

        public Dictionary<string, SerializedDataInputPort> Serialize() {
            return GetPorts()
                .ToDictionary(it => it.Key, it => it.Value.Serialize());
        }
        
        private readonly Dictionary<string, Dictionary<Guid, ValueChangeWatcher>> valueChangeWatchers = new();
        private readonly Dictionary<string, Dictionary<Guid, AssetStateChangeWatcher>> assetStateChangeWatchers = new();
        private readonly Dictionary<Asset, UnityAction<bool>> assetStateChangeSubscribers = new();

        private record ValueChangeWatcher(Action<object, object> Action, string Owner, bool Deep);

        private record AssetStateChangeWatcher(Action<bool> Action, string Owner);

        public Guid WatchValueChange<T>(string dataInputKey, Action<T, T> onChange, bool deep = true, Guid handle = default) {
            if (dataInputKey == null) {
                throw new Exception("Watching value change on null data input key. Did you use nameof()?");
            }
            var dataInputPort = GetPort(dataInputKey);
            if (dataInputPort == null) {
                throw new Exception($"Data input port {dataInputKey} does not exist");
            }
            if (dataInputPort.Type != typeof(T) && typeof(T) != typeof(object)) {
                throw new Exception($"Data input port {dataInputKey} is not of type {typeof(T).Name}");
            }
            if (!valueChangeWatchers.ContainsKey(dataInputKey)) {
                valueChangeWatchers[dataInputKey] = new();
            }
            SetupWatchedPort(dataInputKey);
            if (handle == default) {
                handle = Guid.NewGuid();
            }
            valueChangeWatchers[dataInputKey].Add(handle,
                new ValueChangeWatcher(
                    (from, to) => onChange((T)(from ?? default(T)), (T)(to ?? default(T))),
                    GetExternalCallerName(),
                    deep));
            // Debug.Log($"Value change watcher registered at {valueChangeWatchers[dataInputKey][handle].Owner} for {dataInputKey}");
            return handle;
        }

        public void UnwatchValueChange(string dataInputKey, Guid handle) {
            var dataInputPort = GetPort(dataInputKey);
            if (dataInputPort == null) return;

            if (dataInputPort is not WatchedDataInputPort) {
                return;
            }
            if (!valueChangeWatchers.ContainsKey(dataInputKey)) {
                return;
            }
            valueChangeWatchers[dataInputKey].Remove(handle);
        }

        public void UnwatchValueChange(Guid handle) {
            foreach (var (portKey, watchers) in valueChangeWatchers) {
                if (watchers.ContainsKey(handle)) {
                    UnwatchValueChange(portKey, handle);
                    return;
                }
            }
        }
        
        public void UnwatchAllValueChanges() {
            foreach (var (portKey, watchers) in valueChangeWatchers) {
                var handles = watchers.Keys.ToList();
                foreach (var handle in handles) {
                    UnwatchValueChange(portKey, handle);
                }
            }
        }
        
        public Guid WatchAssetStateChange(string dataInputKey, Action<bool> onStateChange) {
            var dataInputPort = GetPort(dataInputKey);
            if (dataInputPort == null) {
                throw new Exception($"Data input port {dataInputKey} does not exist");
            }
            if (dataInputPort.Type.GetKind() != TypeKind.Asset) {
                throw new Exception($"Data input port {dataInputKey} is not of asset type");
            }
            if (!assetStateChangeWatchers.ContainsKey(dataInputKey)) {
                assetStateChangeWatchers[dataInputKey] = new();
            }
            SetupWatchedPort(dataInputKey);
            var guid = Guid.NewGuid();
            assetStateChangeWatchers[dataInputKey].Add(
                guid,
                new AssetStateChangeWatcher(onStateChange, GetExternalCallerName()));
            // Debug.Log($"Asset state change watcher registered at {assetStateChangeWatchers[dataInputKey][guid].Owner} for {dataInputKey}");
            return guid;
        }

        public void UnwatchAssetStateChange(string dataInputKey, Guid handle) {
            var dataInputPort = GetPort(dataInputKey);

            if (dataInputPort is not WatchedDataInputPort) {
                return;
            }
            if (!assetStateChangeWatchers.ContainsKey(dataInputKey)) {
                return;
            }
            assetStateChangeWatchers[dataInputKey].Remove(handle);
        }

        public void UnwatchAssetStateChange(Guid handle) {
            foreach (var (portKey, watchers) in assetStateChangeWatchers) {
                if (watchers.ContainsKey(handle)) {
                    UnwatchAssetStateChange(portKey, handle);
                    return;
                }
            }
        }
        
        public void UnwatchAllAssetStateChanges() {
            foreach (var (portKey, watchers) in assetStateChangeWatchers) {
                var handles = watchers.Keys.ToList();
                foreach (var handle in handles) {
                    UnwatchAssetStateChange(portKey, handle);
                }
            }
        }

        private void SetupWatchedPort(string dataInputKey) {
            var dataInputPort = GetPort(dataInputKey);
            if (dataInputPort == null) {
                throw new Exception($"Data input port {dataInputKey} does not exist");
            }
            if (dataInputPort is WatchedDataInputPort) {
                return;
            }

            Ports[dataInputKey] = new WatchedDataInputPort(dataInputPort, async newValue => {
                await UniTask.SwitchToMainThread();

                var currentValue = Ports[dataInputKey].Getter();
                dataInputPort.SetValue(newValue);

                if (!Equals(currentValue, newValue)) {
                    // Unregister previous asset watcher
                    if (dataInputPort.Type.GetKind() == TypeKind.Asset) {
                        var asset = (Asset)currentValue;
                        if (asset != null) {
                            if (assetStateChangeSubscribers.ContainsKey(asset)) {
                                asset.OnActiveStateChange.RemoveListener(assetStateChangeSubscribers[asset]);
                            }
                        }
                    }

                    if (valueChangeWatchers.ContainsKey(dataInputKey)) {
                        NotifyValueWatchers(dataInputKey, currentValue, newValue);
                    }

                    SetupAssetWatcher(newValue);
                }
            });
            SetupAssetWatcher(dataInputPort.Getter());

            void SetupAssetWatcher(object value) {
                if (dataInputPort.Type.GetKind() == TypeKind.Asset) {
                    var asset = (Asset)value;
                    if (asset == null) return;

                    void UnityAction(bool state) {
                        if (assetStateChangeWatchers.ContainsKey(dataInputKey)) {
                            foreach (var watcher in assetStateChangeWatchers[dataInputKey].Values) {
                                try {
                                    watcher.Action(state);
                                } catch (Exception e) {
                                    Log.UserError($"Asset state change watcher registered at {watcher.Owner} for {dataInputKey} throws an exception", e);
                                }
                            }
                        }
                    }

                    assetStateChangeSubscribers[asset] = UnityAction;
                    asset.OnActiveStateChange.AddListener(UnityAction);
                }
            }
        }

        public object GetPortValue(string key) {
            return Ports[key].Getter();
        }

        public T GetPortValue<T>(string key) {
            return (T)GetPortValue(key);
        }

        public void SetPortValue(string key, object value) {
            if (!Ports.ContainsKey(key)) {
                throw new Exception($"Data input port {key} does not exist on entity {Parent.Id}");
            }
            Ports[key].SetValue(value);
        }

        public override void Clear() {
            Ports.Values.ForEach(it => it.Dispose());
            base.Clear();
            valueChangeWatchers.Clear();
            assetStateChangeWatchers.Clear();
            foreach (var (asset, subscriber) in assetStateChangeSubscribers) {
                asset.OnActiveStateChange.RemoveListener(subscriber);
            }
        }

        private string GetExternalCallerName() {
            var stackTrace = new StackTrace();
            for (var i = 0; i < stackTrace.FrameCount; i++) {
                var frame = stackTrace.GetFrame(i);
                var declaringType = frame.GetMethod().ReflectedType;
                if (declaringType != typeof(DataInputPortCollection)
                    && declaringType != typeof(Node)
                    && declaringType != typeof(Asset)
                    && declaringType != typeof(Plugin)) {
                    return declaringType?.Name + "::" + frame.GetMethod().Name;
                }
            }
            return "unknown";
        }

        public SerializedDataInputPort CreateSerializedPort(string path) {
            var port = GetPort(path);
            if (port != null) return port.Serialize();

            if (path.IndexOf('.') < 0) return null;

            var portKey = path[..path.IndexOf('.')];
            port = GetPort(portKey);
            if (port == null) return null;

            var remainingPath = path[(path.IndexOf('.') + 1)..];
            while (remainingPath.Length > 0) {
                var hasAccessor = remainingPath.IndexOf('.') >= 0;
                var remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                if (port.Type.GetKind().IsArray()) {
                    var arrayType = port.Type;
                    var elementType = arrayType.GetElementType()!;
                    var elementPort = port.Serialize();
                    elementPort.type = elementType.FriendlyFullName();
                    elementPort.typeKind = elementType.GetKind();

                    object defaultValue;
                    if (elementType.GetKind() == TypeKind.StructuredData) {
                        defaultValue = (StructuredData)elementType.DelegateForCtor().Invoke(Array.Empty<object>());
                    } else {
                        defaultValue = elementType.IsValueType ? Activator.CreateInstance(elementType, Array.Empty<object>()) : null;
                    }
                    elementPort.defaultValue = DataInputPort.Serialize(elementType, defaultValue);

                    // Try to deserialize the actual value
                    StructuredData sd = null;
                    var array = (Array)port.Getter();
                    if (int.TryParse(remainingPathKey, out var idx)) {
                        if (array.Length <= idx) {
                            Log.UserError($"Array index {idx} out of bounds for {port.Key} in {path}");
                            return null;
                        }
                        if (array.GetValue(idx) is not StructuredData structuredData) return null;
                        sd = structuredData;
                        
                        try {
                            var o = array.GetValue(idx);
                            var serializedValue = DataInputPort.Serialize(elementType, o);
                            elementPort.value = serializedValue;
                        } catch (Exception e) {
                            Log.UserError("Failed to deserialize array element. Using default value.", e);
                            elementPort.value = elementPort.defaultValue;
                        }
                    } else if (remainingPathKey.StartsWith("@")) {
                        var key = remainingPathKey[1..];
                        // Try to find the element by key
                        for (var i = 0; i < array.Length; i++) {
                            var o = array.GetValue(i);
                            if (o is not (StructuredData and IKeyIndexedStructuredData keyedSd) || keyedSd.StructuredDataKey != key) continue;
                            
                            sd = (StructuredData) o;
                            var serializedValue = DataInputPort.Serialize(elementType, sd);
                            elementPort.value = serializedValue;
                        }
                        if (sd == null) {
                            Log.UserError($"Array element with key {key} not found for {port.Key} in {path}");
                            return null;
                        }
                    } else {
                        return null;
                    }
                    
                    if (!hasAccessor) {
                        return elementPort;
                    }
                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];

                    hasAccessor = remainingPath.IndexOf('.') >= 0;
                    remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                    port = sd.DataInputPortCollection.GetPort(remainingPathKey);
                    if (port == null) return null;

                    if (!hasAccessor) {
                        return port.Serialize();
                    }

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                } else if (port.Type.GetKind() == TypeKind.StructuredData) {
                    if (port.Getter() is not StructuredData sd) return null;
                        
                    hasAccessor = remainingPath.IndexOf('.') >= 0;
                    remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                    port = sd.DataInputPortCollection.GetPort(remainingPathKey);
                    if (port == null) return null;

                    if (!hasAccessor) {
                        return port.Serialize();
                    }

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                } else {
                    return null;
                }
            }
            return null;
        }

        public void NotifyValueWatchers(string dataInputKey, object currentValue, object newValue, bool fromNested = false) {
            if (dataInputKey == null || !valueChangeWatchers.ContainsKey(dataInputKey)) return;
            var watchers = valueChangeWatchers[dataInputKey].Values.ToList();
            foreach (var watcher in watchers) {
                if (fromNested && !watcher.Deep) continue;
                try {
                    watcher.Action(currentValue, newValue);
                } catch (Exception e) {
                    Log.UserError($"Value change watcher registered at {watcher.Owner} for {dataInputKey} throws an exception", e);
                }
            }
        }

        public bool SetSerializedValueAtPath(string path, string serializedValue, bool broadcast = false) {
            void SetSerializedValue(DataInputPort port, string value) {
                // Replace structure data IDs with new IDs. Otherwise, these entities will replace the original ones!
                if (port.Type.GetKind() == TypeKind.StructuredData) {
                    value = JsonConvert.DeserializeObject<SerializedStructuredData>(value)
                        .Also(it => it.id = Guid.NewGuid())
                        .Let(JsonConvert.SerializeObject);
                } else if (port.Type.GetKind() == TypeKind.StructuredDataArray) {
                    value = JsonConvert.DeserializeObject<SerializedStructuredData[]>(value)
                        .Also(it => it.ForEach(sd => sd.id = Guid.NewGuid()))
                        .Let(JsonConvert.SerializeObject);
                }
                port.SetSerializedValue(value, Context.OpenedScene, Parent);
            }

            var entity = Parent;
            var port = GetPort(path);
            if (port != null) {
                SetSerializedValue(port, serializedValue);
                if (broadcast) entity.BroadcastDataInput(port.Key);
                return true;
            }

            if (path.IndexOf('.') < 0) {
                Log.UserError("Invalid data path: " + path);
                return false;
            }

            var portKey = path[..path.IndexOf('.')];
            port = GetPort(portKey);
            if (port == null) {
                Log.UserError("Invalid data path: " + path);
                return false;
            }

            var value = port.Getter();
            if (value == null) {
                Log.UserError("Unexpected null value at data path: " + path);
                return false;
            }

            var originalValue = port.ParseSerializedValue(port.SerializeValue(), Context.OpenedScene, Parent);

            var remainingPath = path[(path.IndexOf('.') + 1)..];
            while (remainingPath.Length > 0) {
                var hasAccessor = remainingPath.IndexOf('.') >= 0;
                var remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                if (port.Type.GetKind().IsArray()) {
                    if (port.Getter() is not Array arrayValue) {
                        Log.UserError("Unexpected non-array value at data path: " + path);
                        return false;
                    }

                    if (!hasAccessor) {
                        if (int.TryParse(remainingPathKey, out var index)) {
                            try {
                                arrayValue.SetValue(DataInputPort.Deserialize(arrayValue.GetType().GetElementType()!, port.Key, serializedValue, Context.OpenedScene, Parent), index);
                                if (broadcast) entity.BroadcastDataInput(port.Key);
                                NotifyValueWatchers(portKey, originalValue, value);
                                return true;
                            } catch (Exception e) {
                                Log.Error($"Error while setting array element at index {remainingPathKey} at data path: " + path, e);
                                return false;
                            }
                        }
                        if (remainingPathKey.StartsWith("@")) {
                            var key = remainingPathKey[1..];
                            // Try to find the element by key
                            for (var i = 0; i < arrayValue.Length; i++) {
                                var o = arrayValue.GetValue(i);
                                if (o is not (StructuredData and IKeyIndexedStructuredData keyedSd) || keyedSd.StructuredDataKey != key) continue;
                                
                                try {
                                    arrayValue.SetValue(DataInputPort.Deserialize(arrayValue.GetType().GetElementType()!, port.Key, serializedValue, Context.OpenedScene, Parent), i);
                                    if (broadcast) entity.BroadcastDataInput(port.Key);
                                    NotifyValueWatchers(portKey, originalValue, value);
                                    return true;
                                } catch (Exception e) {
                                    Log.Error($"Error while setting array element with key {key} at data path: " + path, e);
                                    return false;
                                }
                            }
                            Log.UserError($"Array element with key {key} not found for {port.Key} in {path}");
                            return false;
                        }
                        Log.UserError($"Invalid array index {remainingPathKey} for {port.Key} at data path: {path}");
                        return false;
                    }

                    StructuredData sd = null;
                    if (int.TryParse(remainingPathKey, out var idx)) {
                        if (arrayValue.Length <= idx) {
                            Log.UserError($"Array index {idx} out of bounds for {port.Key}");
                            return false;
                        }
                        if (arrayValue.GetValue(idx) is not StructuredData structuredData) return false;
                        sd = structuredData;
                    } else if (remainingPathKey.StartsWith("@")) {
                        var key = remainingPathKey[1..];
                        // Try to find the element by key
                        for (var i = 0; i < arrayValue.Length; i++) {
                            var o = arrayValue.GetValue(i);
                            if (o is not (StructuredData and IKeyIndexedStructuredData keyedSd) || keyedSd.StructuredDataKey != key) continue;
                            
                            sd = (StructuredData) o;
                        }
                        if (sd == null) {
                            Log.UserError($"Array element with key {key} not found for {port.Key} in {path}");
                            return false;
                        }
                    } else {
                        Log.UserError($"Invalid array index {remainingPathKey} for {port.Key} at data path: {path}");
                        return false;
                    }

                    entity = sd;
                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];

                    hasAccessor = remainingPath.IndexOf('.') >= 0;
                    remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                    port = sd.DataInputPortCollection.GetPort(remainingPathKey);
                    if (port == null) {
                        Log.UserError($"Invalid key {remainingPathKey} at data path: " + path);
                        return false;
                    }

                    if (!hasAccessor) {
                        SetSerializedValue(port, serializedValue);
                        if (broadcast) entity.BroadcastDataInput(port.Key);
                        NotifyValueWatchers(portKey, originalValue, value);
                        return true;
                    }

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                } else if (port.Type.GetKind() == TypeKind.StructuredData) {
                    if (port.Getter() is not StructuredData sd) return false;
                    entity = sd;
                        
                    hasAccessor = remainingPath.IndexOf('.') >= 0;
                    remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                    port = sd.DataInputPortCollection.GetPort(remainingPathKey);
                    if (port == null) {
                        Log.UserError($"Invalid key {remainingPathKey} at data path: " + path);
                        return false;
                    }

                    if (!hasAccessor) {
                        SetSerializedValue(port, serializedValue);
                        if (broadcast) entity.BroadcastDataInput(port.Key);
                        NotifyValueWatchers(portKey, originalValue, value);
                        return true;
                    }

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                } else {
                    SetSerializedValue(port, serializedValue);
                    if (broadcast) entity.BroadcastDataInput(port.Key);
                    NotifyValueWatchers(portKey, originalValue, value);
                    return true;
                }
            }
            Log.UserError("Invalid data path: " + path);
            return false;
        }
        
        // Note: Will NOT trigger change event if the value is the same object
        public bool SetValueAtPath(string path, object value, bool broadcast = false) {
            var entity = Parent;
            var port = GetPort(path);
            if (port != null) {
                port.SetValue(value);
                if (broadcast) entity.BroadcastDataInput(path);
                return true;
            }

            if (path.IndexOf('.') < 0) {
                Log.UserError("Invalid data path: " + path);
                return false;
            }

            var portKey = path[..path.IndexOf('.')];
            port = GetPort(portKey);
            if (port == null) {
                Log.UserError("Invalid data path: " + path);
                return false;
            }

            var obj = port.Getter();
            var originalValue = port.Getter();
            
            var remainingPath = path[(path.IndexOf('.') + 1)..];
            while (remainingPath.Length > 0) {
                var hasAccessor = remainingPath.IndexOf('.') >= 0;
                var remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                if (port.Type.GetKind().IsArray()) {
                    if (port.Getter() is not Array arrayValue) {
                        Log.UserError("Unexpected non-array value at data path: " + path);
                        return false;
                    }

                    if (!hasAccessor) {
                        if (int.TryParse(remainingPathKey, out var index)) {
                            try {
                                arrayValue.SetValue(value, index);
                                if (broadcast) entity.BroadcastDataInput(port.Key);
                                NotifyValueWatchers(portKey, originalValue, obj);
                                return true;
                            } catch (Exception e) {
                                Log.Error($"Error while setting array element at index {remainingPathKey} at data path: " + path, e);
                                return false;
                            }
                        }
                        if (remainingPathKey.StartsWith("@")) {
                            var key = remainingPathKey[1..];
                            for (var i = 0; i < arrayValue.Length; i++) {
                                var o = arrayValue.GetValue(i);
                                if (o is not (StructuredData and IKeyIndexedStructuredData keyedSd) || keyedSd.StructuredDataKey != key) continue;
                                try {
                                    arrayValue.SetValue(value, i);
                                    if (broadcast) entity.BroadcastDataInput(port.Key);
                                    NotifyValueWatchers(portKey, originalValue, obj);
                                    return true;
                                } catch (Exception e) {
                                    Log.Error($"Error while setting array element at index {key} at data path: " + path, e);
                                    return false;
                                }
                            }
                            Log.UserError($"Array element with key {key} not found for {port.Key} in {path}");
                            return false;
                        }
                        Log.UserError($"Invalid array index {remainingPathKey} at data path: " + path);
                        return false;
                    }

                    StructuredData sd = null;
                    if (int.TryParse(remainingPathKey, out var idx)) {
                        if (arrayValue.Length <= idx) {
                            Log.UserError($"Array index {idx} out of bounds for {port.Key}");
                            return false;
                        }
                        if (arrayValue.GetValue(idx) is not StructuredData structuredData) return false;
                        sd = structuredData;
                    } else if (remainingPathKey.StartsWith("@")) {
                        var key = remainingPathKey[1..];
                        // Try to find the element by key
                        for (var i = 0; i < arrayValue.Length; i++) {
                            var o = arrayValue.GetValue(i);
                            if (o is not (StructuredData and IKeyIndexedStructuredData keyedSd) || keyedSd.StructuredDataKey != key) continue;
                            
                            sd = (StructuredData) o;
                        }
                        if (sd == null) {
                            Log.UserError($"Array element with key {key} not found for {port.Key} in {path}");
                            return false;
                        }
                    } else {
                        Log.UserError($"Invalid array index {remainingPathKey} for {port.Key} at data path: {path}");
                        return false;
                    }
                    
                    entity = sd;

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];

                    hasAccessor = remainingPath.IndexOf('.') >= 0;
                    remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                    port = sd.DataInputPortCollection.GetPort(remainingPathKey);
                    if (port == null) {
                        Log.UserError($"Invalid key {remainingPathKey} at data path: " + path);
                        return false;
                    }

                    if (!hasAccessor) {
                        port.SetValue(value);
                        if (broadcast) entity.BroadcastDataInput(port.Key);
                        NotifyValueWatchers(portKey, originalValue, obj);
                        return true;
                    }

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                } else if (port.Type.GetKind() == TypeKind.StructuredData) {
                    if (port.Getter() is not StructuredData sd) return false;
                    entity = sd;
                        
                    hasAccessor = remainingPath.IndexOf('.') >= 0;
                    remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                    port = sd.DataInputPortCollection.GetPort(remainingPathKey);
                    if (port == null) {
                        Log.UserError($"Invalid key {remainingPathKey} at data path: " + path);
                        return false;
                    }

                    if (!hasAccessor) {
                        port.SetValue(value);
                        if (broadcast) entity.BroadcastDataInput(port.Key);
                        NotifyValueWatchers(portKey, originalValue, obj);
                        return true;
                    }

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                } else {
                    port.SetValue(value);
                    if (broadcast) entity.BroadcastDataInput(port.Key);
                    NotifyValueWatchers(portKey, originalValue, obj);
                    return true;
                }
            }
            Log.UserError("Invalid data path: " + path);
            return false;
        }
        
        public object GetValueAtPath(string path) {
            var port = GetPort(path);
            if (port != null) {
                return port.Getter();
            }

            if (path.IndexOf('.') < 0) {
                Log.UserError("Invalid data path: " + path);
                return null;
            }

            var portKey = path[..path.IndexOf('.')];
            port = GetPort(portKey);
            if (port == null) {
                Log.UserError("Invalid data path: " + path);
                return null;
            }

            var remainingPath = path[(path.IndexOf('.') + 1)..];
            while (remainingPath.Length > 0) {
                var hasAccessor = remainingPath.IndexOf('.') >= 0;
                var remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                if (port.Type.GetKind().IsArray()) {
                    if (port.Getter() is not Array arrayValue) {
                        Log.UserError("Unexpected non-array value at data path: " + path);
                        return null;
                    }

                    if (!hasAccessor) {
                        if (int.TryParse(remainingPathKey, out var index)) {
                            try {
                                return arrayValue.GetValue(index);
                            } catch (Exception e) {
                                Log.UserError($"Error while getting array element at index {remainingPathKey} at data path: " + path, e);
                                return null;
                            }
                        }
                        if (remainingPathKey.StartsWith("@")) {
                            var key = remainingPathKey[1..];
                            // Try to find the element by key
                            for (var i = 0; i < arrayValue.Length; i++) {
                                var o = arrayValue.GetValue(i);
                                if (o is not (StructuredData and IKeyIndexedStructuredData keyedSd) || keyedSd.StructuredDataKey != key) continue;
                                return o;
                            }
                            Log.UserError($"Array element with key {key} not found for {port.Key} in {path}");
                            return null;
                        }
                        Log.UserError($"Invalid array index {remainingPathKey} for {port.Key} at data path: {path}");
                        return null;
                    }

                    StructuredData sd = null;

                    if (int.TryParse(remainingPathKey, out var idx)) {
                        if (arrayValue.Length <= idx) {
                            Log.UserError($"Array index {idx} out of bounds for {port.Key}");
                            return null;
                        }
                        if (arrayValue.GetValue(idx) is not StructuredData structuredData) return null;
                        sd = structuredData;
                    } else if (remainingPathKey.StartsWith("@")) {
                        var key = remainingPathKey[1..];
                        // Try to find the element by key
                        for (var i = 0; i < arrayValue.Length; i++) {
                            var o = arrayValue.GetValue(i);
                            if (o is not (StructuredData and IKeyIndexedStructuredData keyedSd) || keyedSd.StructuredDataKey != key) continue;
                            sd = (StructuredData) o;
                            break;
                        }
                        if (sd == null) {
                            Log.UserError($"Array element with key {key} not found for {port.Key} in {path}");
                            return null;
                        }
                    } else {
                        Log.UserError($"Invalid array index {remainingPathKey} for {port.Key} at data path: {path}");
                        return null;
                    }
                    
                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];

                    hasAccessor = remainingPath.IndexOf('.') >= 0;
                    remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                    port = sd.DataInputPortCollection.GetPort(remainingPathKey);
                    if (port == null) {
                        Log.UserError($"Invalid key {remainingPathKey} at data path: " + path);
                        return null;
                    }

                    if (!hasAccessor) {
                        return port.Getter();
                    }

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                } else if (port.Type.GetKind() == TypeKind.StructuredData) {
                    if (port.Getter() is not StructuredData sd) return null;
                        
                    hasAccessor = remainingPath.IndexOf('.') >= 0;
                    remainingPathKey = remainingPath[..(hasAccessor ? remainingPath.IndexOf('.') : remainingPath.Length)];
                    port = sd.DataInputPortCollection.GetPort(remainingPathKey);
                    if (port == null) {
                        Log.UserError($"Invalid key {remainingPathKey} at data path: " + path);
                        return null;
                    }

                    if (!hasAccessor) {
                        return port.Getter();
                    }

                    remainingPath = remainingPath[(remainingPath.IndexOf('.') + 1)..];
                } else {
                    return port.Getter();
                }
            }
            Log.UserError("Invalid data path: " + path);
            return null;
        }
    }
}
