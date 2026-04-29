using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class FileWatcher
    {
        public string Path { get; }

        public Action OnChange { get; set; }

        public FileWatcher(string path)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}