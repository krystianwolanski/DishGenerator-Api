using DishesGenerator.Domain.Abstractions;
using DishesGenerator.Domain.Entities;
using DishesGenerator.Domain.ValueObjects;

namespace DishesGenerator.Domain.Events
{
    public sealed record DishIngredientRemoved(Dish dish, DishIngredient dishIngredient) : IDomainEvent;
}
