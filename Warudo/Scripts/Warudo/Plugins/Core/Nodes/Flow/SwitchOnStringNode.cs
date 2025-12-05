using System.Globalization;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SwitchOnStringNode : Node
    {
        public string[] Cases;
        public string Input;
        public bool IgnoreCase;
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