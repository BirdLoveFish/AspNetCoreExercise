using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    /// <summary>
    /// HttpClient 命名客户端
    /// </summary>
    /// <returns></returns>
    public class NameController: ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NameController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("top");
            var response = await client.GetAsync("/value");
            response.EnsureSuccessStatusCode();
            return Ok(await response.Content.ReadAsStringAsync());
        }
    }
}
