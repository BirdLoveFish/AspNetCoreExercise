using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Configuration;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace LogExercise.Extensions
{
    public class RequestInfoEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("CusString", "CusString"));
            //logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("HttpMethod", new LogAsyncMethods().GetActualAsyncMethodName()));
            //LogContext.PushProperty("Methods", new LogAsyncMethods().GetActualAsyncMethodName());
        }
    }

    //public class LogAsyncMethods
    //{
    //    public object GetActualAsyncMethodName([CallerMemberName]string name = null,[CallerLineNumber]int line=0) 
    //    {
    //        return new { name,line };
    //    }
    //}

    public static class EnricherExtensions
    {
        public static LoggerConfiguration WithRequestInfo(this LoggerEnrichmentConfiguration enrich)
        {
            if (enrich == null)
                throw new ArgumentNullException(nameof(enrich));

            return enrich.With<RequestInfoEnricher>();
        }
    }

    public class ThreadIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                    "ThreadId", Thread.CurrentThread.ManagedThreadId));
        }
    }
}
