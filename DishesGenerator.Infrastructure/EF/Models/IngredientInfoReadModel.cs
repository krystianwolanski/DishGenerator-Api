using DishesGenerator.Domain.ValueObjects;

namespace DishesGenerator.Infrastructure.EF.Models
{
    public class IngredientInfoReadModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public float KcalsPer100Grams { get; private set; }
        public Money PricePer100Grams { get; private set; }
    }
}
