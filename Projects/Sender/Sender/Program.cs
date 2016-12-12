using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
namespace Sender
{
    class Program
    {

        static void Send( string temp )
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
        static string Task1(string tp)
        {
            string choice = "1#";
            if ( tp.Equals("1") )
                choice += "usd";
            else if ( tp.Equals("2") )
                choice += "kzt";

            return choice;
        }

        static string Task2(string id, string amount, string l4digits)
        {
            string res = "2#" + id + "!" + amount + "%" + l4digits;
            return res;
        }

        static string Task3(string x, string y)
        {
            string loc = "3#" + x + "^" + y;
            return loc;
        }
        static void Main( string[] args )
        {
            Console.WriteLine("Hello");
            while ( true )
            {

                Console.WriteLine("1 - Currency");
                Console.WriteLine("2 - Loan");
                Console.WriteLine("3 - Location");
                Console.WriteLine("0 - Exit");

                string choice = Console.ReadLine();
                switch ( choice )
                {
                    case "1":
                        Console.WriteLine("1-usd, 2-kzt");
                        string tp = Console.ReadLine();
                        string res;
                        if ( !tp.Equals("1") && !tp.Equals("2") )
                            Console.WriteLine("Invalid");
                        else
                        {
                            res = Task1(tp);
                            Send(res);
                        }
                        break;
                    case "2":
                        string amount, l4digits, id;
                        Console.WriteLine("Enter id");
                        id = Console.ReadLine();
                        Console.WriteLine("Enter amount");
                        amount = Console.ReadLine();
                        Console.WriteLine("Enter last 4 digits");
                        l4digits = Console.ReadLine();
                        string rs = Task2(id, amount, l4digits);
                        Send(rs);
                        break;
                    case "3":
                        Console.WriteLine("Enter location X and Y");
                        string x = Console.ReadLine();
                        string y = Console.ReadLine();
                        string loc = Task3(x, y);
                        Send(loc);
                        break;
                    case "0":
                        return;
                }
            }
            
            
        }
    }
}
