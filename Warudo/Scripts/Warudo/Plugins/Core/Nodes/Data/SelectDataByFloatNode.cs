using System.Linq;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Data
{
    public class SelectDataByFloatNode : Node
    {
        public float InputFloat;
        public float[] Cases;
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