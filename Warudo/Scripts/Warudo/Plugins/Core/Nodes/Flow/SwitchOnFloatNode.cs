using System;
using System.Globalization;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SwitchOnFloatNode : Node
    {
        public float[] Cases;
        public float Input;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public void SetupExitPorts()
        {
            throw new NotImplementedException();
        }
    }
}