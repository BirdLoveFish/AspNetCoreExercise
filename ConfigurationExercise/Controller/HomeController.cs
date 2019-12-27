using ConfigurationExercise.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationExercise.Controller
{
    public class HomeController: ControllerBase
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            //获取所有的键值对，内存的，文件的
            //var result = _configuration.AsEnumerable();

            /* 向索引器一样获取 只能获取值为字符串的数据*/
            //获取json文件中的字符串
            //var result = _configuration["name"];

            //获取对象 无法获取
            //var result = _configuration["person"];

            //获取数组 无法获取
            //var result = _configuration["array"];

            /* 使用GetValue方法 无法获取数组和对象*/
            //获取单一节点下的值
            //var result = _configuration.GetValue<string>("name");

            //获取对象节点下的值
            //var result = _configuration.GetValue<string>("person:name");

            //获取数组节点的值
            //var result = _configuration.GetValue<int>("array:2");
            //会将int转为string string转为int为报错
            //var result = _configuration.GetValue<string>("array:2");

            /* GetSection 永远不会返回null*/
            //对象节点 {"path":"person","key":"person","value":null}
            //var result = _configuration.GetSection("person");

            //对象中的值节点 {"path":"person:name","key":"name","value":"zhao li"}
            //可以直接获取result.value来获取值
            //var result = _configuration.GetSection("person:name");

            //数组节点 {"path":"array","key":"array","value":null}
            //var result = _configuration.GetSection("array");

            //数组中的值节点 {"path":"array:2","key":"2","value":"3"}
            //var result = _configuration.GetSection("array:2");

            /* GetChildren 获得的数据IConfigurationSection集合 */
            /* 
             * [{"key":"0","path":"array:0","value":"1"},
             * {"key":"1","path":"array:1","value":"2"},
             * {"key":"2","path":"array:2","value":"3"},
             * {"key":"3","path":"array:3","value":"4"}] 
             */
            //var result = _configuration.GetSection("array").GetChildren();

            /* Bind将对象绑定至类 */
            //var result = new Person();
            //_configuration.GetSection("person").Bind(result);

            /* Get<T>将对象绑定至类 */
            //var result = _configuration.GetSection("person").Get<Person>();

            /* 将数组绑定至类 */
            //Bind 该数组在根节点下
            //var result = new ArrayModel();
            //_configuration.Bind(result);

            //Get<T>
            var result = _configuration.Get<ArrayModel>();

            return Ok(result);
        }
    }
}
