using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using SwaggerExercise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerExercise.Controllers
{
    /// <summary>
    /// aaaaaaaaaaaaaa
    /// </summary>
    //[ApiVersion("1.0", Deprecated = false)]
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    //[ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Home Index 例子
        /// </summary>
        /// <response code="200">成功</response>
        /// <response code="400">错误</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Index(string name)
        {
            return Ok(new Response { Age = 1, Name = "zhang"});
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="id">iddddddd</param>
        /// <param name="gender">xingbie</param>
        /// <response code="200">成功</response>
        /// <response code="400">错误</response>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Posts([FromBody]Request request)
        {
            return Ok(new Response { Age = 1, Name = "zhang" });
        }
    }
}
