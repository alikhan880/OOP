using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;

namespace Endterm
{
    interface ILoan : IOperation
    {
    }

    class Loan : ILoan
    {
        string id;
        string name;

        public void Response()
        {
            Application app = Application.GetInstance();
            app.SentToQueue2(name + ", your id is: " + id + ". We can give you $10000");

        }

        public void Parse( Message msg )
        {
            this.id = msg.id;
            this.name = msg.name;
        }
    }
}
