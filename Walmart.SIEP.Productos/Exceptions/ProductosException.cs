using System;

namespace Walmart.SIEP.Productos.Exceptions {
    public class ProductosException : Exception {
        public ProductosException(string message) : base(message) { }
    }
}
