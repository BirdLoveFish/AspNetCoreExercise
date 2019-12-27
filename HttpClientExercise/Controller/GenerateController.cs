using HttpClientExercise.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    /// <summary>
    /// 生成的客户端
    /// </summary>
    /// <returns></returns>
    public class GenerateController: ControllerBase
    {
        private readonly IGeneratedClientService _generatedClientService;

        public GenerateController(IGeneratedClientService generatedClientService)
        {
            _generatedClientService = generatedClientService;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await _generatedClientService.GetSelfValue());
        }
    }
}
