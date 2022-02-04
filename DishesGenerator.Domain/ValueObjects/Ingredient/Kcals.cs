using DishesGenerator.Domain.Exceptions;

namespace DishesGenerator.Domain.ValueObjects
{
    public record Kcals
    {
        public float Value { get; set; }

        public Kcals(float value)
        {
            if (value is < 0)
                throw new InvalidKcalException(value);

            Value = value;
        }

        public static implicit operator float(Kcals kcal)
            => kcal.Value;

        public static implicit operator Kcals(float kcal)
            => new(kcal);
    }
}
