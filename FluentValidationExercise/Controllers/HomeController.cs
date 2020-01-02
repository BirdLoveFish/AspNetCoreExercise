using FluentValidationExercise.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationExercise.Controllers
{
    [Route("[controller]/[action]")]
    //使用这个特性会显示其他的信息
    //使用ModelState只会返回错误信息
    [ApiController]
    public class HomeController: ControllerBase
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return Ok("Home Index");
        }

        public IActionResult Validate([FromBody]Person person)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            return Ok("Success");
        }
    }
}
