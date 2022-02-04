using DishesGenerator.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
