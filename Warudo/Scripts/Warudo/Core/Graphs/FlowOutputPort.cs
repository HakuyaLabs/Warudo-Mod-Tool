using System;
using System.Reflection;
using Vexe.Fast.Reflection;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Graphs {
	public sealed record FlowOutputPort(string Key, Func<Continuation> GetContinuation, Action<Continuation> SetContinuation, FlowOutputProperties Properties) : Port(Key, Properties) {
		public SerializedFlowOutputPort Serialize() {
			return new SerializedFlowOutputPort {
				key = Key,
				properties = Properties.Clone()
			};
		}

		public static FlowOutputPort CreateFlowOutputPortFromReflectionMeta(ReflectedFlowOutputPortMeta meta, object target) {
			var flowOutputField = meta.FieldInfo;
			var properties = meta.Properties;
			var getter = flowOutputField.DelegateForGet();
			var setter = flowOutputField.DelegateForSet();
			var port = new FlowOutputPort(
				flowOutputField.Name,
				() => (Continuation)getter.Invoke(target),
				continuation => setter.Invoke(ref target, continuation),
				properties.Clone());
			return port;
		}

		public static ReflectedFlowOutputPortMeta GetReflectionMeta(FieldInfo fieldInfo) {
			if (!fieldInfo.HasCustomAttribute<FlowOutputAttribute>()) return null;
			if (fieldInfo.FieldType != typeof(Continuation)) {
				throw new Exception($"{fieldInfo.DeclaringType?.Name}::{fieldInfo.Name} is marked as flow output but is not of type Continuation");
			}
			
			var label = fieldInfo.GetCustomAttribute<LabelAttribute>()?.Label ?? fieldInfo.Name.ToSpacedPascalCase();
			if (fieldInfo.HasCustomAttribute<HideLabelAttribute>()) label = "";
			if (label == "Enter") {
				label = "ENTER";
			} else if (label == "Exit") {
				label = "EXIT";
			}
			var description = fieldInfo.GetCustomAttribute<DescriptionAttribute>()?.Description;
			var sectionTitle = fieldInfo.GetCustomAttribute<SectionAttribute>()?.Title;
			
			var properties = new FlowOutputProperties {
				order = fieldInfo.GetCustomAttribute<FlowOutputAttribute>().Order,
				label = label, 
				description = description, 
				sectionTitle = sectionTitle
			};

			return new ReflectedFlowOutputPortMeta(fieldInfo, properties);
		}
	}
	
	public record ReflectedFlowOutputPortMeta(FieldInfo FieldInfo, FlowOutputProperties Properties);
}
