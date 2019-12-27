using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExercise.Extensions
{
    public class PollyTopService
    {
        private readonly HttpClient _client;
        public PollyTopService(HttpClient client)
        {
            client.BaseAddress = new Uri("http://feiniaomuyu.top");
            client.DefaultRequestHeaders.Add("key", "value");
            _client = client;
        }

        public async Task<string> GetTopValue()
        {
            var response = await _client.GetAsync("/value");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 异常处理没有产生作用
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetTopWrongValue()
        {
            Console.WriteLine("*************************111");
            var response = await _client.GetAsync("/value");
            response.StatusCode = HttpStatusCode.RequestTimeout;
            return await response.Content.ReadAsStringAsync();
        }
    }
}
