using DishesGenerator.Domain.ValueObjects;

namespace DishesGenerator.Infrastructure.EF.Models
{
    internal class DishIngredientReadModel
    {
        public int Id { get; private set; }
        public float GramsWeight { get; private set; }
        public int IngredientInfoId { get; private set; }
        public IngredientInfoReadModel IngredientInfo { get; private set; }
        public int DishId { get; private set; }
        public DishReadModel Dish { get; private set; }

        public Money Price => GramsWeight / 100 * IngredientInfo.PricePer100Grams;
        public float Kcals => GramsWeight / 100 * IngredientInfo.KcalsPer100Grams;
    }
}
