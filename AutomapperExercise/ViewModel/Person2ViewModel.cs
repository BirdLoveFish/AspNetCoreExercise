using AutomapperExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomapperExercise.ViewModel
{
    public class Person2ViewModel
    {
        public int Id { get; set; }
        public string Name1 { get; set; }
        public List<Student2ViewModel> Students { get; set; }
    }
}
