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

            //如果AutoMapper的映射类写在本项目中，使用下面的方式
            //var assembly = typeof(Program).Assembly;
            //services.AddAutoMapper(assembly);
            //也可以写类型
            services.AddAutoMapper(typeof(AutoMapperOptions));

            //如果AutoMapper的映射类写在别的项目中，使用下面的方式
            //var assembly = Assembly.Load("AutoMapperProfile");
            //services.AddAutoMapper(assembly);
            //也可以写类型
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
