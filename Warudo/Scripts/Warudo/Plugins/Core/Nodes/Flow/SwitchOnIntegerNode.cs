using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SwitchOnIntegerNode : Node
    {
        public int[] Cases;
        public int Input;
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