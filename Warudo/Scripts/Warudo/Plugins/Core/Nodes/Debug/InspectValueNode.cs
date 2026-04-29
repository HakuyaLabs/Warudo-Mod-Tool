using Newtonsoft.Json;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class InspectValueNode : Node
    {
        public object A;
        public string Text = "";
        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}