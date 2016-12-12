using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;

namespace Endterm
{
    interface ILocation:IOperation
    {

    }
    class Location : ILocation
    {
        string x;
        string y;


        public void Response()
        {
            Application app = Application.GetInstance();
            app.SentToQueue2("You are at x: " + x + ", y: " + y + ". Your nearest ATM is at x:123, y:256.");
        }

        public void Parse( Message msg )
        {
            this.x = msg.x_axis;
            this.y = msg.y_axis;
        }
    }
}
