using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutofacExercise.Interceptors;
using AutofacExercise.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutofacExercise
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //本身的依赖注入也可以使用
            services.AddTransient<INameService, NameService>();

            services.AddControllers().AddControllersAsServices();
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

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //注册模块
            builder.RegisterModule(new AutofacModule());
        }
    }
}
