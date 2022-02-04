namespace DishesGenerator.Domain.Exceptions
{
    public class IngredientNameIsEmptyException : DishesGeneratorException
    {
        public IngredientNameIsEmptyException() : base("Ingredient name is empty.")
        {
        }
    }
}
