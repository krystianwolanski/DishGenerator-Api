namespace DishesGenerator.Domain.ValueObjects
{
    public class IngredientInfo
    {
        public int Id { get; private set; }
        public IngredientName Name { get; private set; }
        public Kcals KcalsPer100Grams { get; private set; }
        public Money PricePer100Grams { get; private set; }

        public IngredientInfo(int id, IngredientName name)
        {
            Id = id;
            Name = name;
        }
    }
}
