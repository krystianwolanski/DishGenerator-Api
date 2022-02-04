using DishesGenerator.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace DishesGenerator.Domain.ValueObjects
{
    public record Currency
    {
        private string _code;

        private Currency(string code)
        {
            _code = code;
        }

        public static Currency Euro => new("EUR");

        public static Currency From(string code)
        {
            var currency = new Currency(code);

            if (!SupportedCurrencies.Contains(currency))
                throw new UnsupportedCurrencyException(code);

            return currency;
        }

        private Currency()
        {

        }

        protected static IEnumerable<Currency> SupportedCurrencies
        {
            get
            {
                yield return Euro;
            }
        }

        public static implicit operator string(Currency currency)
            => currency._code;

        public override string ToString()
            => _code;
    }
}
