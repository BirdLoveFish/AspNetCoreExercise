using Autofac.Extras.DynamicProxy;
using AutofacExercise.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacExercise.Services
{
    [Intercept(typeof(TestInterceptor))]
    public interface IValueService
    {
        string Fun();

        string VFun();
    }
    
    public class ValueService : IValueService
    {
        public string Fun()
        {
            return "Value Fun";
        }

        public string VFun()
        {
            return "Value VFun";
        }
    }

    //public class Value2Service : IValueService
    //{
    //    public string Fun()
    //    {
    //        return "Value2 Fun";
    //    }

    //    public string VFun()
    //    {
    //        return "Value2 VFun";
    //    }
    //}
}
