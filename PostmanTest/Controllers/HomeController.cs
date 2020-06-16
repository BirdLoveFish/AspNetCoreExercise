using Microsoft.AspNetCore.Mvc;

namespace PostmanTest.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("Para")]
        public IActionResult Para(string para1, string para2)
        {
            return Ok(new
            {
                para1,para2
            });
        }
    }
}
