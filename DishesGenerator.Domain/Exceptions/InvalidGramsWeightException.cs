namespace DishesGenerator.Domain.Exceptions
{
    public class InvalidGramsWeightException : DishesGeneratorException
    {
        public InvalidGramsWeightException(float value) : base($"Invalid value ({value}) of grams.")
        {
        }
    }
}
