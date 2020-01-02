using AutoMapper;
using AutoMapperProfile.Model;
using AutoMapperProfile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperProfile
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
        }
    }
}
