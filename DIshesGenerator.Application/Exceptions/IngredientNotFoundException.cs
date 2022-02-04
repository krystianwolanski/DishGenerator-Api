using DishesGenerator.Domain.Exceptions;

namespace DishesGenerator.Application.Exceptions
{
    public class IngredientNotFoundException : DishesGeneratorException
    {
        public IngredientNotFoundException(string name) : base($"Ingredient with name '{name}' not found.")
        {

        } 
    }
}
