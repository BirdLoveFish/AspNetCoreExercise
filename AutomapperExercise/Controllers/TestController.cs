using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutomapperExercise.Controllers
{
    public class TestProfile: Profile
    {
        public TestProfile()
        {
            CreateMap<A, B>();
            CreateMap<B, A>();
        }
    }

    //测试，大部分情况下是自定义的快，也有小部分的情况是automapper快
    //总体来说，automap是不错的
    public class TestController: ControllerBase
    {
        private readonly IMapper _mapper;

        public TestController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Compare()
        {
            Stopwatch stopwatch = new Stopwatch();
            var a = new A
            {
                A1 = "A1",
                A2 = "A2",
                A3 = "A3",
                A4 = "A4",
                A5 = "A5",
                A6 = "A6",
                A7 = "A7",
            };
            var aList = new List<A>();
            for(int i = 0; i < 100; i++)
            {
                aList.Add(a);
            }
            stopwatch.Start();
            var bList = _mapper.Map<List<B>>(aList);
            stopwatch.Stop();
            var autoTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            var cList = new List<B>();
            foreach (var item in aList)
            {
                cList.Add(new B
                {
                    A1 = item.A1,
                    A2 = item.A2,
                    A3 = item.A3,
                    A4 = item.A4,
                    A5 = item.A5,
                    A6 = item.A6,
                    A7 = item.A7,
                });
            }
            stopwatch.Stop();
            var cusTime = stopwatch.ElapsedMilliseconds;

            return Ok(new { autoTime, cusTime });
        }


    }

    public class A
    {
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public string A5 { get; set; }
        public string A6 { get; set; }
        public string A7 { get; set; }
    }

    public class B
    {
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public string A5 { get; set; }
        public string A6 { get; set; }
        public string A7 { get; set; }
    }


}
