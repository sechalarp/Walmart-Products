using System.Linq;
using Walmart.SIEP.Productos.Models.Clases;

namespace Walmart.SIEP.Productos.Helpers {
    public abstract class DataQueryHelper {
        protected string palabra;
        public string Palabra { get => palabra; set => palabra = value; }

        public DataQueryHelper(string _palabra) {
            palabra = _palabra;
        }

        public abstract IQueryable<ProductoDTO> GetProductById(int palabra);

        public abstract IQueryable<ProductoDTO> GetProductByBrand(string palabra);

        public abstract IQueryable<ProductoDTO> GetProductByDescription(string palabra);

        public abstract IQueryable<ProductoDTO> GetProductByName(string palabra);
    }
}
