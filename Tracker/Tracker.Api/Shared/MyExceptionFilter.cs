using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Tracker.Shared
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private ILogger<MyExceptionFilter> _logger;

        public MyExceptionFilter(ILogger<MyExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var exception = context.Exception;
            var message = exception.GetBaseException().Message;
            var stack = exception.StackTrace;

            _logger.LogError(new EventId(0), exception, message);

            HttpResponse response = context.HttpContext.Response;

            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";

            context.Result = new JsonResult(new MyExceptionMessage(message));

        }
    }
}
