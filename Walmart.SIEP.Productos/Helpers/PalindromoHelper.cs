namespace Walmart.SIEP.Productos.Helpers {
    public abstract class PalindromoHelper {
        protected string palindromo;
        public string Palindromo { get => palindromo; set => palindromo = value; }

        public PalindromoHelper(string _palindromo) {
            palindromo = _palindromo;
        }

        public abstract bool ValidarPalindromo(string palindromo);
    }
}
