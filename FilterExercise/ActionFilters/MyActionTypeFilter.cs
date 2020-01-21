using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExercise.ActionFilters
{
    public class MyActionTypeFilter : IAsyncActionFilter
    {
        public MyActionTypeFilter(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            await next();
        }
    }
}
