using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerExercise.Models
{
    /// <summary>
    /// yyyyyyyyyyy
    /// </summary>
    public class Request
    {
        /// <summary>
        /// ssssssssssssss
        /// </summary>
        [Description("年龄")]
        public int Age { get; set; }
        [Description("描述")]
        [DefaultValue("rrrrrrrrrrr")]
        [Required]
        public string Name { get; set; }

        [DefaultValue(true)]
        [DisplayName("是否")]
        public bool Is { get; set; }
    }
}
