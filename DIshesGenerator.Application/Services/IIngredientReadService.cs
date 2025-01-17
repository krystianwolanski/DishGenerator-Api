﻿using DishesGenerator.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishesGenerator.Application.Services
{
    public interface IIngredientReadService
    {
        Task<int?> GetIngredientIdByName(IngredientName name);
    }
}
