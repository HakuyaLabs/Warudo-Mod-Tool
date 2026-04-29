using System;

namespace Warudo.Core.Utils {
    public class UserException : Exception {
        
        public UserException(string message) : base(message) {
        }
        
        public UserException(string message, Exception innerException) : base(message, innerException) {
        }
        
        public UserException(Exception innerException) : base(innerException.Message, innerException) {
        }
        
    }
}
