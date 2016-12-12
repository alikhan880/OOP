using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using EndPoint;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using Messaging;

namespace EndPoint
{
    class Program
    {
        static void Main( string[] args )
        {
            var container = new UnityContainer();
            Bootstrapper.SetupContainer(container);

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
                        var ms = JsonConvert.DeserializeObject<Message>(message);

                        Console.WriteLine(ms.type);

                        var cl = container.Resolve<IOperation>(ms.type);
                        cl.Parser(ms);
                        cl.Response();
                    };

                    channel.BasicConsume(queue: "database", noAck: true, consumer: consumer);

                    Console.ReadKey();
                }
            }
        }
    }
}
