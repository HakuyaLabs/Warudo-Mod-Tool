using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class DoNNode : Node
    {
        public int N = 1;
        public string Text;
        protected bool HideText() => throw new NotImplementedException();
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Reset()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}