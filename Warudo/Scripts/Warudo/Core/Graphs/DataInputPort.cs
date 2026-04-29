using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Vexe.Fast.Reflection;
using Warudo.Core.Scenes;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Resource;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Graphs {
	public record DataInputPort(string Key, Type Type, string DefaultValue, Func<object> Getter, Action<object> Setter, DataInputProperties Properties, Action<object> StructuredDataInitializer) : Port(Key, Properties) {

		private object valueRef;
		
		public string SerializeValue() => Serialize(Type, Getter());
		
		public string SerializeArrayElement(int index) {
			if (!Type.GetKind().IsArray()) {
				throw new Exception($"Cannot serialize element for non-array type {Type}");
			}
			var array = (Array) Getter();
			if (index < 0 || index >= array.Length) {
				throw new Exception($"Index {index} out of bounds for array of length {array.Length}");
			}
			return Serialize(Type.GetElementType()!, array.GetValue(index));
		}

		public object AppendArray(Scene scene, Entity structuredDataParent) {
			var el = Type.GetKind() switch {
				TypeKind.EnumArray => Type.GetElementType()!.GetEnumValues().GetValue(0),
				TypeKind.ValueArray => Type.GetElementType()! == typeof(string) ? "" : Activator.CreateInstance(Type.GetElementType()!),
				TypeKind.AssetArray => null,
				TypeKind.StructuredDataArray => null,
				_ => throw new Exception($"Cannot append default element for non-array type {Type}")
			};
			if (Type.GetKind() == TypeKind.StructuredDataArray) {
				var sd = Context.StructuredDataTypeRegistry.CreateEntity(Type.GetElementType()!);
				sd.Scene = scene;
				sd.PortKey = Key;
				sd.Parent = structuredDataParent;
				StructuredDataInitializer?.Invoke(sd);
				el = sd;
			}
			AddArrayElement(el);
			return el;
		}

		public void SetArrayElement(int index, object element) {
			if (!Type.GetKind().IsArray()) {
				throw new Exception($"Cannot set element for non-array type {Type}");
			}
			var array = (Array) Getter();
			if (index >= array.Length) {
				throw new Exception($"Cannot set element at index {index} for array of length {array.Length}");
			}
			var newArray = Array.CreateInstance(Type.GetElementType()!, array.Length);
			Array.Copy(array, newArray, array.Length);
			newArray.SetValue(element, index);
			SetValue(newArray);
		}
		
		public object SetSerializedArrayElement(int index, string serializedElement, Scene scene, Entity structuredDataParent) {
			if (!Type.GetKind().IsArray()) {
				throw new Exception($"Cannot set element for non-array type {Type}");
			}
			var element = Deserialize(Type.GetElementType()!, Key, serializedElement, scene, structuredDataParent);
			SetArrayElement(index, element);
			return element;
		}
		
		public void AddArrayElement(object element) {
			if (!Type.GetKind().IsArray()) {
				throw new Exception($"Cannot add element for non-array type {Type}");
			}
			var array = (Array) Getter();
			if (array == null) {
				ClearArray();
			}
			var newArray = Array.CreateInstance(Type.GetElementType()!, array.Length + 1);
			Array.Copy(array, newArray, array.Length);
			newArray.SetValue(element, array.Length);
			SetValue(newArray);
		}

		public void RemoveArrayElement(int index) {
			if (!Type.GetKind().IsArray()) {
				throw new Exception($"Cannot remove element for non-array type {Type}");
			}

			var arr = (Array) Getter();
			if (index < 0 || index >= arr.Length) {
				throw new Exception($"Index {index} out of bounds for array of length {arr.Length}");
			}
			var newArr = Array.CreateInstance(Type.GetElementType()!, arr.Length - 1);
			// Copy arr to newArr except for the element at index
			Array.Copy(arr, newArr, index);
			Array.Copy(arr, index + 1, newArr, index, arr.Length - index - 1);
			SetValue(newArr);
		}
		
		public void MoveArrayElement(int fromIndex, int toIndex) {
			if (!Type.GetKind().IsArray()) {
				throw new Exception($"Cannot append default element for non-array type {Type}");
			}
			if (fromIndex == toIndex) {
				return;
			}
			
			var arr = (Array) Getter();
			var newArr = Array.CreateInstance(Type.GetElementType()!, arr.Length);

			if (toIndex > fromIndex) {
				Array.Copy(arr, newArr, fromIndex);
				Array.Copy(arr, fromIndex + 1, newArr, fromIndex, toIndex - fromIndex);
				newArr.SetValue(arr.GetValue(fromIndex), toIndex);
				Array.Copy(arr, toIndex + 1, newArr, toIndex + 1, arr.Length - toIndex - 1);
			} else {
				Array.Copy(arr, newArr, toIndex);
				newArr.SetValue(arr.GetValue(fromIndex), toIndex);
				Array.Copy(arr, toIndex, newArr, toIndex + 1, fromIndex - toIndex);
				Array.Copy(arr, fromIndex + 1, newArr, fromIndex + 1, arr.Length - fromIndex - 1);
			}
			SetValue(newArr);
		}
		
		public void ClearArray() {
			if (!Type.GetKind().IsArray()) {
				throw new Exception($"Cannot clear non-array type {Type}");
			}
			var newArr = Array.CreateInstance(Type.GetElementType()!, 0);
			SetValue(newArr);
		}
		
		public int ArrayLength => Type.GetKind().IsArray() ? ((Array) Getter()).Length : throw new Exception($"Cannot get length of non-array type {Type}");

		public static string Serialize(Type type, object v) {
			if (v == null) return null;
			switch (type.GetKind()) {
				case TypeKind.Reference:
					return null;
				case TypeKind.Enum: {
					var serializedEnumType = Context.TypeRegistry.GetSerializedEnumType(type);
					var serializedEnum = serializedEnumType.members.FirstOrDefault(it => it.value == Convert.ToInt64(v));
					if (serializedEnum == null) throw new Exception($"Enum value {v} not found in {type}");
					return JsonConvert.SerializeObject(serializedEnum.Also(it => it.Localize()));
				}
				case TypeKind.EnumArray: {
					var serializedEnumType = Context.TypeRegistry.GetSerializedEnumType(type.GetElementType()!);
					var jArray = new JArray();
					foreach (var el in (Array)v) {
						var serializedEnum = serializedEnumType.members.FirstOrDefault(it => it.value == Convert.ToInt64(el));
						if (serializedEnum == null) throw new Exception($"Enum value {el} not found in {type.GetElementType()!}");
						jArray.Add(JObject.Parse(JsonConvert.SerializeObject(serializedEnum.Also(it => it.Localize()))));
					}
					return JsonConvert.SerializeObject(jArray);
				}
				case TypeKind.Asset:
					return JsonConvert.SerializeObject(new AssetIdentifier {name = ((Asset) v).Name, id = ((Asset) v).Id });
				case TypeKind.AssetArray: {
					var jArray = new JArray();
					foreach (var el in (Array)v) {
						jArray.Add(el == null ? null : JObject.Parse(JsonConvert.SerializeObject(
							new AssetIdentifier {name = ((Asset) el).Name, id = ((Asset) el).Id })));
					}
					return JsonConvert.SerializeObject(jArray);
				}
				case TypeKind.Value:
				case TypeKind.ValueArray:
					return JsonConvert.SerializeObject(v);
				case TypeKind.StructuredData:
					return JsonConvert.SerializeObject(((StructuredData) v).Serialize());
				case TypeKind.StructuredDataArray: {
					var jArray = new JArray();
					foreach (var el in (Array)v) {
						jArray.Add(JObject.Parse(Serialize(type.GetElementType(), el)));
					}
					return JsonConvert.SerializeObject(jArray);
				}
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public static object Deserialize(Type type, string portKey, string serializedValue, Scene scene, Entity structuredDataParent) {
			if (serializedValue == null) return null;
			switch (type.GetKind()) {
				case TypeKind.Reference:
					return null;
				case TypeKind.Value:
				case TypeKind.ValueArray: {
					object deserializedValue;
					try {
						deserializedValue = JsonConvert.DeserializeObject(serializedValue, type);
					} catch (Exception e) {
						throw new UserException($"Could not deserialize data value {serializedValue}. Was it correctly serialized?", e);
					}
					return deserializedValue;
				}
				case TypeKind.Enum: {
					var serializedEnum = JsonConvert.DeserializeObject<SerializedEnum>(serializedValue);
					if (serializedEnum == null) {
						throw new UserException($"Could not deserialize enum from {serializedValue}. Was it correctly serialized?");
					}
					var enumValue = Enum.ToObject(type, serializedEnum.value);
					if (Enum.IsDefined(type, enumValue)) {
						return enumValue;
					}
					Debug.LogWarning($"Could not find enum value {serializedEnum.value} in {type}, falling back to first value");
					return Enum.GetValues(type).GetValue(0);
				}
				case TypeKind.Asset: {
					var serializedAsset = JsonConvert.DeserializeObject<AssetIdentifier>(serializedValue);
					if (serializedAsset == null) {
						return null;
					}
					var asset = scene.GetAsset(serializedAsset.id);
					if (asset == null) {
						Debug.LogWarning($"Could not find loaded asset {serializedValue}");
					}
					return asset;
				}
				case TypeKind.EnumArray: {
					var serializedEnums = JsonConvert.DeserializeObject<SerializedEnum[]>(serializedValue);
					if (serializedEnums == null) {
						throw new UserException($"Could not deserialize enum[] from {serializedValue}. Was it correctly serialized?");
					}
					
					var elType = type.GetElementType()!;
					var enumValues = Array.CreateInstance(elType, serializedEnums.Length);
					for (var index = 0; index < serializedEnums.Length; index++) {
						var serializedEnum = serializedEnums[index];
						if (serializedEnum == null) {
							enumValues.SetValue(Enum.GetValues(elType).GetValue(0), index);
						} else {
							var enumValue = Enum.ToObject(elType, serializedEnum.value);
							if (!Enum.IsDefined(elType, enumValue)) {
								Debug.LogWarning($"Could not find enum value {serializedEnum.value} in {elType}, falling back to first value");
								enumValue = Enum.GetValues(elType).GetValue(0);
							}
							enumValues.SetValue(enumValue, index);
						}
					}
					return enumValues;
				}
				case TypeKind.AssetArray: {
					var serializedAssets = JsonConvert.DeserializeObject<AssetIdentifier[]>(serializedValue);
					if (serializedAssets == null) {
						throw new Exception($"Could not deserialize asset id from {serializedValue}. Was it correctly serialized?");
					}
					
					var elType = type.GetElementType()!;
					var assetValues = Array.CreateInstance(elType, serializedAssets.Length);
					for (var index = 0; index < serializedAssets.Length; index++) {
						var serializedAsset = serializedAssets[index];
						Asset asset = null;
						if (serializedAsset != null) {
							asset = scene.GetAsset(serializedAsset.id);
							if (asset == null) {
								Debug.LogWarning($"Could not find loaded asset {serializedAsset}");
							}
						}
						assetValues.SetValue(asset, index);
					}
					return assetValues;
				}
				case TypeKind.StructuredData: {
					var serializedStructuredData = JsonConvert.DeserializeObject<SerializedStructuredData>(serializedValue);
					if (serializedStructuredData == null) {
						throw new Exception($"Could not deserialize structured data from {serializedValue}. Was it correctly serialized?");
					}

					if (serializedStructuredData.id == default) {
						serializedStructuredData.id = Guid.NewGuid();
					}
					if (serializedStructuredData.dataInputs == null) {
						var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(serializedValue);
						if (values != null) {
							serializedStructuredData.dataInputs = values.ToDictionary(kv => kv.Key, kv => new SerializedDataInputPort {
								value = kv.Value
							});
						}
					}

					var sd = Context.StructuredDataTypeRegistry.CreateEntity(type);
					serializedStructuredData.id = Guid.NewGuid(); // Always use new ID for structured data - or it could clash with existing entity (e.g. duplicate asset)

					sd.Scene = scene;
					sd.PortKey = portKey;
					sd.Parent = structuredDataParent;
					sd.Deserialize(serializedStructuredData);
					return sd;
				}
				case TypeKind.StructuredDataArray: {
					JArray jArray;
					try {
						jArray = JArray.Parse(serializedValue);
					} catch (Exception e) {
						throw new UserException($"Could not deserialize structured data array from {serializedValue}. Was it correctly serialized?", e);
					}

					var elType = type.GetElementType()!;
					var array = Array.CreateInstance(elType, jArray.Count);
					for (var index = 0; index < jArray.Count; index++) {
						var jToken = jArray[index];
						if (jToken.Type != JTokenType.Object) {
							throw new Exception($"Could not deserialize structured data array from {serializedValue}. Was it correctly serialized?");
						}
						// Debug.Log("Array type is: " + elType.AssemblyQualifiedName);
						var o = Deserialize(elType, portKey, jToken.ToString(), scene, structuredDataParent);
						// Debug.Log("Actual deserialized type is: " + o.GetType().AssemblyQualifiedName);
						array.SetValue(
							o, 
							index);
					}
					return array;
				}
				default: {
					throw new ArgumentOutOfRangeException();
				}
			}
		}
		
		public void SetValue(object value) {
			// Destroy structured data not referenced in the new value, as this port is the only reference to it
			if (Type.GetKind() == TypeKind.StructuredData) {
				var sd = (StructuredData) Getter();
				if (sd is { Created: true } && sd != value) {
					sd.Destroy();
				}
			} else if (Type.GetKind() == TypeKind.StructuredDataArray) {
				var toArr = (Array) value;
				var toIds = toArr.Cast<StructuredData>().Select(sd => sd.Id).ToHashSet();
				
				var arr = (Array) Getter();
				if (arr != null) {
					foreach (var el in arr) {
						var sd = (StructuredData) el;
						if (sd is { Created: true } && !toIds.Contains(sd.Id)) {
							sd.Destroy();
						}
					}
				}
			}
			Setter(value);
		}
		
		public void SetSerializedValue(string serializedValue, Scene scene, Entity structuredDataParent) {
			SetValue(Deserialize(Type, Key, serializedValue, scene, structuredDataParent));
		}
		
		public object ParseSerializedValue(string serializedValue, Scene scene, Entity structuredDataParent) {
			return Deserialize(Type, Key, serializedValue, scene, structuredDataParent);
		}
		
		public object ParseSerializedValueFrom(SerializedEntity serializedEntity, Scene scene, Entity structuredDataParent) {
			if (serializedEntity.dataInputs != null && serializedEntity.dataInputs.TryGetValue(Key, out var input)) {
				return ParseSerializedValue(input.value, scene, structuredDataParent);
			}
			return null;
		}

		public SerializedDataInputPort Serialize() {
			return new SerializedDataInputPort {
				key = Key,
				type = Type.FriendlyFullName(),
				typeKind = Type.GetKind(),
				defaultValue = DefaultValue,
				value = SerializeValue(),
				properties = Properties.Clone()
			};
		}

		public void Dispose() {
			if (Properties.typeProperties is StringDataInputTypeProperties stringDataInputTypeProperties) {
				Context.AutoCompleteManager.Unregister(stringDataInputTypeProperties.autoCompleteId);
			}
		}

		public static DataInputPort CreateDataInputPortFromReflectionMeta(ReflectedDataInputPortMeta meta, object valueProvider, object methodProvider, Entity structuredDataParent, Scene scene) {
			var valueTargetRef = valueProvider;

			var dataInputField = meta.FieldInfo;
			var properties = meta.Properties.Clone();
			
			var getter = dataInputField.DelegateForGet();
			var setter = dataInputField.DelegateForSet();
			var defaultValue = getter.Invoke(valueProvider);

			var type = dataInputField.FieldType;
			var typeKind = type.GetKind();
			
			// Check if is enum and is it valid; if not, set to first value of Enum
			if (typeKind == TypeKind.Enum && !type.IsEnumDefined(defaultValue)) {
				defaultValue = Enum.GetValues(type).GetValue(0);
				setter.Invoke(ref valueTargetRef, defaultValue);
			}
			
			// Check if is array and is null
			if (typeKind is TypeKind.EnumArray or TypeKind.ValueArray or TypeKind.AssetArray && defaultValue == null) {
				defaultValue = Array.CreateInstance(type.GetElementType()!, 0);
				setter.Invoke(ref valueTargetRef, defaultValue);
			}

			Action<object> structuredDataInitializer = null;
			// Check if is structured data
			if (typeKind is TypeKind.StructuredData or TypeKind.StructuredDataArray) {
				if (meta.StructuredDataInitializerMethodInfo != null) {
					var invoker = meta.StructuredDataInitializerMethodInfo.DelegateForCall();
					structuredDataInitializer = obj => invoker.Invoke(methodProvider, new[] { obj });
				}

				var structuredDataType = typeKind == TypeKind.StructuredDataArray ? type.GetElementType()! : type;
				
				if (defaultValue == null) {
					if (type.IsArray) {
						var sdArray = Array.CreateInstance(type.GetElementType()!, 0);
						setter.Invoke(ref valueTargetRef, sdArray);
					} else {
						var sd = Context.StructuredDataTypeRegistry.CreateEntity(structuredDataType);
						sd.Scene = scene;
						sd.PortKey = dataInputField.Name;
						sd.Parent = structuredDataParent;
						structuredDataInitializer?.Invoke(sd);
						setter.Invoke(ref valueTargetRef, sd);
					}
				} else {
					if (type.IsArray) {
						for (var i = 0; i < ((Array)defaultValue).Length; i++) {
							var sd = (StructuredData)((Array)defaultValue).GetValue(i);
							sd.Scene = scene;
							sd.PortKey = dataInputField.Name;
							sd.Parent = structuredDataParent;
						}
					} else {
						var sd = (StructuredData)defaultValue;
						sd.Scene = scene;
						sd.PortKey = dataInputField.Name;
						sd.Parent = structuredDataParent;
					}
				}

				var defaultSd = (StructuredData)structuredDataType.DelegateForCtor().Invoke(Array.Empty<object>());
				defaultSd.Scene = scene;
				defaultSd.PortKey = dataInputField.Name;
				defaultSd.Parent = structuredDataParent;
				
				if (type.IsArray) {
					defaultValue = Array.CreateInstance(type.GetElementType()!, 0);
				} else {
					defaultValue = defaultSd;
				}
			}
			
			var port = new DataInputPort(
				dataInputField.Name,
				type,
				Serialize(type, defaultValue),
				() => getter.Invoke(valueProvider),
				v => setter.Invoke(ref valueTargetRef, v),
				properties,
				structuredDataInitializer);
			
			if (typeKind is TypeKind.Asset or TypeKind.AssetArray) {
				// Debug.Log($"Registering auto complete provider for {meta.FieldInfo.ReflectedType!.Name}::{dataInputField.Name}");

				var guid = Guid.NewGuid();
				var assetType = type.IsArray ? type.GetElementType()! : type;

				if (meta.TypeIdFilterAttribute != null) {
					// Use TypeId filter for asset selection
					var typeId = meta.TypeIdFilterAttribute.TypeId;
					if (meta.AssetFilterMethodInfo != null) {
						var invoker = meta.AssetFilterMethodInfo.DelegateForCall();
						Context.AutoCompleteManager.Register(guid, AssetSelectionProvider.ForTypeId(assetType, typeId, asset => {
							try {
								return (bool)invoker.Invoke(methodProvider, new object[] { asset });
							} catch (Exception e) {
								Debug.LogError($"Error invoking asset filter method {meta.AssetFilterMethodInfo.Name}: {e.Message}");
								return false;
							}
						}));
					} else {
						Context.AutoCompleteManager.Register(guid, AssetSelectionProvider.ForTypeId(assetType, typeId));
					}
				} else if (meta.AssetFilterMethodInfo != null) {
					var invoker = meta.AssetFilterMethodInfo.DelegateForCall();
					Context.AutoCompleteManager.Register(guid, AssetSelectionProvider.For(assetType, asset => {
						try {
							return (bool)invoker.Invoke(methodProvider, new object[] { asset });
						} catch (Exception e) {
							Debug.LogError($"Error invoking asset filter method {meta.AssetFilterMethodInfo.Name}: {e.Message}");
							return false;
						}
					}));
				} else {
					Context.AutoCompleteManager.Register(guid, AssetSelectionProvider.For(assetType));
				}
				
				((StringDataInputTypeProperties) properties.typeProperties).autoCompleteId = guid;
			} else if (meta.AutoCompleteResourceType != null) {
				var guid = Guid.NewGuid();
				Context.AutoCompleteManager.Register(guid, async () => Context.ResourceManager.ProvideResources(meta.AutoCompleteResourceType).ToAutoCompleteList());
				((StringDataInputTypeProperties) properties.typeProperties).autoCompleteId = guid;
			} else if (meta.AutoCompleteMethodInfo != null) {
				// Debug.Log($"Registering auto complete provider for {meta.FieldInfo.ReflectedType!.Name}::{dataInputField.Name}");

				var guid = Guid.NewGuid();
				var invoker = meta.AutoCompleteMethodInfo.DelegateForCall();
				Context.AutoCompleteManager.Register(guid, () => (UniTask<AutoCompleteList>)invoker.Invoke(methodProvider, Array.Empty<object>()));
				((StringDataInputTypeProperties) properties.typeProperties).autoCompleteId = guid;
			}
			return port;
		}

		public static ReflectedDataInputPortMeta GetReflectionMeta(FieldInfo fieldInfo, Type methodProviderType = null) {
			if (methodProviderType == null) {
				methodProviderType = fieldInfo.ReflectedType;
				if (methodProviderType == null) {
					throw new Exception("Method provider type is null");
				}
			}
			
			// Markdown
			MethodInfo hiddenIfMethodInfo = null;
			MethodInfo sectionHiddenIfMethodInfo = null;
			var mdAttribute = fieldInfo.GetCustomAttribute<MarkdownAttribute>();
			if (mdAttribute != null) {
				if (fieldInfo.FieldType != typeof(string)) {
					throw new Exception("Markdown fields must be of type string");
				}
				var mdProperties = new DataInputProperties {
					order = mdAttribute.Order,
					transient = !mdAttribute.Persist,
					sectionTitle = fieldInfo.GetCustomAttribute<SectionAttribute>()?.Title
				};
				var typeProperties = new StringDataInputTypeProperties {
					markdown = true,
					markdownPrimary = mdAttribute.Primary
				};
				mdProperties.typeProperties = typeProperties;
				if (fieldInfo.HasCustomAttribute<HiddenIfAttribute>()) {
					var methodName = fieldInfo.GetCustomAttribute<HiddenIfAttribute>().MethodName;
					if (methodName != null) {
						hiddenIfMethodInfo = methodProviderType.GetProvidingMethod<bool>(methodName);
					}
				}
				if (fieldInfo.HasCustomAttribute<SectionHiddenIfAttribute>()) {
					var methodName = fieldInfo.GetCustomAttribute<SectionHiddenIfAttribute>().MethodName;
					if (methodName != null) {
						sectionHiddenIfMethodInfo = methodProviderType.GetProvidingMethod<bool>(methodName);
					}
				}
				return new ReflectedDataInputPortMeta(fieldInfo, mdProperties, null, 
					fieldInfo.GetCustomAttribute<HiddenIfAttribute>(), 
					hiddenIfMethodInfo, null, null,
					fieldInfo.GetCustomAttribute<SectionHiddenIfAttribute>(),
					sectionHiddenIfMethodInfo,
					null, null, null);
			}
			
			// Regular data input
			if (!fieldInfo.HasCustomAttribute<DataInputAttribute>()) return null;

			var label = fieldInfo.GetCustomAttribute<LabelAttribute>()?.Label ?? fieldInfo.Name.ToSpacedPascalCase();
			if (fieldInfo.HasCustomAttribute<HideLabelAttribute>()) label = "";
			var description = fieldInfo.GetCustomAttribute<DescriptionAttribute>()?.Description;
			var sectionTitle = fieldInfo.GetCustomAttribute<SectionAttribute>()?.Title;
				
			var properties = new DataInputProperties {
				transient = fieldInfo.HasCustomAttribute<TransientAttribute>() || TransientTypes.Contains(fieldInfo.FieldType),
				order = fieldInfo.GetCustomAttribute<DataInputAttribute>().Order,
				hidden = fieldInfo.HasCustomAttribute<HiddenAttribute>(),
				disabled = fieldInfo.HasCustomAttribute<DisabledAttribute>(),
				label = label,
				description = description,
				sectionTitle = sectionTitle,
				alwaysHidden = fieldInfo.HasCustomAttribute<HiddenAttribute>(),
				alwaysDisabled = fieldInfo.HasCustomAttribute<DisabledAttribute>()
			};

			if (fieldInfo.FieldType == typeof(int) || fieldInfo.FieldType == typeof(int[])) {
				var typeProperties = new IntegerDataInputTypeProperties();
				var integerSlider = fieldInfo.GetCustomAttribute<IntegerSliderAttribute>();
				if (integerSlider != null) {
					typeProperties.min = integerSlider.Min;
					typeProperties.max = integerSlider.Max;
					typeProperties.step = integerSlider.Step;
				}
				properties.typeProperties = typeProperties;
			} else if (fieldInfo.FieldType == typeof(float) || fieldInfo.FieldType == typeof(float[])) {
				var typeProperties = new FloatDataInputTypeProperties();
				var floatSlider = fieldInfo.GetCustomAttribute<FloatSliderAttribute>();
				if (floatSlider != null) {
					typeProperties.min = floatSlider.Min;
					typeProperties.max = floatSlider.Max;
					typeProperties.step = floatSlider.Step;
				}
				properties.typeProperties = typeProperties;
			} else if (fieldInfo.HasCustomAttribute<AutoCompleteResourceAttribute>()) {
				var typeProperties = new StringDataInputTypeProperties();
				var autoCompleteAttribute = fieldInfo.GetCustomAttribute<AutoCompleteResourceAttribute>();
				typeProperties.autoComplete = true;
				typeProperties.forceSelection = true;
				typeProperties.defaultLabel = autoCompleteAttribute?.DefaultLabel;
				typeProperties.defaultLabel = fieldInfo.GetCustomAttribute<DefaultLabelAttribute>()?.DefaultLabel ?? typeProperties.defaultLabel;
				typeProperties.previewGallery = fieldInfo.HasCustomAttribute<PreviewGalleryAttribute>();
				typeProperties.multiline = false;
				properties.typeProperties = typeProperties;
			} else if (fieldInfo.FieldType == typeof(string) || fieldInfo.FieldType == typeof(string[])) {
				var typeProperties = new StringDataInputTypeProperties();
				var autoCompleteAttribute = fieldInfo.GetCustomAttribute<AutoCompleteAttribute>();
				typeProperties.autoComplete = autoCompleteAttribute != null;
				typeProperties.forceSelection = autoCompleteAttribute?.ForceSelection ?? false;
				typeProperties.defaultLabel = autoCompleteAttribute?.DefaultLabel ?? null;
				typeProperties.defaultLabel = fieldInfo.GetCustomAttribute<DefaultLabelAttribute>()?.DefaultLabel ?? typeProperties.defaultLabel;
				typeProperties.previewGallery = fieldInfo.HasCustomAttribute<PreviewGalleryAttribute>();
				typeProperties.multiline = fieldInfo.HasCustomAttribute<MultilineInputAttribute>();
				properties.typeProperties = typeProperties;
			} else if (fieldInfo.FieldType.InheritsFrom(typeof(Asset)) || (fieldInfo.FieldType.IsArray && fieldInfo.FieldType.GetElementType().InheritsFrom(typeof(Asset)))) {
				var typeProperties = new StringDataInputTypeProperties();
				typeProperties.autoComplete = true;
				typeProperties.forceSelection = true;
				typeProperties.defaultLabel = fieldInfo.GetCustomAttribute<DefaultLabelAttribute>()?.DefaultLabel;
				properties.typeProperties = typeProperties;
			} else if (fieldInfo.FieldType.InheritsFrom(typeof(StructuredData)) || fieldInfo.FieldType.InheritsFrom(typeof(StructuredData[]))) {
				var typeProperties = new StructuredDataInputTypeProperties();
				var structuredDataType = fieldInfo.FieldType.IsArray ? fieldInfo.FieldType.GetElementType()! : fieldInfo.FieldType;
				if (structuredDataType.GetConstructors().All(it => it.GetParameters().Length != 0)) {
					throw new Exception($"Structured data type {structuredDataType.FriendlyFullName()} must have a parameterless constructor");
				}
				foreach (var sdFieldInfo in structuredDataType.GetFields()) {
					var type = sdFieldInfo.FieldType;
					var elType = type.IsArray ? type.GetElementType()! : type;
					if (elType == structuredDataType) {
						throw new Exception($"Structured data type {structuredDataType.FriendlyFullName()} cannot have a self-referent field {sdFieldInfo.Name}");
					}
				}
				properties.typeProperties = typeProperties;
				// Initialization of typeProperties is done in CreateFromReflectionMeta
			} else if (fieldInfo.FieldType == typeof(Color) || fieldInfo.FieldType == typeof(Color[])) {
				var typeProperties = new ColorDataInputTypeProperties {
					hdr = fieldInfo.HasCustomAttribute<HDRAttribute>()
				};
				properties.typeProperties = typeProperties;
			} else if (fieldInfo.FieldType.IsEnum || (fieldInfo.FieldType.IsArray && fieldInfo.FieldType.GetElementType().IsEnum)) {
				var typeProperties = new EnumDataInputTypeProperties {
					cardSelect = fieldInfo.HasCustomAttribute<CardSelectAttribute>()
				};
				properties.typeProperties = typeProperties;
			}

			MethodInfo autoCompleteMethodInfo = null;
			string autoCompleteResourceType = null;
			if (fieldInfo.HasCustomAttribute<AutoCompleteResourceAttribute>()) {
				if (fieldInfo.FieldType != typeof(string) && fieldInfo.FieldType != typeof(string[])) {
					throw new Exception($"{fieldInfo.DeclaringType!.Name}::{fieldInfo.Name} cannot have an auto complete resource provider because it is not of string or string[] type");
				}
				autoCompleteResourceType = fieldInfo.GetCustomAttribute<AutoCompleteResourceAttribute>().ResourceType;
			} else if (fieldInfo.HasCustomAttribute<AutoCompleteAttribute>()) {
				if (fieldInfo.FieldType != typeof(string) && fieldInfo.FieldType != typeof(string[])) {
					throw new Exception($"{fieldInfo.DeclaringType!.Name}::{fieldInfo.Name} cannot have an auto complete provider because it is not of string or string[] type");
				}
				var methodName = fieldInfo.GetCustomAttribute<AutoCompleteAttribute>().MethodName;
				autoCompleteMethodInfo = methodProviderType.GetProvidingMethod<UniTask<AutoCompleteList>>(methodName);
			}

			if (fieldInfo.HasCustomAttribute<HiddenIfAttribute>()) {
				var methodName = fieldInfo.GetCustomAttribute<HiddenIfAttribute>().MethodName;
				if (methodName != null) {
					hiddenIfMethodInfo = methodProviderType.GetProvidingMethod<bool>(methodName);
				}
			}
			if (fieldInfo.HasCustomAttribute<SectionHiddenIfAttribute>()) {
				var methodName = fieldInfo.GetCustomAttribute<SectionHiddenIfAttribute>().MethodName;
				if (methodName != null) {
					sectionHiddenIfMethodInfo = methodProviderType.GetProvidingMethod<bool>(methodName);
				}
			}
			
			MethodInfo disabledIfMethodInfo = null;
			if (fieldInfo.HasCustomAttribute<DisabledIfAttribute>()) {
				var methodName = fieldInfo.GetCustomAttribute<DisabledIfAttribute>().MethodName;
				if (methodName != null) {
					disabledIfMethodInfo = methodProviderType.GetProvidingMethod<bool>(methodName);
				}
			}
			
			MethodInfo assetFilterMethodInfo = null;
			if (fieldInfo.HasCustomAttribute<AssetFilterAttribute>()) {
				var methodName = fieldInfo.GetCustomAttribute<AssetFilterAttribute>().MethodName;
				var fieldType = fieldInfo.FieldType;
				if (fieldType.IsArray) {
					fieldType = fieldType.GetElementType()!;
				}
				assetFilterMethodInfo = methodProviderType.GetProvidingMethod<bool>(methodName, fieldType);
			}
			
			MethodInfo structuredDataInitializerMethodInfo = null;
			if (fieldInfo.FieldType.InheritsFrom(typeof(StructuredData)) || fieldInfo.FieldType.InheritsFrom(typeof(StructuredData[]))) {
				var methodName = fieldInfo.GetCustomAttribute<StructuredDataInitializerAttribute>()?.MethodName;
				if (methodName != null) {
					var elementType = fieldInfo.FieldType.IsArray ? fieldInfo.FieldType.GetElementType()! : fieldInfo.FieldType;
					structuredDataInitializerMethodInfo = methodProviderType.GetProvidingMethod(typeof(void), methodName, elementType);
				}
			}
			return new ReflectedDataInputPortMeta(
				fieldInfo,
				properties,
				autoCompleteMethodInfo,
				fieldInfo.GetCustomAttribute<HiddenIfAttribute>(),
				hiddenIfMethodInfo,
				fieldInfo.GetCustomAttribute<DisabledIfAttribute>(),
				disabledIfMethodInfo,
				fieldInfo.GetCustomAttribute<SectionHiddenIfAttribute>(),
				sectionHiddenIfMethodInfo,
				assetFilterMethodInfo,
				structuredDataInitializerMethodInfo,
				autoCompleteResourceType,
				fieldInfo.GetCustomAttribute<TypeIdFilterAttribute>());
		}

		private static readonly HashSet<Type> TransientTypes = new() {
			typeof(Quaternion[])
		};
	}
	public record WatchedDataInputPort : DataInputPort {
		public WatchedDataInputPort(DataInputPort port, Action<object> setter) : base(port.Key, port.Type, port.DefaultValue, port.Getter, setter, port.Properties, port.StructuredDataInitializer) {
		}
	}

	public record ReflectedDataInputPortMeta(
		FieldInfo FieldInfo, 
		DataInputProperties Properties,
		MethodInfo AutoCompleteMethodInfo,
		HiddenIfAttribute HiddenIfAttribute,
		MethodInfo HiddenIfMethodInfo, 
		DisabledIfAttribute DisabledIfAttribute,
		MethodInfo DisabledIfMethodInfo,
		SectionHiddenIfAttribute SectionHiddenIfAttribute,
		MethodInfo SectionHiddenIfMethodInfo,
		MethodInfo AssetFilterMethodInfo,
		MethodInfo StructuredDataInitializerMethodInfo,
		string AutoCompleteResourceType,
		TypeIdFilterAttribute TypeIdFilterAttribute = null);
}
