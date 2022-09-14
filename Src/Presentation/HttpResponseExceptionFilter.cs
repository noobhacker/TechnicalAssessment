using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TechnicalAssessment.Core.Exceptions;

namespace TechnicalAssessment.Presentation
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        private readonly ILogger<HttpResponseExceptionFilter> _logger;

        public HttpResponseExceptionFilter(ILogger<HttpResponseExceptionFilter> logger)
        {
            _logger = logger;
        }

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
            else if (context.Exception is not null)
            {
                context.Result = new ObjectResult(context.Exception?.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                _logger.LogError($"Unhandled internal server error: \n{context.Exception?.Message}\n{context.Exception?.StackTrace}");
            }

            context.ExceptionHandled = true;
        }
    }
}
