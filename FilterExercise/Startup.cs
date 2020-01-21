using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterExercise.ActionFilters;
using FilterExercise.AuthFilters;
using FilterExercise.ResultFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FilterExercise
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MyActionServiceFilter>();


            services.AddControllers(config=>
            {
                //全局筛选器
                //注册在前面的先执行
                //config.Filters.Add(typeof(MyActionFIlter));
                //config.Filters.Add(typeof(MyActionFilterAsync));
                //config.Filters.Add(typeof(MyResultFilter));
                //config.Filters.Add(typeof(MyResultFilterAsync));
                config.Filters.Add(typeof(MyAuthFilter));
                config.Filters.Add(typeof(MyAlawaysResultFilter));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
