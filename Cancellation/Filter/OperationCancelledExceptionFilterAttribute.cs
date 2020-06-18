using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Cancellation.Filter
{
    public class OperationCancelledExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is OperationCanceledException)
            {
                //_logger.LogInformation("request was cancelled");
                context.ExceptionHandled = false;
                context.Result = new StatusCodeResult(499);
            }
        }
    }
}
