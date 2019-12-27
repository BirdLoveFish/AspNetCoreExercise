using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    public class ValueController: ControllerBase
    {
        public ValueController()
        {

        }

        public IActionResult Get()
        {
            return Ok();
        }

    }
}
