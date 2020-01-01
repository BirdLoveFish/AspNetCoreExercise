using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogExercise.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Sinks.File;

namespace LogExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithRequestInfo()
            .WriteTo.Console()
            .WriteTo.File(
                "log.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {CusString}|{Method}|{SourceContext}|{MemberName}|{FilePath}|{LineNumber}|{Message:lj}{NewLine}{Exception}")
            .CreateLogger();

            LogContext.PushProperty("A", 1);

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        /* 
                         * 放在上面和下面都一样，Startup中的Configure可以写日志
                         * ConfigureServices无法写日志
                         */
                        .UseSerilog()
                        ;
                });
    }
}
