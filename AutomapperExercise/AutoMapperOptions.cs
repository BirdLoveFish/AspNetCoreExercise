using AutoMapper;
using AutomapperExercise.Model;
using AutomapperExercise.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomapperExercise
{
    public class AutoMapperOptions : Profile
    {
        public AutoMapperOptions()
        {
            //Person -> PersonViewModel的映射
            //在使用RequestViewModel和ResponseViewModel时，可以只配置单向的
            CreateMap<Person, PersonViewModel>();
            //PersonViewModel -> Person的映射
            //CreateMap<PersonViewModel, Person>();

            CreateMap<Student, StudentViewModel>();
            //CreateMap<StudentViewModel, Student>();

            //自定义名字映射
            CreateMap<Person, Person2ViewModel>()
                .ForMember(dest => dest.Name1, config => config.MapFrom(source => source.Name));
            //嵌套的自定义名字映射
            //CreateMap<Student, Student2ViewModel>()
            //    .ForMember(dest => dest.Name1, config => config.MapFrom(source => source.Name));


            //CreateMap<Student, Student2ViewModel>()
            //    .ForMember(dest => dest.Name1, config => config.MapFrom(source => source.Name))
            //    //在映射前修改，修改的是源
            //    .BeforeMap((source, dest) => source.Name = source.Name.TrimStart('_'));

            CreateMap<Student, Student2ViewModel>()
                .ForMember(dest => dest.Name1, config => config.MapFrom(source => source.Name))
                //在映射后修改，修改的是目标
                .AfterMap((source, dest) => dest.Name1 = dest.Name1.TrimStart('_'));

            //测试两个类不对应时的状况


            //有不同属性
            CreateMap<DifferentOne, DifferentTwo>();
            //有不同属性
            CreateMap<DifferentTwo, DifferentOne>();
        }
    }
}
