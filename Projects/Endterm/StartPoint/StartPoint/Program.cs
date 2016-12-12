using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Messaging;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;

namespace StartPoint
{
    class Program
    {
        static void Currency()
        {
            Console.WriteLine("1-USD\n2-KZT");
            string choice = Console.ReadLine();
            switch ( choice )
            {
                case "1":
                    string serialization = JsonConvert.SerializeObject(new Message("Currency", "USD", "", "", "", ""));
                    Sender.Send(serialization); 
                    break;
                case "2":
                    string serialization2 = JsonConvert.SerializeObject(new Message("Currency", "KZT", "", "", "", ""));
                    Sender.Send(serialization2);
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
            Sender.Send(serialization);
        }

        static void Location()
        {
            Console.WriteLine("Enter x-axis");
            string x_axis = Console.ReadLine();
            Console.WriteLine("Enter y-axis");
            string y_axis = Console.ReadLine();
            string serialization = JsonConvert.SerializeObject(new Message("Location", "", "", "", x_axis, y_axis));
            Sender.Send(serialization);
        }
        static void Main( string[] args )
        {
            bool accepted = false;
            bool firstStart = true;
            while ( true )
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using ( var connection = factory.CreateConnection() )
                {
                    using ( var channel = connection.CreateModel() )
                    {
                        channel.QueueDeclare(queue: "databaseResponse", durable: false, exclusive: false, autoDelete: false, arguments: null);

                        var consumer = new EventingBasicConsumer(channel);

                        consumer.Received += ( model, ea ) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            Console.WriteLine(message);
                        };

                        channel.BasicConsume(queue: "databaseResponse", noAck: true, consumer: consumer);
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
                }
            }
        }
    }
}
