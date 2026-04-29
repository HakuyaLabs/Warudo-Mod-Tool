using System;
using System.Reflection;
using Vexe.Fast.Reflection;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Graphs {
	public sealed record DataOutputPort(string Key, Type Type, Func<object> ComputedValue, DataOutputProperties Properties) : Port(Key, Properties) {
		public SerializedDataOutputPort Serialize() {
			return new SerializedDataOutputPort {
				key = Key,
				type = Type.FriendlyFullName(),
				properties = Properties.Clone()
			};
		}

		public static DataOutputPort CreateDataOutputPortFromReflectionMeta(ReflectedDataOutputPortMeta meta, object target) {
			var dataOutputMethod = meta.MethodInfo;
			var properties = meta.Properties;
			
			var invoker = dataOutputMethod.DelegateForCall();
			return new DataOutputPort(dataOutputMethod.Name, dataOutputMethod.ReturnType, () => invoker(target, null), properties.Clone());
		}
		
		public static ReflectedDataOutputPortMeta GetReflectionMeta(MethodInfo methodInfo, Type methodProviderType = null) {
			if (methodProviderType == null) {
				methodProviderType = methodInfo.ReflectedType;
				if (methodProviderType == null) {
					throw new Exception("Method provider type is null");
				}
			}
			
			if (!methodInfo.HasCustomAttribute<DataOutputAttribute>()) return null;
			
			var label = methodInfo.GetCustomAttribute<LabelAttribute>()?.Label ?? methodInfo.Name.ToSpacedPascalCase();
			if (methodInfo.HasCustomAttribute<HideLabelAttribute>()) label = "";
			var description = methodInfo.GetCustomAttribute<DescriptionAttribute>()?.Description;
			var sectionTitle = methodInfo.GetCustomAttribute<SectionAttribute>()?.Title;
				
			var properties = new DataOutputProperties {
				order = methodInfo.GetCustomAttribute<DataOutputAttribute>().Order,
				label = label,
				description = description, 
				sectionTitle = sectionTitle
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

			return new ReflectedDataOutputPortMeta(
				methodInfo,
				properties,
				methodInfo.GetCustomAttribute<HiddenIfAttribute>(),
				hiddenIfMethodInfo,
				methodInfo.GetCustomAttribute<DisabledIfAttribute>(),
				disabledIfMethodInfo);
		}
	}
	
	public record ReflectedDataOutputPortMeta(
		MethodInfo MethodInfo,
		DataOutputProperties Properties,
		HiddenIfAttribute HiddenIfAttribute,
		MethodInfo HiddenIfMethodInfo, 
		DisabledIfAttribute DisabledIfAttribute,
		MethodInfo DisabledIfMethodInfo);
}
