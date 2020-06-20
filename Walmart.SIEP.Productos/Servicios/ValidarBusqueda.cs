using System;
using System.Linq;
using Walmart.SIEP.Productos.Helpers;

namespace Walmart.SIEP.Productos.Servicios {
    public class ValidarBusqueda : PalindromoHelper {
        public ValidarBusqueda(string palabra) : base(palabra) {}

        public override bool ValidarPalindromo(string palabraBusqueda) {
            return palabraBusqueda.SequenceEqual(palabraBusqueda.Reverse());
        }
    }
}
