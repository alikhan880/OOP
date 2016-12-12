using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingSerializing
{
    [Serializable]
    public class Message
    {
        public string id;
        public string name;
        public int x;
        public Message(string id = null, string name = null, int x = -1 )
        {
            this.id = id;
            this.name = name;
            this.x = x;
        }
    }
}
