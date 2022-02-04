using DishesGenerator.Domain.Exceptions;

namespace DishesGenerator.Domain.ValueObjects
{
    public record GramsWeight
    {
        public float Value { get; }

        public GramsWeight(float value)
        {
            if (value is <= 0)
                throw new InvalidGramsWeightException(value);

            Value = value;
        }

        public static implicit operator float(GramsWeight gramsWeight)
            => gramsWeight.Value;

        public static implicit operator GramsWeight(float gramsWeight)
            => new(gramsWeight);
    }
}
