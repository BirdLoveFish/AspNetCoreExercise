using AutoMapper;
//using AutoMapperProfile.Model;
//using AutoMapperProfile.ViewModel;
using AutomapperExercise.Model;
using AutomapperExercise.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomapperExercise.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return Ok("Home Index");
        }

        /// <summary>
        /// 常规按名字映射
        /// </summary>
        /// <returns></returns>
        public IActionResult Map()
        {
            var person = new Person
            {
                Id = 1,
                Name = "zhang",
                Students = new List<Student>
                {
                    new Student
                    {
                        Age = 20,
                        Name = "san"
                    }
                }
            };
            return Ok(_mapper.Map<PersonViewModel>(person));
        }

        /// <summary>
        /// 名称不同的映射
        /// </summary>
        /// <returns></returns>
        public IActionResult Map2()
        {
            var person = new Person
            {
                Id = 1,
                Name = "zhang",
                Students = new List<Student>
                {
                    new Student
                    {
                        Age = 20,
                        Name = "_san"
                    }
                }
            };
            return Ok(_mapper.Map<Person2ViewModel>(person));
        }

        /// <summary>
        /// 对象至对象的映射
        /// </summary>
        /// <returns></returns>
        public IActionResult Map3()
        {
            var person = new Person
            {
                Id = 1,
                Name = "zhang",
                Students = new List<Student>
                {
                    new Student
                    {
                        Age = 20,
                        Name = "_san"
                    }
                }
            };

            var person2ViewModel = new Person2ViewModel();

            _mapper.Map(person, person2ViewModel);

            return Ok(person2ViewModel);
        }

        public IActionResult Map4()
        {
            var one = new DifferentOne
            {
                One = "one one",
                Two = "one two",
                Three = "one three"
            };

            var two = new DifferentTwo
            {
                Two = "two two",
                Three = "two three",
                Four = "two four"
            };

            //不存在的会设置为原来的值
            //_mapper.Map(one, two);

            //不存在会赋值为null
            two = _mapper.Map<DifferentTwo>(one);

            return Ok(two);
        }
    }
}
