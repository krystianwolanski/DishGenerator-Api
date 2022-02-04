using DishesGenerator.Domain.Entities;
using System.Threading.Tasks;

namespace DishesGenerator.Domain.Repositories
{
	public interface IDishRepository
	{
		Task<Dish> GetAsync(int id);
		Task AddAsync(Dish dish);
		Task UpdateAsync(Dish dish);
		Task DeleteAsync(Dish dish);
	}
}
