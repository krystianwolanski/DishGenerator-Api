namespace DishesGenerator.Domain.Exceptions
{
    public class DishNameIsEmptyException : DishesGeneratorException
    {
        public DishNameIsEmptyException() : base("Dish name is empty.")
        {
        }
    }
}
