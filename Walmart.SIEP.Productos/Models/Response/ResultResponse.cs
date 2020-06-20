namespace Walmart.SIEP.Productos.Models.Response {
    public class ResultResponse {
        public ResultResponse() {
            MessageError = "Oh! Ha habido un problema al procesar la información";
        }
        public string IdError { get; set; }
        public string MessageError { get; set; }
        public string Data { get; set; }
    }
}
