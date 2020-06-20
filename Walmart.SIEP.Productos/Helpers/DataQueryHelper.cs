using System.Collections.Generic;
using Walmart.SIEP.Productos.Models.Clases;

namespace Walmart.SIEP.Productos.Helpers {
    public abstract class DataQueryHelper {
        protected string palabra;
        public string Palabra { get => palabra; set => palabra = value; }

        public DataQueryHelper(string _palabra) {
            palabra = _palabra;
        }

        public abstract List<ProductoDTO> GetProductById(int palabra);

        public abstract List<ProductoDTO> GetProductByName(string palabra);
    }
}
