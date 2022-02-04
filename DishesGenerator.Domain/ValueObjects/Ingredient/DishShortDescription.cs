using DishesGenerator.Domain.Exceptions;

namespace DishesGenerator.Domain.ValueObjects
{
    public record DishShortDescription
    {
        public string Value { get; }
        public DishShortDescription(string value)
        {
            if (value.Length > 300)
                throw new MaximumLenghtOfDescriptionHasExceededException();

            Value = value;
        }

        public static implicit operator string(DishShortDescription description)
            => description.Value;

        public static implicit operator DishShortDescription(string description)
            => new(description);
    }
}
