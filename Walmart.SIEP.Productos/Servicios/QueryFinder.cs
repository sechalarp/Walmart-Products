using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Walmart.SIEP.Productos.Data;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Models.Clases;

namespace Walmart.SIEP.Productos.Servicios {
    public class QueryFinder : DataQueryHelper {
        private List<ProductoDTO> listResultDB;
        public QueryFinder(string palabra) : base(palabra) {
            listResultDB = new List<ProductoDTO>();
        }

        public override List<ProductoDTO> GetProductById(int palabra) {
            ProductsData data = new ProductsData();
            IMongoCollection<ProductoDTO> resultData = data.GetProductDataById();
            listResultDB = (from r in resultData.AsQueryable()
                        where r.IdProductoDTO == palabra
                        select new ProductoDTO { IdObjetoDTO = r.IdObjetoDTO, IdProductoDTO = r.IdProductoDTO, MarcaProductoDTO = r.MarcaProductoDTO, DescripcionProductoDTO = r.DescripcionProductoDTO, FotoProductoDTO = r.FotoProductoDTO, ValorProductoDTO = r.ValorProductoDTO }).ToList();
            return listResultDB;
        }

        public override List<ProductoDTO> GetProductByName(string palabra) {
            ProductsData data = new ProductsData();

            IMongoCollection<BsonDocument> products =  data.GetProductDataByName();
            FilterDefinitionBuilder<BsonDocument> builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = @"{ $or: [{ ""brand"" : {$in: [/$palabra$/] }},{ ""description"" : {$in: [/$palabra$/] }}] }".Replace("$palabra$", palabra);
            List<BsonDocument> resultFiltros = products.Find(filter).ToList();

            foreach (BsonDocument item in resultFiltros) {
                ProductoDTO myObj = BsonSerializer.Deserialize<ProductoDTO>(item);
                listResultDB.Add(myObj);
            }

            return listResultDB;
        }
    }
}
