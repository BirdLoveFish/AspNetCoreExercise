using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExercise.Extensions
{
    /// <summary>
    /// HttpClient 类型化客户端
    /// </summary>
    public class TypedClientService2
    {
        //为私有
        private readonly HttpClient _client;
        public TypedClientService2(HttpClient client)
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
    }
}
