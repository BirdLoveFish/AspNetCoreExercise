using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LogExercise.Extensions
{
    public class RequestInfoEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("CusString", "CusString"));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Method", LogAsyncMethods.GetActualAsyncMethodName()));
        }
    }

    public static class LogAsyncMethods
    {
        public static object GetActualAsyncMethodName([CallerMemberName]string name = null,[CallerLineNumber]int line=0) 
        {
            return new { name,line };
        }
    }

    public static class EnricherExtensions
    {
        public static LoggerConfiguration WithRequestInfo(this LoggerEnrichmentConfiguration enrich)
        {
            if (enrich == null)
                throw new ArgumentNullException(nameof(enrich));

            return enrich.With<RequestInfoEnricher>();
        }
    }

    public static class LoggerExtensions
    {
        public static ILogger Here(this ILogger logger,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return logger
                .ForContext("MemberName", memberName)
                .ForContext("FilePath", sourceFilePath)
                .ForContext("LineNumber", sourceLineNumber);
        }
    }
}
