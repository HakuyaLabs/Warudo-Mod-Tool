using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class AssetGameObjectPropertyNode : AssetGameObjectComponentNode
    {
        public string Property;
        public string PropertyType;
        protected const string PropertyValuePortName = "PropertyValue";
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedNode serialized)
        {
            throw new NotImplementedException();
        }

        protected void UpdatePropertyType()
        {
            throw new NotImplementedException();
        }

        protected abstract void CreatePropertyPort();
        public async UniTask<AutoCompleteList> AutoCompleteProperty()
        {
            throw new NotImplementedException();
        }

        protected object GetPropertyValue()
        {
            throw new NotImplementedException();
        }

        protected static bool IsValidType(Type type)
        {
            throw new NotImplementedException();
        }

        protected static string ToFriendlyName(string input)
        {
            throw new NotImplementedException();
        }
    }
}