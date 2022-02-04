using DishesGenerator.Application.Commands;
using DishesGenerator.Application.DTO.Dish;
using DishesGenerator.Application.Queries;
using DishesGenerator.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishesGenerator.Api.Controllers
{
    public class DishGeneratorController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> CreateDish([FromBody] CreateDish createDish)
        {
            await Mediator.Send(createDish);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<DishDto>>> GenerateDishes([FromQuery]GenerateDishesDto generateDishesDto)
        {
            var maxMoney = generateDishesDto.MaxMoney;
            var maxKcalPerPortion = generateDishesDto.MaxKcalPerPortion;
            var ingredientsNames = generateDishesDto.IngredientsNames;

            var generateDishesQuery = new GenerateDishes(
                maxKcalPerPortion, 
                new Money(maxMoney.Value),
                ingredientsNames);
        
            var dishes = await Mediator.Send(generateDishesQuery);

            return Ok(dishes);
        }
    }
}
