using System;

namespace Walmart.SIEP.Productos.Exceptions {
    public class PalindromoException : Exception {
        public PalindromoException(string message) : base(message) { }
    }
}
