using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientExercise.Extensions
{
    /// <summary>
    /// 生成的客户端
    /// </summary>
    public interface IGeneratedClientService
    {
        [Get("/value/index")]
        Task<string> GetSelfValue();
    }
}
