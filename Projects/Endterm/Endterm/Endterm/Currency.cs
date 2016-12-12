using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;

namespace Endterm
{
    interface ICurrency : IOperation
    {
    }

    class Currency : ICurrency
    {
        
        string type;
        string USD = "$1 - 350KZT";
        string KZT = "1KZT - $0.003";


        public void Response()
        {
            Application app = Application.GetInstance();
            if ( type.Equals("USD") )
            {
                app.SentToQueue2("Current currency is: " + USD);
            }
            else if ( type.Equals("KZT") )
            {
                app.SentToQueue2("Current currency is: " + KZT);
            }

        }

        public void Parse( Message msg )
        {
            this.type = msg.currency;
        }
    }
}
