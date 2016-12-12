using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endterm
{
    public interface IOperation
    {
        void Response();
        void Parse( Message msg );
    }
}
