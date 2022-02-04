using DishesGenerator.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DishesGenerator.Infrastructure.EF.Models
{
    internal class DishReadModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public uint Portions { get; private set; }
        public List<DishIngredientReadModel> Ingredients { get; private set; }

        
        public float KcalsPerPortion => Ingredients.Sum(i => i.Kcals) / Portions;

    }
}
