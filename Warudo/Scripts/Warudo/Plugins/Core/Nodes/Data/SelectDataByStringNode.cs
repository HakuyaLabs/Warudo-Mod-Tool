using System.Linq;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Server;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Data
{
    public class SelectDataByStringNode : Node
    {
        public string InputString;
        public string[] Cases;
        public object Output()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public void SetupInputPorts()
        {
            throw new NotImplementedException();
        }
    }
}