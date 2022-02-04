using DishesGenerator.Domain.Abstractions;
using DishesGenerator.Domain.Events;
using DishesGenerator.Domain.Exceptions;
using DishesGenerator.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace DishesGenerator.Domain.Entities
{
    public class Dish : AggregateRoot<int>
    {
        public DishName Name { get; }
        public DishShortDescription ShortDescription { get; }
        public LinkedList<DishIngredient> Ingredients { get; } = new();
        public uint Portions { get; }

        public Dish(DishName name,
            DishShortDescription shortDescription,
            uint portions,
            IEnumerable<DishIngredient> ingredients)
        {
            Name = name;
            ShortDescription = shortDescription;
            Portions = portions;

            foreach (var ingredient in ingredients)
                AddIngredient(ingredient);
        }

        private Dish()
        {

        }

        public void AddIngredient(DishIngredient ingredient)
        {
            var ingredientExists = Ingredients.Any(i => i.IngredientInfo.Name == ingredient.IngredientInfo.Name);

            if (ingredientExists)
                throw new IngredientAlreadyExistsException(ingredient.IngredientInfo.Name);

            Ingredients.AddLast(ingredient);

            AddEvent(new DishIngredientAdded(this, ingredient));
        }

        public void RemoveIngredient(string ingredientName)
        {
            var ingredient = Ingredients.SingleOrDefault(i => i.IngredientInfo.Name == ingredientName);
            if (ingredient is null)
                throw new DishIngredientNotFoundException(ingredientName);

            Ingredients.Remove(ingredient);

            AddEvent(new DishIngredientRemoved(this, ingredient));
        }
    }
}
