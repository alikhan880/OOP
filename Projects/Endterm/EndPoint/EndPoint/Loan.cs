using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;
using Microsoft.Practices.Unity;

namespace EndPoint
{
    interface ILoan : IOperation
    {

    }
    public class TestLoan : ILoan
    {
        string id;
        string name;

        public string ObtainLoan()
        {
            return "$10000";
        }

        public void Response( )
        {
            
            Sender.Send(name + ", your id is: " + id + ". We can give you $10000");

        }

        public void Parser( Message msg )
        {
            this.id = msg.id;
            this.name = msg.name;
        }
    }
}
