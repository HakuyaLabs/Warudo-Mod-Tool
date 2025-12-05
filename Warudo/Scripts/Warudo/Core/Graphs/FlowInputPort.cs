using System;
using System.Reflection;
using Vexe.Fast.Reflection;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Graphs {
	public sealed record FlowInputPort(string Key, Func<Continuation> GetContinuation, FlowInputProperties Properties) : Port(Key, Properties) {
		public SerializedFlowInputPort Serialize() {
			return new SerializedFlowInputPort {
				key = Key,
				properties = Properties.Clone()
			};
		}

		public static FlowInputPort CreateFlowInputPortFromReflectionMeta(ReflectedFlowInputPortMeta meta, object target) {
			var flowInputMethod = meta.MethodInfo;
			var properties = meta.Properties;
			
			var invoker = flowInputMethod.DelegateForCall();
			return new FlowInputPort(flowInputMethod.Name, () => (Continuation)invoker(target, null), properties.Clone());
		}
		
		public static ReflectedFlowInputPortMeta GetReflectionMeta(MethodInfo methodInfo) {
			if (!methodInfo.HasCustomAttribute<FlowInputAttribute>()) return null;
			if (methodInfo.ReturnType != typeof(Continuation)) {
				throw new Exception($"{methodInfo.DeclaringType?.Name}::{methodInfo.Name} is marked as flow input but does not return a Continuation");
			}
			
			var label = methodInfo.GetCustomAttribute<LabelAttribute>()?.Label ?? methodInfo.Name.ToSpacedPascalCase();
			if (methodInfo.HasCustomAttribute<HideLabelAttribute>()) label = "";
			if (label == "Enter") {
				label = "ENTER";
			} else if (label == "Exit") {
				label = "EXIT";
			}
			var description = methodInfo.GetCustomAttribute<DescriptionAttribute>()?.Description;
			var sectionTitle = methodInfo.GetCustomAttribute<SectionAttribute>()?.Title;
			
			var properties = new FlowInputProperties {
				order = methodInfo.GetCustomAttribute<FlowInputAttribute>().Order,
				label = label, 
				description = description,
				sectionTitle = sectionTitle
			};
					
			return new ReflectedFlowInputPortMeta(methodInfo, properties);
		}
	}
	
	public record ReflectedFlowInputPortMeta(MethodInfo MethodInfo, FlowInputProperties Properties);
}
