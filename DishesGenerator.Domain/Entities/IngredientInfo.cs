namespace DishesGenerator.Domain.ValueObjects
{
    public class IngredientInfo
    {
        public int Id { get; }
        public IngredientName Name { get; }
        public Kcals KcalsPer100Grams { get; }
        public Money PricePer100Grams { get; }

        public IngredientInfo(int id, IngredientName name)
        {
            Id = id;
            Name = name;
        }
    }
}
