using Warudo.Plugins.Core.Assets.Prop;
using Event = Warudo.Core.Events.Event;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class ScreenBrowserMessageNode : Event
    {
        public ScreenAsset Screen { get; private set; }

        public string Message { get; private set; }

        public ScreenBrowserMessageNode(ScreenAsset screenAsset, string message)
        {
            throw new NotImplementedException();
        }
    }
}