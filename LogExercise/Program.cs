using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogExercise.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
            //Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Verbose()
            //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //.Enrich.FromLogContext()
            //.Enrich.WithRequestInfo()
            //.WriteTo.Console()
            //.WriteTo.File(
            //    "log.txt",
            //    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {CusString}|{Method}|{SourceContext}|{MemberName}|{FilePath}|{LineNumber}|{Message:lj}{NewLine}{Exception}")
            //.CreateLogger();

            //LogContext.PushProperty("A", 1);

            //try
            //{
            //    Log.Information("Starting web host");
            //    CreateHostBuilder(args).Build().Run();
            //    return;
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Host terminated unexpectedly");
            //    return;
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
            #endregion

            #region NLog
            ConfigureNLog();
            CreateHostBuilder(args).Build().Run();
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
                        //.UseSerilog()
                        .ConfigureLogging(config =>
                        {
                            config.ClearProviders();
                            config.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                        })
                        .UseNLog()
                        .UseStartup<Startup>()
                        ;
                });

        private static void ConfigureNLog()
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget
            {
                Layout = @"${date:format=HH\:mm\:ss} ${level} ${message}",
            };
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget
            {
                FileName = "file.log",
                Layout = @"${date:format=HH\:mm\:ss} ${level} ${message}",
            };
            config.AddTarget("file", fileTarget);

            config.AddRule(LogLevel.Trace, LogLevel.Fatal, "console");
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, "file");
            LogManager.Configuration = config;
        }


    }

    
}
