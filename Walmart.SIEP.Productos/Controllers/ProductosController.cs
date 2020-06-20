using System;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Models.Response;
using Walmart.SIEP.Productos.Servicios;

namespace Walmart.SIEP.Productos.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : BaseController {
        public ProductosController(TelemetryClient telemetry) : base(telemetry) {}

        /// <summary>
        /// Metodo que retorna productos según el valor entregado
        /// </summary>
        /// <param name="producto">Corresponde al IdProducto, Marca o Descripción para buscar en BD</param>
        /// <returns>JSON Object</returns>
        [HttpGet("obtenerproductos")]
        public ActionResult<ResultResponse> ObtenerProductos([FromHeader] string producto) {
            ValidarRequestService validacionService = new ValidarRequestService(_telemetry);
            ResultResponse resultValidate = validacionService.CheckRequest(producto);
            if (!string.IsNullOrEmpty(resultValidate.IdError))
                return BadRequest(resultValidate.MessageError);

            PalindromoHelper palindrome = new ValidarBusqueda(producto);
            PalindromoService objectPalindromo = new PalindromoService(palindrome, _telemetry);
            bool resultPalindromo = Convert.ToBoolean(objectPalindromo.ValidarPalindromo(producto).IsPalindromo);

            ProductosService objectService = new ProductosService(_telemetry);
            ResultResponse registros = objectService.ObtenerProducto(producto, resultPalindromo);
            return Ok(registros);
        }
    }
}