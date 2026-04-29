using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;

namespace Warudo.Core.Data {
    public class Mixin {

        protected Entity Owner { get; set; }

        public virtual void OnCreate() {
        }

        public virtual void OnDestroy() {
        }

        public ReflectedMixinMeta GetMixinMeta() {
            var fieldInfo = Owner.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.FieldType == this.GetType() && fi.GetValue(Owner) == this);
            if (fieldInfo == null) {
                throw new Exception($"Could not find field info for mixin of type {this.GetType().Name} in owner entity of type {Owner.GetType().Name}");
            }
            return Mixin.GetReflectionMeta(fieldInfo);
        }
        
        public static Mixin CreateMixinFromReflectionMeta(ReflectedMixinMeta reflectedMixinMeta, Entity owner, out List<(DataInputPort, ReflectedDataInputPortMeta)> createdDataInputPorts, out List<(TriggerPort, ReflectedTriggerPortMeta)> createdTriggerPorts) {
            createdDataInputPorts = new List<(DataInputPort, ReflectedDataInputPortMeta)>();
            createdTriggerPorts = new List<(TriggerPort, ReflectedTriggerPortMeta)>();
            
            var mixin = (Mixin) Activator.CreateInstance(reflectedMixinMeta.FieldInfo.FieldType);
            mixin.Owner = owner;

            reflectedMixinMeta.FieldInfo.SetValue(owner, mixin);

            foreach (var portMeta in reflectedMixinMeta.DataInputs) {
                var port = DataInputPort.CreateDataInputPortFromReflectionMeta(portMeta, mixin, mixin, owner, Context.OpenedScene);
                port.Properties.order = reflectedMixinMeta.Attribute.Order + port.Properties.order / 10000f;
                owner.DataInputPortCollection.AddPort(port);
                createdDataInputPorts.Add((port, portMeta));
            }
            foreach (var portMeta in reflectedMixinMeta.Triggers) {
                var port = TriggerPort.CreateTriggerPortFromReflectionMeta(portMeta, mixin);
                port.Properties.order = reflectedMixinMeta.Attribute.Order + port.Properties.order / 10000f;
                owner.TriggerPortCollection.AddPort(port);
                createdTriggerPorts.Add((port, portMeta));
            }
            
            return mixin;
        }
        
        public static ReflectedMixinMeta GetReflectionMeta(FieldInfo fieldInfo) {
			if (!fieldInfo.HasCustomAttribute<MixinAttribute>()) return null;
            var dataInputs = new List<ReflectedDataInputPortMeta>();
            foreach (var dataFieldInfo in fieldInfo.FieldType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
                var dataInputPortTypeMeta = DataInputPort.GetReflectionMeta(dataFieldInfo);
                if (dataInputPortTypeMeta != null) {
                    dataInputs.Add(dataInputPortTypeMeta);
                }
            }
            var triggers = new List<ReflectedTriggerPortMeta>();
            foreach (var methodInfo in fieldInfo.FieldType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
                var triggerPortTypeMeta = TriggerPort.GetReflectionMeta(methodInfo);
                if (triggerPortTypeMeta != null) {
                    triggers.Add(triggerPortTypeMeta);
                }
            }
            MethodInfo hiddenIfMethodInfo = null;
            MethodInfo disabledIfMethodInfo = null;
            if (fieldInfo.HasCustomAttribute<HiddenIfAttribute>()) {
                var methodName = fieldInfo.GetCustomAttribute<HiddenIfAttribute>().MethodName;
                if (methodName != null) {
                    hiddenIfMethodInfo = fieldInfo.DeclaringType.GetProvidingMethod<bool>(methodName);
                }
            }
            if (fieldInfo.HasCustomAttribute<DisabledIfAttribute>()) {
                var methodName = fieldInfo.GetCustomAttribute<DisabledIfAttribute>().MethodName;
                if (methodName != null) {
                    disabledIfMethodInfo = fieldInfo.DeclaringType.GetProvidingMethod<bool>(methodName);
                }
            }
            return new ReflectedMixinMeta(
				fieldInfo,
				fieldInfo.GetCustomAttribute<MixinAttribute>(),
                dataInputs,
                triggers,
                fieldInfo.GetCustomAttribute<HiddenIfAttribute>(),
                hiddenIfMethodInfo,
                fieldInfo.GetCustomAttribute<DisabledIfAttribute>(),
                disabledIfMethodInfo,
                fieldInfo.GetCustomAttribute<TypeIdFilterAttribute>());
        }

    }

    public class BehavioralMixin : Mixin {

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

    public record ReflectedMixinMeta(
        FieldInfo FieldInfo,
        MixinAttribute Attribute,
        List<ReflectedDataInputPortMeta> DataInputs,
        List<ReflectedTriggerPortMeta> Triggers,
        HiddenIfAttribute HiddenIfAttribute,
        MethodInfo HiddenIfMethodInfo,
        DisabledIfAttribute DisabledIfAttribute,
        MethodInfo DisabledIfMethodInfo,
        TypeIdFilterAttribute TypeIdFilterAttribute);
}
