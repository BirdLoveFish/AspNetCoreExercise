using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Environment.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IConfiguration configuration, 
            IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            /*  
             *  发布后不管是Release还是Debug都是Production
             *  
             *  Production和Development是环境变量
             *  Debug和Release是宏定义
             */
            //var result = _webHostEnvironment.EnvironmentName;

            var result = _configuration["key1"];

            return Ok(result);
        }
        
    }
}
