using System;
using System.Linq;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class AssetGameObjectComponentNode : AssetGameObjectNode
    {
        public string Component;
        public async UniTask<AutoCompleteList> AutoCompleteComponent()
        {
            throw new NotImplementedException();
        }

        protected Component FindTargetComponent(Transform transform)
        {
            throw new NotImplementedException();
        }

        protected static readonly Type[] ValidTypes = new Type[]{typeof(int), typeof(bool), typeof(float), typeof(double), typeof(long), typeof(Vector2), typeof(Vector3), typeof(Vector4), typeof(Color), typeof(string)};
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