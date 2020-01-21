using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExercise.ResultFilters
{
    public class MyResultFilter : IResultFilter
    {
        private readonly ILogger<MyResultFilter> _logger;

        public MyResultFilter(ILogger<MyResultFilter> logger)
        {
            _logger = logger;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation((context.Result as OkObjectResult).Value.ToString());
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation((context.Result as OkObjectResult).Value.ToString());
        }
    }
}
