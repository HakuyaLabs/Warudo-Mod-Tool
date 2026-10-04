using System;

namespace Warudo.Core.Data {
    public sealed class StructuredDataTypeRegistry : EntityTypeRegistry<StructuredData, StructuredDataTypeMeta> {

        public StructuredDataTypeMeta RegisterType(Type type) {
            return RegisterType(type.AssemblyQualifiedName, type);
        }

        public override StructuredDataTypeMeta GetTypeMeta(Type type) {
            return base.GetTypeMeta(type) ?? RegisterType(type);
        }

    }
    
    public class StructuredDataTypeMeta : EntityTypeMeta {
    }
}
