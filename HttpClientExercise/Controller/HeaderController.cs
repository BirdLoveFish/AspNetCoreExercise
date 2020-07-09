using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    public class HeaderController: ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HeaderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return Ok(HttpContext.Request.Headers);
        }

        public async Task<IActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("aaa","aaa,bbb");

            //默认会帮我们检查头的合法性，而Authorization不可能包含"，"，所以会报错
            client.DefaultRequestHeaders.Add("Authorization", "aaaa,bbb");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "aaaa,bbb");
            
            //不能这样直接用Content-Type，get没必要用Content-Type
            //post需要加上HttpContent,有StringContent,FormContent,FileContent等等
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            //var result = await client.GetAsync("http://localhost:5000/header/index");
            var result = await client.PostAsync("http://localhost:5000/header/index", 
                new StringContent("111"));

            result.EnsureSuccessStatusCode();


            return Ok(await result.Content.ReadAsStringAsync());
        }
    }
}
