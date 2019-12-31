using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LogExercise
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }
        public void ConfigureServices(
            IServiceCollection services)
        {
            //在ConfigureServices中打印日志，只需要使用Log静态方法就可以了
            Log.Information("Starting Startup ConfigureServices");

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app,
            ILogger<Startup> logger)
        {
            //这里可以使用注入的方法
            logger.LogInformation("Starting Startup Configure");

            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //可以使返回的信息有所不同，具体可以查看Image目录下的图片
            //app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
