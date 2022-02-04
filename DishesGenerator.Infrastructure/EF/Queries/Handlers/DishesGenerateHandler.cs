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
using System;

namespace DishesGenerator.Infrastructure.EF.Queries.Handlers
{
    internal sealed class DishesGenerateHandler : IRequestHandler<GenerateDishes, List<DishDto>>
    {
        private readonly DbSet<DishReadModel> _dishes;

        public DishesGenerateHandler(ReadDbContext readDbContext)
        {
            _dishes = readDbContext.Dishes;
        }

        public async Task<List<DishDto>> Handle(GenerateDishes request, CancellationToken cancellationToken)
        {
            var (maxKcalPerPortion, maxPricePerPortion, ingredientsNames) = request;

            var query = _dishes
                .Where(d => d.Ingredients
                    .Sum(x => x.GramsWeight / 100 * x.IngredientInfo.PricePer100Grams) / d.Portions <= maxPricePerPortion);
            
            query = query
                .Where(d => d.Ingredients
                    .Sum(x => x.GramsWeight / 100 * x.IngredientInfo.KcalsPer100Grams) / d.Portions <= maxKcalPerPortion);

            if (ingredientsNames is not null)
            {
                query = query.Where(d => d.Ingredients.Any(i => ingredientsNames.Contains(i.IngredientInfo.Name)));
            }

            return await query.Select(d => new DishDto
            {
                Name = d.Name,
                ShortDescription = d.ShortDescription,
                Portions = d.Portions,
                Ingredients = d.Ingredients.Select(i => new IngredientDto
                {
                    Name = i.IngredientInfo.Name,
                    Grams = i.GramsWeight,
                    Kcals = i.GramsWeight / 100 * i.IngredientInfo.KcalsPer100Grams,
                    Price = i.GramsWeight / 100 * i.IngredientInfo.PricePer100Grams
                }),
                KcalPerPortion = d.Ingredients.Sum(i => i.GramsWeight / 100 * i.IngredientInfo.KcalsPer100Grams) / d.Portions,
                PricePerPortion = d.Ingredients.Sum(i => i.GramsWeight / 100 * i.IngredientInfo.PricePer100Grams) / d.Portions
            }).ToListAsync();
          
        }
    }
}
