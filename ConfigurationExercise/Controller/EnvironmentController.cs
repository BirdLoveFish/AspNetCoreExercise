using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationExercise.Controller
{
    public class EnvironmentController: ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EnvironmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 环境变量
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            /* 在命令行中输入(只有从项目的目录中输入，PowerShell没用)
             * set MyKey=hello
             * dotnet run
             * 
             * 得到 hello
             * 关闭命令行则该配置项消失
             */

            /*
             * setx MyKey hello
             * 设置用户的环境变量
             */

            /*
             * setx MyKey hello /m
             * 设置系统的环境变量
             * 但是需要获取权限
             */

            /*
             * command中的设置会覆盖appsettings中的设置
             */

            var result = _configuration["MyKey"];
            return Ok(result);
        }
    }
}
