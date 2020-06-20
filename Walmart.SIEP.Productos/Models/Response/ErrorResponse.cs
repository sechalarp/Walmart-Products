namespace Walmart.SIEP.Productos.Models.Response {
    public class ErrorResponse {
        public ErrorResponse() {
            Message = "Oh! Se ha generado un error";
        }
        public string Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
