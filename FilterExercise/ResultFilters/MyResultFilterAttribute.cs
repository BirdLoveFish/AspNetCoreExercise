using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExercise.ResultFilters
{
    public class MyResultFilterAttribute : ResultFilterAttribute
    {
        private readonly string _name;
        private readonly int _age;

        public MyResultFilterAttribute(string name, int age)
        {
            _name = name;
            _age = age;
        }
        public override async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            //在await前面的是最终返回的result
            context.Result = new OkObjectResult("ing");
            await next();
            context.Result = new OkObjectResult("ed");
        }
    }
}
