using FileExercise.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExercise.Controllers
{
    public class UploadController : Controller
    {
        private readonly IHostEnvironment _env;

        private readonly string _dir;

        public UploadController(IHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 上传单个文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SingleFile(IFormFile file)
        {
            if(file == null)
            {
                return Ok("file = null");
            }

            var pathname = Path.Combine(_dir, file.FileName);

            using (var fileStream =
                new FileStream(pathname, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            //return RedirectToAction(nameof(Index));
            return Ok();
        }

        /// <summary>
        /// 同时上传多个文件
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult MultipleFiles(IEnumerable<IFormFile> files)
        {
            foreach (var file in files)
            {
                var pathname = Path.Combine(_dir, file.FileName);

                using var fileStream =
                    new FileStream(pathname, FileMode.Create, FileAccess.Write);
                file.CopyTo(fileStream);
            }
            //return RedirectToAction(nameof(Index));
            return Ok();
        }

        /// <summary>
        /// 用自定义Model 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult FileInModel(CustomFileViewModel vm)
        {
            var pathname = Path.Combine(_dir, vm.Other);

            using (var fileStream =
                new FileStream(pathname, FileMode.Create, FileAccess.Write))
            {
                vm.File.CopyTo(fileStream);
            }
            //return RedirectToAction(nameof(Index));
            return Ok();
        }




    }
}
