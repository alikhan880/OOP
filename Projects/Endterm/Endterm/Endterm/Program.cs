using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Endterm
{
    class Program
    {
        static void Main( string[] args )
        {
            UnityContainer container = new UnityContainer();
            Bootstrapper.SetupContainer(container);

            Application application = Application.GetInstance();
            application.StartMenu();
            ThreadStart ts = new ThreadStart(Application.ReceiveFromQueue1);
            Thread t = new Thread(ts);
            t.Start();
            ThreadStart ts2 = new ThreadStart(Application.ReceiveFromQueue2);
            Thread t2 = new Thread(ts2);
            t2.Start();
            Console.Read();
        }
    }
}
