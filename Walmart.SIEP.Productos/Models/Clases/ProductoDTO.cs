using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Walmart.SIEP.Productos.Models.Clases {
    public class ProductoDTO {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId IdObjetoDTO { get; set; }
        [BsonElement("id")]
        public int IdProductoDTO { get; set; }
        [BsonElement("brand")]
        public string MarcaProductoDTO { get; set; }
        [BsonElement("description")]
        public string DescripcionProductoDTO { get; set; }
        [BsonElement("image")]
        public string FotoProductoDTO { get; set; }
        [BsonElement("price")]
        public decimal ValorProductoDTO { get; set; }
    }
}
