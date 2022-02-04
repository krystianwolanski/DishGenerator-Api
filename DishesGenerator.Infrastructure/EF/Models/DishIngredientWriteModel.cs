namespace DishesGenerator.Infrastructure.EF.Models
{
    public class DishIngredientWriteModel
    {
        public int Id { get; init; }
        public float GramsWeight { get; init; }
        public int DishId { get; private set; }
        public DishWriteModel Dish { get; private set; }
        public int IngredientInfoId { get; init; }
        public IngredientInfoWriteModel IngredientInfo { get; init; }

    }
}
