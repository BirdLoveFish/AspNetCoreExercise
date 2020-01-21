using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExercise.ResultFilters
{
    //所有的返回结构都要经过这里，包括异常过滤器和授权过滤器
    public class MyAlawaysResultFilter : IAsyncAlwaysRunResultFilter
    {
        public async Task OnResultExecutionAsync(
            ResultExecutingContext context, 
            ResultExecutionDelegate next)
        {

            await next();
        }
    }
}
