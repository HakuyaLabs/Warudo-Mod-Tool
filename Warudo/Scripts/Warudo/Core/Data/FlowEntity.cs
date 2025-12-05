using System;
using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Data {
    public abstract class FlowEntity<TMeta, TSerialized> : BehavioralEntity<TMeta, TSerialized>, IFlowEntity where TSerialized : SerializedEntity {

        public DataOutputPortCollection DataOutputPortCollection { get; } = new();
        public FlowInputPortCollection FlowInputPortCollection { get; } = new();
        public FlowOutputPortCollection FlowOutputPortCollection { get; } = new();
        
        protected void Define(List<ReflectedDataOutputPortMeta> dataOutputPorts, List<ReflectedFlowInputPortMeta> flowInputPorts, List<ReflectedFlowOutputPortMeta> flowOutputPorts) {
            foreach (var portMeta in dataOutputPorts) {
                var port = DataOutputPort.CreateDataOutputPortFromReflectionMeta(portMeta, this);
                DataOutputPortCollection.AddPort(port);
                SetupPredicateAttribute(port.Key, portMeta.HiddenIfAttribute, portMeta.HiddenIfMethodInfo, this, () => port.Properties.hidden, v => port.Properties.hidden = v, _ => BroadcastDataOutputProperties(port.Key));
                SetupPredicateAttribute(port.Key, portMeta.DisabledIfAttribute, portMeta.DisabledIfMethodInfo, this, () => port.Properties.disabled, v => port.Properties.disabled = v, _ => BroadcastDataOutputProperties(port.Key));
            }
            foreach (var portMeta in flowInputPorts) {
                FlowInputPortCollection.AddPort(FlowInputPort.CreateFlowInputPortFromReflectionMeta(portMeta, this));
            }
            foreach (var portMeta in flowOutputPorts) {
                FlowOutputPortCollection.AddPort(FlowOutputPort.CreateFlowOutputPortFromReflectionMeta(portMeta, this));
            }
        }
        
        public virtual DataOutputPort AddDataOutputPort(string key, Type type, Func<object> valueComputer, DataOutputProperties properties = null) {
            properties ??= new DataOutputProperties {
                label = key.ToSpacedPascalCase(),
                order = DataOutputPortCollection.GetPorts().Max(p => p.Value.Properties.order) + 1
            };
            var port = new DataOutputPort(key, type, valueComputer, properties.Clone());
            DataOutputPortCollection.AddPort(port);
            return port;
        }
        
        public virtual DataOutputPort AddDataOutputPort<T>(string key, Func<T> valueComputer, DataOutputProperties properties = null) {
            return AddDataOutputPort(key, typeof(T), () => valueComputer(), properties);
        }

        public virtual FlowInputPort AddFlowInputPort(string key, Func<string> outputGetter, FlowInputProperties properties = null) {
            properties ??= new FlowInputProperties {
                label = key.ToSpacedPascalCase(),
                order = FlowInputPortCollection.GetPorts().Max(p => p.Value.Properties.order) + 1
            };
            var port = new FlowInputPort(key, () => FlowOutputPortCollection.GetPort(outputGetter()).GetContinuation(), properties.Clone());
            FlowInputPortCollection.AddPort(port);
            return port;
        }

        public virtual FlowOutputPort AddFlowOutputPort(string key, FlowOutputProperties properties = null) {
            properties ??= new FlowOutputProperties {
                label = key.ToSpacedPascalCase(),
                order = FlowOutputPortCollection.GetPorts().Max(p => p.Value.Properties.order) + 1
            };
            Continuation cont = null;
            var port = new FlowOutputPort(key, () => cont, v => cont = v, properties.Clone());
            FlowOutputPortCollection.AddPort(port);
            return port;
        }

        public DataOutputPort GetDataOutputPort(string key) {
            return DataOutputPortCollection.GetPort(key);
        }
        
        public void BroadcastDataOutputProperties(string key) {
            if (key == null) {
                Log.Error("Attempting to broadcast data output port with null key. Did you use nameof()?");
                return;
            }
            var port = DataOutputPortCollection.GetPort(key);
            if (port == null) {
                Log.Error("Attempting to broadcast data output port with unknown key: " + key + ". Did you use nameof()?");
                return;
            }
            Context.ServiceMessageQueue.QueueEntityDataOutputProperties(this, key);
        }
        
        public override void Destroy() {
            base.Destroy();
            DataOutputPortCollection.Clear();
            FlowInputPortCollection.Clear();
            FlowOutputPortCollection.Clear();
        }

    }

    public interface IFlowEntity {

        Guid Id { get; }
        
        DataOutputPort GetDataOutputPort(string key);

    }
}
