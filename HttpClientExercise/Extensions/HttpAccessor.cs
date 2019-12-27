using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientExercise.Extensions
{
    public class HttpAccessor
    {
        private readonly HttpContext _httpContext;

        public HttpAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public string Get()
        {
            return _httpContext.Request.Headers.FirstOrDefault().Key;
        }
    }
}
