using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitWeb.Extensions
{
    public class RabbitListener
    {
        ConnectionFactory factory { get; set; }
        IConnection connection { get; set; }
        IModel channel { get; set; }

        public void Register()
        {
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                int m = 0;
            };
            channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);
        }

        public void Deregister()
        {
            connection.Close();
        }

        public RabbitListener()
        {
            factory = new ConnectionFactory() 
            { 
                HostName = "localhost",
                UserName = "admin",
                Password = "admin"
            };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }
    }
}
