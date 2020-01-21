using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExercise.ActionFilters
{
    public class MyActionFilterAsync : IAsyncActionFilter
    {
        private readonly ILogger<MyActionFilterAsync> _logger;

        public MyActionFilterAsync(ILogger<MyActionFilterAsync> logger)
        {
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            _logger.LogInformation(context.ActionDescriptor.DisplayName);
            await next();
            _logger.LogInformation(context.ActionDescriptor.DisplayName);
        }
    }
}
