using NUnit.Framework;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Servicios;

namespace UnitTest_Walmart.SIEP.Productos {
    public class UnitTest_Palindromo {
        public void Setup() {
        }

        [Test]
        public void PalindromoCheck() {
            //Arrange
            string palindromo = "salas";

            PalindromoHelper resultPalindromo = new ValidarBusqueda(palindromo);

            //Act
            var response = resultPalindromo.ValidarPalindromo(palindromo);

            //Assert
            Assert.IsTrue(response);
        }
    }
}
