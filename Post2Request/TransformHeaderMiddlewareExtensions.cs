using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post2Request
{
    public static class TransformHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseTransformHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TransformHeaderMiddlware>();
        }
    }
}
