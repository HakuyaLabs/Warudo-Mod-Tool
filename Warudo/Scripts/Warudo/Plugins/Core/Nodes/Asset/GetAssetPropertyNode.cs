using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Scenes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetAssetPropertyNode : Node
    {
        public Asset Asset;
        public string DataPath;
        public object OutputValue()
        {
            throw new NotImplementedException();
        }
    }
}