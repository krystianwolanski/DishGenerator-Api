using DishesGenerator.Infrastructure.EF;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DishesGenerator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(Application.DependencyInjection).Assembly);
            services.AddSqlServer(configuration);

            return services;
        }
    }
}
