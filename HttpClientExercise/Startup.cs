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
            /* HttpClient�����÷� */
            services.AddHttpClient();

            /* HttpClient�����ͻ��� */
            services.AddHttpClient("top",options=>
            {
                options.BaseAddress = new Uri("http://feiniaomuyu.top");
                options.DefaultRequestHeaders.Add("key", "value");
            });

            /* HttpClient���ͻ��ͻ��� */
            //�����÷�
            //services.AddHttpClient<TypedClientService>();

            //������Ϣ�����ﶨ��
            services.AddHttpClient<TypedClientService>(options=>
            {
                options.BaseAddress = new Uri("http://feiniaomuyu.top");
                options.DefaultRequestHeaders.Add("key", "value");
            });

            /* ���ɵĿͻ��� */
            services.AddHttpClient("Generate", options =>
            {
                options.BaseAddress = new Uri("http://localhost:5000");
                options.DefaultRequestHeaders.Add("key", "value");
            }).AddTypedClient(c => Refit.RestService.For<IGeneratedClientService>(c));

            /* ��վ�����м�� */
            services.AddTransient<ValidateHeaderHandler>();
            services.AddTransient<ValidateHeader2Handler>();
            services.AddHttpClient("outGoing", options =>
            {
                options.BaseAddress = new Uri("http://feiniaomuyu.top");
                //����400 ����
                options.DefaultRequestHeaders.Add("key", "value");
                //���headͷ
                //options.DefaultRequestHeaders.Add("head", "value");
            })
                .AddHttpMessageHandler<ValidateHeaderHandler>()
                .AddHttpMessageHandler<ValidateHeader2Handler>();

            /* Polly���� */

            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(10));
            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(30));

            //һ���Զ������
            var registry = services.AddPolicyRegistry();

            registry.Add("regular", timeout);
            registry.Add("long", longTimeout);

            services.AddHttpClient<PollyTopService>()
                //���������
                .AddTransientHttpErrorPolicy(p =>
                    p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)))
                //��̬ѡ�����
                .AddPolicyHandler(p =>
                    p.Method == HttpMethod.Get ? timeout : longTimeout)
                //��Ӳ���
                .AddPolicyHandlerFromRegistry("regular")
                .AddPolicyHandlerFromRegistry("long");

            //HttpClient Ĭ�������� Ĭ��Ϊ2����
            services.AddHttpClient("lifetime")
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            /* IHttpContextAccessor��ȡHttpContextʵ�� */
            //�������
            services.AddHttpContextAccessor();
            //���߶�����
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
