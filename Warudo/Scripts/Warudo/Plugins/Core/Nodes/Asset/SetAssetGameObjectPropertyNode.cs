using System;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetAssetGameObjectPropertyNode : AssetGameObjectPropertyNode
    {
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        protected override void CreatePropertyPort()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedNode serialized)
        {
            throw new NotImplementedException();
        }
    }
}