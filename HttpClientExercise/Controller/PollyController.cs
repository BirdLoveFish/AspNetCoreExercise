using HttpClientExercise.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    public class PollyController: ControllerBase
    {
        private readonly PollyTopService _pollyTopService;

        public PollyController(PollyTopService pollyTopService)
        {
            _pollyTopService = pollyTopService;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await _pollyTopService.GetTopValue());
        }

        public async Task<IActionResult> Wrong()
        {
            return Ok(await _pollyTopService.GetTopWrongValue());
        }
    }
}
