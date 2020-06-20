using MongoDB.Driver;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Models.Clases;

namespace Walmart.SIEP.Productos.Data {
    public class ProductsData {
        private IMongoDatabase _walmartDB;
        public ProductsData() {
            _walmartDB = Conectar();
        }

        private IMongoDatabase Conectar() {
            var client = new MongoClient($"mongodb+srv://{AppSettingsHelper.GetKeyString("BD:User")}:{AppSettingsHelper.GetKeyString("BD:Password")}@{AppSettingsHelper.GetKeyString("BD:Cluster")}/{AppSettingsHelper.GetKeyString("BD:Nombre")}?retryWrites=true&w=majority");
            return client.GetDatabase(AppSettingsHelper.GetKeyString("BD:Nombre"));
        }

        //public async Task<List<ProductoDTO>> GetProductData() {
        //    return await _walmartDB.GetCollection<ProductoDTO>("products").Find(new BsonDocument()).ToListAsync();
        //}

        public IMongoCollection<ProductoDTO> GetProductDataByName() {
            return _walmartDB.GetCollection<ProductoDTO>("products");
        }

        public IMongoCollection<ProductoDTO> GetProductDataById() {
            return _walmartDB.GetCollection<ProductoDTO>("products");
        }
    }
}
