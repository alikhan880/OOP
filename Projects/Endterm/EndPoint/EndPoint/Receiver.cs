using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using Messaging;

namespace EndPoint
{
    public static class Receiver
    {
        public static Message Receive()
        {
            Message response = null;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare(queue: "database", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += ( model, ea ) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        //Console.WriteLine(message.GetType());
                        var ms = JsonConvert.DeserializeObject<Message>(message);

                        response = ms;
                        
                        Console.WriteLine(ms.GetType());
                        
                        //response = (Message)ms;
                        
                    };

                    channel.BasicConsume(queue: "database", noAck: true, consumer: consumer);

                    Console.ReadKey();
                }
            }
            return response;
        }
    }
}
