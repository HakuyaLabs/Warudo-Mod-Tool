using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets.Prop;
using Warudo.Plugins.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Event
{
    public class OnScreenBrowserMessageEvent : Node
    {
        public ScreenAsset Screen;
        public string Message()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}