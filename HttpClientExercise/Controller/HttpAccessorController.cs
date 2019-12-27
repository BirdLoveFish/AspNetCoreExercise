using HttpClientExercise.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    public class HttpAccessorController: ControllerBase
    {
        private readonly HttpAccessor _httpAccessor;

        public HttpAccessorController(HttpAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }
        public IActionResult Index()
        {
            return Ok(_httpAccessor.Get());
        }
    }
}
