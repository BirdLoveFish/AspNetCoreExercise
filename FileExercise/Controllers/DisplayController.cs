using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileExercise.Controllers
{
    public class DisplayController:Controller
    {
        private readonly IHostEnvironment _env;

        public DisplayController(IHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            //在发布后，这里是获取不到FileExercise根目录的，而是获取publish文件夹
            var rootPath = _env.ContentRootPath;
            var files = Directory.GetFiles(rootPath);
            
            return Ok(files.Where(o => o.EndsWith("html") | o.EndsWith("png")));
        }
    }
}
