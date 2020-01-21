using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExercise.ResultFilters
{
    public class MyResultFilterAsync : IAsyncResultFilter
    {
        private readonly ILogger<MyResultFilterAsync> _logger;

        public MyResultFilterAsync(ILogger<MyResultFilterAsync> logger)
        {
            _logger = logger;
        }
        public async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            _logger.LogInformation((context.Result as OkObjectResult).Value.ToString());
            await next();
            _logger.LogInformation((context.Result as OkObjectResult).Value.ToString());
        }
    }
}
