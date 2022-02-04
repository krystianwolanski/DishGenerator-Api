using DishesGenerator.Infrastructure.EF.Contexts;
using DishesGenerator.Infrastructure.EF.Models;
using DishesGenerator.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DishesGenerator.Application.DTO.Dish;
using DishesGenerator.Application.DTO.Ingredient;

namespace DishesGenerator.Infrastructure.EF.Queries.Handlers
{
    internal sealed class DishesGenerateHandler : IRequestHandler<GenerateDishes, List<DishDto>>
    {
        private readonly DbSet<DishReadModel> _dishes;

        public DishesGenerateHandler(ReadDbContext readDbContext)
        {
            _dishes = readDbContext.Dishes;
        }

        public Task<List<DishDto>> Handle(GenerateDishes request, CancellationToken cancellationToken)
        {
            var (maxKcalPerPortion, maxPricePerPortion, ingredientsNames) = request;

            var query = _dishes
                .Include(d => d.Ingredients)
                .ThenInclude(d => d.IngredientInfo)
                .Where(d => d.Ingredients
                    .Sum(x => x.GramsWeight / 100 * x.IngredientInfo.KcalsPer100Grams) / (float)d.Portions
                        <= maxKcalPerPortion);

            if (ingredientsNames is not null)
            {
                query = query.Where(d => d.Ingredients.Any(i => ingredientsNames.Contains(i.IngredientInfo.Name)));
            }

            var result = query.AsEnumerable().Where(d => d.Ingredients
                .Sum(x => x.Price) / d.Portions <= maxPricePerPortion);

            return Task.FromResult(result.Select(d => new DishDto
            {
                Name = d.Name,
                ShortDescription = d.ShortDescription,
                Portions = d.Portions,
                Ingredients = d.Ingredients.Select(i => new IngredientDto
                {
                    Name = i.IngredientInfo.Name,
                    Kcals = i.Kcals,
                    Grams = i.GramsWeight,
                    Price = i.Price.ToString()
                }),
                KcalPerPortion = d.KcalsPerPortion
            }).ToList());
        }
    }
}
