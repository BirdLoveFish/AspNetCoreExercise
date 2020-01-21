using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExercise.ActionFilters
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        //private readonly ILogger<MyActionFilterAttribute> _logger;

        //public MyActionFilterAttribute(ILogger<MyActionFilterAttribute> logger)
        //{
        //    _logger = logger;
        //}
        public async override Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            //ModelBinding在这个前面
            if (!context.ModelState.IsValid)
            {
                context.Result = new ObjectResult("cuo la");
                return;
            }
            await next();
            //_logger.LogInformation("MyActionFilterAttribute ed");
        }
    }
}
