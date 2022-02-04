using DishesGenerator.Domain.ValueObjects;

namespace DishesGenerator.Infrastructure.EF.Models
{
    public record IngredientInfoWriteModel
    {
        public int Id { get; private set; }
        public string Name { get; init; }
        public float KcalsPer100Grams { get; init; }
        public string PricePer100Grams { get; init; }
    }
}
