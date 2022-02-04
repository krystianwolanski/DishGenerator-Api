using System.Linq;

namespace DishesGenerator.Domain.ValueObjects
{

    public record Money
    {
        public Currency Currency { get; init; }
        public double Value { get; init; }

        public Money(Currency currency, double value)
        {
            Currency = currency;
            Value = value;
        }

        public Money(string value)
        {
            var splited = value.Split(" ");

            Value = double.Parse(splited.First());
            Currency = Currency.From(splited.Last());
        }

        private Money()
        {

        }

        public static implicit operator double (Money value)
            => value.Value;

        public static Money operator *(GramsWeight grams, Money money)
        {
            return new Money(money.Currency, grams.Value * money.Value);
        }

        public override string ToString()
        {
            return $"{Value} {Currency}";
        }
    }
}
