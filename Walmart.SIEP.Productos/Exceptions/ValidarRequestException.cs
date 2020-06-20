using System;

namespace Walmart.SIEP.Productos.Exceptions {
    public class ValidarRequestException : Exception {
        public ValidarRequestException(string message) : base(message) { }
    }
}
