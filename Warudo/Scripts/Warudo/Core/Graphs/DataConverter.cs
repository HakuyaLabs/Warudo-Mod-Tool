using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Warudo.Core.Utils;

namespace Warudo.Core.Graphs {
    public interface IDataConverter {
        object Convert(object data);
    }
    
    public abstract class DataConverter<T1, T2> : IDataConverter {
        public abstract T2 Convert(T1 data);
        
        public object Convert(object data) {
            return Convert((T1)data);
        }
    }
    
    public class IntToFloatConverter : DataConverter<int, float> {
        public override float Convert(int data) {
            return data;
        }
    }

    public class Int32ToSingleConverter : DataConverter<Int32, Single> {
        public override float Convert(int data) {
            return data;
        }
    }
    
    public class FloatToIntConverter : DataConverter<float, int> {
        public override int Convert(float data) {
            return (int)data;
        }
    }

    public class IntToStringConverter : DataConverter<int, string> {
        public override string Convert(int data) {
            return data.ToString();
        }
    }
    
    public class FloatToStringConverter : DataConverter<float, string> {
        public override string Convert(float data) {
            return data.ToString(CultureInfo.InvariantCulture);
        }
    }
    
    public class BoolToStringConverter : DataConverter<bool, string> {
        public override string Convert(bool data) {
            return data.ToString();
        }
    }
    
    public class IdentityConverter : IDataConverter {
        public object Convert(object data) {
            return data;
        }
    }

    public static class DataConverters {

        private static readonly Dictionary<(Type fromType, Type toType), IDataConverter> Converters = new();

        public static void Initialize() {
            Converters.Clear();
            RegisterInternalConverter(new IntToFloatConverter());
            RegisterInternalConverter(new FloatToIntConverter());
            RegisterInternalConverter(new IntToStringConverter());
            RegisterInternalConverter(new FloatToStringConverter());
            RegisterInternalConverter(new BoolToStringConverter());
            Context.Service?.BroadcastDataConverters(Serialize());
        }
        
        private static void RegisterInternalConverter<T1, T2>(DataConverter<T1, T2> converter) {
            Converters[(typeof(T1), typeof(T2))] = converter;
        }
        
        public static void RegisterConverter<T1, T2>(DataConverter<T1, T2> converter) {
            RegisterInternalConverter(converter);
            Context.Service?.BroadcastDataConverters(Serialize());
        }
        
        public static void RegisterGenericConverter(Type fromType, Type toType, IDataConverter converter) {
            Converters[(fromType, toType)] = converter;
            Context.Service?.BroadcastDataConverters(Serialize());
        }

        public static object Convert(object v, Type fromType, Type toType) {
            if (fromType == toType || toType == typeof(object)) {
                return v;
            }
            if (Converters.TryGetValue((v.GetType(), toType), out var converter)) {
                return converter.Convert(v);
            }
            if (Converters.TryGetValue((fromType, toType), out converter)) {
                return converter.Convert(v);
            }
            throw new Exception($"No converter found for {fromType} to {toType}");
        }
        
        public static bool CanConvert(Type fromType, Type toType) {
            return Converters.ContainsKey((fromType, toType));
        }

        public static SerializedDataConverters Serialize() {
            return new SerializedDataConverters {
                converters = Converters.Select(it => new SerializedDataConverter {
                    fromType = it.Key.fromType.FriendlyFullName(),
                    toType = it.Key.toType.FriendlyFullName()
                }).ToList()
            };
        }
        
    }

    [Serializable]
    public class SerializedDataConverters {
        public List<SerializedDataConverter> converters;
    }
    
    [Serializable]
    public class SerializedDataConverter {
        public string fromType;
        public string toType;
    }
}
