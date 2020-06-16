using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LogExercise.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Web;
using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Sinks.File;
using LogLevel = NLog.LogLevel;

namespace LogExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Serilog
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            //.Enrich.WithRequestInfo()
            .Enrich.With(new ThreadIdEnricher())
            .WriteTo.Console(
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]|{Message:lj} |{SourceContext} {NewLine}")
            // {Method}:http请求的方法名
            // {Information}
            // {Exception}
            .WriteTo.File(
                "log.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]|{Message:lj} |{Information}| {NewLine}")
            .CreateLogger();
            
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
            #endregion

            #region NLog
            // https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-3
            //var config = ConfigureNLog();

            ////在startup前打印日志
            ////var logger = NLogBuilder.ConfigureNLog(config).GetCurrentClassLogger();
            ////logger.Info("Program Startup");

            //var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            //    logger.LogInformation("Program Startup");
            //}

            //host.Run();
            #endregion

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder

                        /* 
                         * 放在上面和下面都一样，Startup中的Configure可以写日志
                         * ConfigureServices无法写日志
                         */
                        .UseSerilog()
                        .ConfigureLogging(config =>
                        {
                            config.ClearProviders();
                            config.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                        })
                        //.UseNLog()
                        .UseStartup<StartupSerilog>()
                        //.UseStartup<StartupNLog>()
                        ;
                });

        private static LoggingConfiguration ConfigureNLog()
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget
            {
                Layout = @"${date:format=HH\:mm\:ss} ${level} ${message}",
            };
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget
            {
                FileName = @"logs/${shortdate}/file.log",
                Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${callsite}",
            };
            config.AddTarget("file", fileTarget);

            config.AddRule(LogLevel.Info, LogLevel.Fatal, "console");
            config.AddRule(LogLevel.Info, LogLevel.Fatal, "file");
            LogManager.Configuration = config;
            return config;
        }


    }
}
