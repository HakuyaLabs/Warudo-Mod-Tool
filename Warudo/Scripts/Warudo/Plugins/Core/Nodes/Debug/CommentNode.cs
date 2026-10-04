using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class CommentNode : Node
    {
        public string Text = "";
        public void Edit()
        {
            throw new NotImplementedException();
        }

        public string Content = "Hello World!";
        public void Done()
        {
            throw new NotImplementedException();
        }

        public bool Editing = false;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}