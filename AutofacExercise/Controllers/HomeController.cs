using Autofac.Extras.DynamicProxy;
using AutofacExercise.Interceptors;
using AutofacExercise.Services;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacExercise.Controllers
{
    [Intercept(typeof(TestInterceptor))]
    public class HomeController: ControllerBase
    {
        private readonly TopicService _topicService;
        private readonly IValueService _valueService;
        private readonly Inter1 _inter1;
        private readonly Inter2 _inter2;
        private readonly INameService _nameService;

        //属性注入
        //public TopicService _topicService { get; set; }
        //public IValueService _valueService { get; set; }
        //public Inter1 _inter1 { get; set; }
        //public Inter2 _inter2 { get; set; }

        public HomeController(
            TopicService topicService,
            IValueService valueService,
            Inter1 inter1,
            Inter2 inter2,
            INameService nameService
            )
        {
            _topicService = topicService;
            _valueService = valueService;
            _inter1 = inter1;
            _inter2 = inter2;
            _nameService = nameService;
        }
        public IActionResult Index()
        {
            return Ok("Home Index");
        }

        /// <summary>
        /// 直接调用类的方法
        /// </summary>
        /// <returns></returns>
        public virtual IActionResult CallClass()
        {
            return Ok(_topicService.Fun());
        }

        /// <summary>
        /// 调用接口的方法
        /// </summary>
        /// <returns></returns>
        public virtual IActionResult CallInterface()
        {
            return Ok(_valueService.Fun());
        }

        /// <summary>
        /// 调用虚的方法
        /// </summary>
        /// <returns></returns>
        public IActionResult CallVirtual()
        {
            return Ok(_valueService.VFun());
        }

        /// <summary>
        /// 调用其他程序集中的接口
        /// </summary>
        /// <returns></returns>
        public IActionResult CallAssembly()
        {
            return Ok(_inter1.Fun());
        }

        public IActionResult CallServiceInStartup()
        {
            return Ok(_nameService.Fun());
        }
    }
}
