using Microsoft.ApplicationInsights;
using System;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Models.Response;

namespace Walmart.SIEP.Productos.Servicios {
    public class PalindromoService : ServiceBase {
        private readonly PalindromoHelper _palindromo;
        public PalindromoService(PalindromoHelper palindromo, TelemetryClient telemetry) : base(telemetry) {
            _palindromo = palindromo;
        }

        internal ResultResponse ValidarPalindromo(string palabra) {
            try {
                bool resultadoPalindromo = _palindromo.ValidarPalindromo(palabra);
                return new ResultResponse {
                    MessageError = string.Empty,
                    IsPalindromo = resultadoPalindromo
                };
            } catch (Exception ex) {
                return RegisterException(ex);
            }
        }
    }
}
