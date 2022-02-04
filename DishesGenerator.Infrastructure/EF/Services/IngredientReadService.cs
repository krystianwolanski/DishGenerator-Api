using DishesGenerator.Application.Services;
using DishesGenerator.Domain.ValueObjects;
using DishesGenerator.Infrastructure.EF.Contexts;
using DishesGenerator.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DishesGenerator.Infrastructure.EF.Services
{
    internal sealed class IngredientReadService : IIngredientReadService
    {
        private readonly DbSet<IngredientInfoReadModel> _ingredients;

        public IngredientReadService(ReadDbContext dbContext)
        {
            _ingredients = dbContext.IngredientsInfos;
        }

        public int? GetIngredientIdByName(IngredientName name)
        {
            var result = _ingredients
                .Where(i => i.Name == name)
                .Select(i => i.Id)
                .Single();

            return result == 0 ? null : result;
        }
    }
}
