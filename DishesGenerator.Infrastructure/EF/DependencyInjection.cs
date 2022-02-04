using DishesGenerator.Application.Services;
using DishesGenerator.Domain.Repositories;
using DishesGenerator.Infrastructure.EF.Contexts;
using DishesGenerator.Infrastructure.EF.Repositories;
using DishesGenerator.Infrastructure.EF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DishesGenerator.Infrastructure.EF
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<IIngredientReadService, IngredientReadService>();

            services.AddDbContext<ReadDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DishGeneratorConnectionString")),ServiceLifetime.Transient);

            services.AddDbContext<WriteDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DishGeneratorConnectionString")));

            return services;
        }
    }
}
