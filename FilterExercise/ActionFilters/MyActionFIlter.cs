using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExercise.ActionFilters
{
    public class MyActionFIlter : IActionFilter
    {
        private readonly ILogger<MyActionFIlter> _logger;

        public MyActionFIlter(ILogger<MyActionFIlter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation(context.ActionDescriptor.DisplayName);
            //_logger.LogInformation(context.ActionDescriptor);
        }
    }
}
