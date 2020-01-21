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
    public class StartupSerilog
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public StartupSerilog(
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }
        public void ConfigureServices(
            IServiceCollection services)
        {
            //��ConfigureServices�д�ӡ��־��ֻ��Ҫʹ��Log��̬�����Ϳ�����
            Log.Information("Starting Startup ConfigureServices");

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app,
            ILogger<StartupSerilog> logger)
        {
            //�������ʹ��ע��ķ���
            logger.LogInformation("Starting Startup Configure");

            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //����ʹ���ص���Ϣ������ͬ��������Բ鿴ImageĿ¼�µ�ͼƬ
            //app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
