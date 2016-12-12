using Messaging;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Endterm
{
    public class Application
    {
        private static Application appInstance;
        private Application()
        {

        }

        public static Application GetInstance()
        {
            if ( appInstance == null )
            {
                appInstance = new Application();
            }

            return appInstance;
        }

        public void StartMenu()
        {
            Console.WriteLine("1-Currency\n2-Loan\n3-Location\n0-Exit");
            string choice = Console.ReadLine();
            switch ( choice )
            {
                case "1":
                    Currency();
                    break;
                case "2":
                    Loan();
                    break;
                case "3":
                    Location();
                    break;
                case "0":
                    return;
            }
        }

        static void Currency()
        {
            Console.WriteLine("1-USD\n2-KZT");
            string choice = Console.ReadLine();
            switch ( choice )
            {
                case "1":
                    string serialization = JsonConvert.SerializeObject(new Message("Currency", "USD", "", "", "", ""));
                    SendToQueue1(serialization);
                    ;
                    break;
                case "2":
                    string serialization2 = JsonConvert.SerializeObject(new Message("Currency", "KZT", "", "", "", ""));
                    SendToQueue1(serialization2);
                    break;
            }
        }

        static void Loan()
        {
            Console.WriteLine("Enter id");
            string id = Console.ReadLine();
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            string serialization = JsonConvert.SerializeObject(new Message("Loan", "", id, name, "", ""));
            SendToQueue1(serialization);
        }

        static void Location()
        {
            Console.WriteLine("Enter x-axis");
            string x_axis = Console.ReadLine();
            Console.WriteLine("Enter y-axis");
            string y_axis = Console.ReadLine();
            string serialization = JsonConvert.SerializeObject(new Message("Location", "", "", "", x_axis, y_axis));
            SendToQueue1(serialization);
        }

        private static void SendToQueue1( string msg )
        {
            Console.WriteLine("STQ1");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare(queue: "queue1", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    string message = msg;
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "queue1", basicProperties: null, body: body);
                    channel.Close();
                    connection.Close();

                }
            }
        }

        public void SentToQueue2( string msg )
        {
            Console.WriteLine("STQ2");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare(queue: "queue2", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    string message = msg;
                    var body = Encoding.UTF8.GetBytes(message);


                    channel.BasicPublish(exchange: "", routingKey: "queue2", basicProperties: null, body: body);
                    channel.Close();
                    connection.Close();
                }
            }
        }

        

        public static void ReceiveFromQueue1()
        {
            bool received = false;
            Console.WriteLine("RFQ1");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare(queue: "queue1", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += ( model, ea ) =>
                    {

                        received = true;
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        var msg = JsonConvert.DeserializeObject<Message>(message);
                        Console.WriteLine(msg);
                        UnityContainer container = new UnityContainer();
                        Bootstrapper.SetupContainer(container);
                        var res = container.Resolve<IOperation>(msg.type);
                        res.Parse(msg);
                        res.Response();

                    };

                    
                    
                    channel.BasicConsume(queue: "queue1", noAck: true, consumer: consumer);
                    if ( received )
                    {
                        channel.Close();
                        connection.Close();
                    }


                }
            }
        }

        public static void ReceiveFromQueue2()
        {
            bool received = false;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare(queue: "queue2", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += ( model, ea ) =>
                    {
                        received = true;
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("RFQ2");

                        Console.WriteLine(message);
                        
                    };
                   
                    
                    channel.BasicConsume(queue: "queue2", noAck: true, consumer: consumer);
                    if ( received )
                    {
                        channel.Close();
                        connection.Close();

                    }


                }
            }
        }

    }
}
