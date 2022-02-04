using DishesGenerator.Domain.ValueObjects;
using MediatR;
using System.Collections.Generic;
using DishesGenerator.Application.DTO.Dish;

namespace DishesGenerator.Application.Queries
{
    public sealed record GenerateDishes(
        float maxKcalPerPortion,
        Money maxMoney,
        IEnumerable<string> ingredientsNames) : IRequest<List<DishDto>>;
}
