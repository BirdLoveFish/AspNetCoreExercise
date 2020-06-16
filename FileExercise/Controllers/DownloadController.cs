using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using System.IO;

namespace FileExercise.Controllers
{
    public class DownloadController: Controller
    {
        private readonly IHostEnvironment _env;

        private readonly string _dir;

        public DownloadController(IHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayText(string filename)
        {
            var pathname = Path.Combine(_dir, filename);
            var result = System.IO.File.ReadAllText(pathname);
            return Ok(result);
        }

        /// <summary>
        /// 返回图片
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IActionResult DisplayImage(string filename)
        {
            var pathname = Path.Combine(_dir, filename);
            var result64 = System.IO.File.OpenRead(pathname);

            //可以返回Base64的字符串
            //var result = Convert.ToBase64String(result64);
            //return Ok(result);

            //返回图片文件的bytes
            //return File(result64, "image/png");

            //直接返回图片文件
            //return PhysicalFile(pathname, "text/plain");
            return File(result64, "text/plain", "a.txt");
        }

        /// <summary>
        /// 可以改变图片的尺寸
        /// </summary>
        /// <param name="width"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IActionResult DisplayImage2(int width, string filename)
        {
            var pathname = Path.Combine(_dir, filename);
            using (var imgBmp = new Bitmap(pathname))
            {
                //找到新尺寸
                var oWidth = imgBmp.Width;
                var oHeight = imgBmp.Height;
                var height = oHeight;
                if (width > oWidth)
                {
                    width = oWidth;
                }
                else
                {
                    height = width * oHeight / oWidth;
                }
                var newImg = new Bitmap(imgBmp, width, height);
                newImg.SetResolution(72, 72);
                var ms = new MemoryStream();
                newImg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                var bytes = ms.GetBuffer();
                ms.Close();
                return File(bytes, "image/png");
            }
        }
    }
}
