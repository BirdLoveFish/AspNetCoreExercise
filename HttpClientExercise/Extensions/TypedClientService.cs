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
    public class TypedClientService
    {
        //为公有
        public HttpClient Client { get; }
        public TypedClientService(HttpClient client)
        {
            client.BaseAddress = new Uri("http://feiniaomuyu.top");
            client.DefaultRequestHeaders.Add("key", "value");
            Client = client;
        }

        public async Task<string> GetTopValue()
        {
            var response = await Client.GetAsync("/value");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
