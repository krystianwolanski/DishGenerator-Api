namespace DishesGenerator.Domain.Exceptions
{
    public class MaximumLenghtOfDescriptionHasExceededException : DishesGeneratorException
    {
        public static int MaxLenght => 300;
        public MaximumLenghtOfDescriptionHasExceededException() : base($"Max lenght of desription ({MaxLenght}) was exceeded.")
        {
        }
    }
}
