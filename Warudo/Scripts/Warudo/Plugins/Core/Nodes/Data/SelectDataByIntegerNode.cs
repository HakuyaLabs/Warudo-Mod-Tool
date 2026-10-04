using System.Linq;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Data
{
    public class SelectDataByIntegerNode : Node
    {
        public int InputInteger;
        public int[] Cases;
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