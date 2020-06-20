using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using Walmart.SIEP.Productos.Exceptions;
using Walmart.SIEP.Productos.Models.Clases;
using Walmart.SIEP.Productos.Models.Response;
using Walmart.SIEP.Productos.Helpers;

namespace Walmart.SIEP.Productos.Servicios {
    internal class ProductosService : ServiceBase {
        private List<ProductoDTO> resultado;
        internal ProductosService(TelemetryClient telemetry) : base(telemetry) {}

        internal ResultResponse ObtenerProducto(string palabra, bool isPalindromo) {
            try {
                bool isPalabraNumeric = false;
                if (int.TryParse(palabra, out int palabraNumerica))
                    isPalabraNumeric = true;

                DataQueryHelper queryResult = new QueryFinder(palabra);

                if (isPalabraNumeric) {
                    resultado = queryResult.GetProductById(palabraNumerica);
                } else {
                    resultado = queryResult.GetProductByName(palabra);
                }

                ResultResponse objResult = new ResultResponse {
                    MessageError = string.Empty,
                    Data = resultado,
                    IsPalindromo = isPalindromo
                };
                return objResult;
            } catch (ProductosException ex) {
                string mensajeCliente = ex.Message.Split(":|")[1];
                ResultResponse result = RegisterException(ex);
                result.MessageError = $"{result.MessageError} : {mensajeCliente}";
                return result;
            } catch (Exception ex) {
                return RegisterException(ex);
            }
        }
    }
}
