using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SafeStorage.Controllers
{
    public class HomeController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            /*
             * 会在项目.csproj文件中创建guid
             * 会创建 %APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json
             *        ~/.microsoft/usersecrets/<user_secrets_id>/secrets.json
             * dotnet user-secrets init 初始化机密
             * dotnet user-secrets set "key1" "value" 设置机密，一个一个设置
             * dotnet user-secrets list 列出所有机密
             * dotnet user-secrets remove "key1" 删除单个机密
             * dotnet user-secrets clear 删除所有机密
             */

            var result = _configuration["key1"];

            return Ok(result);
        }
    }
}
