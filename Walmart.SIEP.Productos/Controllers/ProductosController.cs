using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Models.Enums;
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
        public async Task<ActionResult<ResultResponse>> ObtenerProductos([FromHeader] string producto) {
            if (string.IsNullOrEmpty(producto))
                return BadRequest(StringHelper.GetDescription(EMessages.EMessageProductNullOrEmpty));

            PalindromoHelper palindrome = new ValidarBusqueda(producto);
            PalindromoService objectPalindromo = new PalindromoService(palindrome, _telemetry);
            bool resultPalindromo = Convert.ToBoolean(objectPalindromo.ValidarPalindromo(producto).Data);

            ProductosService objectService = new ProductosService(_telemetry);
            ResultResponse registro = objectService.ObtenerProducto(producto, resultPalindromo);
            return Ok(registro);
        }
    }
}