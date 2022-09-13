using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TechnicalAssessment.Core.Exceptions;

namespace TechnicalAssessment.Presentation
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is RestfulException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Message)
                {
                    StatusCode = (int)httpResponseException.HttpCode
                };
            } 
            else
            {
                context.Result = new ObjectResult(context.Exception?.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

            context.ExceptionHandled = true;
        }
    }
}
