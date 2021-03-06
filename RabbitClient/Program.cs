﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace RabbitClient
{
    class Program
    {
        #region 简单模式 单个客户端 服务端消息直接发送到这个客户端
        //static void Main(string[] args)
        //{
        //    //创建连接工厂
        //    ConnectionFactory factory = new ConnectionFactory
        //    {
        //        UserName = "admin",//用户名
        //        Password = "admin",//密码
        //        HostName = "localhost"//rabbitmq ip
        //    };

        //    //创建连接
        //    var connection = factory.CreateConnection();
        //    //创建通道
        //    var channel = connection.CreateModel();

        //    //事件基本消费者
        //    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

        //    //接收到消息事件
        //    consumer.Received += (ch, ea) =>
        //    {
        //        var message = Encoding.UTF8.GetString(ea.Body);
        //        Console.WriteLine($"收到消息： {message}");
        //        //确认该消息已被消费
        //        channel.BasicAck(ea.DeliveryTag, false);
        //    };
        //    //启动消费者 设置为手动应答消息
        //    channel.BasicConsume("hello", false, consumer);
        //    Console.WriteLine("消费者已启动");
        //    Console.ReadKey();
        //    channel.Dispose();
        //    connection.Close();
        //}
        #endregion

        #region work模式 多个客户端 服务端消息直接发送到客户端 客户端之间竞争获得消息 每个消息只能被获取一次
        static void Main(string[] args)
        {
            //创建连接工厂
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
                //确认该消息已被消费
                channel.BasicAck(ea.DeliveryTag, false);
            };
            //启动消费者 设置为手动应答消息
            //channel.BasicConsume("hello", false, consumer);
            channel.BasicConsume("world", false, consumer);
            Console.WriteLine("消费者已启动");
            Console.ReadKey();
            channel.Dispose();
            connection.Close();
        }
        #endregion
    }
}
