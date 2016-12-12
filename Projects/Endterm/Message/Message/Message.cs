using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    [Serializable]
    public class Message
    {
        public string type;
        public string currency;
        public string id;
        public string name;
        public string x_axis;
        public string y_axis;
        

        public Message( string _type = null, string _currency = null, string _id = null, string _name = null, string _x_axis = null, string _y_axis = null )
        {
            type = _type;
            currency = _currency;
            id = _id;
            name = _name;
            x_axis = _x_axis;
            y_axis = _y_axis;
        }
    }
}
