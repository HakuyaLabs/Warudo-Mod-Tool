using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using AOT;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Core.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using AOT;
    using UnityEngine;

    public sealed class FsNotify : MonoBehaviour
    {
        private delegate void NativeCallback(IntPtr jsonUtf8, IntPtr userData);
        public sealed class Change
        {
            public string kind;
            public string[] paths;
            public string error;
        }

        private sealed class WatchContext
        {
            public FsNotify owner;
            public int id;
            public Action<int, Change> callback;
        }

        private sealed class WatchEntry
        {
            public IntPtr nativeHandle;
            public GCHandle contextHandle;
        }

        private struct PendingChange
        {
            public WatchContext context;
            public Change change;
        }

        public int AddWatch(string path, Action<int, Change> callback, bool recursive = true, bool syncInitialList = true, uint settleMilliseconds = 500)
        {
            throw new NotImplementedException();
        }

        public bool RemoveWatch(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllWatches()
        {
            throw new NotImplementedException();
        }
    }
}