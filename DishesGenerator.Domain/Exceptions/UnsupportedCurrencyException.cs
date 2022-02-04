namespace DishesGenerator.Domain.Exceptions
{
    public class UnsupportedCurrencyException : DishesGeneratorException
    {
        public UnsupportedCurrencyException(string code) : base($"Currency of code {code} is unsupported.")
        {
        }
    }
}
