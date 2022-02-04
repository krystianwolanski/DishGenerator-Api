using DishesGenerator.Domain.Exceptions;

namespace DishesGenerator.Domain.ValueObjects
{
    public class IngredientName
    {
        public string Value;

        public IngredientName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new IngredientNameIsEmptyException();

            Value = value;
        }

        private IngredientName()
        {

        }

        public static implicit operator string(IngredientName ingredientName)
            => ingredientName.Value;

        public static implicit operator IngredientName(string ingredientName)
            => new(ingredientName);
    }
}
