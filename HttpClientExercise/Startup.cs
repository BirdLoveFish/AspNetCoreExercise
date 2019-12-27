using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientExercise.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;

namespace HttpClientExercise
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            /* HttpClient基本用法 */
            services.AddHttpClient();

            /* HttpClient命名客户端 */
            services.AddHttpClient("top",options=>
            {
                options.BaseAddress = new Uri("http://feiniaomuyu.top");
                options.DefaultRequestHeaders.Add("key", "value");
            });

            /* HttpClient类型化客户端 */
            //常规用法
            //services.AddHttpClient<TypedClientService>();

            //基础信息在这里定义
            services.AddHttpClient<TypedClientService>(options=>
            {
                options.BaseAddress = new Uri("http://feiniaomuyu.top");
                options.DefaultRequestHeaders.Add("key", "value");
            });

            /* 生成的客户端 */
            services.AddHttpClient("Generate", options =>
            {
                options.BaseAddress = new Uri("http://localhost:5000");
                options.DefaultRequestHeaders.Add("key", "value");
            }).AddTypedClient(c => Refit.RestService.For<IGeneratedClientService>(c));

            /* 出站请求中间件 */
            services.AddTransient<ValidateHeaderHandler>();
            services.AddTransient<ValidateHeader2Handler>();
            services.AddHttpClient("outGoing", options =>
            {
                options.BaseAddress = new Uri("http://feiniaomuyu.top");
                //返回400 错误
                options.DefaultRequestHeaders.Add("key", "value");
                //添加head头
                //options.DefaultRequestHeaders.Add("head", "value");
            })
                .AddHttpMessageHandler<ValidateHeaderHandler>()
                .AddHttpMessageHandler<ValidateHeader2Handler>();

            /* Polly策略 */

            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(10));
            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(30));

            //一次性定义策略
            var registry = services.AddPolicyRegistry();

            registry.Add("regular", timeout);
            registry.Add("long", longTimeout);

            services.AddHttpClient<PollyTopService>()
                //错误处理策略
                .AddTransientHttpErrorPolicy(p =>
                    p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)))
                //动态选择策略
                .AddPolicyHandler(p =>
                    p.Method == HttpMethod.Get ? timeout : longTimeout)
                //添加策略
                .AddPolicyHandlerFromRegistry("regular")
                .AddPolicyHandlerFromRegistry("long");

            //HttpClient 默认生存期 默认为2分钟
            services.AddHttpClient("lifetime")
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            /* IHttpContextAccessor获取HttpContext实例 */
            //必须调用
            services.AddHttpContextAccessor();
            //三者都可以
            //services.AddTransient<HttpAccessor>();
            //services.AddSingleton<HttpAccessor>();
            services.AddScoped<HttpAccessor>();
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
