using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Environment;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class AssetGameObjectNode : Node
    {
        public GameObjectAsset Asset;
        public string GameObjectPath;
        public async UniTask<AutoCompleteList> AutoCompleteGameObjectPath()
        {
            throw new NotImplementedException();
        }

        public Transform FindTargetTransform()
        {
            throw new NotImplementedException();
        }
    }
}