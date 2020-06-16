using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FileExercise.Controllers
{
    public class PurlController:ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _dir;

        public PurlController(IWebHostEnvironment environment)
        {
            _environment = environment;
            _dir = _environment.WebRootPath + "/file";
        }

        public IActionResult Upload(IFormFile file)
        {
            if (file == null)
            {
                return Ok("file = null");
            }

            var pathname = Path.Combine(_dir, file.FileName);

            using (var fileStream =
                new FileStream(pathname, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            return Ok("success");
        }

        /* Download 
         * 
         * 文件下载有2种方式
         * File是将文件读取到内存中(是Stream还是Byte还是String都无所谓)，再返回
         * PhysicalFile是直接返回硬盘中的文件
         * 
         * 其实还有第三种方式
         * 由于我们用了app.UseStaticFiles();
         * 所以我们可以访问静态文件
         */

        public IActionResult Display(string filename)
        {
            var pathname = Path.Combine(_dir, filename);
            var result = System.IO.File.ReadAllText(pathname);
            return Ok(result);
        }

        public IActionResult DisplayV2(string filename)
        {
            var pathname = Path.Combine(_dir, filename);
            var result = System.IO.File.OpenRead(pathname);

            return File(result, "image/png");
        }

        public IActionResult DisplayV3(string filename)
        {
            var pathname = Path.Combine(_dir, filename);
            var result = System.IO.File.OpenRead(pathname);
            return File(result, "image/png", "pic1.png");
        }

        public IActionResult DisplayV4(string filename)
        {
            var pathname = Path.Combine(_dir, filename);
            return PhysicalFile(pathname, "image/png", "pic1.png");
        }

    }
}
