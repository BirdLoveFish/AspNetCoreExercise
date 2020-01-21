using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitWeb.Controllers
{
    public class HomeController: Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return Ok("Home Index");
        }

        [HttpPost]
        public IActionResult Receive([FromBody]string data)
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "admin",//用户名
                Password = "admin",//密码
                HostName = "localhost"//rabbitmq ip
            };

            //创建连接
            var connection = factory.CreateConnection();
            //创建通道
            var channel = connection.CreateModel();

            //声明一个队列
            channel.QueueDeclare("hello", false, false, false, null);

            var sendBytes = Encoding.UTF8.GetBytes(data);
            channel.BasicPublish("", "hello", null, sendBytes);

            channel.Close();
            connection.Close();

            return Ok();
        }
   
        private void Handle()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "admin",//用户名
                Password = "admin",//密码
                HostName = "localhost"//rabbitmq ip
            };

            //创建连接
            var connection = factory.CreateConnection();
            //创建通道
            var channel = connection.CreateModel();

            //事件基本消费者
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

            //接收到消息事件
            consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                Console.WriteLine($"收到消息： {message}");
                Thread.Sleep(2);
                //确认该消息已被消费
                channel.BasicAck(ea.DeliveryTag, false);
            };
            //启动消费者 设置为手动应答消息
            channel.BasicConsume("hello", false, consumer);
            channel.Dispose();
            connection.Close();
        }


    }
}
