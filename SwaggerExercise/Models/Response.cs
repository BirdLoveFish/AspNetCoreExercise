using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerExercise.Models
{
    public class Response
    {
        [DisplayName("姓名")]
        public int Age { get; set; }
        [DisplayName("姓名")]
        public string Name { get; set; } = "ttt";
    }
}
