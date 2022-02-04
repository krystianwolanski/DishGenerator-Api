using DishesGenerator.Application.Services;
using DishesGenerator.Domain.ValueObjects;
using DishesGenerator.Infrastructure.EF.Contexts;
using DishesGenerator.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DishesGenerator.Infrastructure.EF.Services
{
    internal sealed class IngredientReadService : IIngredientReadService
    {
        private readonly IServiceProvider _serviceProvider;

        public IngredientReadService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<int?> GetIngredientIdByName(IngredientName name)
        {

            var _ingredients = ((ReadDbContext)_serviceProvider.GetRequiredService(typeof(ReadDbContext))).IngredientsInfos;
                
            var result = await _ingredients
                .Where(i => i.Name == name)
                .Select(i => i.Id)
                .SingleOrDefaultAsync();

            return result == 0 ? null : result;
        }
    }
}
