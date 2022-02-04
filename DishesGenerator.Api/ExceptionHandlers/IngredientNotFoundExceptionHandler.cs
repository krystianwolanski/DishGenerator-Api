using DishesGenerator.Api.ExceptionHandlers.Common;
using DishesGenerator.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DishesGenerator.Api.ExceptionHandlers
{
    public class IngredientNotFoundExceptionHandler : IExceptionHandler<IngredientNotFoundException>
    {
        public void HandleException(ExceptionContext context, IngredientNotFoundException exception)
        {
            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The specified resource was not found.",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}
