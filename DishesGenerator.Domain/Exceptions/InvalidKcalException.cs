namespace DishesGenerator.Domain.Exceptions
{
    public class InvalidKcalException : DishesGeneratorException
    {
        public InvalidKcalException(float value) : base($"Invalid value ({value}) of kcal.")
        {
        }
    }
}
