using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DishesGenerator.Domain.Exceptions
{
    public class IngredientAlreadyExistsException : DishesGeneratorException
    {
        public IngredientAlreadyExistsException(string name) : base($"Ingredient with name {name} already exists.")
        {

        }
    }
}
