using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogExercise
{
    public class StartupNLog
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public StartupNLog(
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddControllers();

            //不要在这里面打印日志
        }

        public void Configure(IApplicationBuilder app)
        {

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
