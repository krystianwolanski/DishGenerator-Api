namespace DishesGenerator.Domain.ValueObjects
{
    public sealed record DishIngredient
    {
        public GramsWeight GramsWeight { get; init; }
        public IngredientInfo IngredientInfo { get; init; }

        public DishIngredient(GramsWeight gramsWeight, IngredientInfo ingredientInfo)
        {
            GramsWeight = gramsWeight;
            IngredientInfo = ingredientInfo;
        }
    }
}
