using MailExercise.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IUserAction _userAction;

        public HomeController(IEmailService emailService, IUserAction userAction)
        {
            _emailService = emailService;
            _userAction = userAction;
        }

        public IActionResult Index()
        {
            return Ok("Hello Index");
        }

        //发送
        public IActionResult Send(string address)
        {
            //校验邮箱是否为空
            if (string.IsNullOrEmpty(address))
            {
                return BadRequest("email address error");
            }

            //正则校验邮箱
            Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (!r.IsMatch(address))
            {
                return BadRequest("email address error");
            }
            string num = Guid.NewGuid().ToString();
            _userAction.Add(new Models.User(address, num));
            _emailService.Send(address, num);
            return Ok("请查收邮件");
        }

        public IActionResult Validation(string email, string code)
        {
            var result = _userAction.Valid(email, code);
            if (!result)
            {
                return BadRequest("错误");
            }
            return Ok("验证正确");
        }

    }
}
