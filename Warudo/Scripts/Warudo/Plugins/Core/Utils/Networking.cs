using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public static class Networking
    {
        public static IEnumerable<IPAddress> GetLocalIPAddresses()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<IPAddress> GetAllLocalIPv4(params NetworkInterfaceType[] interfaceTypes)
        {
            throw new NotImplementedException();
        }

        public static int FindFreePort(int startingPort)
        {
            throw new NotImplementedException();
        }
    }
}