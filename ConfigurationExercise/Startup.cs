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

namespace ConfigurationExercise
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        //IConfiguration只能在这里注入
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //IConfiguration不能再方法里面注入
        public void ConfigureServices(IServiceCollection services)
        {
            var result = Configuration["name"];
            services.AddControllers();
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
