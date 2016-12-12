using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace Connection
{
    class Program
    {
        static void Main( string[] args )
        {
            try
            {
                //Console.WriteLine("Enter name");
                //string name = Console.ReadLine();
                //Console.WriteLine("Enter password");
                //string password = Console.ReadLine();

                //StreamReader sr = File.OpenText(''); 

                string myConnection = "datasource=localhost;Initial Catalog='web';username=root;";
                string query = "INSERT INTO users (login, password) VALUES('" + name + "','" + password + "');";

                MySqlConnection myConnection2 = new MySqlConnection(myConnection);
                MySqlCommand myCommand2 = new MySqlCommand(query, myConnection2);
                MySqlDataReader myReader2;
                myConnection2.Open();
                myReader2 = myCommand2.ExecuteReader();
                Console.WriteLine("Save Data");
                while ( myReader2.Read() )
                {
                }
                myConnection2.Close();
            } catch(Exception e )
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
