using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
namespace Receiver
{
    class Program
    {
        static void Send( string answer )
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare(queue: "database", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    string message = answer;
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "database", basicProperties: null, body: body);

                }
            }
        }

        static void Task1Receiver( string m )
        {
            char[] delimiters = { '#'};
            string[] data = m.Split(delimiters);
            Console.WriteLine("Operationg Type: " + data[ 0 ] + '\n' + "Currency Type: " + data[ 01 ] + '\n');
            
        }

        static void Task2Receiver( string m )
        {
            char[] delimiters = { '#', '!', '%' };
            string[] data = m.Split(delimiters);
            Console.WriteLine("Operation Type: " + data[ 0 ] + "\n" + "User id: " + data[ 1 ] + "\n" + "Cash amount: " + data[ 2 ] + "\n" + "Last 4 digits: " + data[ 3 ] + '\n');

        }

        static void Task3Receiver( string m )
        {
            char[] delimiters = { '#', '^' };
            string[] data = m.Split(delimiters);
            Console.WriteLine("Operation Type: " + data[ 0 ] + '\n' + "X: " + data[ 1 ] + '\n' + "Y: " + data[ 2 ] + '\n');
        }


        static void Main( string[] args )
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare(queue: "database", durable: false, exclusive: false, autoDelete: false, arguments:null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += ( model, ea ) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        //var ms = JsonConvert.DeserializeObject(message);
                        Console.WriteLine(message);
                        //if ( message[ 0 ] == '1' )
                        //{
                        //    Task1Receiver(message);
                        //}
                        //else if ( message[ 0 ] == '2' )
                        //{
                        //    Task2Receiver(message);
                        //}
                        //else if ( message[ 0 ] == '3' )
                        //{
                        //    Task3Receiver(message);
                        //}
                        //Console.WriteLine(" [x] Received {0}", message);
                    };

                    channel.BasicConsume(queue: "database", noAck: true, consumer: consumer);

                    Console.ReadKey();
                }
            }
        }
    }
}
