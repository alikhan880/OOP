using Messaging;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndPoint
{
    interface ICurrency : IOperation
    {

    }

    public class TestCurrency : ICurrency
    {
        string type;
        string USD = "$1 - 350KZT";
        string KZT = "1KZT - $0.003";

        public string ObtainCurrency()
        {
            return "$100";
        }
        public void Response()
        {
            if ( type.Equals("USD") )
            {
                Sender.Send("Current currency is: " + USD);
            }
            else if ( type.Equals("KZT") )
            {
                Sender.Send("Current currency is: " + KZT);
            }

        }

        public void Parser( Message msg )
        {
            this.type = msg.currency;
        }
    }
}
