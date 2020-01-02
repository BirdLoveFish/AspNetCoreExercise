using Autofac;
using Autofac.Extras.DynamicProxy;
using AutofacExercise.Interceptors;
using AutofacExercise.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AutofacExercise
{
    public class AutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestInterceptor>();

            //调用其他程序集
            Assembly assembliesDomain = Assembly.Load("Implement");
            builder.RegisterAssemblyTypes(assembliesDomain)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors();

            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                    .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                    .PropertiesAutowired() // 允许属性注入
                    .EnableClassInterceptors(); // 允许在Controller类上使用拦截器


            // 在这里添加服务注册
            //以类型的方式直接注册
            builder.RegisterType<TopicService>();

            //以接口的形式注册
            //builder.RegisterType<ValueService>().AsImplementedInterfaces();
            //后注册的会覆盖前面注册的
            //builder.RegisterType<Value2Service>().AsImplementedInterfaces();
        }


    }
}
