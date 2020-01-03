using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitServer
{
    class Program
    {
        #region 服务器直接到客户端模式
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

        //    //声明一个队列
        //    channel.QueueDeclare("hello", false, false, false, null);

        //    //channel.QueueBind("hello", "direct", "123456", null);

        //    Console.WriteLine("\nRabbitMQ连接成功，请输入消息，输入exit退出！");

        //    string input;
        //    do
        //    {
        //        input = Console.ReadLine();

        //        var sendBytes = Encoding.UTF8.GetBytes(input);
        //        //发布消息
        //        channel.BasicPublish("", "hello", null, sendBytes);

        //    } while (input.Trim().ToLower() != "exit");
        //    channel.Close();
        //    connection.Close();
        //}
        #endregion

        #region direct模式 每个消息只能被一个客户端接收
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

        //    //定义一个Direct类型交换机
        //    channel.ExchangeDeclare("direct", ExchangeType.Direct, false, false, null);

        //    //声明一个队列
        //    channel.QueueDeclare("hello", false, false, false, null);

        //    channel.QueueBind("hello", "direct", "123456", null);

        //    Console.WriteLine("\nRabbitMQ连接成功，请输入消息，输入exit退出！");

        //    string input;
        //    do
        //    {
        //        input = Console.ReadLine();

        //        var sendBytes = Encoding.UTF8.GetBytes(input);
        //        //发布消息
        //        channel.BasicPublish("", "hello", null, sendBytes);

        //    } while (input.Trim().ToLower() != "exit");
        //    channel.Close();
        //    connection.Close();
        //}
        #endregion


        #region Fanout模式 每个消息可以被所有客户端接收
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

        //    //定义一个Direct类型交换机
        //    channel.ExchangeDeclare("fanout", ExchangeType.Fanout, false, false, null);

        //    //声明2个队列
        //    channel.QueueDeclare("hello", false, false, false, null);
        //    channel.QueueDeclare("world", false, false, false, null);

        //    channel.QueueBind("hello", "fanout", "123456", null);
        //    channel.QueueBind("world", "fanout", "123456", null);

        //    Console.WriteLine("\nRabbitMQ连接成功，请输入消息，输入exit退出！");

        //    string input;
        //    do
        //    {
        //        input = Console.ReadLine();

        //        var sendBytes = Encoding.UTF8.GetBytes(input);
        //        //发布消息
        //        channel.BasicPublish("fanout", "123456", null, sendBytes);

        //    } while (input.Trim().ToLower() != "exit");
        //    channel.Close();
        //    connection.Close();
        //}
        #endregion


        #region Topic模式 每个消息可以被所有匹配RouteKey的队列接收
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

            //定义一个Direct类型交换机
            channel.ExchangeDeclare("topic", ExchangeType.Topic, false, false, null);

            //声明2个队列
            channel.QueueDeclare("hello", false, false, false, null);
            channel.QueueDeclare("world", false, false, false, null);
            //topic模式中的routekey必须使用"."来区分"*"匹配一个单词 "#"匹配多个单词
            channel.QueueBind("hello", "topic", "topic.*", null);
            channel.QueueBind("world", "topic", "topic.#", null);

            Console.WriteLine("\nRabbitMQ连接成功，请输入消息，输入exit退出！");

            string input;
            do
            {
                input = Console.ReadLine();

                var sendBytes = Encoding.UTF8.GetBytes(input);
                //发布消息
                channel.BasicPublish("topic", "topic.one.two", null, sendBytes);

            } while (input.Trim().ToLower() != "exit");
            channel.Close();
            connection.Close();
        }
        #endregion
    }
}
