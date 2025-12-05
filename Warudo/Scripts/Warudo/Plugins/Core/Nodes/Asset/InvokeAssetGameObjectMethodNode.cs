using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class InvokeAssetGameObjectMethodNode : AssetGameObjectComponentNode
    {
        public string Method;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public async UniTask<AutoCompleteList> AutoCompleteMethod()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedNode serialized)
        {
            throw new NotImplementedException();
        }
    }
}