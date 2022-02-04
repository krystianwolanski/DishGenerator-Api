using System.Collections.Generic;

namespace DishesGenerator.Application.DTO.Dish
{
    public class GenerateDishesDto
    {
        public float MaxKcalPerPortion { get; set; }
        public MoneyDto MaxMoney { get; set; }
        public IEnumerable<string> IngredientsNames { get; set; }
    }
}
