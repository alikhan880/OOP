using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartPoint
{
    public static class Sender
    {
        public static void Send(string temp)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare(queue: "database", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    string message = temp;
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "database", basicProperties: null, body: body);

                }
            }
        }
    }
}
