using DishesGenerator.Api.ExceptionHandlers.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DishesGenerator.Api.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IExceptionHandlerContext _exceptionHandlerContext;

        public ApiExceptionFilterAttribute(IExceptionHandlerContext exceptionHandlerContext)
        {
            _exceptionHandlerContext = exceptionHandlerContext;
        }

        public override void OnException(ExceptionContext context)
        {
            _exceptionHandlerContext.HandleExceptions(context);

            base.OnException(context);
        }
    }
}
