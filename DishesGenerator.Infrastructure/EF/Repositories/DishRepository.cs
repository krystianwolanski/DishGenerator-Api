using DishesGenerator.Domain.Entities;
using DishesGenerator.Domain.Repositories;
using DishesGenerator.Domain.ValueObjects;
using DishesGenerator.Infrastructure.EF.Contexts;
using DishesGenerator.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DishesGenerator.Infrastructure.EF.Repositories
{
    internal sealed class DishRepository : IDishRepository
    {
   

        private readonly DbSet<DishWriteModel> _dishes;
        private readonly WriteDbContext _dbContext;

        public DishRepository(WriteDbContext dbContext)
        {
            _dishes = dbContext.Dishes;
            _dbContext = dbContext;
        }

        public async Task AddAsync(Dish dish)
        {

            var dishWriteModel = new DishWriteModel
            {
                Name = dish.Name,
                ShortDescription = dish.ShortDescription,
                Portions = dish.Portions,
                DishIngredients = dish.Ingredients.Select(i => new DishIngredientWriteModel
                {
                    GramsWeight = i.GramsWeight,
                    IngredientInfoId = i.IngredientInfo.Id
                }).ToList()

            };
            
            await _dishes.AddAsync(dishWriteModel);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Dish dish)
        {
            throw new System.NotImplementedException();
        }

        public Task<Dish> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Dish dish)
        {
            throw new System.NotImplementedException();
        }
    }
}
