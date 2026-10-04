using System;

namespace Warudo.Core.Persistence {
    [Serializable]
    public class FileEntry {
        public string path;
        public string relativePath;
        public string absolutePath;
        public string fileName;
        public long lastModifiedTime;
    }
}
