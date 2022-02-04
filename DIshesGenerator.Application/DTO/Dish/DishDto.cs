using DishesGenerator.Application.DTO.Ingredient;
using System.Collections.Generic;

namespace DishesGenerator.Application.DTO.Dish
{
    public class DishDto
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public uint Portions { get; set; }
        public float KcalPerPortion { get; set; }
        public double PricePerPortion { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }
    }
}
