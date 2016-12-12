using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;
using Microsoft.Practices.Unity;

namespace EndPoint
{
    interface ILocation : IOperation
    {

    }

    public class TestLocation : ILocation
    {
        string x;
        string y;

        public string obtainX()
        {
            return "12";
        }

        public string obtainY()
        {
            return "14";
        }

        public void Response()
        {
            Sender.Send("You are at x: " + x + ", y: " + y + ". Your nearest ATM is at x:123, y:256.");
        }

        public void Parser( Message msg )
        {
            this.x = msg.x_axis;
            this.y = msg.y_axis;
        }
    }
}
