using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using Walmart.SIEP.Productos.Data;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Models.Clases;

namespace Walmart.SIEP.Productos.Servicios {
    public class QueryFinder : DataQueryHelper {
        private IQueryable<ProductoDTO> resultado;
        private IMongoCollection<ProductoDTO> resultData;
        public QueryFinder(string palabra) : base(palabra) { }

        public override IQueryable<ProductoDTO> GetProductById(int palabra) {
            ProductsData data = new ProductsData();
            resultData = data.GetProductDataById();
            resultado = from r in resultData.AsQueryable()
                        where r.IdProductoDTO == palabra
                        select r;
            return resultado;
        }

        public override IQueryable<ProductoDTO> GetProductByBrand(string palabra) {
            ProductsData data = new ProductsData();
            resultData = data.GetProductDataByName();//DRY!
            resultado = from c in resultData.AsQueryable()
                        where c.MarcaProductoDTO.Contains(palabra)
                        select c;
            return resultado;
        }

        public override IQueryable<ProductoDTO> GetProductByDescription(string palabra) {
            ProductsData data = new ProductsData();
            resultData = data.GetProductDataByName();//DRY!
            resultado = from c in resultData.AsQueryable()
                        where c.DescripcionProductoDTO.Contains(palabra)
                        select c;
            return resultado;
        }

        public override IQueryable<ProductoDTO> GetProductByName(string palabra) {
            ProductsData data = new ProductsData();
            resultData = data.GetProductDataByName();//DRY!
            resultado = from c in resultData.AsQueryable()
                        where c.DescripcionProductoDTO.Contains(palabra)
                        select c;

            
            return resultado;
        }
    }
}
