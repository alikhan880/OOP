using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace testingSerializing
{
    class Program
    {
        static void Main( string[] args )
        {
            List<Message> messages = new List<Message>();
            messages.Add(new Message("123", "Artur", 20));
            messages.Add(new Message("456", "Ceaser", 30));
            messages.Add(new Message("789", "Remus", 40));
            messages.Add(new Message("012", "Troyan", 50));
            messages.Add(new Message("", "Troyan", 50));
            string serialization = JsonConvert.SerializeObject(messages);
            Console.WriteLine(serialization);
            Console.ReadKey();
        }
    }
}
