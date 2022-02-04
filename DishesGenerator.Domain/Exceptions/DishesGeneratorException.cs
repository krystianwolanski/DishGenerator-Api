using System;

namespace DishesGenerator.Domain.Exceptions
{
    public abstract class DishesGeneratorException : Exception
    {
        public DishesGeneratorException(string message) : base(message)
        {

        }   
    }
}
