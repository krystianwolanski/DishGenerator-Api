using System.Linq;

namespace DishesGenerator.Domain.ValueObjects
{

    public record Money
    {
        //public string Currency { get; init; }
        public double Value { get; init; }

        public Money(double value)
        {
            Value = value;
        }

     
        private Money()
        {

        }

        public static implicit operator double(Money value)
            => value.Value;

        public static implicit operator Money(double value)
            => new(value);

        public static Money operator *(GramsWeight grams, Money money)
        {
            return new Money(grams.Value * money.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
