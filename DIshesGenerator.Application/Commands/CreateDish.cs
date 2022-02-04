using DishesGenerator.Application.DTO.Ingredient.AddIngredientDto;
using DishesGenerator.Application.Exceptions;
using DishesGenerator.Application.Services;
using DishesGenerator.Domain.Entities;
using DishesGenerator.Domain.Repositories;
using DishesGenerator.Domain.ValueObjects;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DishesGenerator.Application.Commands
{
    public sealed record CreateDish(string Name, string ShortDescription, uint Portions, AddIngredientDto[] Ingredients) : IRequest;

    public sealed class CreateDishHandler : IRequestHandler<CreateDish>
    {
        private readonly IIngredientReadService _ingredientReadService;
        private readonly IDishRepository _dishRepository;

        public CreateDishHandler(IIngredientReadService ingredientReadService, IDishRepository dishRepository)
        {
            _ingredientReadService = ingredientReadService;
            _dishRepository = dishRepository;
        }

        public async Task<Unit> Handle(CreateDish request, CancellationToken cancellationToken)
        {
            var (name, shortDescription, portions, ingredients) = request;

            var dishIngredientsTasks = ingredients
                .Select(async i =>
                {
                    var ingredientId = await _ingredientReadService.GetIngredientIdByName(i.IngredientName);

                    if (ingredientId is null)
                        throw new IngredientNotFoundException(i.IngredientName);

                    return new DishIngredient(i.Grams,
                        new IngredientInfo(ingredientId.Value, i.IngredientName));
                });

            var dishIngredients = await Task.WhenAll(dishIngredientsTasks);

            var dish = new Dish(name, shortDescription, portions, dishIngredients.ToList());

            await _dishRepository.AddAsync(dish);

            return Unit.Value;
        }
    }

}
