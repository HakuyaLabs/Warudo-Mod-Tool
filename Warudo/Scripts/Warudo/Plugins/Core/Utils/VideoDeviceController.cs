using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class VideoDeviceController
    {
        public string Id { get; }

        public Device UsingDevice { get; private set; }

        public VideoDeviceController(string id, Action onForcedRelease, Action onUse)
        {
            throw new NotImplementedException();
        }

        public void UseDevice(string targetDeviceName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}