using System.Collections.Generic;
using Walmart.SIEP.Productos.Models.Clases;

namespace Walmart.SIEP.Productos.Models.Response {
    public class ResultResponse {
        public ResultResponse() {
            MessageError = "Oh! Ha habido un problema al procesar la información";
        }
        public string IdError { get; set; }
        public string MessageError { get; set; }
        public List<ProductoDTO> Data { get; set; }
        public bool IsPalindromo { get; set; }
    }
}
