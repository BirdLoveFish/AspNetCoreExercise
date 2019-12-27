using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    /// <summary>
    /// 出站请求中间件
    /// </summary>
    public class OutgoingController: ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OutgoingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("outGoing");
            var response = await client.GetAsync("http://feiniaomuyu.top/value");
            return Ok(await response.Content.ReadAsStringAsync());

        }
    }
}
