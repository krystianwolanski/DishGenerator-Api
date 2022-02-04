using DishesGenerator.Domain.Exceptions;

namespace DishesGenerator.Domain.ValueObjects
{
    public class DishName
    {
        public string Value { get; }

        public DishName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DishNameIsEmptyException();

            Value = value;
        }

        public static implicit operator string(DishName dishName)
            => dishName.Value;

        public static implicit operator DishName(string dishName)
            => new(dishName);
    }
}
