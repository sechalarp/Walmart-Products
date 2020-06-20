using Microsoft.ApplicationInsights;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Walmart.SIEP.Productos.Data;
using Walmart.SIEP.Productos.Exceptions;
using Walmart.SIEP.Productos.Models.Clases;
using Walmart.SIEP.Productos.Models.Response;
using MongoDB.Bson;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Models.Enums;

namespace Walmart.SIEP.Productos.Servicios {
    internal class ProductosService : ServiceBase {
        private IQueryable<ProductoDTO> resultado;
        private IQueryable<ProductoDTO> resultadoBrand;
        private IQueryable<ProductoDTO> resultadoDescription;
        //private IMongoCollection<ProductoDTO> resultData;
        internal ProductosService(TelemetryClient telemetry) : base(telemetry) {}

        internal ResultResponse ObtenerProducto(string palabra, bool isPalindromo) {
            try {
                bool isPalabraNumeric = false;
                int palabraNumerica = 0;

                if (int.TryParse(palabra, out palabraNumerica))
                    isPalabraNumeric = true;

                //Palindromos que existen: assa adda
                DataQueryHelper queryResult = new QueryFinder(palabra);

                if (isPalabraNumeric) {
                    resultado = queryResult.GetProductById(palabraNumerica);
                } else {
                    //resultadoBrand = queryResult.GetProductByBrand(palabra);
                    //resultadoDescription = queryResult.GetProductByDescription(palabra);
                    //resultado = resultadoBrand.Union(resultadoDescription);
                    resultado = queryResult.GetProductByName(palabra);
                }

                ResultResponse objResult = new ResultResponse {
                    MessageError = string.Empty,
                    Data = JsonConvert.SerializeObject(resultado).ToString()
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
