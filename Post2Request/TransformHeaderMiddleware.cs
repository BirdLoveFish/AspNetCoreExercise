using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post2Request
{
    /// <summary>
    /// 当客户端只能传输get或者post时，可以通过在Header中传get post delete patch put
    /// 来表明应该请求的类型，本函数就是将Header中的Method转换为真实的Method
    /// </summary>
    public class TransformHeaderMiddlware
    {
        private readonly RequestDelegate _next;

        public TransformHeaderMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //最好使用映射，可能传过来的post
            if (context.Request.Headers.TryGetValue("CustomMethod", out var method))
            {
                context.Request.Method = method.ToString();
            }
            else
            {
                context.Request.Method = "POST";
            }
            
            await _next(context);
        }
    }
}
