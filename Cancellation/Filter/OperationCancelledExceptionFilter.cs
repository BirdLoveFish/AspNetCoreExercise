using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cancellation.Filter
{
    public class OperationCancelledExceptionFilter: IExceptionFilter
    {
        private readonly ILogger<OperationCancelledExceptionFilter> _logger;

        public OperationCancelledExceptionFilter(
            ILogger<OperationCancelledExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is OperationCanceledException)
            {
                _logger.LogInformation("request was cancelled");
                context.ExceptionHandled = true;
                context.Result = new StatusCodeResult(499);
            }
        }
    }
}
