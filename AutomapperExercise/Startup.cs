using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
//using AutoMapperProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutomapperExercise
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //���AutoMapper��ӳ����д�ڱ���Ŀ�У�ʹ������ķ�ʽ
            //var assembly = typeof(Program).Assembly;
            //services.AddAutoMapper(assembly);
            //Ҳ����д����
            services.AddAutoMapper(typeof(AutoMapperOptions));

            //���AutoMapper��ӳ����д�ڱ����Ŀ�У�ʹ������ķ�ʽ
            //var assembly = Assembly.Load("AutoMapperProfile");
            //services.AddAutoMapper(assembly);
            //Ҳ����д����
            //services.AddAutoMapper(typeof(AutoMapperOptions));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
