using HttpClientExercise.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    /// <summary>
    /// HttpClient 类型化客户端
    /// </summary>
    /// <returns></returns>
    public class TypeController: ControllerBase
    {
        private readonly TypedClientService _typedClientService;

        public TypeController(TypedClientService typedClientService)
        {
            _typedClientService = typedClientService;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await _typedClientService.GetTopValue());
        }
    }
}
