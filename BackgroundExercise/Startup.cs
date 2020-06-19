using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackgroundExercise.Background1;
using BackgroundExercise.Background2;
using BackgroundExercise.Background3;
using BackgroundExercise.Background4;
using BackgroundExercise.Background5;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundExercise
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // ��ʱ��
            //services.AddHostedService<TimedHostedService>();

            // CreateScope
            //services.AddHostedService<ConsumeScopedServiceHostedService>();
            //services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

            // ʵ����ʵ�� ��Ϣ����
            //services.AddSingleton<MonitorLoop>();
            //services.AddHostedService<QueuedHostedService>();
            //services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();

            // ��Ϣ���У���ϢΪһ������
            //services.AddHostedService<MessageQueueHostedService>();
            //services.AddSingleton<IMessageTaskQueue, MessageTaskQueue>();

            //��Ϣ���У���ϢΪһ���ַ���
            services.AddHostedService<MessageStringQueueHostedService>();
            services.AddSingleton<IMessageStringQueue, MessageStringQueue>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
