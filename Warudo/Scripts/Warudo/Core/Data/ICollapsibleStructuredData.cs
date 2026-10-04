using System;

namespace Warudo.Core.Data {
    public interface ICollapsibleStructuredData {
        public Guid Id { get; }
        public string GetHeader();
    }
}
