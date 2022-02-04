using System.Collections.Generic;

namespace DishesGenerator.Infrastructure.EF.Models
{
    public class DishWriteModel
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public string ShortDescription { get; init; }
        public List<DishIngredientWriteModel> DishIngredients { get; init; }
        public uint Portions { get; init; }
    }
}
