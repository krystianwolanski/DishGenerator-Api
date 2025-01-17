﻿using DishesGenerator.Api.ExceptionHandlers.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace DishesGenerator.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebUI(this IServiceCollection services)
        {
            services.AddScoped<IExceptionHandlerContext, ExceptionHandlerContext>();
            services.AddExceptionHandlers();

            return services;
        }
        public static IServiceCollection AddExceptionHandlers(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(item => !item.IsAbstract && !item.IsInterface &&
                    item.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Any(i => i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>)))
                .ToList()
                .ForEach(exceptionHandler =>
                {
                    var serviceType = exceptionHandler.GetInterfaces()
                        .First(i => i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));

                    services.AddSingleton(serviceType, exceptionHandler);
                });

            return services;
        }
    }
}
