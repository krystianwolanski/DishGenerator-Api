namespace DishesGenerator.Domain.Exceptions
{
    public class DishIngredientNotFoundException : DishesGeneratorException
    {
        public DishIngredientNotFoundException(string name) : base($"Dish ingredient with name {name} not found.")
        {
        }
    }
}
