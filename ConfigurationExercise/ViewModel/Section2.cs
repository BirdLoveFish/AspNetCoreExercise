using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationExercise.ViewModel
{
    public class Section2
    {
        public Sub1 Sub1 { get; set; }
        public Sub2 Sub2 { get; set; }
    }

    public class Sub1
    {
        public string Name { get; set; }
    }

    public class Sub2
    {
        public string Name { get; set; }
    }
}
