using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ToggleCharacterMeshesNode : Node
    {
        public CharacterAsset Character;
        public string[] Meshes;
        public ToggleAction Action;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public async UniTask<AutoCompleteList> AutoCompleteMeshAndSkinnedMesh()
        {
            throw new NotImplementedException();
        }
    }
}