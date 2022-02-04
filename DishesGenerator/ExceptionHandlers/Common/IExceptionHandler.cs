using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace DishesGenerator.Api.ExceptionHandlers.Common
{
    public interface IExceptionHandler<in ExceptionType> where ExceptionType : Exception
    {
        public void HandleException(ExceptionContext context, ExceptionType exception);
    }
}
