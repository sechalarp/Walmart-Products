using MongoDB.Driver;
using NUnit.Framework;
using Walmart.SIEP.Productos.Data;
using Walmart.SIEP.Productos.Models.Clases;

namespace UnitTest_Walmart.SIEP.Productos {
    public class UnitTest_MongoConexion {
        public void Setup() {
        }

        [Test]
        public void MongoConexionCollection() {
            //Arrange
            string coleccionMongoDB = "products";
            ProductsData data = new ProductsData();
            //Act
            IMongoCollection<ProductoDTO> resultData = data.GetProductDataById();

            //Assert
            Assert.AreEqual(coleccionMongoDB, resultData.CollectionNamespace.CollectionName);
        }
    }
}
