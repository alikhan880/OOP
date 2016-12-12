using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace EndPoint
{
    public static class Sender
    {
        public static void Send(string msg)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare(queue: "databaseResponse", durable: false, exclusive: false, autoDelete: false, arguments: null);
                   
                    var body = Encoding.UTF8.GetBytes(msg);

                    channel.BasicPublish(exchange: "", routingKey: "databaseResponse", basicProperties: null, body: body);

                }
            }
        }
    }
}
