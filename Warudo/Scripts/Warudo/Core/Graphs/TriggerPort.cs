using System;
using System.Reflection;
using Vexe.Fast.Reflection;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Graphs {
	public sealed record TriggerPort(string Key, Action OnTrigger, TriggerProperties Properties) : Port(Key, Properties) {
		public SerializedTriggerPort Serialize() {
			return new SerializedTriggerPort {
				key = Key,
				properties = Properties.Clone()
			};
		}

		public void Dispose() {
		}

		public static TriggerPort CreateTriggerPortFromReflectionMeta(ReflectedTriggerPortMeta meta, object methodProvider) {
			var triggerMethod = meta.MethodInfo;
			var properties = meta.Properties.Clone();

			var invoker = triggerMethod.DelegateForCall();
			void OnTrigger() => invoker(methodProvider, null);

			var triggerPort = new TriggerPort(triggerMethod.Name, OnTrigger, properties);

			return triggerPort;
		}
		
		public static ReflectedTriggerPortMeta GetReflectionMeta(MethodInfo methodInfo) {
			if (!methodInfo.HasCustomAttribute<TriggerAttribute>()) return null;
			var methodProviderType = methodInfo.ReflectedType;
			if (methodProviderType == null) {
				throw new Exception("Auto complete source type is null");
			}
			
			var label = methodInfo.GetCustomAttribute<LabelAttribute>()?.Label ?? methodInfo.Name.ToSpacedPascalCase();
			if (methodInfo.HasCustomAttribute<HideLabelAttribute>()) label = "";
			var description = methodInfo.GetCustomAttribute<DescriptionAttribute>()?.Description;
			var sectionTitle = methodInfo.GetCustomAttribute<SectionAttribute>()?.Title;

			var properties = new TriggerProperties {
				order = methodInfo.GetCustomAttribute<TriggerAttribute>().Order,
				hidden = methodInfo.HasCustomAttribute<HiddenAttribute>(),
				disabled = methodInfo.HasCustomAttribute<DisabledAttribute>(),
				label = label, 
				description = description,
				sectionTitle = sectionTitle,
				alwaysHidden = methodInfo.HasCustomAttribute<HiddenAttribute>(),
				alwaysDisabled = methodInfo.HasCustomAttribute<DisabledAttribute>()
			};
					
			MethodInfo hiddenIfMethodInfo = null;
			if (methodInfo.HasCustomAttribute<HiddenIfAttribute>()) {
				var methodName = methodInfo.GetCustomAttribute<HiddenIfAttribute>().MethodName;
				if (methodName != null) {
					hiddenIfMethodInfo = methodProviderType.GetProvidingMethod<bool>(methodName);
				}
			}
			
			MethodInfo disabledIfMethodInfo = null;
			if (methodInfo.HasCustomAttribute<DisabledIfAttribute>()) {
				var methodName = methodInfo.GetCustomAttribute<DisabledIfAttribute>().MethodName;
				if (methodName != null) {
					disabledIfMethodInfo = methodProviderType.GetProvidingMethod<bool>(methodName);
				}
			}
			
			MethodInfo sectionHiddenIfMethodInfo = null;
			if (methodInfo.HasCustomAttribute<SectionHiddenIfAttribute>()) {
				var methodName = methodInfo.GetCustomAttribute<SectionHiddenIfAttribute>().MethodName;
				if (methodName != null) {
					sectionHiddenIfMethodInfo = methodProviderType.GetProvidingMethod<bool>(methodName);
				}
			}
			return new ReflectedTriggerPortMeta(methodInfo, properties, methodInfo.GetCustomAttribute<HiddenIfAttribute>(), hiddenIfMethodInfo, methodInfo.GetCustomAttribute<DisabledIfAttribute>(), disabledIfMethodInfo,
				methodInfo.GetCustomAttribute<SectionHiddenIfAttribute>(), sectionHiddenIfMethodInfo);
		}
	}

	public record ReflectedTriggerPortMeta(
		MethodInfo MethodInfo,
		TriggerProperties Properties,
		HiddenIfAttribute HiddenIfAttribute,
		MethodInfo HiddenIfMethodInfo,
		DisabledIfAttribute DisabledIfAttribute,
		MethodInfo DisabledIfMethodInfo,
		SectionHiddenIfAttribute SectionHiddenIfAttribute,
		MethodInfo SectionHiddenIfMethodInfo);
}
