using System;

namespace Warudo.Core.Data {
    public sealed class MissingStructuredDataException : Exception {
        public string PortKey { get; }

        public MissingStructuredDataException(string portKey, Exception innerException)
            : base("Could not restore structured data at port " + portKey, innerException) {
            PortKey = portKey;
        }
    }
}
